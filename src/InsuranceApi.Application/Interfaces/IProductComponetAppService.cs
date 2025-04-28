using InsuranceApi.Core.Models;

namespace InsuranceApi.Application.Interfaces
{
    public interface IProductComponetAppService
    {
        Task<ProductComponetScreenModel?> ListAsync(int code);
    }
}
