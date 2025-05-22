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
    }
}
