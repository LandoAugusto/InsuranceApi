using InsuranceApi.Application.Interfaces;
using InsuranceApi.Application.Services;
using InsuranceApi.Controllers.V1.Base;
using InsuranceApi.Core.Model;
using InsuranceApi.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceApi.Controllers.V1
{
    public class FlexRateController(IFlexRateAppService flexRateAppService) : BaseController
    {
        private readonly IFlexRateAppService _flexRateAppService = flexRateAppService;

        /// <summary>
        ///  Consulta a taxa mix pelo o id 
        /// </summary>
        /// <remarks>
        /// remark goes here.
        /// </remarks>
        /// <param name="id">Required </param>
        /// <return>Returns comment</return>
        /// <response code="200">Ok</response>        
        [HttpGet]
        [Route("get-flexRate/{id}")]
        [ProducesResponseType(typeof(BaseDataResponseModel<FlexRateModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<FlexRateModel>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseDataResponseModel<FlexRateModel>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var response = await _flexRateAppService.GetAsync(id);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>

        [HttpPost]
        [Route("get-flexRate-all/{productVersionId}")]
        [ProducesResponseType(typeof(BaseDataResponseModel<FlexRateModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<FlexRateModel>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseDataResponseModel<FlexRateModel>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllAsync(FlexRateMixFilterModel request)
        {
            var response = await _flexRateAppService.ListAsync(request);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("simulation-flex-rate-mix")]
        [ProducesResponseType(typeof(BaseDataResponseModel<SimulationModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<SimulationModel>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseDataResponseModel<SimulationModel>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SimulationAsync(SimulationFilterModel request)
        {
            var response = await _flexRateAppService.SimulationMixAsync(request);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }
    }
}