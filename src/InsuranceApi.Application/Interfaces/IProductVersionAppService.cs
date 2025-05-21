using InsuranceApi.Core.Models;

namespace InsuranceApi.Application.Interfaces
{
    public interface IProductVersionAppService
    {   
        Task<InsuredObjectModel?> GetInsuredObjectAsync(int productVersionId);
        Task<CoverageModel?> GetByCoverageIdAsync(int productVersionId, int coverageId);
        Task<IEnumerable<CoverageModel?>> ListCoverageAsync(int productVersionId);
        Task<IEnumerable<TermTypeModel?>> ListTermTypeAsync(int productVersionId);
        Task<IEnumerable<LawsuitTypeModel?>> ListLawsuitTypeAsync(int productVersionId);
        Task<IEnumerable<PaymentMethodModel?>> ListPaymentMethodAsync(int productVersionId);
        Task<IEnumerable<PaymentFrequencyModel?>> ListPaymentFrequencyAsync(int productVersionId);
        Task<ProductVersionAcceptanceModel?> GetAcceptanceAsync(int productId, int profileId);
        Task<IEnumerable<ProductVersionClauseModel?>> ListClauseAsync(int productVersionId, decimal insuredAmountValue);
        Task<IEnumerable<PaymentInstallmentModel?>> ListPaymentInstallmentAsync(int productVersionId, int paymentMethodId);
    }
}
