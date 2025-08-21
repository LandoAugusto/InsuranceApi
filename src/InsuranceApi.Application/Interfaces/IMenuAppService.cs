using InsuranceApi.Core.Models;

namespace InsuranceApi.Application.Interfaces
{
    public  interface IMenuAppService
    {
        Task<ListMenuModel> GetMenuAsync(string roleName);
        Task<IEnumerable<MenuModel>> GetMenuAllAsync();
        Task<bool> SaveMenuRoleAsync(SaveMenuRoleModel request);
    }
}
