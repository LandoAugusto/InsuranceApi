using InsuranceApi.Core.Models;

namespace InsuranceApi.Application.Interfaces
{
    public interface IAuthenticationAppService
    {
        Task<TokenModelResponse> GetAsync(string login, string password);
    }
}
