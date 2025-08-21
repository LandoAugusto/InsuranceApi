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
            services.AddScoped<IQuotationWarrantyAppService, QuotationWarrantyAppService>();
            services.AddScoped<IFlexRateAppService, FlexRateAppService>();
            services.AddScoped<IBrokerAppService, BrokerAppService>();
            services.AddScoped<IBorrowerAppService, BorrowerAppService>();
            services.AddScoped<ICommonAppService, CommonAppService>();
            services.AddScoped<IAuthenticationAppService, AuthenticationAppService>();            
            services.AddScoped<ILaborCourtAppService, LaborCourtAppService>();
            services.AddScoped<ICivilCourtAppService, CivilCourtAppService>();
            services.AddScoped<IMenuAppService, MenuAppService>();
            services.AddScoped<IProductAppService, ProductAppService>();
            services.AddScoped<IProductVersionAppService, ProductVersionAppService>();
            services.AddScoped<ILegalRecourseTypeAppService, LegalRecourseTypeAppService>();
            services.AddScoped<IProductComponentScreenAppService, ProductComponentScreenAppService>();
            services.AddScoped<IVehicleAppService, VehicleAppService>();
            services.AddScoped<IPersonAppService, PersonAppService>();
            services.AddScoped<IBorrowerAppealFeeAppService, BorrowerAppealFeeAppService>();
            services.AddScoped<IAppealFeeAppService, AppealFeeAppService>();
        }
    }
}
