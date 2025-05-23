using InsuranceApi.Application.Interfaces;
using InsuranceApi.Controllers.V1.Base;
using InsuranceApi.Core.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Identity;
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
    }
}


