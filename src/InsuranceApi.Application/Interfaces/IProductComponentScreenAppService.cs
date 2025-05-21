using InsuranceApi.Core.Models;

namespace InsuranceApi.Application.Interfaces
{
    public interface IProductComponentScreenAppService
    {
        Task<ProductComponentScreenModel?> GetComponentScreenAsync(int code);
    }
}
