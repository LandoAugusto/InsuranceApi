using InsuranceApi.Application.Interfaces;
using InsuranceApi.Core.Models;
using InsuranceApi.Service.Client.Interfaces.Product;

namespace InsuranceApi.Application.Services
{
    internal class ProductVersionAppService(IProductVersionService productVersionService) : IProductVersionAppService
    {
        private readonly IProductVersionService _productVersionService = productVersionService;

        public async Task<ProductVersionAcceptanceModel?> GetAcceptanceAsync(int productId, int profileId)
        {
            return await _productVersionService.GetAcceptanceAsync(productId, profileId);
        }

        public async Task<InsuredObjectModel?> GetInsuredObjectAsync(int productVersionId)
        {
            return await _productVersionService.GetInsuredObjectAsync(productVersionId);
        }

        public async Task<CoverageModel?> GetByCoverageIdAsync(int productVersionId, int coverageId)
        {
            return await _productVersionService.GetByCoverageIdAsync(productVersionId, coverageId);
        }

        public async Task<IEnumerable<CoverageModel?>> ListCoverageAsync(int productVersionId)
        {
            return await _productVersionService.ListCoverageAsync(productVersionId);
        }

        public async Task<IEnumerable<ProductVersionClauseModel?>> ListClauseAsync(int productVersionId, decimal insuredAmountValue)
        {
            return await _productVersionService.ListClauseAsync(productVersionId, insuredAmountValue);
        }

        public async Task<IEnumerable<TermTypeModel?>> ListTermTypeAsync(int productVersionId)
        {
            return await _productVersionService.ListTermTypeAsync(productVersionId);
        }

        public async Task<IEnumerable<LawsuitTypeModel?>> ListLawsuitTypeAsync(int productVersionId)
        {
            return await _productVersionService.ListLawsuitTypeAsync(productVersionId);
        }
        public async Task<IEnumerable<PaymentMethodModel?>> ListPaymentMethodAsync(int productVersionId)
        {
            return await _productVersionService.ListPaymentMethodAsync(productVersionId);
        }

        public async Task<IEnumerable<PaymentFrequencyModel?>> ListPaymentFrequencyAsync(int productVersionId)
        {
            return await _productVersionService.ListPaymentFrequencyAsync(productVersionId);
        }

        public async Task<IEnumerable<PaymentInstallmentModel?>> ListPaymentInstallmentAsync(int productVersionId, int paymentMethodId)
        {
            return await _productVersionService.ListPaymentInstallmentAsync(productVersionId, paymentMethodId);
        }
    }
}
