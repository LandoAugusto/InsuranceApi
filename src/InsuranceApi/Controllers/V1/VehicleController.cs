using InsuranceApi.Application.Interfaces;
using InsuranceApi.Controllers.V1.Base;

using InsuranceApi.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceApi.Controllers.V1
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="vehicleAppService"></param>
    public class VehicleController(IVehicleAppService vehicleAppService) : BaseController
    {
        private readonly IVehicleAppService _vehicleAppService = vehicleAppService;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        [Route("get-vehicle-brand/{name}")]
        [ProducesResponseType(typeof(BaseDataResponseModel<IEnumerable<VehicleBrandModel>>), StatusCodes.Status200OK)]        
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSearchBrandAsync(string name)
        {
            var response = await _vehicleAppService.GetSearchBrandAsync(name);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vehicleBranchId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        [Route("get-vehicle-model/{vehicleBranchId}/{name}")]
        [ProducesResponseType(typeof(BaseDataResponseModel<IEnumerable<VehicleBrandModel>>), StatusCodes.Status200OK)]        
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSearchBrandAsync(int vehicleBranchId, string? name)
        {
            var response = await _vehicleAppService.GetVehicleModelAsync(vehicleBranchId, name);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vehicleModelId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        [Route("get-vehicle-version/{vehicleModelId}/{name}")]
        [ProducesResponseType(typeof(BaseDataResponseModel<IEnumerable<VehicleBrandModel>>), StatusCodes.Status200OK)]        
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetVehicleVersionAsync(int vehicleModelId, string? name)
        {
            var response = await _vehicleAppService.GetVehicleVersionAsync(vehicleModelId, name);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }

        /// <summary>
        /// 
        /// </summary>     
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        [Route("get-vehicle-year")]
        [ProducesResponseType(typeof(BaseDataResponseModel<IEnumerable<VehicleBrandModel>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetVehicleYearAsync()
        {
            var response = await _vehicleAppService.GetVehicleYearAsync();
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }
    }
}
