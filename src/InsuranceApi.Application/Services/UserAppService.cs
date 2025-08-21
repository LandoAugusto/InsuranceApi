using InsuranceApi.Application.Interfaces;
using InsuranceApi.Core.Models;

namespace InsuranceApi.Application.Services
{
    public class UserAppService(Service.Client.Interfaces.IAuthenticationService authenticationService)
        : IUserAppService
    {
        private readonly Service.Client.Interfaces.IAuthenticationService _authenticationService = authenticationService;

        public async Task<IEnumerable<UseModel>?> GetUserAsync(string? id, string? login, string? email)
        {
            return await _authenticationService.GetUserAsync(new UserFilterModel()
            {
                Id = id,
                Login = login,
                Email = email
            });
        }

        public async Task<UseModel> GetUserByIdAsync(string userId)
        {
            return await _authenticationService.GetUserByIdAsync(userId);
        }

        public async Task<RoleModel> GetRoleByIdAsync(int roleId)
        {
            return await _authenticationService.GetRoleByIdAsync(roleId);
        }
        public async Task<IEnumerable<RoleModel>?> GetRolesAsync(int? roleId, string? name)
        {
            return await _authenticationService.GetRoleAsync(roleId, name);
        }

        public async Task<string> SaveRoleAsync(SaveRoleModel request)
        {
            return await _authenticationService.SaveRoleAsync(request);
        }

        public async Task<int> SaveUsersync(SaveUserModel request)
        {
            return await _authenticationService.SaveUserAsync(request);
        }

        public async Task<bool> UpdateUserAsync(UpdateUserModel request)
        {
            return await _authenticationService.UpdateUserAsync(request);
        }
        public async Task<bool> UpdateUserPasswordAsync(UpdatePasswordUserModel request)
        {
            return await _authenticationService.UpdateUserPasswordAsync(request);
        }
    }
}
