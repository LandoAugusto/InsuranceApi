using InsuranceApi.Core.Models;

namespace InsuranceApi.Application.Interfaces
{
    public interface IQuotationAppService
    {
        Task<IEnumerable<QuotationModel>?> GetByNumberAsync(int quotationNumber);
    }
}
