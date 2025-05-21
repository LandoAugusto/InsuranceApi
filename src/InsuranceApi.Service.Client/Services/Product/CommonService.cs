using Component.Log.Interfaces;
using InsuranceApi.Core.Infrastructure.Configuration;
using InsuranceApi.Core.Infrastructure.Exceptions;
using InsuranceApi.Core.Infrastructure.Http;
using InsuranceApi.Core.Model;
using InsuranceApi.Core.Models;
using InsuranceApi.Service.Client.Interfaces.Product;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace InsuranceApi.Service.Client.Services.Product
{
    internal class CommonService(ILogWriter logWriter, IHttpClientFactory httpClientFactory, IOptions<ApiConfig> option) : ICommonService
    {
        private readonly ILogWriter _logWriter = logWriter;
        private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
        private readonly HttpConfig _endpont = option.Value.Configurations.First(x => x.Name.Equals("Product"));

        public async Task<IEnumerable<StateModel>?> GetStateModelAsync()
        {
            var rawRequest = new RawRequest();
            var rawResponse = new RawResponse();
            try
            {
                var _httpClient = new RestClient(_httpClientFactory.CreateClient(_endpont.Name));

                rawRequest.RequestUri = $"{_endpont.Url}/v1/common/get-state";
                rawResponse = await _httpClient.GetAsync<RawRequest, RawResponse>(rawRequest.RequestUri, rawRequest);
                var response = JsonConvert.DeserializeObject<BaseDataResponseModel<IEnumerable<StateModel>>>(rawResponse.Conteudo);
                if (!response.TransactionStatus.Sucess)
                {
                    throw new BusinessException(response.TransactionStatus.Message);
                }
                return response.Data;
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
        public async Task<IEnumerable<RecordStatusModel>?> GetRecordStatusAsync()
        {
            var rawRequest = new RawRequest();
            var rawResponse = new RawResponse();
            try
            {
                var _httpClient = new RestClient(_httpClientFactory.CreateClient(_endpont.Name));

                rawRequest.RequestUri = $"{_endpont.Url}/v1/common/get-record-status";
                rawResponse = await _httpClient.GetAsync<RawRequest, RawResponse>(rawRequest.RequestUri, rawRequest);
                var response = JsonConvert.DeserializeObject<BaseDataResponseModel<IEnumerable<RecordStatusModel>>>(rawResponse.Conteudo);
                if (!response.TransactionStatus.Sucess)
                {
                    throw new BusinessException(response.TransactionStatus.Message);
                }
                return response.Data;
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
        public async Task<IEnumerable<TermTypeModel>?> GetTermTypeAsync()
        {
            var rawRequest = new RawRequest();
            var rawResponse = new RawResponse();
            try
            {
                var _httpClient = new RestClient(_httpClientFactory.CreateClient(_endpont.Name));

                rawRequest.RequestUri = $"{_endpont.Url}/v1/common/get-term-type";
                rawResponse = await _httpClient.GetAsync<RawRequest, RawResponse>(rawRequest.RequestUri, rawRequest);
                var response = JsonConvert.DeserializeObject<BaseDataResponseModel<IEnumerable<TermTypeModel>>>(rawResponse.Conteudo);
                if (!response.TransactionStatus.Sucess)
                {
                    throw new BusinessException(response.TransactionStatus.Message);
                }
                return response.Data;
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
        public async Task<IEnumerable<AddressTypeModel>?> GetAddressTypeAsync()
        {
            var rawRequest = new RawRequest();
            var rawResponse = new RawResponse();
            try
            {
                var _httpClient = new RestClient(_httpClientFactory.CreateClient(_endpont.Name));

                rawRequest.RequestUri = $"{_endpont.Url}/v1/common/get-term-type";
                rawResponse = await _httpClient.GetAsync<RawRequest, RawResponse>(rawRequest.RequestUri, rawRequest);
                var response = JsonConvert.DeserializeObject<BaseDataResponseModel<IEnumerable<AddressTypeModel>?>>(rawResponse.Conteudo);
                if (!response.TransactionStatus.Sucess)
                {
                    throw new BusinessException(response.TransactionStatus.Message);
                }
                return response.Data;
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
        public async Task<IEnumerable<DocumenTypeModel>?> GetDocumentypeAsync()
        {
            var rawRequest = new RawRequest();
            var rawResponse = new RawResponse();
            try
            {
                var _httpClient = new RestClient(_httpClientFactory.CreateClient(_endpont.Name));

                rawRequest.RequestUri = $"{_endpont.Url}/v1/common/get-term-type";
                rawResponse = await _httpClient.GetAsync<RawRequest, RawResponse>(rawRequest.RequestUri, rawRequest);
                var response = JsonConvert.DeserializeObject<BaseDataResponseModel<IEnumerable<DocumenTypeModel>?>>(rawResponse.Conteudo);
                if (!response.TransactionStatus.Sucess)
                {
                    throw new BusinessException(response.TransactionStatus.Message);
                }
                return response.Data;
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
        public async Task<IEnumerable<InsuredTypeModel>?> GetInsuredTypeAsync()
        {
            var rawRequest = new RawRequest();
            var rawResponse = new RawResponse();
            try
            {
                var _httpClient = new RestClient(_httpClientFactory.CreateClient(_endpont.Name));

                rawRequest.RequestUri = $"{_endpont.Url}/v1/common/get-term-type";
                rawResponse = await _httpClient.GetAsync<RawRequest, RawResponse>(rawRequest.RequestUri, rawRequest);
                var response = JsonConvert.DeserializeObject<BaseDataResponseModel<IEnumerable<InsuredTypeModel>?>>(rawResponse.Conteudo);
                if (!response.TransactionStatus.Sucess)
                {
                    throw new BusinessException(response.TransactionStatus.Message);
                }
                return response.Data;
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

