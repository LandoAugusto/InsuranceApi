using InsuranceApi.Core.Entities;
using InsuranceApi.Infra.Data.Contexts;
using InsuranceApi.Infra.Data.Interfaces;
using InsuranceApi.Infra.Data.Repositories.Standard;

namespace InsuranceApi.Infra.Data.Repositories
{
    internal class FlexRateBrokerRepository(InsuranceDbContext context) : DomainRepository<FlexRateBroker>(context), IFlexRateBrokerRepository
    {
        public async Task<IEnumerable<FlexRateBroker?>> GetAsync(int brokerId)
        {
            var query =
                    await Task.FromResult(
                        GenerateQuery(
                            filter: (filtr => filtr.BrokerId.Equals(brokerId) ),
                            orderBy: item => item.OrderBy(y => y.FlexRateBrokerId)));

            return query.AsEnumerable();
        }
    }
}
