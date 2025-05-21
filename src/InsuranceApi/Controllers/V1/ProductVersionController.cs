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
    public class ProductVersionController(IProductVersionAppService productVersionAppService) : BaseController
    {
        private readonly IProductVersionAppService _productVersionService = productVersionAppService;   
        /// <summary>
        /// 
        /// </summary>
        /// <param name="productId"></param>        
        /// <param name="profileId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("get-product-version-acceptance/{productId}/{profileId}")]
        [ProducesResponseType(typeof(BaseDataResponseModel<ProductVersionAcceptanceModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<ProductVersionAcceptanceModel>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(BaseDataResponseModel<ProductVersionAcceptanceModel>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAcceptanceAsync(int productId, int coverageId, int profileId)
        {
            var response = await _productVersionService.GetAcceptanceAsync(productId,  profileId);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }
    }
}
