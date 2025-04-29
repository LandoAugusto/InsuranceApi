using InsuranceApi.Core.Entities.Enumerators;
using InsuranceApi.Core.Models;

namespace InsuranceApi.Application.Interfaces
{
    public interface ICivilCourtService
    {
        Task<IEnumerable<CivilCourtModel>?> ListAsync(CivilCourtFilterModel filter);        
    }
}
