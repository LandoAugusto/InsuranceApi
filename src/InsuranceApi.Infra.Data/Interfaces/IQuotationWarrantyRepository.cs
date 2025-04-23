using InsuranceApi.Core.Entities;
using InsuranceApi.Infra.Data.Repositories.Standard.Interfaces;

namespace InsuranceApi.Infra.Data.Interfaces
{
    public interface IQuotationWarrantyRepository : IDomainRepository<QuotationWarranty>    
    {
        Task<IEnumerable<QuotationWarranty?>> ListAsync(int? quotationId, int? warrantyId);
    }
}
