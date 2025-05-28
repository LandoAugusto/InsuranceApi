using InsuranceApi.Application.Interfaces;
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
        public async Task<IEnumerable<PaymentMethodModel>?> ListPaymentMethodAsync(int productVersionId)
        {
            var response = await _productVersionService.ListPaymentMethodAsync(productVersionId);
            if (response == null) return null;

            return response;
        }

        public async Task<IEnumerable<PaymentFrequencyModel>?> ListPaymentFrequencyAsync(int productVersionId)
        {
            var response = await _productVersionService.ListPaymentFrequencyAsync(productVersionId);
            if (response == null) return null;

            return response;
        }

        public async Task<IEnumerable<PaymentInstallmentModel>?> ListPaymentInstallmentAsync(int productVersionId, int paymentMethodId)
        {
            var response = await _productVersionService.ListPaymentInstallmentAsync(productVersionId, paymentMethodId);
            if (response == null) return null;

            return response;
        }

        public async Task<IEnumerable<CalculationTypeModel>?> GetProductVersionCalculationTypeAsync(int productVersionId, int profileId)
        {
            var response = await _productVersionService.ListCalculationTypeAsync(productVersionId, profileId);
            if (response == null) return null;

            return response;
        }

        public async Task<CalculationTypeAcceptanceModel?> GetProductVersionCalculationTypeAcceptanceAsync(int productVersionId, int profileId, int calculationTypeId)
        {
            var response = await _productVersionService.GetCalculationTypeAcceptanceAsync(productVersionId, profileId, calculationTypeId);
            if (response == null) return null;

            return response;
        }

        public async Task<IEnumerable<ConstructionTypeModel>?> GetProductVersionConstructionTypeAsync(int productVersionId)
        {
            var response = await _productVersionService.ListConstructionTypeAsync(productVersionId);
            if (response == null) return null;

            return response;
        }

        public async Task<IEnumerable<ActivityModel>?> GetProductVersionActivityAsync(int productVersionId, int profileId, string? name)
        {
            var response = await _productVersionService.ListActivityAsync(productVersionId, profileId, name);
            if (response == null) return null;

            return response;
        }

        public async Task<IEnumerable<ContractTypeModel>?> GetProductVersionContractTypeAsync(int productVersionId)
        {
            var response = await _productVersionService.ListContractTypeAsync(productVersionId);
            if (response == null) return null;

            return response;
        }
    }
}
