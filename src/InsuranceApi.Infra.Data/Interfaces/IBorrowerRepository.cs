using InsuranceApi.Core.Entities;
using InsuranceApi.Core.Entities.Enumerators;
using InsuranceApi.Infra.Data.Repositories.Standard.Interfaces;

namespace InsuranceApi.Infra.Data.Interfaces
{
    public interface IBorrowerRepository : IDomainRepository<Borrower>
    {
        Task<IEnumerable<Borrower>?> ListAsync(int? brokerId, string name, RecordStatusEnum recordStatus);
    }
}
