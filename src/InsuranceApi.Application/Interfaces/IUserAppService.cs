using InsuranceApi.Core.Models;

namespace InsuranceApi.Application.Interfaces
{
    public interface IUserAppService
    {
        Task<IEnumerable<UseModel>?> GetUserAsync(string? id, string? login, string? email);
        Task<UseModel> GetUserByIdAsync(string userId);
        Task<RoleModel> GetRoleByIdAsync(int roleId);
        Task<IEnumerable<RoleModel>?> GetRolesAsync(int? roleId, string? name);
        Task<string> SaveRoleAsync(SaveRoleModel request);
         Task<int> SaveUsersync(SaveUserModel request);
        Task<bool> UpdateUserAsync(UpdateUserModel request);
        Task<bool> UpdateUserPasswordAsync(UpdatePasswordUserModel request);
    }
}
