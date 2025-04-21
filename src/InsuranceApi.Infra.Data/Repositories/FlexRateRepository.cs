using InsuranceApi.Core.Entities;
using InsuranceApi.Core.Entities.Enumerators;
using InsuranceApi.Infra.Data.Contexts;
using InsuranceApi.Infra.Data.Interfaces;
using InsuranceApi.Infra.Data.Repositories.Standard;
using Microsoft.EntityFrameworkCore;

namespace InsuranceApi.Infra.Data.Repositories
{
    internal class FlexRateRepository(InsuranceDbContext context) : DomainRepository<FlexRate>(context), IFlexRateRepository
    {
        public async Task<IEnumerable<FlexRate?>> ListAsync(int? productVersionId, RecordStatusEnum recordStatus)
        {
            var query =
                    await Task.FromResult(
                        GenerateQuery(
                            filter: (filtr => filtr.Status == recordStatus
                                && (productVersionId == null || filtr.ProductVersionId == productVersionId)),
                            includeProperties: source =>
                                    source                                    
                                    .Include(item => item.RateType)
                                    .Include(item => item.OperationType),
                            orderBy: item => item.OrderBy(y => y.FlexRateId)));

            return query.AsEnumerable();
        }
    }
}
