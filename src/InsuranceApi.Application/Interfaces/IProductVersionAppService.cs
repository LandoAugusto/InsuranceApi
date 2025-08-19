using InsuranceApi.Core.Models;

namespace InsuranceApi.Application.Interfaces
{
    public interface IProductVersionAppService
    {
        Task<IEnumerable<PlanModel>?> GetPlanAsync(int productVersionId);
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
        Task<IEnumerable<ConstructionTypeModel>?> GetConstructionTypeAsync(int productVersionId, int profileId);
        Task<IEnumerable<ActivityModel>?> GetActivityAsync(int productVersionId, int profileid, string? name);
        Task<IEnumerable<ContractTypeModel>?> GetContractTypeAsync(int productVersionId);
        Task<IEnumerable<PlanModel>?> GetPlanActivityAsync(int productVersionId, int activityId);
        Task<IEnumerable<PlanUsepropertyStructureModel>?> GetPlanUsepropertyStructure(int productVersionId, int useTypeId, int propertyStructureId);
        Task<IEnumerable<PlanCoverageFranchiseModel>?> GetPlanCoverageFranchiseAsync(int productVersionId, int planId);
        Task<IEnumerable<Localization>?> GetLocalizationAsync(int productVersionId);
        Task<IEnumerable<AssistanceModel>?> GetPlanAssistanceAsync(int productVersionId, int planId);
        Task<IEnumerable<QuestionnaireModel>?> GetQuestionnaireAsync(int productVersionId);
        Task<IEnumerable<PropertyStructureModel>?> GetPropertyStructureAsync(int productVersionId, int constructionTypeId, int useTypeId, int profileId);
        Task<IEnumerable<UseTypeModel>?> GetUseTypeAsync(int productVersionId, int constructionTypeId, int profileId);
    }
}
