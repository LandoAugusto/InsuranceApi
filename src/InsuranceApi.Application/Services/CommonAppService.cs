using AutoMapper;
using InsuranceApi.Application.Interfaces;
using InsuranceApi.Core.Entities.Enumerators;
using InsuranceApi.Core.Models;
using InsuranceApi.Infra.Data.Interfaces;
using InsuranceApi.Service.Client.Interfaces;
using InsuranceApi.Service.Client.Models;

namespace InsuranceApi.Application.Services
{
    public class CommonAppService(IMapper mapper, IDocumentTypeRepository documentTypeRepository, IInsuredTypeRepository insuredTypeRepository,
        IAddressTypeRepository adrressTypeRepository, IZipCodeClientService zipCodeService) : ICommonAppService
    {

        private readonly IMapper _mapper = mapper;
        private readonly IDocumentTypeRepository _documentTypeRepository = documentTypeRepository;
        private readonly IInsuredTypeRepository _insuredTypeRepository = insuredTypeRepository;
        private readonly IAddressTypeRepository _adrressTypeRepository = adrressTypeRepository;
        private readonly IZipCodeClientService _zipCodeService = zipCodeService;

        public async Task<ZipCodeModel?> GetZipCodeAsync(string zipCode)
        {
            var response = await _zipCodeService.GetAsync(zipCode);
            if (response == null) return null;

            return response;
        }

        public async Task<IEnumerable<AddressTypeModel>?> ListAddressTypeAsync(RecordStatusEnum recordStatusEnum)
        {
            var response = await _adrressTypeRepository.ListAsync(recordStatusEnum);
            if (response == null) return null;

            return _mapper.Map<IEnumerable<AddressTypeModel>>(response);
        }

        public async Task<IEnumerable<DocumentTypeModel>?> ListDocumentTypeAsync(RecordStatusEnum recordStatusEnum)
        {
            var response = await _documentTypeRepository.ListAsync(recordStatusEnum);
            if (response == null) return null;

            return _mapper.Map<IEnumerable<DocumentTypeModel>>(response);
        }

        public async Task<IEnumerable<InsuredTypeModel>?> ListInsuredTypeAsync(RecordStatusEnum recordStatusEnum)
        {
            var response = await _insuredTypeRepository.ListAsync(recordStatusEnum);
            if (response == null) return null;

            return _mapper.Map<IEnumerable<InsuredTypeModel>>(response);
        }
    }
}

