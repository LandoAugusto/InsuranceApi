using InsuranceApi.Core.Models;

namespace InsuranceApi.Service.Client.Interfaces.Product
{
    public interface ILegalRecourseTypeService
    {
        Task<IEnumerable<LegalRecourseTypeModel>?> GetAllAsync();
    }
}
