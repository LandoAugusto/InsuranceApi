using AutoMapper;
using InsuranceApi.Application.Interfaces;
using InsuranceApi.Service.Client.Interfaces;
using InsuranceApi.Service.Client.Models;

namespace InsuranceApi.Application.Services
{
    public class CommonAppService(IMapper mapper, IZipCodeClientService zipCodeService) : ICommonAppService
    {

        public readonly IMapper _mapper = mapper;
        public readonly IZipCodeClientService _zipCodeService = zipCodeService;

        public async Task<ZipCodeModel> GetZipCodeAsync(string zipCode)
        {
            var response = await _zipCodeService.GetAsync(zipCode);
            if (response == null) return null;

            return response;
        }

        public async Task<IEnumerable<AddressTypeModel>> GetAddressTypeAsync()
        {
            var response = new List<AddressTypeModel>() {

                new()
                {
                    AddressTypeId = 1,
                    Name ="Residencial"

                },
                new(){

                    AddressTypeId = 2,
                    Name ="Comercial"
                },
                  new(){

                    AddressTypeId = 3,
                    Name ="Correspondência"
                }
            };


            return response;
        }

        public async Task<IEnumerable<DocumenTypeModel>> GetDocumentypeAsync()
        {
            var response = new List<DocumenTypeModel>() {

                new()
                {
                    DocumenTypeId = 1,
                    Name ="CPF"

                },
                new(){

                    DocumenTypeId = 2,
                    Name ="CNPJ"
                }
            };


            return response;
        }
    }
}

