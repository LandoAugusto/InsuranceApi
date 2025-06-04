using InsuranceApi.Application.Interfaces;
using InsuranceApi.Controllers.V1.Base;
using InsuranceApi.Core.Entities.Enumerators;
using InsuranceApi.Core.Model;
using InsuranceApi.Core.Models;
using InsuranceApi.Service.Client.Interfaces.Product;
using InsuranceApi.Service.Client.Models;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceApi.Controllers.V1
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="commonAppService"></param>
    public class CommonController(ICommonAppService commonAppService) : BaseController
    {
        private readonly ICommonAppService _commonAppService = commonAppService;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get-zipCode/{zipCode}")]
        [ProducesResponseType(typeof(BaseDataResponseModel<ZipCodeModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetZipCodelAsync(string zipCode)
        {
            var response = await _commonAppService.GetZipCodeAsync(zipCode);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get-state-all")]
        [ProducesResponseType(typeof(BaseDataResponseModel<IEnumerable<StateModel?>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetStateAsync()
        {
            var response = await _commonAppService.GetStateAsync();
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get-status-all")]
        [ProducesResponseType(typeof(BaseDataResponseModel<IEnumerable<RecordStatusModel?>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetStatusAsync()
        {
            var response = await _commonAppService.GetStatusAsync();
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get-term-type-all")]
        [ProducesResponseType(typeof(BaseDataResponseModel<IEnumerable<TermTypeModel?>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTermTypeAsync()
        {
            var response = await _commonAppService.GetTermTypeAsync();
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get-address-type")]
        [ProducesResponseType(typeof(BaseDataResponseModel<IEnumerable<AddressTypeModel>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAddressTypeAsync()
        {
            var response = await _commonAppService.GetAddressTypeAsync();
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get-document-type")]
        [ProducesResponseType(typeof(BaseDataResponseModel<IEnumerable<DocumenTypeModel>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetDocumentypeAsync()
        {
            var response = await _commonAppService.GetDocumentypeAsync();
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get-insured-type")]
        [ProducesResponseType(typeof(BaseDataResponseModel<IEnumerable<InsuredTypeModel>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetInsuredTypeModelAsync()
        {
            var response = await _commonAppService.GetInsuredTypeAsync();
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get-insurance-type")]
        [ProducesResponseType(typeof(BaseDataResponseModel<InsuranceTypeModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetInsuranceTypeAsync()
        {
            var response = await _commonAppService.GetInsuranceTypeAsync();
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get-insurer")]
        [ProducesResponseType(typeof(BaseDataResponseModel<InsurerModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetInsurerAsync(string? name)
        {
            var response = await _commonAppService.GetInsurerAsync();
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get-claims-experience-bonus")]
        [ProducesResponseType(typeof(BaseDataResponseModel<ClaimsExperienceBonusModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetClaimsExperienceBonusModelAsync()
        {
            var response = await _commonAppService.GetClaimsExperienceBonusAsync();
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get-buildings-contents")]
        [ProducesResponseType(typeof(BaseDataResponseModel<BuildingsContentsModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBuildingsContentsAsync()
        {
            var response = await _commonAppService.GetBuildingsContentsAsync();
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="constructionTypeId"></param>
       /// <param name="useTypeId"></param>
       /// <param name="profileId"></param>
       /// <returns></returns>
        [HttpGet]
        [Route("get-property-structure/{constructionTypeId}/{useTypeId}/{profileId}")]
        [ProducesResponseType(typeof(BaseDataResponseModel<PropertyStructureModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPropertyStructureAsync(int constructionTypeId, int useTypeId, int profileId)
        {
            var response = await _commonAppService.GetPropertyStructureAsync(constructionTypeId, useTypeId, profileId);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="constructionTypeId"></param>
        /// <param name="profileId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("get-use-type/{constructionTypeId}/{profileId}")]
        [ProducesResponseType(typeof(BaseDataResponseModel<PropertyStructureModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUseTypeAsync(int constructionTypeId, int profileId)
        {
            var response = await _commonAppService.GetUseTypeAsync(constructionTypeId, profileId);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get-person-type")]
        [ProducesResponseType(typeof(BaseDataResponseModel<IEnumerable<PersonTypeModel>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPersonTypeAsync()
        {
            var response = await _commonAppService.GetPersonTypeAsync();
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get-quotation-status")]
        [ProducesResponseType(typeof(BaseDataResponseModel<IEnumerable<QuotationStatusModel>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetQuotationStatusAsync()
        {
            var response = await _commonAppService.GetQuotationStatusAsync();
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get-protective-devices-fire")]
        [ProducesResponseType(typeof(BaseDataResponseModel<IEnumerable<ProtectiveDevicesModel>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProtectiveDevicesFireAsync()
        {
            var response = await _commonAppService.GetProtectiveDevicesFireAsync(ProtectiveDevicesTypeEnum.Fire);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get-protective-devices-theft")]
        [ProducesResponseType(typeof(BaseDataResponseModel<IEnumerable<ProtectiveDevicesModel>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProtectiveDevicesTheftAsync()
        {
            var response = await _commonAppService.GetProtectiveDevicesTheftAsync(ProtectiveDevicesTypeEnum.Theft);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }
    }
}
