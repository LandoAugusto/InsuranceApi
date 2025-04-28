using AutoMapper;
using InsuranceApi.Application.Interfaces;
using InsuranceApi.Core.Entities;
using InsuranceApi.Core.Entities.Enumerators;
using InsuranceApi.Core.Extensions;
using InsuranceApi.Core.Infrastructure.Exceptions;
using InsuranceApi.Core.Models;
using InsuranceApi.Infra.Data.Interfaces;
using System.Text;

namespace InsuranceApi.Application.Services
{
    internal class FlexRateAppService(IMapper mapper, IFlexRateRepository flexRateRepository, IFlexRateBrokerRepository flexRateBrokerRepository) : IFlexRateAppService
    {
        private readonly IMapper _mapper = mapper;
        private readonly IFlexRateRepository _flexRateRepository = flexRateRepository;
        private readonly IFlexRateBrokerRepository _flexRateBrokerRepository = flexRateBrokerRepository;

        public async Task<FlexRateModel?> GetAsync(int flexRateId)
        {
            var entidade = await _flexRateRepository.GetByIdAsync(flexRateId);

            if (entidade == null) return null;
            return _mapper.Map<FlexRateModel>(entidade);
        }

        public async Task<IEnumerable<FlexRateModel?>> ListAsync(FlexRateMixFilterModel request)
        {
            var flexRate = await _flexRateRepository.ListAsync(request.ProductVersionId, RecordStatusEnum.Ativo);
            if (!flexRate.IsAny<FlexRate>()) return null;

            if (request.BrokerId > 0)
            {
                var flexRateBroker = await _flexRateBrokerRepository.GetAsync(request.BrokerId.Value);
                if (!flexRateBroker.IsAny<FlexRateBroker>()) return null;

                flexRate = (from fx in flexRate.ToList()
                            join fxb in flexRateBroker.ToList() on fx.FlexRateId equals fxb.FlexRateId
                            select fx);
            }
            if (request.BorrowerId > 0)
            {
            }

            return _mapper.Map<IEnumerable<FlexRateModel>>(flexRate);

        }

        public async Task<SimulationModel> SimulationMixAsync(SimulationFilterModel simulation)
        {
            ///-- Busca os dados da taxa flex
            var flexRate = await _flexRateRepository.GetByIdAsync(simulation.FlexRateMixId) ??
                throw new BusinessException("Taxa mix não localiza.");

            var returnSimulation = new SimulationModel
            {
                FlexRateMixId = flexRate.FlexRateId,
                CalculatedComissionPercentage = simulation.SimulationComissionPercentage,
                SimulationValidDays = int.Parse((simulation.EndOfTerm.Date - simulation.StartOfTerm.Date).TotalDays.ToString()),
                SimulationPremiumValue = simulation.SimulationPremiumValue,
                SimulationInsuredAmountValue = simulation.SimulationInsuredAmountValue,
                SimulationFlexRateValue = simulation.SimulationFlexRateValue,
                SimulationComissionValue = simulation.SimulationComissionValue,
                SimulationOperationTypeId = flexRate.OperationTypeId,
                SimulationIsByValue = flexRate.IsByValue,
                SimulationComissionPercentage = simulation.SimulationComissionPercentage,
                SimulationComissionMaxValue = flexRate.ComissionMaxValue,
                SimulationRateType = flexRate.RateTypeId
            };

            //-- Apura o fator do período para poder apurar a taxa correta quando calcular ela fazendo PREMIO/IS
            var periodRatio = 365M / ((decimal)returnSimulation.SimulationValidDays);
            returnSimulation.SimulationRiskRatioValue = (returnSimulation.SimulationPremiumValue / returnSimulation.SimulationInsuredAmountValue) * 100M * periodRatio;

            if (returnSimulation.SimulationRateType == (int)FlexRateTypeEnum.Tax)
            {
                SimulationTax(returnSimulation);
            }
            else if (returnSimulation.SimulationRateType == (int)FlexRateTypeEnum.Premium)
            {
                var stringBuilder = new StringBuilder();
                SimulationPremium(stringBuilder, returnSimulation);
                returnSimulation.CalculatedMessage = stringBuilder.ToString();
            }
            else if (returnSimulation.SimulationRateType == (int)FlexRateTypeEnum.Comission)
            {
                SimulationComission(returnSimulation);
            }

            //-- Apura as diferenças
            returnSimulation.CalculatedPremiumDifferencePercentage = ((returnSimulation.CalculatedPremiumValue / simulation.SimulationPremiumValue) - 1M) * 100M;
            returnSimulation.CalculatedPremiumDifferenceValue = returnSimulation.CalculatedPremiumValue - simulation.SimulationPremiumValue;
            returnSimulation.CalculatedComissionDifferencePercentage = ((returnSimulation.CalculatedComissionValue / returnSimulation.SimulationComissionValue) - 1M) * 100M;
            returnSimulation.CalculatedComissionDifferenceValue = returnSimulation.CalculatedComissionValue - simulation.SimulationComissionValue;
            returnSimulation.CalculatedStatus = (returnSimulation.CalculatedPremiumDifferenceValue > 0);

            return returnSimulation;
        }

        private static void SimulationComission(SimulationModel simulation)
        {
            if (simulation.SimulationIsByValue)
            {
                if (simulation.SimulationOperationTypeId == 2)
                {
                    //-- Agravo 
                    simulation.CalculatedComissionValue = simulation.SimulationComissionValue + simulation.SimulationFlexRateValue;
                }
                else
                {
                    //-- Desconto
                    simulation.CalculatedComissionValue = simulation.SimulationComissionValue - simulation.SimulationFlexRateValue;
                }
            }
            else
            {
                if (simulation.SimulationOperationTypeId == 2)
                {
                    //-- Agravo 
                    simulation.CalculatedComissionValue = simulation.CalculatedComissionValue * (1M + (simulation.SimulationFlexRateValue / 100M));
                }
                else
                {
                    //-- Desconto
                    simulation.CalculatedComissionValue = simulation.CalculatedComissionValue * (1M - (simulation.SimulationFlexRateValue / 100M));
                }
            }

            //-- Na taxa do tipo comissão não altera prêmio e taxa de risco
            simulation.CalculatedRateValue = simulation.SimulationRiskRatioValue;
            simulation.CalculatedPremiumValue = simulation.SimulationPremiumValue;

        }
        private static void SimulationPremium(StringBuilder stringBuilder, SimulationModel simulation)
        {
            if (simulation.SimulationIsByValue)
            {
                if (simulation.SimulationOperationTypeId == 2)
                {
                    simulation.CalculatedPremiumValue = simulation.SimulationPremiumValue + simulation.SimulationFlexRateValue;
                }
                else
                {
                    simulation.CalculatedPremiumValue = simulation.SimulationPremiumValue - simulation.SimulationFlexRateValue;
                }
            }
            else
            {
                if (simulation.SimulationOperationTypeId == 2)
                {
                    simulation.CalculatedPremiumValue = simulation.SimulationPremiumValue * (1M + (simulation.SimulationFlexRateValue / 100M));
                }
                else
                {
                    simulation.CalculatedPremiumValue = simulation.SimulationPremiumValue * (1M - (simulation.SimulationFlexRateValue / 100M));
                }
            }

            //-- Apura o fator do período para poder apurar a taxa correta quando calcular ela fazendo PREMIO/IS
            var periodRatio = 365M / ((decimal)simulation.SimulationValidDays);
            simulation.CalculatedRateValue = (simulation.CalculatedPremiumValue / simulation.SimulationInsuredAmountValue) * 100M * periodRatio;

            //-- Atualiza o valor de comissão. Calcula o novo percentual de comissão somente se for agravo
            if (simulation.SimulationOperationTypeId == 2)
            {
                var novoPercentualComissao = 0M;
                if (simulation.SimulationIsByValue)
                {
                    novoPercentualComissao = simulation.SimulationComissionPercentage * (simulation.CalculatedPremiumValue.Value / simulation.SimulationPremiumValue);
                }
                else
                {
                    novoPercentualComissao = simulation.SimulationComissionPercentage * (1M + (simulation.SimulationFlexRateValue / 100M));
                }

                if (novoPercentualComissao > simulation.SimulationComissionMaxValue)
                {
                    novoPercentualComissao = simulation.SimulationComissionMaxValue;
                    stringBuilder.AppendLine($"Percentual de comissão ajustado para o máximo permitido  de {novoPercentualComissao}");

                    var newPremiumValue = ((simulation.SimulationComissionMaxValue / 100M) / (simulation.SimulationComissionPercentage / 100M)) * simulation.SimulationPremiumValue;
                    simulation.CalculatedPremiumValue = newPremiumValue;
                    stringBuilder.AppendLine($"Valor do prêmio ajustado para o máximo permitido  de {newPremiumValue}");

                    simulation.CalculatedRateValue = (newPremiumValue / simulation.SimulationInsuredAmountValue) * 100M * periodRatio;
                }
                simulation.CalculatedComissionValue = simulation.CalculatedPremiumValue * (novoPercentualComissao / 100M);
                simulation.CalculatedComissionPercentage = novoPercentualComissao;
            }
            else
            {
                simulation.CalculatedComissionValue = simulation.CalculatedPremiumValue * (simulation.SimulationComissionPercentage / 100M);
            }
        }
        private static void SimulationTax(SimulationModel simulation)
        {
            if (simulation.SimulationIsByValue)
            {
                if (simulation.SimulationOperationTypeId == 2)
                {
                    //-- Agravo 
                    simulation.CalculatedRateValue = simulation.SimulationRiskRatioValue + (simulation.SimulationFlexRateValue / 100M);
                }
                else
                {
                    //-- Desconto
                    simulation.CalculatedRateValue = simulation.SimulationRiskRatioValue - (simulation.SimulationFlexRateValue / 100M);
                }
            }
            else
            {
                if (simulation.SimulationOperationTypeId == 2)
                {
                    //-- Agravo 
                    simulation.CalculatedRateValue = simulation.SimulationRiskRatioValue * (1M + (simulation.SimulationFlexRateValue / 100M));
                }
                else
                {
                    //-- Desconto
                    simulation.CalculatedRateValue = simulation.SimulationRiskRatioValue * (1M - (simulation.SimulationFlexRateValue / 100M));
                }
            }

            //-- Atualiza o valor do prêmio
            simulation.CalculatedPremiumValue = ((simulation.CalculatedRateValue / 100M) / 365M) * simulation.SimulationInsuredAmountValue * decimal.Parse(simulation.SimulationValidDays.ToString());

            //-- Verifica pelo prêmio mínimo
            simulation.CalculatedPremiumValue = decimal.Round(simulation.CalculatedPremiumValue.Value, 2);

            //-- Atualiza o valor de comissão. Calcula o novo percentual de comissão somente se for agravo
            if (simulation.SimulationOperationTypeId == 2)
            {
                var novoPercentualComissao = 0M;
                if (simulation.SimulationIsByValue)
                {
                    novoPercentualComissao = simulation.SimulationComissionPercentage * (simulation.CalculatedPremiumValue.Value / simulation.SimulationPremiumValue);
                }
                else
                {
                    novoPercentualComissao = simulation.SimulationComissionPercentage * (1M + (simulation.SimulationFlexRateValue / 100M));
                }
                if (novoPercentualComissao > simulation.SimulationComissionMaxValue)
                {
                    novoPercentualComissao = simulation.SimulationComissionMaxValue;
                }
                simulation.CalculatedComissionValue = simulation.CalculatedPremiumValue * (novoPercentualComissao / 100M);
                simulation.CalculatedComissionPercentage = novoPercentualComissao;
            }
            else
            {
                simulation.CalculatedComissionValue = simulation.CalculatedPremiumValue * (simulation.SimulationComissionPercentage / 100M);
            }
        }
    }
}
