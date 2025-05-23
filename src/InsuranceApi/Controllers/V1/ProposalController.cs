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
    /// <param name="quotationAppService"></param>
    public class ProposalController(IQuotationAppService quotationAppService) : BaseController
    {
        private readonly IQuotationAppService _quotationAppService = quotationAppService;


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
    }
}