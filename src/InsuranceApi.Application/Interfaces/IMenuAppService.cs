using InsuranceApi.Core.Models;

namespace InsuranceApi.Application.Interfaces
{
    public  interface IMenuAppService
    {
        Task<ListMenuModel> GetMenuAsync(string roleName);
    }
}
