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
    /// <param name="legalRecourseType"></param>
    public class LegalRecourseTypeController(ILegalRecourseTypeAppService legalRecourseType) : BaseController
    {
        private readonly ILegalRecourseTypeAppService _legalRecourseType = legalRecourseType;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get-all")]
        [ProducesResponseType(typeof(BaseDataResponseModel<IEnumerable<LegalRecourseTypeModel>?>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _legalRecourseType.GetAllAsync();
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }
    }
}
