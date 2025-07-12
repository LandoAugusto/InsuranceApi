using InsuranceApi.Application.Interfaces;
using InsuranceApi.Core.Infrastructure.Exceptions;
using InsuranceApi.Core.Models;
using InsuranceApi.Service.Client.Interfaces.Product;
using Nest;

namespace InsuranceApi.Application.Services
{
    internal class ProductVersionAppService(IProductVersionService productVersionService) : IProductVersionAppService
    {
        private readonly IProductVersionService _productVersionService = productVersionService;

        public async Task<ProductVersionModel?> GetAsync(int productId)
        {
            var response = await _productVersionService.GetAsync(productId);
            if (response == null) return null;

            return response;
        }
        public async Task<ProductVersionAcceptanceModel?> GetAcceptanceAsync(int productVersionId, int profileId)
        {
            var response = await _productVersionService.GetAcceptanceAsync(productVersionId, profileId);
            if (response == null) return null;

            return response;
        }

        public async Task<InsuredObjectModel?> GetInsuredObjectAsync(int productVersionId)
        {
            var response = await _productVersionService.GetInsuredObjectAsync(productVersionId);
            if (response == null) return null;

            return response;
        }

        public async Task<CoverageModel?> GetByCoverageIdAsync(int productVersionId, int coverageId)
        {
            var response = await _productVersionService.GetByCoverageIdAsync(productVersionId, coverageId);
            if (response == null) return null;

            return response;
        }

        public async Task<IEnumerable<CoverageModel>?> ListCoverageAsync(int productVersionId)
        {
            var response = await _productVersionService.ListCoverageAsync(productVersionId);
            if (response == null) return null;

            return response;
        }

        public async Task<IEnumerable<ProductVersionClauseModel?>> ListClauseAsync(int productVersionId, decimal insuredAmountValue)
        {
            var response = await _productVersionService.ListClauseAsync(productVersionId, insuredAmountValue);
            if (response == null) return null;

            return response;
        }

        public async Task<IEnumerable<TermTypeModel>?> ListTermTypeAsync(int productVersionId)
        {
            var response = await _productVersionService.ListTermTypeAsync(productVersionId);
            if (response == null) return null;

            return response;
        }

        public async Task<IEnumerable<LawsuitTypeModel>?> ListLawsuitTypeAsync(int productVersionId)
        {
            var response = await _productVersionService.ListLawsuitTypeAsync(productVersionId);
            if (response == null) return null;

            return response;
        }
        public async Task<IEnumerable<PaymentMethodModel>?> GetPaymentMethodAsync(int productVersionId)
        {
            var response = await _productVersionService.GetPaymentMethodAsync(productVersionId);
            if (response == null) return null;

            return response;
        }

        public async Task<IEnumerable<PaymentFrequencyModel>?> GetPaymentFrequencyAsync(int productVersionId)
        {
            var response = await _productVersionService.GetPaymentFrequencyAsync(productVersionId);
            if (response == null) return null;

            return response;
        }

        public async Task<IEnumerable<PaymentInstallmentModel>?> GetPaymentInstallmentAsync(int productVersionId, int paymentMethodId)
        {
            var response = await _productVersionService.GetPaymentInstallmentAsync(productVersionId, paymentMethodId);
            if (response == null) return null;

            return response;
        }

        public async Task<IEnumerable<CalculationTypeModel>?> GetCalculationTypeAsync(int productVersionId, int profileId)
        {
            var response = await _productVersionService.GetCalculationTypeAsync(productVersionId, profileId);
            if (response == null) return null;

            return response;
        }

        public async Task<CalculationTypeAcceptanceModel?> GetCalculationTypeAcceptanceAsync(int productVersionId, int profileId, int calculationTypeId)
        {
            var response = await _productVersionService.GetCalculationTypeAcceptanceAsync(productVersionId, profileId, calculationTypeId);
            if (response == null) return null;

            return response;
        }

        public async Task<IEnumerable<ConstructionTypeModel>?> GetConstructionTypeAsync(int productVersionId, int profileId)
        {
            var response = await _productVersionService.GetConstructionTypeAsync(productVersionId, profileId);
            if (response == null) return null;

            return response;
        }

        public async Task<IEnumerable<ActivityModel>?> GetActivityAsync(int productVersionId, int profileId, string? name)
        {
            var response = await _productVersionService.GetActivityAsync(productVersionId, profileId, name);
            if (response == null) return null;

            return response;
        }

        public async Task<IEnumerable<ContractTypeModel>?> GetContractTypeAsync(int productVersionId)
        {
            var response = await _productVersionService.GetContractTypeAsync(productVersionId);
            if (response == null) return null;

            return response;
        }

        public async Task<IEnumerable<PlanModel>?> GetPlanActivityAsync(int productVersionId, int activityId)
        {
            var response = await _productVersionService.GetPlanActivityAsync(productVersionId, activityId);
            if (response == null) return null;

            return response;
        }

        public async Task<IEnumerable<Localization>?> GetLocalizationAsync(int productVersionId)
        {
            var response = await _productVersionService.GetLocalizationAsync(productVersionId);
            if (response == null) return null;

            return response;
        }

        public async Task<IEnumerable<PlanCoverageActivityModel>?> GetPlanCoverageActivityAsync(PlanCoverageActivityFilterModel request)
        {
            var response = new List<PlanCoverageActivityModel>();
            var coverages = await _productVersionService.GetPlanCoverageAsync(request.ProductVersionId, request.PlanId);
            if (coverages == null) return null;

            foreach (var cob in coverages.OrderBy(cob => cob?.CoverageId).ThenBy(cob => cob?.CoverageBasic))
            {
                var limit = await _productVersionService.GetCoverageActivityLimitAsync(request.ProductVersionId, cob.CoverageId, request.ActivityId, request.ProfileId);
                if (limit == null)
                {
                    throw new BusinessException($"Não encontrado os percentual de limite para a cobertura {cob.Name} ");
                }

                if (cob.CoverageBasic)
                {
                    if(request.InsuredAmountValue < limit.InsuredAmountMin)
                    {
                        throw new BusinessException($"A Cobertura {cob.Name}  possui o valor minimo para a IS é de R$:{limit.InsuredAmountMin:N2}.");
                    }
                    if (request.InsuredAmountValue > limit.InsuredAmountMax)
                    {
                        throw new BusinessException($"A Cobertura {cob.Name} possui o valor máximo paraa IS  é de R$:{limit.InsuredAmountMax:N2}. ");
                    }
                }

                var coverage = new PlanCoverageActivityModel()
                {
                    CoverageId = cob.CoverageId,
                    Name = cob.Name,
                    Description = cob.Description,
                    BranchId = cob.BranchId,
                    CoverageGroupId = cob.CoverageGroupId,
                    CoverageBasic = cob.CoverageBasic,
                    CoverageRestricted = cob.CoverageRestricted,
                    InsuredAmountMin = limit.InsuredAmountMin,
                    InsuredAmountMax = limit.InsuredAmountMax
                };

                var franchise = await _productVersionService.GetCoverageFranchiseAsync(request.ProductVersionId, cob.CoverageId);
                if (franchise.Any())
                {
                    franchise.ToList().ForEach(item =>
                    {
                        coverage.Franchise.Add(item);
                    });
                }

                response.Add(coverage);
            }

            return response;
        }
    }
}
