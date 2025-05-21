using InsuranceApi.Application.Interfaces;
using InsuranceApi.Core.Models;
using InsuranceApi.Service.Client.Interfaces.Product;

namespace InsuranceApi.Application.Services
{
    internal class ProductVersionAppService(IProductVersionService productVersionService) : IProductVersionAppService
    {
        private readonly IProductVersionService _productVersionService = productVersionService;
        public async Task<ProductVersionAcceptanceModel?> GetAcceptanceAsync(int productId,  int profileId)
        {
            return await _productVersionService.GetAcceptanceAsync(productId, profileId);
        }
    }
}
