using InsuranceApi.Core.Entities.Enumerators;
using InsuranceApi.Core.Models;

namespace InsuranceApi.Application.Interfaces
{
    public interface ILaborCourtService
    {   
        Task<IEnumerable<LaborCourtModel>?> ListAsync(LaborCourtFilterModel filter);
    }
}
