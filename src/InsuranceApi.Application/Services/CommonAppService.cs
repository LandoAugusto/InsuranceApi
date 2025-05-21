using InsuranceApi.Application.Interfaces;
using InsuranceApi.Core.Extensions;
using InsuranceApi.Core.Models;
using InsuranceApi.Service.Client.Interfaces;
using InsuranceApi.Service.Client.Interfaces.Product;
using InsuranceApi.Service.Client.Models;

namespace InsuranceApi.Application.Services
{
    public class CommonAppService(IZipCodeService zipCodeService, ICommonService commonService) : ICommonAppService
    {
        private readonly IZipCodeService _zipCodeService = zipCodeService;
        private readonly ICommonService _commonService = commonService;

        public async Task<ZipCodeModel?> GetZipCodeAsync(string zipCode)
        {
            var response = await _zipCodeService.GetAsync(zipCode);
            if (response == null) return null;

            return response;
        }

        public async Task<IEnumerable<StateModel?>> GetStateAsync()
        {
            var response = await _commonService.GetStateModelAsync();
            if (!response.IsAny<StateModel>()) return null;

            return response;
        }

        public async Task<IEnumerable<RecordStatusModel?>> GetStatusAsync()
        {
            var response = await _commonService.GetRecordStatusAsync();
            if (!response.IsAny<RecordStatusModel>()) return null;

            return response;
        }

        public async Task<IEnumerable<TermTypeModel?>> GetTermTypeAsync()
        {
            var response = await _commonService.GetTermTypeAsync();
            if (!response.IsAny<TermTypeModel>()) return null;

            return response;
        }

        public async Task<IEnumerable<AddressTypeModel>> GetAddressTypeAsync()
        {
            var response = await _commonService.GetAddressTypeAsync();
            if (!response.IsAny<AddressTypeModel>()) return null;

            return response;
        }

        public async Task<IEnumerable<DocumenTypeModel>> GetDocumentypeAsync()
        {
            var response = await _commonService.GetDocumentypeAsync();
            if (!response.IsAny<DocumenTypeModel>()) return null;

            return response;
        }

        public async Task<IEnumerable<InsuredTypeModel>> GetInsuredTypeAsync()
        {
            var response = await _commonService.GetInsuredTypeAsync();
            if (!response.IsAny<InsuredTypeModel>()) return null;

            return response;
        }
    }
}