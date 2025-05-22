using AutoMapper;
using InsuranceApi.Application.Interfaces;
using InsuranceApi.Core.Extensions;
using InsuranceApi.Core.Models;
using InsuranceApi.Service.Client.Interfaces.Product;

namespace InsuranceApi.Application.Services
{
    internal class LaborCourtAppService(ILaborCourtService laborCourtService) : ILaborCourtAppService
    {
        private readonly ILaborCourtService _laborCourtService = laborCourtService;


        public async Task<IEnumerable<LaborCourtModel>?> GetAllAsync()
        {
            var response = await _laborCourtService.GetAllAsync();
            if (!response.IsAny<LaborCourtModel>()) return null;

            return response;
        }
        public async Task<IEnumerable<LaborCourtModel>?> ListAsync(LaborCourtFilterModel filter)
        {
            var response = await _laborCourtService.ListAsync(filter);
            if (!response.IsAny<LaborCourtModel>()) return null;

            return response;
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
