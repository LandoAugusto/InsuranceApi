using InsuranceApi.Core.Entities;
using InsuranceApi.Infra.Data.Repositories.Standard.Interfaces;

namespace InsuranceApi.Infra.Data.Interfaces
{
    public  interface IFlexRateBrokerRepository : IDomainRepository<FlexRateBroker>
    {
        Task<IEnumerable<FlexRateBroker?>> GetAsync(int brokerId);
    }
}
