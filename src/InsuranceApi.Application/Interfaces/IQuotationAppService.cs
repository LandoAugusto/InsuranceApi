using InsuranceApi.Core.Models;

namespace InsuranceApi.Application.Interfaces
{
    public interface IQuotationAppService
    {
        Task<QuotationModel?> CreateQuotationAsync(int userId, CreateQuotationModel request);
        Task<IEnumerable<QuotationModel>?> GetByNumberAsync(int quotationNumber);
        Task<CalculateValidityModel> CalculateValidityAsync(CalculateValidityFilterModel request);
    }
}
