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
            services.AddScoped<IBorrowerClientService, BorrowerClientService>();
            services.AddScoped<IBrokerClientService, BrokerClientService>();
            services.AddScoped<IProductClientService, ProductClientService>();
            services.AddScoped<ICalculationClientService, CalculationClientService>();
            services.AddScoped<IAuthenticationClientService, AuthenticationClientService>();

            return services;
        }
    }
}
