using InsuranceApi.Application.Extensions;
using InsuranceApi.Infra.Data.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InsuranceApi.Infra.IoC.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static void AddIoC(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAppServices();
            services.AddInfraData(configuration);            
        }
    }
}
