using InsuranceApi.Application.Interfaces;
using InsuranceApi.Controllers.V1.Base;
using InsuranceApi.Core.Entities.Enumerators;
using InsuranceApi.Core.Model;
using InsuranceApi.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceApi.Controllers.V1
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="laborCourtService"></param>
    public class LaborCourtController(ILaborCourtAppService laborCourtService) : BaseController
    {
        private readonly ILaborCourtAppService _laborCourtService = laborCourtService;


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get-all")]
        [ProducesResponseType(typeof(BaseDataResponseModel<LaborCourtModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<LaborCourtModel>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseDataResponseModel<LaborCourtModel>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _laborCourtService.GetAllAsync();
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("get-list")]
        [ProducesResponseType(typeof(BaseDataResponseModel<CivilCourtModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<CivilCourtModel>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseDataResponseModel<CivilCourtModel>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ListAsync(LaborCourtFilterModel request)
        {
            var response = await _laborCourtService.ListAsync(request);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }
    }
}
