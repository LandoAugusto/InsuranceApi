using InsuranceApi.Infra.Data.Contexts;
using InsuranceApi.Infra.Data.Interfaces;
using InsuranceApi.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InsuranceApi.Infra.Data.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfraData(this IServiceCollection services, IConfiguration configuration) =>
        services
        .AddDbContext<InsuranceDbContext>(
            options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Scoped
        )
        .AddRepositories();

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IQuotationRepository, QuotationRepository>();           

            return services;
        }
    }
}
