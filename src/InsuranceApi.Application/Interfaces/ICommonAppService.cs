using InsuranceApi.Core.Entities;
using InsuranceApi.Core.Entities.Enumerators;
using InsuranceApi.Core.Models;
using InsuranceApi.Service.Client.Models;

namespace InsuranceApi.Application.Interfaces
{
    public interface ICommonAppService
    {
        Task<ZipCodeModel?> GetZipCodeAsync(string zipCode);
        Task<IEnumerable<AddressTypeModel>?> ListAddressTypeAsync(RecordStatusEnum recordStatusEnum);
        Task<IEnumerable<InsuredTypeModel>?> ListInsuredTypeAsync(RecordStatusEnum recordStatusEnum);
        Task<IEnumerable<DocumentTypeModel>?> ListDocumentTypeAsync(RecordStatusEnum recordStatusEnum);
    }
}
