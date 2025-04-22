using InsuranceApi.Application.Interfaces;
using InsuranceApi.Core.Models;

namespace InsuranceApi.Application.Services
{
    internal class QuotationWarrantyAppService : IQuotationWarrantyAppService
    {
        public async Task<QuotationWarrantyResponseModel> SaveUpdateAsync(QuotationWarrantyRequestModel request)
        {


            return new QuotationWarrantyResponseModel();
        }

        public Task<UpdateLaborCourtResponseModel> UpdateLaborCourtAsync(string legalCasenumber)
        {
            int? labourCourtId = null;
            int? civilCourtId = null;
            // NNNNNNN-DD.AAAA.J.TR.0000            
            if (!string.IsNullOrWhiteSpace(legalCasenumber))
            {
                var partes = legalCasenumber.Split('.');
                if (partes.Length == 5)
                {
                    int parsed = 0;
                    if (int.TryParse(partes[3], out parsed))
                    {
                        labourCourtId = parsed;
                    }
                    if (int.TryParse(partes[4], out parsed))
                    {
                        civilCourtId = parsed;
                    }
                }
            }

            return Task.FromResult(new UpdateLaborCourtResponseModel
            {
                LegalCasenumber = legalCasenumber,
                LabourCourtId = labourCourtId,
                CivilCourtId = civilCourtId
            });
        }
    }
}
