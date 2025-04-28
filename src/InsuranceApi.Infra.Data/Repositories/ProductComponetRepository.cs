using InsuranceApi.Core.Entities;
using InsuranceApi.Infra.Data.Contexts;
using InsuranceApi.Infra.Data.Interfaces;
using InsuranceApi.Infra.Data.Repositories.Standard;
using Microsoft.EntityFrameworkCore;

namespace InsuranceApi.Infra.Data.Repositories
{
    internal class ProductComponetRepository(InsuranceDbContext context) : DomainRepository<ProductComponent>(context), IProductComponetRepository
    {

        public async Task<ProductComponent?> GetAsync(int code)
        {
            var query =
                    await Task.FromResult(
                        GenerateQuery(
                            filter: (filtr => filtr.Code.Equals(code)),
                             includeProperties: source =>
                                    source
                                    .Include(item => item.ProductComponentScreen)
                                    .ThenInclude(item => item.Component),
                            orderBy: item => item.OrderBy(y => y.Id)));

            return query.FirstOrDefault();
        }
    }
}
