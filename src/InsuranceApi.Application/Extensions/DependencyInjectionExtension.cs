using InsuranceApi.Application.Interfaces;
using InsuranceApi.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace InsuranceApi.Application.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static void AddAppServices(this IServiceCollection services)
        {             
            services.AddScoped<IQuotationAppService, QuotationAppService>();
            services.AddScoped<IFlexRateAppService, FlexRateAppService>();
        }
    }
}
