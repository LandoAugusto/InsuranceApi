using InsuranceApi.Application.Interfaces;
using InsuranceApi.Core.Entities.Enumerators;
using InsuranceApi.Core.Extensions;
using InsuranceApi.Core.Models;
using InsuranceApi.Service.Client.Interfaces.Product;

namespace InsuranceApi.Application.Services
{
    internal class CivilCourtAppService(ICivilCourtService civilCourtService) : ICivilCourtAppService
    {
        private readonly ICivilCourtService _civilCourtService = civilCourtService;


        public async Task<IEnumerable<CivilCourtModel>?> GetAllAsync()
        {   
            var response = await _civilCourtService.GetAllAsync();
            if (!response.IsAny<CivilCourtModel>()) return null;

            return response;
        }

        public async Task<IEnumerable<CivilCourtModel>?> ListAsync(CivilCourtFilterModel filter)
        {
            var recordStatus = (filter.StatusId == null || filter.StatusId == 2) ? RecordStatusEnum.Ativo : RecordStatusEnum.Inativo;

            var response = await _civilCourtService.ListAsync(filter);
            if (!response.IsAny<CivilCourtModel>()) return null;

            return response;
        }
    }
}
