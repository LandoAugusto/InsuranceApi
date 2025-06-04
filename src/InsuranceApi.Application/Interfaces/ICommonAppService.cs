using InsuranceApi.Core.Entities.Enumerators;
using InsuranceApi.Core.Models;
using InsuranceApi.Service.Client.Models;

namespace InsuranceApi.Application.Interfaces
{
    public interface ICommonAppService
    {
        Task<IEnumerable<TermTypeModel?>> GetTermTypeAsync();
        Task<ZipCodeModel?> GetZipCodeAsync(string zipCode);
        Task<IEnumerable<StateModel?>> GetStateAsync();
        Task<IEnumerable<RecordStatusModel?>> GetStatusAsync();
        Task<IEnumerable<AddressTypeModel>> GetAddressTypeAsync();
        Task<IEnumerable<DocumenTypeModel>> GetDocumentypeAsync();
        Task<IEnumerable<InsuredTypeModel>> GetInsuredTypeAsync();
        Task<IEnumerable<InsuranceTypeModel>?> GetInsuranceTypeAsync();
        Task<IEnumerable<InsurerModel>?> GetInsurerAsync();
        Task<IEnumerable<ClaimsExperienceBonusModel>?> GetClaimsExperienceBonusAsync();
        Task<IEnumerable<BuildingsContentsModel>?> GetBuildingsContentsAsync();
        Task<IEnumerable<PropertyStructureModel>?> GetPropertyStructureAsync(int constructionTypeId, int useTypeId, int profileId);
        Task<IEnumerable<UseTypeModel>?> GetUseTypeAsync(int constructionTypeId, int profileId);
        Task<IEnumerable<PersonTypeModel>?> GetPersonTypeAsync();
        Task<IEnumerable<QuotationStatusModel>?> GetQuotationStatusAsync();
        Task<IEnumerable<ProtectiveDevicesModel>?> GetProtectiveDevicesFireAsync(ProtectiveDevicesTypeEnum protectiveDevicesType);

        Task<IEnumerable<ProtectiveDevicesModel>?> GetProtectiveDevicesTheftAsync(ProtectiveDevicesTypeEnum protectiveDevicesType);

    }
}
