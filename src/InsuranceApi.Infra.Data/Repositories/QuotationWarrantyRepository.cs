using InsuranceApi.Core.Entities;
using InsuranceApi.Infra.Data.Contexts;
using InsuranceApi.Infra.Data.Interfaces;
using InsuranceApi.Infra.Data.Repositories.Standard;
using Microsoft.EntityFrameworkCore;

namespace InsuranceApi.Infra.Data.Repositories
{
    internal class QuotationWarrantyRepository(InsuranceDbContext context) : DomainRepository<QuotationWarranty>(context), IQuotationWarrantyRepository
    {
        public async Task<IEnumerable<QuotationWarranty?>> ListAsync(int? quotationId, int? warrantyId)
        {
            var query =
                    await Task.FromResult(
                        GenerateQuery(
                            filter: (filtr => (quotationId == null || filtr.QuotationWarrantyId == quotationId)),
                            includeProperties: source =>
                                    source
                                    .Include(item => item.QuotationWarrantyComplement),
                            orderBy: item => item.OrderBy(y => y.QuotationWarrantyId)));
            return query.AsEnumerable();
        }
    }
}
