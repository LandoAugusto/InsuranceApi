using InsuranceApi.Application.Interfaces;
using InsuranceApi.Core.Entities;
using InsuranceApi.Core.Infrastructure.Exceptions;
using InsuranceApi.Core.Models;
using InsuranceApi.Infra.Data.Interfaces;

namespace InsuranceApi.Application.Services
{
    internal class QuotationAppService(IPersonAppService personAppService, IProductVersionAppService productVersionAppService,
        IQuotationRepository quotationRepository)
        : IQuotationAppService
    {
        private readonly IProductVersionAppService _productVersionAppService = productVersionAppService;
        private readonly IQuotationRepository _quotationRepository = quotationRepository;
        private readonly IPersonAppService _personAppService = personAppService;

        public async Task<QuotationModel> CreateQuotationAsync(int userId, CreateQuotationModel request)
        {
            var person = await _personAppService.GetByDocumentAsync(1, request.Insured.Document);
            if (person == null)
            {

            }
            else
            {
            }

            var quotation = new Quotation
            {

                VersionNumber = 1,
                EndorsementId = request.EndorsementId ?? 0,
                QuotationNumber = request.QuotationNumber ?? 0,
                BrokerId = request.BrokerId,
                InsuranceTypeId = request.InsuranceTypeId,
                StartCoverage = request.StartCoverage,
                EndCoverage = request.EndCoverage,
                ProductVersionId = request.ProductVersionId,
                CalculationTypeId = request.CalculationTypeId,
                ExpirationDate = request.ExpirationDate,
                InclusionDate = DateTime.Now,
                InclusionUserId = userId,
                Status = request.QuotationStatusId,
                PercentageCommission = request.PercentageCommission,
                PercentageDiscount = request.PercentageDiscount,
            };

            var ddddddd = await _quotationRepository.AddAsync(quotation);

            return await Task.FromResult<QuotationModel?>(null);
        }

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
