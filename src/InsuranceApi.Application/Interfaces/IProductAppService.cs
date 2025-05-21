using InsuranceApi.Core.Models;

namespace InsuranceApi.Application.Interfaces
{
    public interface IProductAppService
    {
        Task<IEnumerable<ProductModel>?> GetAllAsync();
    }
}
