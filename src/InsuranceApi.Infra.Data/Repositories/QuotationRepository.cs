using InsuranceApi.Core.Entities;
using InsuranceApi.Infra.Data.Contexts;
using InsuranceApi.Infra.Data.Interfaces;
using InsuranceApi.Infra.Data.Repositories.Standard;

namespace InsuranceApi.Infra.Data.Repositories
{
    internal class QuotationRepository(InsuranceDbContext context) : DomainRepository<Quotation>(context), IQuotationRepository
    {
        public async Task<Quotation?> GetAsync(int quotationId)
        {
            var query =
                    await Task.FromResult(
                        GenerateQuery(
                            filter: (filtr => filtr.QuotationId.Equals(quotationId)),                             
                            orderBy: item => item.OrderBy(y => y.QuotationId)));

            return query.FirstOrDefault();
        }
    }
}
