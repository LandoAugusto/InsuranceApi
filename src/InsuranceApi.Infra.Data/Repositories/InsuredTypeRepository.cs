using InsuranceApi.Core.Entities;
using InsuranceApi.Core.Entities.Enumerators;
using InsuranceApi.Infra.Data.Contexts;
using InsuranceApi.Infra.Data.Interfaces;
using InsuranceApi.Infra.Data.Repositories.Standard;

namespace InsuranceApi.Infra.Data.Repositories
{
    internal class InsuredTypeRepository(InsuranceDbContext context) : DomainRepository<InsuredType>(context), IInsuredTypeRepository
    {
        public async Task<IEnumerable<InsuredType>?> ListAsync(RecordStatusEnum recordStatus)
        {
            var query =
                    await Task.FromResult(
                        GenerateQuery(
                            filter: (filtr => filtr.Status.Equals((int)recordStatus)),
                            orderBy: item => item.OrderBy(y => y.InsuredTypeId)));

            return query.ToList();
        }
    }
}
