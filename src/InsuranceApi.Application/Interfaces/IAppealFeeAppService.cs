using InsuranceApi.Core.Models;

namespace InsuranceApi.Application.Interfaces
{
    public interface IAppealFeeAppService
    {
        Task<FlexRateModel?> GetAsync(int appealFeeId);
        Task<IEnumerable<AppealFeeModel?>> ListAsync(AppealFeeFilterModel request);
    }
}
