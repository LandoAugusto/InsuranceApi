using InsuranceApi.Service.Client.Models;

namespace InsuranceApi.Application.Interfaces
{
    public interface ICommonAppService
    {
        Task<ZipCodeModel?> GetZipCodeAsync(string zipCode);        
    }
}
