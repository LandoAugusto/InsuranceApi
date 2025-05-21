using InsuranceApi.Application.Interfaces;
using InsuranceApi.Core.Models;
using InsuranceApi.Service.Client.Interfaces.Product;

namespace InsuranceApi.Application.Services
{
    internal class ProductComponentScreenAppService(IProductService productService) : IProductComponentScreenAppService
    {
        private readonly IProductService _productService = productService;

        public async Task<ProductComponentScreenModel?> GetComponentScreenAsync(int code)
        {
            return await _productService.GetComponentScreenAsync(code);
        }
    }
}
