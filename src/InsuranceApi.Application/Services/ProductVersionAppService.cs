using AutoMapper;
using InsuranceApi.Application.Interfaces;
using InsuranceApi.Core.Extensions;
using InsuranceApi.Core.Models;
using InsuranceApi.Service.Client.Interfaces.Product;

namespace InsuranceApi.Application.Services
{
    internal class ProductVersionAppService(IMapper mapper ,IProductVersionService productVersionService) : IProductVersionAppService
    {
        private readonly IMapper _mapper = mapper;
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
        public async Task<IEnumerable<ProductVersionClauseModel>?> ListClauseAsync(int productVersionId, decimal insuredAmountValue)
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
        public async Task<IEnumerable<PlanModel>?> GetPlanAsync(int productVersionId)
        {
            var response = await _productVersionService.GetPlanAsync(productVersionId);
            if (response == null) return null;

            return response;
        }
        public async Task<IEnumerable<PlanModel>?> GetPlanActivityAsync(int productVersionId, int activityId)
        {
            var response = await _productVersionService.GetPlanActivityAsync(productVersionId, activityId);
            if (response == null) return null;

            return response;
        }
        public async Task<IEnumerable<PlanUsepropertyStructureModel>?> GetPlanUsepropertyStructure(int productVersionId, int useTypeId, int propertyStructureId)
        {
            var response = await _productVersionService.GetPlanUsepropertyStructure(productVersionId, useTypeId, propertyStructureId);            
            if (response.IsAny<PlanModel>()) return null;
                        
            var planUsePropertyStructure = new List<PlanUsepropertyStructureModel>();   
            return planUsePropertyStructure;
        }

        public async Task<IEnumerable<Localization>?> GetLocalizationAsync(int productVersionId)
        {
            var response = await _productVersionService.GetLocalizationAsync(productVersionId);
            if (response == null) return null;

            return response;
        }
        public async Task<IEnumerable<PlanCoverageFranchiseModel>?> GetPlanCoverageFranchiseAsync(int productVersionId, int planId)
        {
            var response = new List<PlanCoverageFranchiseModel>();
            var coverages = await _productVersionService.GetPlanCoverageAsync(productVersionId, planId);
            if (coverages == null) return null;

            foreach (var cob in coverages.OrderBy(cob => cob?.CoverageId).ThenBy(cob => cob?.CoverageBasic))
            {
                var coverage = new PlanCoverageFranchiseModel()
                {
                    CoverageId = cob.CoverageId,
                    Name = cob.Name,
                    Description = cob.Description,
                    BranchId = cob.BranchId,
                    CoverageGroupId = cob.CoverageGroupId,
                    CoverageBasic = cob.CoverageBasic,
                    CoverageRestricted = cob.CoverageRestricted,
                };

                var franchise = await _productVersionService.GetCoverageFranchiseAsync(productVersionId, cob.CoverageId);
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
        public async Task<IEnumerable<AssistanceModel>?> GetPlanAssistanceAsync(int productVersionId, int planId)
        {
            var model = await _productVersionService.GetPlanAssistanceAsync(productVersionId, planId);
            if (model == null) return null;

            return model;
        }
        public async Task<IEnumerable<QuestionnaireModel>?> GetQuestionnaireAsync(int productVersionId)
        {
            var model = await _productVersionService.GetQuestionnaireAsync(productVersionId);
            if (model == null) return null;

            return model;
        }
        public async Task<IEnumerable<PropertyStructureModel>?> GetPropertyStructureAsync(int productVersionId, int constructionTypeId, int useTypeId, int profileId)
        {
            var response = await _productVersionService.GetPropertyStructureAsync(productVersionId, constructionTypeId, useTypeId, profileId);
            if (!response.IsAny<PropertyStructureModel>()) return null;

            return response;
        }
        public async Task<IEnumerable<UseTypeModel>?> GetUseTypeAsync(int productVersionId, int constructionTypeId, int profileId)
        {
            var response = await _productVersionService.GetUseTypeAsync(productVersionId, constructionTypeId, profileId);
            if (!response.IsAny<UseTypeModel>()) return null;

            return response;
        }
    }
}
