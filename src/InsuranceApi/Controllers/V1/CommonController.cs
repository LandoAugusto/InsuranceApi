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

    }
}
