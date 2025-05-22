using InsuranceApi.Service.Client.Interfaces;
using InsuranceApi.Service.Client.Interfaces.Product;
using InsuranceApi.Service.Client.Services;
using InsuranceApi.Service.Client.Services.Product;
using Microsoft.Extensions.DependencyInjection;

namespace InsuranceApi.Service.Client.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddServiceClient(this IServiceCollection services)
        {
            services.AddScoped<IZipCodeService, ZipCodeService>();
            services.AddScoped<IBorrowerClientService, BorrowerService>();
            services.AddScoped<IBrokerService, BrokerService>();

            services.AddScoped<ICalculationService, CalculationService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductVersionService, ProductVersionService>();
            services.AddScoped<ICommonService, CommonService>();
            services.AddScoped<ILegalRecourseTypeService, LegalRecourseTypeService>();
            services.AddScoped<ILaborCourtService, LaborCourtService>();
            services.AddScoped<ICivilCourtService, CivilCourtService>();

            return services;
        }
    }
}
