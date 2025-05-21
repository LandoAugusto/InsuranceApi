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
    }
}
