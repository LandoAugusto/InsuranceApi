using InsuranceApi.Core.Entities;
using InsuranceApi.Core.Entities.Enumerators;
using InsuranceApi.Infra.Data.Contexts;
using InsuranceApi.Infra.Data.Interfaces;
using InsuranceApi.Infra.Data.Repositories.Standard;

namespace InsuranceApi.Infra.Data.Repositories
{
    internal class LaborCourtRepository(InsuranceDbContext context) : DomainRepository<LaborCourt>(context), ILaborCourtRepository
    {   
        public async Task<IEnumerable<LaborCourt>?> ListAsync(string? name,  string ? stateId, RecordStatusEnum recordStatus)
        {
            var query =
                    await Task.FromResult(
                        GenerateQuery(
                            filter: (filtr => filtr.Status.Equals((int)recordStatus)
                                && (string.IsNullOrEmpty(name) || filtr.Name.Contains(name))                              
                                && (string.IsNullOrEmpty(stateId)|| filtr.State == stateId)
                               ),
                            orderBy: item => item.OrderBy(y => y.LaborCourtId)));

            return query.AsEnumerable();
        }
    }
}