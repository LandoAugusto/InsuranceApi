using InsuranceApi.Core.Entities;
using InsuranceApi.Infra.Data.Contexts;
using InsuranceApi.Infra.Data.Interfaces;
using InsuranceApi.Infra.Data.Repositories.Standard;
using Microsoft.EntityFrameworkCore;

namespace InsuranceApi.Infra.Data.Repositories
{
    internal class PersonRepository(InsuranceDbContext context) : DomainRepository<Person>(context),
        IPersonRepository
    {
        public async Task<Person?> GetByDocumentAsync(int documentTypeId, string document)
        {
            var query =
                    await Task.FromResult(
                        GenerateQuery(
                            filter: (filtr => filtr.Document == document
                            && filtr.DocumentTypeId.Equals(documentTypeId)),
                            includeProperties: source =>
                                    source                                    
                                    .Include(item => item.Address)));

            return query.FirstOrDefault();
        }
    }
}
