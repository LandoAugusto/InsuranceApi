﻿using InsuranceApi.Application.Interfaces;
using InsuranceApi.Controllers.V1.Base;
using InsuranceApi.Core.Entities.Enumerators;

using InsuranceApi.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceApi.Controllers.V1
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="laborCourtAppService"></param>
    public class LaborCourtController(ILaborCourtAppService laborCourtAppService) : BaseController
    {
        private readonly ILaborCourtAppService _laborCourtAppService = laborCourtAppService;


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get-all")]
        [ProducesResponseType(typeof(BaseDataResponseModel<LaborCourtModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _laborCourtAppService.GetAllAsync();
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
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ListAsync(LaborCourtFilterModel request)
        {
            var response = await _laborCourtAppService.ListAsync(request);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="legalCasenumber"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("update-labor-court/{legalCasenumber}")]
        [ProducesResponseType(typeof(BaseDataResponseModel<CivilCourtModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<CivilCourtModel>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseDataResponseModel<CivilCourtModel>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateLaborCourtAsync(string legalCasenumber)
        {
            return base.ReturnSuccess(await _laborCourtAppService.UpdateLaborCourtAsync(legalCasenumber));
        }
    }
}
