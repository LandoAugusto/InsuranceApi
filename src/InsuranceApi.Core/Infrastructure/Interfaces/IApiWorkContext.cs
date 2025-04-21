using InsuranceApi.Core.Infrastructure.Configuration;

namespace InsuranceApi.Core.Infrastructure.Interfaces
{
    public interface IApiWorkContext
    {
        BaseHeader BaseHeader { get; set; }
    }
}
