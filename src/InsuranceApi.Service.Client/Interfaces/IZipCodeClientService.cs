using InsuranceApi.Service.Client.Models;

namespace InsuranceApi.Service.Client.Interfaces
{
    public interface IZipCodeClientService
    {
        Task<ZipCodeResponseModel> GetAsync(string zipcode);
    }
}
