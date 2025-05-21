using InsuranceApi.Application.Interfaces;
using InsuranceApi.Core.Models;
using InsuranceApi.Service.Client.Interfaces.Product;

namespace InsuranceApi.Application.Services
{
    internal class ProductAppService(IProductService productService) : IProductAppService
    {
        private readonly IProductService _productService = productService;

        public async Task<IEnumerable<ProductModel>?> GetAllAsync()
        {
            return await _productService.GetAllAsync();
        }   
    }
}
