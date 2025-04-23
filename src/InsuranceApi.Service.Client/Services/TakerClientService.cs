using Component.Log.Interfaces;
using InsuranceApi.Core.Infrastructure.Configuration;
using InsuranceApi.Core.Infrastructure.Exceptions;
using InsuranceApi.Core.Infrastructure.Http;
using InsuranceApi.Service.Client.Interfaces;
using InsuranceApi.Service.Client.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using static InsuranceApi.Service.Client.Models.TakerResponseModel;

namespace InsuranceApi.Service.Client.Services
{
    /// <summary>
    /// 
    /// </summary>
    internal class TakerClientService(ILogWriter logWriter, IHttpClientFactory httpClientFactory, IOptions<ApiConfig> option) : ITakerClientService
    {

        private readonly ILogWriter _logWriter = logWriter;
        private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
        private readonly HttpConfig _endpont = option.Value.Configurations.First(x => x.Name.Equals("InsuranceApiMockApi"));

        public async Task<IEnumerable<RetornoTomadorDetalheListaDTO>?> ListAsync(int brokerId, string? name)
        {
            var rawRequest = new RawRequest();
            var rawResponse = new RawResponse();

            try
            {
                var _httpClient = new RestClient(_httpClientFactory.CreateClient(_endpont.Name));

                rawRequest.RequestUri = $"{_endpont.Url}/lista-tomador";
                rawRequest.BodyObject = new
                {
                    id_corretor = brokerId,
                    nm_tomador = name
                };

                rawResponse = await _httpClient.PostAsync<RawRequest, RawResponse>(rawRequest.RequestUri, rawRequest);
                var response = JsonConvert.DeserializeObject<TakerResponseModel>(rawResponse.Conteudo);
                if (response?.cd_retorno > 0 && response.cd_retorno != 130001884)
                {
                    throw new BusinessException(response.nm_retorno);
                }


                return response?.ListaTomadorTable1;
            }
            catch (Exception exception)
            {
                _logWriter.Error(message: exception.Message);

                if (exception is BusinessException ex)
                {
                    throw ex;
                }

                throw new ServiceUnavailableException($"Erro na chamada do serviço '{rawRequest.RequestUri}': {exception.Message}", exception);
            }
        }
    }
}
