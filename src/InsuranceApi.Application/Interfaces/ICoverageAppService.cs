using InsuranceApi.Core.Models;

namespace InsuranceApi.Application.Interfaces
{
    public interface ICoverageAppService
    {
       Task<CoverageActivityLimitModel> GetCoverageLimitActivityAsync(CoverageActivityLimitFilterModel request);
    }
}
