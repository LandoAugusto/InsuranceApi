using InsuranceApi.Core.Entities;
using InsuranceApi.Core.Entities.Enumerators;
using InsuranceApi.Infra.Data.Repositories.Standard.Interfaces;

namespace InsuranceApi.Infra.Data.Interfaces
{
    public interface ICivilCourtRepository : IDomainRepository<CivilCourt>
    {   
        Task<IEnumerable<CivilCourt>?> ListAsync(string? name, int? laborCourtId, string? stateId, RecordStatusEnum recordStatus);
    }
}
