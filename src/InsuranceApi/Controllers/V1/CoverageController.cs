using InsuranceApi.Application.Interfaces;
using InsuranceApi.Controllers.V1.Base;

using InsuranceApi.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceApi.Controllers.V1
{
    /// <summary>
    /// 
    /// </summary>
    public class CoverageController(ICoverageAppService coverageAppService) : BaseController
    {
        private readonly ICoverageAppService _coverageAppService = coverageAppService;  

        [HttpPost]
        [Route("get-coverage-limit-activity")]
        [ProducesResponseType(typeof(BaseDataResponseModel<IEnumerable<PlanCoverageFranchiseModel>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCoverageLimitActivityAsync(CoverageActivityLimitFilterModel request)
        {
            var response = await _coverageAppService.GetCoverageLimitActivityAsync(request);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }
    }
}
