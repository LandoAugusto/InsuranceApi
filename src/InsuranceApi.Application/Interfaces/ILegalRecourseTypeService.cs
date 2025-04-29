using InsuranceApi.Core.Entities.Enumerators;
using InsuranceApi.Core.Models;

namespace InsuranceApi.Application.Interfaces
{
    public interface ILegalRecourseTypeService
    {
        Task<IEnumerable<LegalRecourseTypeModel>?> GetAllAsync(RecordStatusEnum recordStatus);
    }
}
