using AutoMapper;
using InsuranceApi.Application.Interfaces;
using InsuranceApi.Service.Client.Interfaces;
using InsuranceApi.Service.Client.Models;

namespace InsuranceApi.Application.Services
{
    public class CommonAppService(IMapper mapper, IZipCodeClientService zipCodeService) : ICommonAppService
    {

        private readonly IMapper _mapper = mapper;
        private readonly IZipCodeClientService _zipCodeService = zipCodeService;

        public async Task<ZipCodeModel?> GetZipCodeAsync(string zipCode)
        {
            var response = await _zipCodeService.GetAsync(zipCode);
            if (response == null) return null;

            return response;
        }
    }
}

