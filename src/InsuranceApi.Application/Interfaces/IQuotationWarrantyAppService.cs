using InsuranceApi.Core.Models;

namespace InsuranceApi.Application.Interfaces
{
    public interface IQuotationWarrantyAppService
    {
        Task<QuotationWarrantyResponseModel> SaveUpdateAsync(QuotationWarrantyRequestModel request);

        Task<UpdateLaborCourtResponseModel> UpdateLaborCourtAsync(string legalCasenumber);
    }
}
