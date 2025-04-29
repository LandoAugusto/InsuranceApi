using InsuranceApi.Core.Entities;
using InsuranceApi.Core.Entities.Enumerators;
using InsuranceApi.Infra.Data.Contexts;
using InsuranceApi.Infra.Data.Interfaces;
using InsuranceApi.Infra.Data.Repositories.Standard;
using Microsoft.EntityFrameworkCore;

namespace InsuranceApi.Infra.Data.Repositories
{
    internal class CivilCourtRepository(InsuranceDbContext context) : DomainRepository<CivilCourt>(context), ICivilCourtRepository
    {
        public async Task<IEnumerable<CivilCourt>?> ListAsync(string? name, int? laborCourtId, string? stateId, RecordStatusEnum recordStatus)
        {
            var query =
                    await Task.FromResult(
                        GenerateQuery(
                            filter: (filtr => filtr.Status.Equals((int)recordStatus)
                                && (string.IsNullOrEmpty(name) || filtr.Name.Contains(name))
                                && (laborCourtId == null || filtr.LaborCourtId == laborCourtId)
                                && (string.IsNullOrEmpty(stateId) || filtr.State == stateId)
                               ),
                             includeProperties: source =>
                                    source
                                    .Include(item => item.LaborCourt),
                            orderBy: item => item.OrderBy(y => y.LaborCourtId)));

            return query.AsEnumerable();
        }
    }
}