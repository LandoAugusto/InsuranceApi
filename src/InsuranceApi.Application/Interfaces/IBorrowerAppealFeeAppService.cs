using InsuranceApi.Core.Models;

namespace InsuranceApi.Application.Interfaces
{
    public interface IBorrowerAppealFeeAppService
    {
        Task<BorrowerAppealFeeModel?> GetAsync(int appealFeeId);
        Task<IEnumerable<BorrowerAppealFeeModel>?> ListAsync(BorrowerAppealFeeFilterModel request);
    }
}
