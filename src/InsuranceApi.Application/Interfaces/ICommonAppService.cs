using InsuranceApi.Core.Entities.Enumerators;
using InsuranceApi.Core.Models;
using InsuranceApi.Service.Client.Models;

namespace InsuranceApi.Application.Interfaces
{
    public interface ICommonAppService
    {
        Task<IEnumerable<PublicBodyModel>> GetPublicBodyAsync();
        Task<IEnumerable<TermTypeModel?>> GetTermTypeAsync();
        Task<ZipCodeModel?> GetZipCodeAsync(string zipCode);
        Task<IEnumerable<StateModel?>> GetStateAsync();
        Task<IEnumerable<RecordStatusModel?>> GetStatusAsync();
        Task<IEnumerable<AddressTypeModel>> GetAddressTypeAsync();
        Task<IEnumerable<DocumentTypeModel>> GetDocumentypeAsync();
        Task<IEnumerable<InsuredTypeModel>> GetInsuredTypeAsync();
        Task<IEnumerable<InsuranceTypeModel>?> GetInsuranceTypeAsync();
        Task<IEnumerable<InsurerModel>?> GetInsurerAsync();
        Task<IEnumerable<ClaimsExperienceBonusModel>?> GetClaimsExperienceBonusAsync();
        Task<IEnumerable<BuildingsContentsModel>?> GetBuildingsContentsAsync(); 
        Task<IEnumerable<PersonTypeModel>?> GetPersonTypeAsync();
        Task<IEnumerable<QuotationStatusModel>?> GetQuotationStatusAsync();
        Task<IEnumerable<ProtectiveDevicesModel>?> GetProtectiveDevicesFireAsync(ProtectiveDevicesTypeEnum protectiveDevicesType);
        Task<IEnumerable<ProtectiveDevicesModel>?> GetProtectiveDevicesTheftAsync(ProtectiveDevicesTypeEnum protectiveDevicesType);
        Task<IEnumerable<GenderModel>?> GetGenderAsync();
        Task<IEnumerable<ProfessionModel>?> GetProfessionAsync(string? name);

    }
}
