using InsuranceApi.Service.Client.Models;

namespace InsuranceApi.Service.Client.Interfaces
{
    public interface IZipCodeService
    {
        Task<ZipCodeModel> GetAsync(string zipcode);
    }
}
