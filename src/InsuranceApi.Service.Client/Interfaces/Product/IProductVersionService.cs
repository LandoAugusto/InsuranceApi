using InsuranceApi.Core.Models;

namespace InsuranceApi.Service.Client.Interfaces.Product
{
    public interface IProductVersionService
    {
        Task<ProductVersionAcceptanceModel?> GetAcceptanceAsync(int productId, int profileId);
    }
}
