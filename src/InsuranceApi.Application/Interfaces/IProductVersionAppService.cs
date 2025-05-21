using InsuranceApi.Core.Models;

namespace InsuranceApi.Application.Interfaces
{
    public interface IProductVersionAppService
    {
        Task<ProductVersionAcceptanceModel?> GetAcceptanceAsync(int productId, int profileId);
    }
}
