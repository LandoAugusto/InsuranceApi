using InsuranceApi.Core.Entities;
using InsuranceApi.Core.Entities.Enumerators;
using InsuranceApi.Infra.Data.Contexts;
using InsuranceApi.Infra.Data.Interfaces;
using InsuranceApi.Infra.Data.Repositories.Standard;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceApi.Infra.Data.Repositories
{
    
    internal class BorrowerAppealFeeRepository(InsuranceDbContext context) : DomainRepository<BorrowerAppealFee>(context), IBorrowerAppealFeeRepository
    {
        public async Task<IEnumerable<BorrowerAppealFee?>> ListAsync(int? productId, int? coverageId, int? takerId, int? termTypeId, RecordStatusEnum recordStatus)
        {
            var query =
                    await Task.FromResult(
                        GenerateQuery(
                            filter: (filtr => filtr.Status.Equals((int)recordStatus)
                                && (termTypeId == null || filtr.TermTypeId == termTypeId)
                                && (takerId == null || filtr.Borrower.PersonId == takerId)
                                && (productId == null || filtr.ProductId == productId)
                                && (coverageId == null || filtr.CoverageId == coverageId)),
                            includeProperties: source =>
                                    source              
                                    .Include(item => item.Borrower),
                            orderBy: item => item.OrderBy(y => y.BorrowerId)));

            return query.AsEnumerable();
        }
    }
}

