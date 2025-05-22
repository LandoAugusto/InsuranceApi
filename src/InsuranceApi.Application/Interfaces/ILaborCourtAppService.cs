using InsuranceApi.Core.Models;

namespace InsuranceApi.Application.Interfaces
{
    public interface ILaborCourtAppService
    {
        Task<IEnumerable<LaborCourtModel>?> GetAllAsync();
        Task<IEnumerable<LaborCourtModel>?> ListAsync(LaborCourtFilterModel filter);
        Task<UpdateLaborCourtResponseModel> UpdateLaborCourtAsync(string legalCasenumber);
    }
}
