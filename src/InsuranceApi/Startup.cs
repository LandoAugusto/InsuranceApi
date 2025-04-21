using Component.LogExtensions;
using InsuranceApi.Extensions;
using InsuranceApi.Infra.IoC;
using InsuranceApi.Infra.IoC.Extensions;

namespace InsuranceApi
{ /// <summary>
  /// 
  /// </summary>
  /// <param name="configuration"></param>
    public class Startup(IConfiguration configuration)
    {

        public readonly IConfiguration Configuration = configuration;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddLog(Configuration);
            services.UseApi(Configuration);
            services.AddIoC(Configuration);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
            }

            app.UseLog();
            app.UseApi(Configuration);
        }
    }
}
