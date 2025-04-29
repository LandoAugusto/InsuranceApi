using InsuranceApi.Core.Entities;
using InsuranceApi.Infra.Data.Repositories.Standard.Interfaces;

namespace InsuranceApi.Infra.Data.Interfaces
{
    public interface ILegalRecourseTypeParameterRepository : IDomainRepository<LegalRecourseTypeParameter>
    {
        Task<LegalRecourseTypeParameter?> GetByLegalRecourseTypeIdAsync(int legalRecourseTypeId);
    }
}
