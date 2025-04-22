using InsuranceApi.Application.Interfaces;
using InsuranceApi.Core.Models;

namespace InsuranceApi.Application.Services
{
    internal class QuotationAppService : IQuotationAppService
    {
        public async Task<IEnumerable<QuotationModel>?> GetByNumberAsync(int quotationNumber)
        {
            return await Task.FromResult<IEnumerable<QuotationModel>?>(null);
        }
    }
}
