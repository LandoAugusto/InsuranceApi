using InsuranceApi.Application.Interfaces;
using InsuranceApi.Controllers.V1.Base;
using InsuranceApi.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceApi.Controllers.V1
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userAppService"></param>
    public class UserController(IUserAppService userAppService)
        : BaseController
    {

        private readonly IUserAppService _userAppService = userAppService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="login"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("get-users")]
        public async Task<ActionResult> GetAsync([FromQuery] string? id, [FromQuery] string? login, [FromQuery] string? email)
        {
            var response = await _userAppService.GetUserAsync(id, login, email);
            if (response == null)
                return base.ReturnNotFound();

            return ReturnSuccess(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("get-user/{userId}")]
        public async Task<ActionResult> GetUserByIdAsync(string userId)
        {
            var response = await _userAppService.GetUserByIdAsync(userId);
            if (response == null)
                return base.ReturnNotFound();
            return ReturnSuccess(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("get-role-by-id/{roleId}")]
        public async Task<ActionResult> GetRoleByIdAsync(int roleId)
        {
            var response = await _userAppService.GetRoleByIdAsync(roleId);
            if (response == null)
                return base.ReturnNotFound();

            return ReturnSuccess(response);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("get-roles")]
        public async Task<ActionResult> GetRolesAsync([FromQuery] int? roleId, [FromQuery] string? name)
        {
            var response = await _userAppService.GetRolesAsync(roleId, name);
            if (response == null)
                return base.ReturnNotFound();

            return ReturnSuccess(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("save-roles")]
        public async Task<ActionResult> SaveRoleAsync(SaveRoleModel request)
        {
            var response = await _userAppService.SaveRoleAsync(request);
            return ReturnSuccess(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("update-user")]
        public async Task<ActionResult> UpdateUserAsync(UpdateUserModel request)
        {
            var response = await _userAppService.UpdateUserAsync(request);

            return ReturnSuccess(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>       
        [HttpPost]
        [Route("update-password")]
        public async Task<ActionResult> UpdateUserPasswordAsync(UpdatePasswordUserModel request)
        {
            var response = await _userAppService.UpdateUserPasswordAsync(request);
            return ReturnSuccess(response);
        }
    }
}
