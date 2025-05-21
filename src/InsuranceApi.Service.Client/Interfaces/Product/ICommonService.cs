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
    }
}
