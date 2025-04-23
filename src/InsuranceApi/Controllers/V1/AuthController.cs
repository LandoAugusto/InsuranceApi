using InsuranceApi.Application.Interfaces;
using InsuranceApi.Controllers.V1.Base;
using InsuranceApi.Core.Model;
using InsuranceApi.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceApi.Controllers.V1
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="authenticationAppService"></param>
    public class AuthController(IAuthenticationAppService authenticationAppService) : BaseController
    {
        private readonly IAuthenticationAppService _authenticationAppService = authenticationAppService;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("token")]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetAsync(TokenModelRequest request)
        {
            return base.ReturnSuccess(await _authenticationAppService.GetAsync(request.Login, request.Password));
        }
    }
}
