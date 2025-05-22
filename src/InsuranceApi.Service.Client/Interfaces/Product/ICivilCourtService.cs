using InsuranceApi.Core.Models;

namespace InsuranceApi.Service.Client.Interfaces.Product
{
    public interface ICivilCourtService
    {
        Task<IEnumerable<CivilCourtModel>?> GetAllAsync();
        Task<IEnumerable<CivilCourtModel>?> ListAsync(CivilCourtFilterModel filter);
    }
}
