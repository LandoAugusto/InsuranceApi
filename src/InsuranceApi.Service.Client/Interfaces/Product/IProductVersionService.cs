﻿using InsuranceApi.Core.Models;

namespace InsuranceApi.Service.Client.Interfaces.Product
{
    public interface IProductVersionService
    {
        Task<ProductVersionModel?> GetAsync(int productId);
        Task<IEnumerable<ProductVersionClauseModel>?> ListClauseAsync(int productVersionId, decimal insuredAmountValue);
        Task<ProductVersionAcceptanceModel?> GetAcceptanceAsync(int productVersionId, int profileId);
        Task<InsuredObjectModel?> GetInsuredObjectAsync(int productVersionId);
        Task<CoverageModel?> GetByCoverageIdAsync(int productVersionId, int coverageId);
        Task<IEnumerable<CoverageModel>?> ListCoverageAsync(int productVersionId);
        Task<IEnumerable<TermTypeModel>?> ListTermTypeAsync(int productVersionId);
        Task<IEnumerable<LawsuitTypeModel>?> ListLawsuitTypeAsync(int productVersionId);
        Task<IEnumerable<PaymentMethodModel>?> GetPaymentMethodAsync(int productVersionId);
        Task<IEnumerable<PaymentFrequencyModel>?> GetPaymentFrequencyAsync(int productVersionId);
        Task<IEnumerable<PaymentInstallmentModel>?> GetPaymentInstallmentAsync(int productVersionId, int paymentMethodId);
        Task<IEnumerable<CalculationTypeModel>?> GetCalculationTypeAsync(int productVersionId, int profileId);
        Task<CalculationTypeAcceptanceModel?> GetCalculationTypeAcceptanceAsync(int productVersionId, int profileId, int calculationTypeId);
        Task<IEnumerable<ConstructionTypeModel?>> GetConstructionTypeAsync(int productVersionId, int profileId);
        Task<IEnumerable<ActivityModel?>> GetActivityAsync(int productVersionId, int profileid, string? name);
        Task<IEnumerable<ContractTypeModel>?> GetContractTypeAsync(int productVersionId);
        Task<IEnumerable<PlanModel?>> GetPlanActivityAsync(int productVersionId, int activityId);
        Task<IEnumerable<PlanModel?>> GetPlanUsepropertyStructure(int productVersionId, int useTypeId, int propertyStructureId);
        Task<IEnumerable<PlanCoverageModel?>> GetPlanCoverageAsync(int productVersionId, int planId);
        Task<IEnumerable<AssistanceModel>?> GetPlanAssistanceAsync(int productVersionId, int planId);
        Task<CoverageActivityLimitModel?> GetCoverageActivityLimitAsync(int productVersionId, int coverageId, int activityId, int profile);
        Task<IEnumerable<Localization>?> GetLocalizationAsync(int productVersionId);
        Task<IEnumerable<FranchiseModel?>> GetCoverageFranchiseAsync(int productVersionId, int coverageId);
        Task<IEnumerable<QuestionnaireModel>> GetQuestionnaireAsync(int productVersionId);
        Task<IEnumerable<PropertyStructureModel>?> GetPropertyStructureAsync(int productVersionId, int constructionTypeId, int useTypeId, int profileId);
        Task<IEnumerable<UseTypeModel>?> GetUseTypeAsync(int productVersionId, int constructionTypeId, int profileId);
    }
}
