using InsuranceApi.Core.Entities;
using InsuranceApi.Core.Entities.Enumerators;
using InsuranceApi.Infra.Data.Contexts;
using InsuranceApi.Infra.Data.Interfaces;
using InsuranceApi.Infra.Data.Repositories.Standard;

namespace InsuranceApi.Infra.Data.Repositories
{
    internal class AppealFeeRepository(InsuranceDbContext context) : DomainRepository<AppealFee>(context), IAppealFeeRepository
    {
        public async Task<IEnumerable<AppealFee>?> ListAsync(decimal? insuredAmountValueMin, decimal? insuredAmountValueMax, decimal? premiumValue, int? termTypeId, RecordStatusEnum recordStatus)
        {
            var query =
                    await Task.FromResult(
                        GenerateQuery(
                            filter: (filtr => filtr.Status.Equals((int)recordStatus)
                                && (premiumValue == null || filtr.PremiumValue == premiumValue)
                                && (insuredAmountValueMin == null || filtr.InsuredAmountValueMin == insuredAmountValueMin)
                                && (insuredAmountValueMax == null || filtr.InsuredAmountValueMax == insuredAmountValueMax)
                                && (termTypeId == null || filtr.TermTypeId == termTypeId)),
                             //includeProperties: source =>
                             //       source
                             //       .Include(item => item.TermType),
                            orderBy: item => item.OrderBy(y => y.AppealFeeId)));

            return query.AsEnumerable();
        }
    }
}
