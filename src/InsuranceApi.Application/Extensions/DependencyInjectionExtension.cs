﻿using InsuranceApi.Application.Interfaces;
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
            services.AddScoped<IProductComponetAppService, ProductComponetAppService>();
            services.AddScoped<ILaborCourtService, LaborCourtService>();
            services.AddScoped<ICivilCourtService, CivilCourtService>();
            services.AddScoped<ILegalRecourseTypeService, LegalRecourseTypeService>();
        }
    }
}
