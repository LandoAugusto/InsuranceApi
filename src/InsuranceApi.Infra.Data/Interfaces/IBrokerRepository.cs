using InsuranceApi.Core.Entities.Enumerators;
using InsuranceApi.Core.Entities;
using InsuranceApi.Infra.Data.Repositories.Standard.Interfaces;

namespace InsuranceApi.Infra.Data.Interfaces
{
    public interface IBrokerRepository : IDomainRepository<Broker>  
    {
        Task<Broker?> GetByIdAsync(int? BrokerId, RecordStatusEnum recordStatus);
    }
}
