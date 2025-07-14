using InsuranceApi.Application.Interfaces;
using InsuranceApi.Controllers.V1.Base;
using InsuranceApi.Core.Model;
using InsuranceApi.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceApi.Controllers.V1
{
    /// <summary>
    /// 
    /// </summary>
    public class ProductVersionController(IProductVersionAppService productVersionAppService) : BaseController
    {
        private readonly IProductVersionAppService _productVersionAppService = productVersionAppService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productId"></param>     
        /// <returns></returns>
        [HttpGet]
        [Route("get-product-version/{productId}")]
        [ProducesResponseType(typeof(BaseDataResponseModel<ProductVersionModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAsync(int productId)
        {
            var response = await _productVersionAppService.GetAsync(productId);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productVersionId"></param>        
        /// <param name="profileId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("get-product-version-acceptance/{productVersionId}/{profileId}")]
        [ProducesResponseType(typeof(BaseDataResponseModel<ProductVersionAcceptanceModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAcceptanceAsync(int productVersionId, int profileId)
        {
            var response = await _productVersionAppService.GetAcceptanceAsync(productVersionId, profileId);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productVersionId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("get-product-version-insured-object/{productVersionId}")]
        [ProducesResponseType(typeof(BaseDataResponseModel<InsuredObjectModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetInsuredObjectAsync(int productVersionId)
        {
            var response = await _productVersionAppService.GetInsuredObjectAsync(productVersionId);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="productVersionId"></param>
        /// <param name="coverageId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("get-product-version-coverage/{productVersionId}/{coverageId}")]
        [ProducesResponseType(typeof(BaseDataResponseModel<CoverageModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByCoverageIdsync(int productVersionId, int coverageId)
        {
            var response = await _productVersionAppService.GetByCoverageIdAsync(productVersionId, coverageId);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }

        /// <summary>
        /// 
        /// </summary>        
        /// <param name="productVersionId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("list-product-version-coverage/{productVersionId}")]
        [ProducesResponseType(typeof(BaseDataResponseModel<IEnumerable<CoverageModel>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ListCoverageAsync(int productVersionId)
        {
            var response = await _productVersionAppService.ListCoverageAsync(productVersionId);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productVersionId"></param>
        /// <param name="insuredAmountValue"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("get-product-version-clause/{productVersionId}/{insuredAmountValue}")]
        [ProducesResponseType(typeof(BaseDataResponseModel<IEnumerable<ProductVersionClauseModel>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ListClauseAsync(int productVersionId, decimal insuredAmountValue)
        {
            var response = await _productVersionAppService.ListClauseAsync(productVersionId, insuredAmountValue);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productVersionId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("get-product-version-term-type/{productVersionId}")]
        [ProducesResponseType(typeof(BaseDataResponseModel<IEnumerable<TermTypeModel>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ListTermTypeAsync(int productVersionId)
        {
            var response = await _productVersionAppService.ListTermTypeAsync(productVersionId);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="productVersionId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("get-product-version-lawsuit-type/{productVersionId}")]
        [ProducesResponseType(typeof(BaseDataResponseModel<IEnumerable<LawsuitTypeModel>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ListLawsuitTypeAsync(int productVersionId)
        {
            var response = await _productVersionAppService.ListLawsuitTypeAsync(productVersionId);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productVersionId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("get-product-version-payment-method/{productVersionId}")]
        [ProducesResponseType(typeof(BaseDataResponseModel<IEnumerable<PaymentMethodModel>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ListPaymentMethodAsync(int productVersionId)
        {
            var response = await _productVersionAppService.GetPaymentMethodAsync(productVersionId);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productVersionId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("get-product-version-payment-frequency/{productVersionId}")]
        [ProducesResponseType(typeof(BaseDataResponseModel<IEnumerable<PaymentFrequencyModel>?>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<IEnumerable<PaymentFrequencyModel>?>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(BaseDataResponseModel<IEnumerable<PaymentFrequencyModel>?>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ListPaymentFrequencyAsync(int productVersionId)
        {
            var response = await _productVersionAppService.GetPaymentFrequencyAsync(productVersionId);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productVersionId"></param>
        /// <param name="paymentMethodId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("get-product-version-payment-installment/{productVersionId}/{paymentMethodId}")]
        [ProducesResponseType(typeof(BaseDataResponseModel<IEnumerable<PaymentInstallmentModel>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<IEnumerable<PaymentInstallmentModel?>>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(BaseDataResponseModel<IEnumerable<PaymentInstallmentModel?>>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ListPaymentInstallmentAsync(int productVersionId, int paymentMethodId)
        {
            var response = await _productVersionAppService.GetPaymentInstallmentAsync(productVersionId, paymentMethodId);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productVersionId"></param>        
        /// <returns></returns>
        [HttpGet]
        [Route("get-product-version-contract-type/{productVersionId}")]
        [ProducesResponseType(typeof(BaseDataResponseModel<IEnumerable<ContractTypeModel>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProductVersionContractTypeAsync(int productVersionId)
        {
            var response = await _productVersionAppService.GetContractTypeAsync(productVersionId);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productVersionId"></param>
        /// <param name="profileId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("get-product-version-calculation-type/{productVersionId}/{profileId}")]
        [ProducesResponseType(typeof(BaseDataResponseModel<IEnumerable<CalculationTypeModel>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProductVersionCalculationTypeAsync(int productVersionId, int profileId)
        {
            var response = await _productVersionAppService.GetCalculationTypeAsync(productVersionId, profileId);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productVersionId"></param>
        /// <param name="profileId"></param>
        /// <param name="calculationTypeId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("get-product-version-calculation-type-acceptance/{productVersionId}/{profileId}/{calculationTypeId}")]
        [ProducesResponseType(typeof(BaseDataResponseModel<CalculationTypeAcceptanceModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProductVersionCalculationTypeAcceptanceAsync(int productVersionId, int profileId, int calculationTypeId)
        {
            var response = await _productVersionAppService.GetCalculationTypeAcceptanceAsync(productVersionId, profileId, calculationTypeId);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productVersionId"></param> 
        /// <param name="profileId"></param> 
        /// <returns></returns>
        [HttpGet]
        [Route("get-product-version-construction-type/{productVersionId}/{profileId}")]
        [ProducesResponseType(typeof(BaseDataResponseModel<IEnumerable<ConstructionTypeModel>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProductVersionConstructionTypeAsync(int productVersionId, int profileId)
        {
            var response = await _productVersionAppService.GetConstructionTypeAsync(productVersionId, profileId);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productVersionId"></param>
        /// <param name="profileid"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("get-product-version-activity/{productVersionId}/{profileid}")]
        [ProducesResponseType(typeof(BaseDataResponseModel<IEnumerable<ActivityModel>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProductVersionActivityAsync(int productVersionId, int profileid, string? name)
        {
            var response = await _productVersionAppService.GetActivityAsync(productVersionId, profileid, name);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productVersionId"></param>
        /// <param name="activityId"></param>        
        /// <returns></returns>
        [HttpGet]
        [Route("get-product-version-plan-activity/{productVersionId}/{activityId}")]
        [ProducesResponseType(typeof(BaseDataResponseModel<IEnumerable<PlanModel>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPlanActivityAsync(int productVersionId, int activityId)
        {
            var response = await _productVersionAppService.GetPlanActivityAsync(productVersionId, activityId);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="productVersionId"></param>
        /// <param name="planId"></param>                
        /// <returns></returns>
        [HttpPost]
        [Route("get-product-version-plan-coverage-franchise/{productVersionId}/{planId}")]
        [ProducesResponseType(typeof(BaseDataResponseModel<IEnumerable<PlanCoverageFranchiseModel>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPlanCoverageAsync(int productVersionId, int planId)
        {
            var response = await _productVersionAppService.GetPlanCoverageFranchiseAsync(productVersionId, planId);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productVersionId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("get-product-version-localization/{productVersionId}")]
        [ProducesResponseType(typeof(BaseDataResponseModel<IEnumerable<Localization>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetLocalizationAsync(int productVersionId)
        {
            var response = await _productVersionAppService.GetLocalizationAsync(productVersionId);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }
    }
}
