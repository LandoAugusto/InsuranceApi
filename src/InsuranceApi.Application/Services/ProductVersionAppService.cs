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
        public async Task<ProductVersionAcceptanceModel?> GetAcceptanceAsync(int productId, int profileId)
        {
            var response = await _productVersionService.GetAcceptanceAsync(productId, profileId);
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

        public async Task<IEnumerable<ConstructionTypeModel>?> GetConstructionTypeAsync(int productVersionId)
        {
            var response = await _productVersionService.GetConstructionTypeAsync(productVersionId);
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

        public async Task<IEnumerable<PlanCoverageActivityLimit>?> GetPlanCoverageActivityAsync(int productVersionId, int planId, int activityId, int profileId)
        {
            var response = new List<PlanCoverageActivityLimit>();
            var coverages = await _productVersionService.GetPlanCoverageAsync(productVersionId, planId);
            if (coverages == null) return null;

            foreach (var item in coverages)
            {
                var limit = await _productVersionService.GetCoverageActivityLimitAsync(productVersionId, item.CoverageId, activityId, profileId);
                if (limit == null)
                {
                    throw new BusinessException($"Não encontrado os percetual de limite para a cobertura {item.Name} ");
                }

                var coverage = new PlanCoverageActivityLimit()
                {
                    CoverageId = item.CoverageId,
                    Name = item.Name,
                    Description = item.Description,
                    BranchId = item.BranchId,
                    CoverageGroupId = item.CoverageGroupId,
                    CoverageBasic = item.CoverageBasic,
                    CoverageRestricted = item.CoverageRestricted,                    
                    Limit = limit
                };
                response.Add(coverage);
            }

            return response;
        }
    }
}
