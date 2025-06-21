using InsuranceApi.Application.Interfaces;
using InsuranceApi.Core.Infrastructure.Exceptions;
using InsuranceApi.Core.Models;

namespace InsuranceApi.Application.Services
{
    internal class QuotationAppService(IProductVersionAppService productVersionAppService) : IQuotationAppService
    {
        private readonly IProductVersionAppService _productVersionAppService = productVersionAppService;
        public async Task<IEnumerable<QuotationModel>?> GetByNumberAsync(int quotationNumber)
        {
            return await Task.FromResult<IEnumerable<QuotationModel>?>(null);
        }

        public async Task<CalculateValidityModel> CalculateValidityAsync(CalculateValidityFilterModel request)
        {
            var calculationTypeAcceptance = await _productVersionAppService.GetCalculationTypeAcceptanceAsync(request.ProductVersionId, request.ProfileId, request.CalculationTypeId)
                ?? throw new NotFoundException("Não foi possivel localizar o tipo de calculo.");

            var productVersionAcceptance = await _productVersionAppService.GetAcceptanceAsync(request.ProductVersionId, request.ProfileId)
                ?? throw new NotFoundException("Não foi possivel localizar a versão alçada do produto.");

            var startCoverage = request.StartCoverage ?? DateTime.Now;
            if (startCoverage.Date < DateTime.Now.Date)
            {
                var differenceInDays = (DateTime.Now.Date - startCoverage.Date).TotalDays;
                if (differenceInDays > productVersionAcceptance.RetroactiveEffectiveDateStartDays)
                {
                    throw new BusinessException($"A quantidade maxima de dias para vigência retroativa é de {productVersionAcceptance.RetroactiveEffectiveDateStartDays}");
                }
            }

            if (startCoverage.Date > DateTime.Now.Date)
            {
                var differenceInDays = (startCoverage.Date - DateTime.Now.Date).TotalDays;
                if (differenceInDays > productVersionAcceptance.LaterEffectiveDateStartDays)
                {
                    throw new BusinessException($"A quantidade maxima de dias para vigência futuro é de {productVersionAcceptance.LaterEffectiveDateStartDays}");
                }
            }

            var response = new CalculateValidityModel()
            {
                StartCoverage = startCoverage,
                CountDaysEnable = calculationTypeAcceptance.IsCountDays
            };

            if (request.CountDays != null)
            {
                var isValido = (request.CountDays >= calculationTypeAcceptance.CountDayMin && request.CountDays <= calculationTypeAcceptance.CountDayMax);
                if (!isValido)
                {
                    throw new BusinessException($"Quantidade de dias para o Tipo de Cálculo  escolhido não pode ser menor que {calculationTypeAcceptance.CountDayMin} dias e nem maior que {calculationTypeAcceptance.CountDayMax}.");
                }
                response.CountDays = request.CountDays.Value;
                response.EndCoverage = response.StartCoverage.AddDays(request.CountDays.Value);
            }
            else
            {
                response.CountDays = calculationTypeAcceptance.CountDayMax;
                response.EndCoverage = response.StartCoverage.AddDays(calculationTypeAcceptance.CountDayMax);
            }

            return response;
        }
    }
}
