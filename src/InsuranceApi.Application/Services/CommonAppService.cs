﻿using InsuranceApi.Application.Interfaces;
using InsuranceApi.Core.Entities.Enumerators;
using InsuranceApi.Core.Extensions;
using InsuranceApi.Core.Models;
using InsuranceApi.Service.Client.Interfaces;
using InsuranceApi.Service.Client.Interfaces.Product;
using InsuranceApi.Service.Client.Models;

namespace InsuranceApi.Application.Services
{
    public class CommonAppService(IZipCodeService zipCodeService, ICommonService commonService)
        : ICommonAppService
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

        public async Task<IEnumerable<InsuranceTypeModel>?> GetInsuranceTypeAsync()
        {
            var response = await _commonService.GetInsuranceTypeAsync();
            if (!response.IsAny<InsuranceTypeModel>()) return null;

            return response;
        }

        public async Task<IEnumerable<InsurerModel>?> GetInsurerAsync()
        {
            var response = await _commonService.GetInsurerAsync();
            if (!response.IsAny<InsurerModel>()) return null;

            return response;
        }

        public async Task<IEnumerable<ClaimsExperienceBonusModel>?> GetClaimsExperienceBonusAsync()
        {
            var response = await _commonService.GetClaimsExperienceBonusAsync();
            if (!response.IsAny<ClaimsExperienceBonusModel>()) return null;

            return response;
        }

        public async Task<IEnumerable<BuildingsContentsModel>?> GetBuildingsContentsAsync()
        {
            var response = await _commonService.GetBuildingsContentsAsync();
            if (!response.IsAny<BuildingsContentsModel>()) return null;

            return response;
        }

        public async Task<IEnumerable<PropertyStructureModel>?> GetPropertyStructureAsync(int constructionTypeId, int useTypeId, int profileId)
        {
            var response = await _commonService.GetPropertyStructureAsync(constructionTypeId, useTypeId, profileId);
            if (!response.IsAny<PropertyStructureModel>()) return null;

            return response;
        }

        public async Task<IEnumerable<UseTypeModel>?> GetUseTypeAsync(int constructionTypeId, int profileId)
        {
            var response = await _commonService.GetUseTypeAsync(constructionTypeId, profileId);
            if (!response.IsAny<UseTypeModel>()) return null;

            return response;
        }

        public async Task<IEnumerable<PersonTypeModel>?> GetPersonTypeAsync()
        {
            var response = await _commonService.GetPersonTypeAsync();
            if (!response.IsAny<PersonTypeModel>()) return null;

            return response;
        }

        public async Task<IEnumerable<QuotationStatusModel>?> GetQuotationStatusAsync()
        {
            var response = await _commonService.GetQuotationStatusAsync();
            if (!response.IsAny<QuotationStatusModel>()) return null;

            return response;
        }

        public async Task<IEnumerable<ProtectiveDevicesModel>?> GetProtectiveDevicesFireAsync(ProtectiveDevicesTypeEnum protectiveDevicesType)
        {
            var response = await _commonService.GetProtectiveDevicesAsync(protectiveDevicesType);
            if (!response.IsAny<ProtectiveDevicesModel>()) return null;

            return response;
        }

        public async Task<IEnumerable<ProtectiveDevicesModel>?> GetProtectiveDevicesTheftAsync(ProtectiveDevicesTypeEnum protectiveDevicesType)
        {
            var response = await _commonService.GetProtectiveDevicesAsync(protectiveDevicesType);
            if (!response.IsAny<ProtectiveDevicesModel>()) return null;

            return response;
        }
    }
}