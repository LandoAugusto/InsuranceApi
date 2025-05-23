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
    /// <param name="quotationWarrantyAppService"></param>
    public class QuotationWarrantyController(IQuotationWarrantyAppService quotationWarrantyAppService) : BaseController
    {
        private readonly IQuotationWarrantyAppService _quotationWarrantyAppService = quotationWarrantyAppService;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("save-update")]
        [ProducesResponseType(typeof(BaseDataResponseModel<QuotationModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SaveUpdateAsync([FromBody] QuotationWarrantyRequestModel request)
        {
            var response = await _quotationWarrantyAppService.SaveUpdateAsync(request);
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
        [ProducesResponseType(typeof(BaseDataResponseModel<UpdateLaborCourtResponseModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseDataResponseModel<>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateLaborCourtAsync(string legalCasenumber)
        {
            return base.ReturnSuccess(await _quotationWarrantyAppService.UpdateLaborCourtAsync(legalCasenumber));
        }
    }
}
