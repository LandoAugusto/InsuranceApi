using InsuranceApi.Core.Entities;
using InsuranceApi.Core.Entities.Enumerators;
using InsuranceApi.Infra.Data.Repositories.Standard.Interfaces;

namespace InsuranceApi.Infra.Data.Interfaces
{
    public interface IFlexRateRepository : IDomainRepository<FlexRate>
    {
        Task<IEnumerable<FlexRate?>> ListAsync(int? productVersionId, RecordStatusEnum recordStatus);
    }
}
