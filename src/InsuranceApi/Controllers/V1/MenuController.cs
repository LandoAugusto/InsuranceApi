using InsuranceApi.Application.Interfaces;
using InsuranceApi.Controllers.V1.Base;
using InsuranceApi.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace InsuranceApi.Controllers.V1
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="menuAppService"></param>
    public class MenuController(IMenuAppService menuAppService) : BaseController
    {
        private readonly IMenuAppService _menuAppService = menuAppService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("get-role-menu")]

        public async Task<ActionResult> GetAsync([FromQuery, Required] string roleName)
        {
            var response = await _menuAppService.GetMenuAsync(roleName);    
            return ReturnSuccess(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get-menu-all")]
        [ProducesResponseType(typeof(BaseDataResponseModel<MenuModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetMenuAllAsync()
        {
            var response = await _menuAppService.GetMenuAllAsync();
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
        [Route("save-role-menu")]    
        [ProducesResponseType(typeof(BaseDataResponseModel<MenuModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SaveMenuRoelAsync(SaveMenuRoleModel request)
        {
            var response = await _menuAppService.SaveMenuRoleAsync(request);
            return base.ReturnSuccess(response);
        }
    }
}


