using InsuranceApi.Core.Models;

namespace InsuranceApi.Service.Client.Interfaces
{
    public interface IAuthenticationService
    {
        Task<string> GetAsync(string login, string password);
        Task<ListMenuModel> GetMenuAsync(string roleName);
    }
}
