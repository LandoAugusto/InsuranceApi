using Component.Log.Interfaces;
using InsuranceApi.Core.Infrastructure.Configuration;
using InsuranceApi.Service.Client.Interfaces;
using Microsoft.Extensions.Options;

namespace InsuranceApi.Service.Client.Services
{
    internal class CalculationClientService(ILogWriter logWriter, IHttpClientFactory httpClientFactory, IOptions<ApiConfig> option) : ICalculationClientService
    {
        private readonly ILogWriter _logWriter = logWriter;
        private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
        private readonly HttpConfig _endpont = option.Value.Configurations.First(x => x.Name.Equals("Product"));
    }
}
