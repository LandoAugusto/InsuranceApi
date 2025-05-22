using InsuranceApi.Core.Entities.Enumerators;
using InsuranceApi.Core.Models;

namespace InsuranceApi.Application.Interfaces
{
    public interface ILegalRecourseTypeAppService
    {
        Task<IEnumerable<LegalRecourseTypeModel>?> GetAllAsync();
    }
}
