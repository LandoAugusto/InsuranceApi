using InsuranceApi.Application.Interfaces;
using InsuranceApi.Controllers.V1.Base;

using InsuranceApi.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceApi.Controllers.V1
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="quotationAppService"></param>
    public class QuotationController(IQuotationAppService quotationAppService) : BaseController
    {
        private readonly IQuotationAppService _quotationAppService = quotationAppService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("create-quotation-residence")]
        [ProducesResponseType(typeof(BaseDataResponseModel<QuotationModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateQuotationAsync(CreateQuotationModel request)
        {
            var response = await _quotationAppService.CreateQuotationAsync(1, request);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="quotationNumber"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("get-version{quotationNumber}")]
        [ProducesResponseType(typeof(BaseDataResponseModel<QuotationModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByNumberAsync(int quotationNumber)
        {
            var response = await _quotationAppService.GetByNumberAsync(quotationNumber);
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
        [Route("calculates-validity")]
        [ProducesResponseType(typeof(BaseDataResponseModel<CalculateValidityModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CalculateValidityAsync(CalculateValidityFilterModel request)
        {
            var response = await _quotationAppService.CalculateValidityAsync(request);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }
    }
}
