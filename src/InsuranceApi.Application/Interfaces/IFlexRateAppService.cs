using InsuranceApi.Core.Entities.Enumerators;
using InsuranceApi.Core.Models;

namespace InsuranceApi.Application.Interfaces
{
    public interface IFlexRateAppService
    {
        Task<FlexRateModel?> GetAsync(int flexRateId);
        Task<IEnumerable<FlexRateModel?>> ListAsync(FlexRateMixFilterModel request);
        Task<SimulationModel> SimulationMixAsync(SimulationFilterModel simulation);
    }
}
