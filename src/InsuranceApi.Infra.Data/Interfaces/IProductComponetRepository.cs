using InsuranceApi.Core.Entities;
using InsuranceApi.Infra.Data.Repositories.Standard.Interfaces;

namespace InsuranceApi.Infra.Data.Interfaces
{
    public interface IProductComponetRepository : IDomainRepository<ProductComponent>
    {
        Task<ProductComponent?> GetAsync(int code);
    }
}
