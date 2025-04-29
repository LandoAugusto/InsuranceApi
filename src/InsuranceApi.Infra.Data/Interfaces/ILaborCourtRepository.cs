using InsuranceApi.Core.Entities;
using InsuranceApi.Core.Entities.Enumerators;
using InsuranceApi.Infra.Data.Repositories.Standard.Interfaces;

namespace InsuranceApi.Infra.Data.Interfaces
{
    public interface ILaborCourtRepository : IDomainRepository<LaborCourt>
    {   
        Task<IEnumerable<LaborCourt>?> ListAsync(string? name, string? stateId, RecordStatusEnum recordStatus);
    }
}
