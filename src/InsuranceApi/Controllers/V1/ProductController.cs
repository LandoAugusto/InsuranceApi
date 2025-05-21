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
    /// <param name="productAppService"></param>
    /// <param name="productComponentScreenAppService"></param>
    public class ProductController(IProductAppService productAppService, IProductComponentScreenAppService productComponentScreenAppService) : BaseController
    {
        private readonly IProductAppService _productAppService = productAppService;
        private readonly IProductComponentScreenAppService _productComponentScreenAppService = productComponentScreenAppService;
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get-all")]
        [ProducesResponseType(typeof(BaseDataResponseModel<ProductModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<ProductModel>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAsync()
        {
            var response = await _productAppService.GetAllAsync();
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get-component-screen/{code}")]
        [ProducesResponseType(typeof(BaseDataResponseModel<ProductModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseDataResponseModel<ProductModel>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetComponentScreenAsync(int code)
        {
            var response = await _productComponentScreenAppService.GetComponentScreenAsync(code);
            if (response == null)
                return ReturnNotFound();

            return base.ReturnSuccess(response);
        }
    }
}
