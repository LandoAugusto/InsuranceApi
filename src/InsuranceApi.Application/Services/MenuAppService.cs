using InsuranceApi.Application.Interfaces;
using InsuranceApi.Core.Models;
using InsuranceApi.Service.Client.Interfaces;

namespace InsuranceApi.Application.Services
{
    internal class MenuAppService(IAuthenticationService authenticationService) 
        : IMenuAppService
    {
        private readonly IAuthenticationService _authenticationService = authenticationService;
        public async Task<ListMenuModel> GetMenuAsync(string roleName)
        {
            return await _authenticationService.GetMenuAsync(roleName);
        }

        public async Task<IEnumerable<MenuModel>> GetMenuAllAsync()
        {
            return await _authenticationService.GetMenuAllAsync();
        }
        public async Task<bool> SaveMenuRoleAsync(SaveMenuRoleModel request)
        {
            return await _authenticationService.SaveMenuRoleAsync(request);
        }
    }
}
