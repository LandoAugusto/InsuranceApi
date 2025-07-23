using InsuranceApi.Core.Entities.Enumerators;
using InsuranceApi.Core.Models;

namespace InsuranceApi.Service.Client.Interfaces.Product
{
    public interface ICommonService
    {
        Task<IEnumerable<TermTypeModel>?> GetTermTypeAsync();
        Task<IEnumerable<StateModel>?> GetStateAsync(string? stateId = null);
        Task<IEnumerable<RecordStatusModel>?> GetRecordStatusAsync();
        Task<IEnumerable<AddressTypeModel>?> GetAddressTypeAsync();
        Task<IEnumerable<DocumentTypeModel>?> GetDocumentypeAsync();
        Task<IEnumerable<InsuredTypeModel>?> GetInsuredTypeAsync();
        Task<IEnumerable<InsuranceTypeModel>?> GetInsuranceTypeAsync();
        Task<IEnumerable<InsurerModel>?> GetInsurerAsync();
        Task<IEnumerable<ClaimsExperienceBonusModel>?> GetClaimsExperienceBonusAsync();
        Task<IEnumerable<BuildingsContentsModel>?> GetBuildingsContentsAsync();     
        Task<IEnumerable<PersonTypeModel>?> GetPersonTypeAsync();
        Task<IEnumerable<QuotationStatusModel>?> GetQuotationStatusAsync();
        Task<IEnumerable<ProtectiveDevicesModel>?> GetProtectiveDevicesAsync(ProtectiveDevicesTypeEnum protectiveDevicesType);
        Task<IEnumerable<GenderModel>?> GetGenderAsync();
        Task<IEnumerable<ProfessionModel>?> GetProfessionAsync(string? name);
    }
}
