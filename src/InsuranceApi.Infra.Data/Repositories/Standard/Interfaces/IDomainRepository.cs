using InsuranceApi.Core.Entities.Interfaces;

namespace InsuranceApi.Infra.Data.Repositories.Standard.Interfaces
{
    public interface IDomainRepository<TEntity> : IRepositoryAsync<TEntity> where TEntity : class, IIdentityEntity
    {
    }
}
