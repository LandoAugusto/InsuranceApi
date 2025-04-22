using InsuranceApi.Core.Entities.Enumerators;
using InsuranceApi.Core.Models;

namespace InsuranceApi.Application.Interfaces
{
    public interface IBrokerAppService
    {
        Task<BrokerModel?> GetAsync(int? brokerId, RecordStatusEnum recordStatus);
    }
}
