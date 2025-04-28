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
    /// <param name="productComponetScreenAppService"></param>
    public class ProductComponentController(IProductComponetAppService productComponetScreenAppService) : BaseController
    {
        private readonly IProductComponetAppService _productComponetScreenAppService = productComponetScreenAppService;


    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [Route("get-component/{code}")]
    [ProducesResponseType(typeof(BaseDataResponseModel<ProductComponetScreenModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseDataResponseModel<ProductComponetScreenModel>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(BaseDataResponseModel<ProductComponetScreenModel>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ListAsync(int code)
    {
        var response = await _productComponetScreenAppService.ListAsync(code);
        if (response == null)
            return ReturnNotFound();

        return base.ReturnSuccess(response);
    }
}
}