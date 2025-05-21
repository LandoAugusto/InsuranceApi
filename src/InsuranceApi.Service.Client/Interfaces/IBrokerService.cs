using InsuranceApi.Service.Client.Models;

namespace InsuranceApi.Service.Client.Interfaces
{
    public interface IBrokerService
    {
        Task<Corretor?> GetByIdAsync(int brokerId);
        Task<IEnumerable<Corretor>?> GetByNameAsync(string name);
        
    }
}
