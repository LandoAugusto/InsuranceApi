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
        Task<IEnumerable<PropertyStructureModel>?> GetPropertyStructureAsync(int useTypeId);
        Task<IEnumerable<UseTypeModel>?> GetUseTypeAsync(int constructionTypeId, int profileId);
        Task<IEnumerable<PersonTypeModel>?> GetPersonTypeAsync();

    }
}
