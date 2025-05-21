using Component.Log.Interfaces;
using InsuranceApi.Core.Infrastructure.Configuration;
using InsuranceApi.Service.Client.Interfaces.Product;
using Microsoft.Extensions.Options;

namespace InsuranceApi.Service.Client.Services.Product
{
    internal class ProductVersionService(ILogWriter logWriter, IHttpClientFactory httpClientFactory, IOptions<ApiConfig> option) :IProductVersionService
    {
        private readonly ILogWriter _logWriter = logWriter;
        private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
        private readonly HttpConfig _endpont = option.Value.Configurations.First(x => x.Name.Equals("Product"));
    }
}
