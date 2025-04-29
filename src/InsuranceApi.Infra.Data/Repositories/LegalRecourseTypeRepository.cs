using InsuranceApi.Core.Entities;
using InsuranceApi.Core.Entities.Enumerators;
using InsuranceApi.Infra.Data.Contexts;
using InsuranceApi.Infra.Data.Interfaces;
using InsuranceApi.Infra.Data.Repositories.Standard;

namespace InsuranceApi.Infra.Data.Repositories
{
    internal class LegalRecourseTypeRepository(InsuranceDbContext context) : DomainRepository<LegalRecourseType>(context), ILegalRecourseTypeRepository
    {
        public async Task<IEnumerable<LegalRecourseType>?> GetAllAsync(RecordStatusEnum recordStatus)
        {
            var query =
                    await Task.FromResult(
                        GenerateQuery(
                            filter: (filtr => filtr.Status.Equals((int)recordStatus)),
                            orderBy: item => item.OrderBy(y => y.LegalRecourseTypeId)));

            return query.AsEnumerable();
        }
    }
}
