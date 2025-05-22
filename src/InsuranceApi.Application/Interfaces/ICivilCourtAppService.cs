using InsuranceApi.Core.Models;

namespace InsuranceApi.Application.Interfaces
{
    public interface ICivilCourtAppService
    {
        Task<IEnumerable<CivilCourtModel>?> GetAllAsync();
        Task<IEnumerable<CivilCourtModel>?> ListAsync(CivilCourtFilterModel filter);        
    }
}
