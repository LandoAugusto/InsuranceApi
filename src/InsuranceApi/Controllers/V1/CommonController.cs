using InsuranceApi.Application.Interfaces;
using InsuranceApi.Controllers.V1.Base;
using InsuranceApi.Core.Entities.Enumerators;
using InsuranceApi.Core.Model;
using InsuranceApi.Core.Models;
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
        [ProducesResponseType(typeof(BaseDataResponseModel<ZipCodeModel>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseDataResponseModel<ZipCodeModel>), StatusCodes.Status404NotFound)]
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
        [Route("get-address-type")]
        [ProducesResponseType(typeof(BaseDataResponseModel<IEnumerable<AddressTypeModel>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<IEnumerable<AddressTypeModel>>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseDataResponseModel<IEnumerable<AddressTypeModel>>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ListAddressTypeAsync()
        {
            var response = await _commonAppService.ListAddressTypeAsync(RecordStatusEnum.Ativo);
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
        [ProducesResponseType(typeof(BaseDataResponseModel<IEnumerable<DocumentTypeModel>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<IEnumerable<DocumentTypeModel>>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseDataResponseModel<IEnumerable<DocumentTypeModel>>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ListDocumentTypeAsync()
        {
            var response = await _commonAppService.ListDocumentTypeAsync(RecordStatusEnum.Ativo);
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
        [ProducesResponseType(typeof(BaseDataResponseModel<IEnumerable<InsuredTypeModel>>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseDataResponseModel<IEnumerable<InsuredTypeModel>>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ListInsuredTypeAsync()
        {
            var response = await _commonAppService.ListInsuredTypeAsync(RecordStatusEnum.Ativo);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }
    }
}
