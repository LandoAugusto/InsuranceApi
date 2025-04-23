using InsuranceApi.Service.Client.Interfaces;
using InsuranceApi.Service.Client.Services;
using Microsoft.Extensions.DependencyInjection;

namespace InsuranceApi.Service.Client.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddServiceClient(this IServiceCollection services)
        {
            services.AddScoped<IZipCodeClientService, ZipCodeClientService>();
            services.AddScoped<ITakerClientService, TakerClientService>();
            services.AddScoped<IBrokerClientService, BrokerClientService>();

            return services;
        }
    }
}
