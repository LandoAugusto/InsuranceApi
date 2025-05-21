using InsuranceApi.Core.Models;

namespace InsuranceApi.Service.Client.Interfaces.Product
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>?> GetAllAsync();
        Task<ProductComponentScreenModel?> GetComponentScreenAsync(int code);
    }
}
