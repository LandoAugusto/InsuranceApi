using InsuranceApi.Core.Models;

namespace InsuranceApi.Service.Client.Interfaces.Product
{
    public interface IProductVersionService
    {
        Task<IEnumerable<ProductVersionClauseModel?>> ListClauseAsync(int productVersionId, decimal insuredAmountValue);
        Task<ProductVersionAcceptanceModel?> GetAcceptanceAsync(int productId, int profileId);
        Task<InsuredObjectModel?> GetInsuredObjectAsync(int productVersionId);
        Task<CoverageModel?> GetByCoverageIdAsync(int productVersionId, int coverageId);
        Task<IEnumerable<CoverageModel?>> ListCoverageAsync(int productVersionId);
        Task<IEnumerable<TermTypeModel?>> ListTermTypeAsync(int productVersionId);
        Task<IEnumerable<LawsuitTypeModel?>> ListLawsuitTypeAsync(int productVersionId);
        Task<IEnumerable<PaymentMethodModel?>> ListPaymentMethodAsync(int productVersionId);
        Task<IEnumerable<PaymentFrequencyModel?>> ListPaymentFrequencyAsync(int productVersionId);
        Task<IEnumerable<PaymentInstallmentModel?>> ListPaymentInstallmentAsync(int productVersionId, int paymentMethodId);
        Task<IEnumerable<CalculationTypeModel?>> ListCalculationTypeAsync(int productVersionId, int profileId);
        Task<CalculationTypeAcceptanceModel?> GetCalculationTypeAcceptanceAsync(int productVersionId, int profileId, int calculationTypeId);
        Task<IEnumerable<ConstructionTypeModel?>> ListConstructionTypeAsync(int productVersionId);
        Task<IEnumerable<ActivityModel?>> ListActivityAsync(int productVersionId, int profileid, string? name);
        Task<IEnumerable<ContractTypeModel?>> ListContractTypeAsync(int productVersionId);
    }
}
