using InsuranceApi.Core.Entities.Enumerators;
using InsuranceApi.Core.Models;

namespace InsuranceApi.Service.Client.Interfaces.Product
{
    public interface ICommonService
    {
        Task<IEnumerable<TermTypeModel>?> GetTermTypeAsync();
        Task<IEnumerable<StateModel>?> GetStateModelAsync();
        Task<IEnumerable<RecordStatusModel>?> GetRecordStatusAsync();
        Task<IEnumerable<AddressTypeModel>?> GetAddressTypeAsync();
        Task<IEnumerable<DocumentTypeModel>?> GetDocumentypeAsync();
        Task<IEnumerable<InsuredTypeModel>?> GetInsuredTypeAsync();
        Task<IEnumerable<InsuranceTypeModel>?> GetInsuranceTypeAsync();
        Task<IEnumerable<InsurerModel>?> GetInsurerAsync();
        Task<IEnumerable<ClaimsExperienceBonusModel>?> GetClaimsExperienceBonusAsync();
        Task<IEnumerable<BuildingsContentsModel>?> GetBuildingsContentsAsync();
        Task<IEnumerable<PropertyStructureModel>?> GetPropertyStructureAsync(int constructionTypeId, int useTypeId, int profileId);
        Task<IEnumerable<UseTypeModel>?> GetUseTypeAsync(int constructionTypeId, int profileId);
        Task<IEnumerable<PersonTypeModel>?> GetPersonTypeAsync();
        Task<IEnumerable<QuotationStatusModel>?> GetQuotationStatusAsync();
        Task<IEnumerable<ProtectiveDevicesModel>?> GetProtectiveDevicesAsync(ProtectiveDevicesTypeEnum protectiveDevicesType);
    }
}
