﻿using Component.Log.Interfaces;
using InsuranceApi.Core.Infrastructure.Configuration;
using InsuranceApi.Core.Infrastructure.Exceptions;
using InsuranceApi.Core.Infrastructure.Http;

using InsuranceApi.Core.Models;
using InsuranceApi.Service.Client.Interfaces.Product;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace InsuranceApi.Service.Client.Services.Product
{
    internal class LaborCourtService(ILogWriter logWriter, IHttpClientFactory httpClientFactory, IOptions<ApiConfig> option) : ILaborCourtService
    {
        private readonly ILogWriter _logWriter = logWriter;
        private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
        private readonly HttpConfig _endpont = option.Value.Configurations.First(x => x.Name.Equals("Product"));


        public async Task<IEnumerable<LaborCourtModel>?> GetAllAsync()
        {
            var rawRequest = new RawRequest();
            var rawResponse = new RawResponse();
            try
            {
                var _httpClient = new RestClient(_httpClientFactory.CreateClient(_endpont.Name));

                rawRequest.RequestUri = $"{_endpont.Url}/v1/LaborCourt/get-all";               
                rawResponse = await _httpClient.GetAsync<RawRequest, RawResponse>(rawRequest.RequestUri, rawRequest);
                var response = JsonConvert.DeserializeObject<BaseDataResponseModel<IEnumerable<LaborCourtModel>>>(rawResponse.Conteudo);
                if (!response.TransactionStatus.Sucess)
                {
                    if (response.TransactionStatus.Code == 404)
                    {
                        return null;
                    }
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

        public async Task<IEnumerable<LaborCourtModel>?> ListAsync(LaborCourtFilterModel filter)
        {
            var rawRequest = new RawRequest();
            var rawResponse = new RawResponse();
            try
            {
                var _httpClient = new RestClient(_httpClientFactory.CreateClient(_endpont.Name));

                rawRequest.RequestUri = $"{_endpont.Url}/v1/LaborCourt/get-search-labor-court";
                rawRequest.BodyObject = new
                {
                    Name = filter.Name,
                    StateId = filter.StateId,
                    StatusId = filter.StatusId
                };
                rawResponse = await _httpClient.PostAsync<RawRequest, RawResponse>(rawRequest.RequestUri, rawRequest);
                var response = JsonConvert.DeserializeObject<BaseDataResponseModel<IEnumerable<LaborCourtModel>>>(rawResponse.Conteudo);
                if (!response.TransactionStatus.Sucess)
                {
                    if (response.TransactionStatus.Code == 404)
                    {
                        return null;
                    }
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
