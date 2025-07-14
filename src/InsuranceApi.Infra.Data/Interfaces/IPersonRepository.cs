using InsuranceApi.Core.Entities;
using InsuranceApi.Infra.Data.Repositories.Standard.Interfaces;

namespace InsuranceApi.Infra.Data.Interfaces
{
    public interface IPersonRepository : IDomainRepository<Person>
    {
        Task<Person?> GetByDocumentAsync(int documentTypeId, string document);
    }
}
