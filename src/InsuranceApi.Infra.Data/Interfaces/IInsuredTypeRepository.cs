using InsuranceApi.Core.Entities;
using InsuranceApi.Core.Entities.Enumerators;
using InsuranceApi.Infra.Data.Repositories.Standard.Interfaces;

namespace InsuranceApi.Infra.Data.Interfaces
{
    public interface IInsuredTypeRepository : IDomainRepository<InsuredType>
    {
        Task<IEnumerable<InsuredType>?> ListAsync(RecordStatusEnum recordStatus);
    }
}
