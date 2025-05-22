using InsuranceApi.Core.Models;

namespace InsuranceApi.Service.Client.Interfaces.Product
{
    public interface ILaborCourtService
    {
        Task<IEnumerable<LaborCourtModel>?> GetAllAsync();
        Task<IEnumerable<LaborCourtModel>?> ListAsync(LaborCourtFilterModel filter);
    }
}
