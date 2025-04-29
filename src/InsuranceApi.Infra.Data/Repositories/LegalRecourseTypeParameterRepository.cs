using InsuranceApi.Core.Entities;
using InsuranceApi.Infra.Data.Contexts;
using InsuranceApi.Infra.Data.Interfaces;
using InsuranceApi.Infra.Data.Repositories.Standard;
using Microsoft.EntityFrameworkCore;

namespace InsuranceApi.Infra.Data.Repositories
{
    internal class LegalRecourseTypeParameterRepository(InsuranceDbContext context) : DomainRepository<LegalRecourseTypeParameter>(context), ILegalRecourseTypeParameterRepository
    {
        public async Task<LegalRecourseTypeParameter?> GetByLegalRecourseTypeIdAsync(int legalRecourseTypeId)
        {
            var query =
                    await Task.FromResult(
                        GenerateQuery(
                            filter: (filtr => filtr.LegalRecourseTypeId == legalRecourseTypeId && filtr.EndCoverage == null),
                            orderBy: item => item.OrderBy(y => y.LegalRecourseTypeId)));

            return query.FirstOrDefault();
        }
    }
}
