using InsuranceApi.Core.Entities.Enumerators;
using InsuranceApi.Core.Models;

namespace InsuranceApi.Application.Interfaces
{
    public interface IBorrowerAppService
    {
        Task<IEnumerable<BorrowerModel>?> ListAsync(int brokerId, string? name);
        Task<IEnumerable<BorrowerModel>?> ListAsync(int? brokerId, string name, RecordStatusEnum recordStatus);
    }
}
