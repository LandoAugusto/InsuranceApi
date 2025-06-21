using InsuranceApi.Core.Models;

namespace InsuranceApi.Application.Interfaces
{
    public interface IProductVersionAppService
    {
        Task<ProductVersionModel?> GetAsync(int productId);
        Task<InsuredObjectModel?> GetInsuredObjectAsync(int productVersionId);
        Task<CoverageModel?> GetByCoverageIdAsync(int productVersionId, int coverageId);
        Task<IEnumerable<CoverageModel>?> ListCoverageAsync(int productVersionId);
        Task<IEnumerable<TermTypeModel>?> ListTermTypeAsync(int productVersionId);
        Task<IEnumerable<LawsuitTypeModel>?> ListLawsuitTypeAsync(int productVersionId);
        Task<IEnumerable<PaymentMethodModel>?> GetPaymentMethodAsync(int productVersionId);
        Task<IEnumerable<PaymentFrequencyModel>?> GetPaymentFrequencyAsync(int productVersionId);
        Task<ProductVersionAcceptanceModel?> GetAcceptanceAsync(int productId, int profileId);
        Task<IEnumerable<ProductVersionClauseModel>?> ListClauseAsync(int productVersionId, decimal insuredAmountValue);
        Task<IEnumerable<PaymentInstallmentModel>?> GetPaymentInstallmentAsync(int productVersionId, int paymentMethodId);
        Task<IEnumerable<CalculationTypeModel>?> GetCalculationTypeAsync(int productVersionId, int profileId);
        Task<CalculationTypeAcceptanceModel?> GetCalculationTypeAcceptanceAsync(int productVersionId, int profileId, int calculationTypeId);
        Task<IEnumerable<ConstructionTypeModel>?> GetConstructionTypeAsync(int productVersionId);
        Task<IEnumerable<ActivityModel>?> GetActivityAsync(int productVersionId, int profileid, string? name);
        Task<IEnumerable<ContractTypeModel>?> GetContractTypeAsync(int productVersionId);
        Task<IEnumerable<PlanModel>?> GetPlanActivityAsync(int productVersionId, int activityId);
        Task<IEnumerable<PlanCoverageActivityModel>?> GetPlanCoverageActivityAsync(int productVersionId, int planId, int activityId, int profileId);
        Task<IEnumerable<Localization>?> GetLocalizationAsync(int productVersionId);
    }
}
