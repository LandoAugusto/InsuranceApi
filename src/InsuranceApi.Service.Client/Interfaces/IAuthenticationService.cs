using InsuranceApi.Core.Models;

namespace InsuranceApi.Service.Client.Interfaces
{
    public interface IAuthenticationService
    {        
        Task<string> GetAsync(string login, string password);
        Task<ListMenuModel> GetMenuAsync(string roleName);
        Task<bool> SaveMenuRoleAsync(SaveMenuRoleModel request);
        Task<IEnumerable<MenuModel>> GetMenuAllAsync();
        Task<IEnumerable<UseModel>?> GetUserAsync(UserFilterModel request);
        Task<UseModel> GetUserByIdAsync(string userId);
        Task<RoleModel> GetRoleByIdAsync(int roleId);
        Task<IEnumerable<RoleModel>?> GetRoleAsync(int? id, string? name);
        Task<string> SaveRoleAsync(SaveRoleModel request);
        Task<bool> UpdateUserPasswordAsync(UpdatePasswordUserModel request);
        Task<int> SaveUserAsync(SaveUserModel request);
        Task<bool> UpdateUserAsync(UpdateUserModel request);
    }
}
