using InsuranceApi.Core.Models;

namespace InsuranceApi.Service.Client.Interfaces.Product
{
    public interface ICommonService
    {
        Task<IEnumerable<TermTypeModel>?> GetTermTypeAsync();
        Task<IEnumerable<StateModel>?> GetStateModelAsync();
        Task<IEnumerable<RecordStatusModel>?> GetRecordStatusAsync();
        Task<IEnumerable<AddressTypeModel>?> GetAddressTypeAsync();
        Task<IEnumerable<DocumenTypeModel>?> GetDocumentypeAsync();
        Task<IEnumerable<InsuredTypeModel>?> GetInsuredTypeAsync();
        Task<IEnumerable<InsuranceTypeModel>?> GetInsuranceTypeAsync();
        Task<IEnumerable<InsurerModel>?> GetInsurerAsync();
        Task<IEnumerable<ClaimsExperienceBonusModel>?> GetClaimsExperienceBonusAsync();
        Task<IEnumerable<BuildingsContentsModel>?> GetBuildingsContentsAsync();
        Task<IEnumerable<PropertyStructureModel>?> GetPropertyStructureAsync(int useTypeId);
        Task<IEnumerable<UseTypeModel>?> GetUseTypeAsync(int constructionTypeId, int profileId);
    }
}
