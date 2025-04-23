using InsuranceApi.Core.Entities;
using InsuranceApi.Core.Entities.Enumerators;
using InsuranceApi.Infra.Data.Contexts;
using InsuranceApi.Infra.Data.Interfaces;
using InsuranceApi.Infra.Data.Repositories.Standard;
using Microsoft.EntityFrameworkCore;

namespace InsuranceApi.Infra.Data.Repositories
{
    internal class BorrowerRepository(InsuranceDbContext context) : DomainRepository<Borrower>(context), IBorrowerRepository
    {
        public async Task<IEnumerable<Borrower>?> ListAsync(int? brokerId, string name, RecordStatusEnum recordStatus)
        {
            var query =
                    await Task.FromResult(
                        GenerateQuery(
                            filter: (filtr => filtr.BrokerId == brokerId && filtr.Status.Equals((int)recordStatus)),
                            includeProperties: source =>
                                    source
                                    .Include(item => item.Person),                                    
                            orderBy: item => item.OrderBy(y => y.BrokerId)));

            return query.ToList();
        }
    }
}
