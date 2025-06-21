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
    internal class ProductVersionService(ILogWriter logWriter, IHttpClientFactory httpClientFactory, IOptions<ApiConfig> option)
        : IProductVersionService
    {
        private readonly ILogWriter _logWriter = logWriter;
        private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
        private readonly HttpConfig _endpont = option.Value.Configurations.First(x => x.Name.Equals("Product"));

        public async Task<ProductVersionModel?> GetAsync(int productId)
        {
            var rawRequest = new RawRequest();
            var rawResponse = new RawResponse();
            try
            {
                var _httpClient = new RestClient(_httpClientFactory.CreateClient(_endpont.Name));

                rawRequest.RequestUri = $"{_endpont.Url}/v1/ProductVersion/get-product-version/{productId}";
                rawResponse = await _httpClient.GetAsync<RawRequest, RawResponse>(rawRequest.RequestUri, rawRequest);
                var response = JsonConvert.DeserializeObject<BaseDataResponseModel<ProductVersionModel>>(rawResponse.Conteudo);
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

        public async Task<ProductVersionAcceptanceModel?> GetAcceptanceAsync(int productVersionId, int profileId)
        {
            var rawRequest = new RawRequest();
            var rawResponse = new RawResponse();
            try
            {
                var _httpClient = new RestClient(_httpClientFactory.CreateClient(_endpont.Name));

                rawRequest.RequestUri = $"{_endpont.Url}/v1/ProductVersion/get-product-version-acceptance/{productVersionId}/{profileId}";
                rawResponse = await _httpClient.GetAsync<RawRequest, RawResponse>(rawRequest.RequestUri, rawRequest);
                var response = JsonConvert.DeserializeObject<BaseDataResponseModel<ProductVersionAcceptanceModel>>(rawResponse.Conteudo);
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
        public async Task<InsuredObjectModel?> GetInsuredObjectAsync(int productVersionCoverageId)
        {
            var rawRequest = new RawRequest();
            var rawResponse = new RawResponse();
            try
            {
                var _httpClient = new RestClient(_httpClientFactory.CreateClient(_endpont.Name));

                rawRequest.RequestUri = $"{_endpont.Url}/v1/ProductVersion/get-product-version-insured-object/{productVersionCoverageId}";
                rawResponse = await _httpClient.GetAsync<RawRequest, RawResponse>(rawRequest.RequestUri, rawRequest);
                var response = JsonConvert.DeserializeObject<BaseDataResponseModel<InsuredObjectModel>>(rawResponse.Conteudo);
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
        public async Task<CoverageModel?> GetByCoverageIdAsync(int productVersionId, int coverageId)
        {
            var rawRequest = new RawRequest();
            var rawResponse = new RawResponse();
            try
            {
                var _httpClient = new RestClient(_httpClientFactory.CreateClient(_endpont.Name));

                rawRequest.RequestUri = $"{_endpont.Url}/v1/ProductVersion/get-product-version-coverage/{productVersionId}/{coverageId}";
                rawResponse = await _httpClient.GetAsync<RawRequest, RawResponse>(rawRequest.RequestUri, rawRequest);
                var response = JsonConvert.DeserializeObject<BaseDataResponseModel<CoverageModel>>(rawResponse.Conteudo);
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
        public async Task<IEnumerable<CoverageModel?>> ListCoverageAsync(int productVersionId)
        {
            var rawRequest = new RawRequest();
            var rawResponse = new RawResponse();
            try
            {
                var _httpClient = new RestClient(_httpClientFactory.CreateClient(_endpont.Name));

                rawRequest.RequestUri = $"{_endpont.Url}/v1/ProductVersion/get-product-version-coverage/{productVersionId}";
                rawResponse = await _httpClient.GetAsync<RawRequest, RawResponse>(rawRequest.RequestUri, rawRequest);
                var response = JsonConvert.DeserializeObject<BaseDataResponseModel<IEnumerable<CoverageModel?>>>(rawResponse.Conteudo);
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
        public async Task<IEnumerable<ProductVersionClauseModel?>> ListClauseAsync(int productVersionId, decimal insuredAmountValue)
        {
            var rawRequest = new RawRequest();
            var rawResponse = new RawResponse();
            try
            {
                var _httpClient = new RestClient(_httpClientFactory.CreateClient(_endpont.Name));

                rawRequest.RequestUri = $"{_endpont.Url}/v1/ProductVersion/list-product-version-clause/{productVersionId}/{insuredAmountValue}";
                rawResponse = await _httpClient.GetAsync<RawRequest, RawResponse>(rawRequest.RequestUri, rawRequest);
                var response = JsonConvert.DeserializeObject<BaseDataResponseModel<IEnumerable<ProductVersionClauseModel?>>>(rawResponse.Conteudo);
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
        public async Task<IEnumerable<LawsuitTypeModel?>> ListLawsuitTypeAsync(int productVersionId)
        {
            var rawRequest = new RawRequest();
            var rawResponse = new RawResponse();
            try
            {
                var _httpClient = new RestClient(_httpClientFactory.CreateClient(_endpont.Name));

                rawRequest.RequestUri = $"{_endpont.Url}/v1/ProductVersion/list-product-version-coverage/{productVersionId}";
                rawResponse = await _httpClient.GetAsync<RawRequest, RawResponse>(rawRequest.RequestUri, rawRequest);
                var response = JsonConvert.DeserializeObject<BaseDataResponseModel<IEnumerable<LawsuitTypeModel?>>>(rawResponse.Conteudo);
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
        public async Task<IEnumerable<PaymentFrequencyModel?>> GetPaymentFrequencyAsync(int productVersionId)
        {
            var rawRequest = new RawRequest();
            var rawResponse = new RawResponse();
            try
            {
                var _httpClient = new RestClient(_httpClientFactory.CreateClient(_endpont.Name));

                rawRequest.RequestUri = $"{_endpont.Url}/v1/ProductVersion/get-product-version-payment-frequency/{productVersionId}";
                rawResponse = await _httpClient.GetAsync<RawRequest, RawResponse>(rawRequest.RequestUri, rawRequest);
                var response = JsonConvert.DeserializeObject<BaseDataResponseModel<IEnumerable<PaymentFrequencyModel?>>>(rawResponse.Conteudo);
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
        public async Task<IEnumerable<PaymentInstallmentModel?>> GetPaymentInstallmentAsync(int productVersionId, int paymentMethodId)
        {
            var rawRequest = new RawRequest();
            var rawResponse = new RawResponse();
            try
            {
                var _httpClient = new RestClient(_httpClientFactory.CreateClient(_endpont.Name));

                rawRequest.RequestUri = $"{_endpont.Url}/v1/ProductVersion/get-product-version-payment-installment/{productVersionId}/{paymentMethodId}";
                rawResponse = await _httpClient.GetAsync<RawRequest, RawResponse>(rawRequest.RequestUri, rawRequest);
                var response = JsonConvert.DeserializeObject<BaseDataResponseModel<IEnumerable<PaymentInstallmentModel?>>>(rawResponse.Conteudo);
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
        public async Task<IEnumerable<PaymentMethodModel?>> GetPaymentMethodAsync(int productVersionId)
        {
            var rawRequest = new RawRequest();
            var rawResponse = new RawResponse();
            try
            {
                var _httpClient = new RestClient(_httpClientFactory.CreateClient(_endpont.Name));

                rawRequest.RequestUri = $"{_endpont.Url}/v1/ProductVersion/get-product-version-payment-method/{productVersionId}";
                rawResponse = await _httpClient.GetAsync<RawRequest, RawResponse>(rawRequest.RequestUri, rawRequest);
                var response = JsonConvert.DeserializeObject<BaseDataResponseModel<IEnumerable<PaymentMethodModel?>>>(rawResponse.Conteudo);
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
        public async Task<IEnumerable<TermTypeModel?>> ListTermTypeAsync(int productVersionId)
        {
            var rawRequest = new RawRequest();
            var rawResponse = new RawResponse();
            try
            {
                var _httpClient = new RestClient(_httpClientFactory.CreateClient(_endpont.Name));

                rawRequest.RequestUri = $"{_endpont.Url}/v1/ProductVersion/get-product-version-term-type/{productVersionId}";
                rawResponse = await _httpClient.GetAsync<RawRequest, RawResponse>(rawRequest.RequestUri, rawRequest);
                var response = JsonConvert.DeserializeObject<BaseDataResponseModel<IEnumerable<TermTypeModel?>>>(rawResponse.Conteudo);
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
        public async Task<IEnumerable<CalculationTypeModel?>> GetCalculationTypeAsync(int productVersionId, int profileId)
        {
            var rawRequest = new RawRequest();
            var rawResponse = new RawResponse();
            try
            {
                var _httpClient = new RestClient(_httpClientFactory.CreateClient(_endpont.Name));

                rawRequest.RequestUri = $"{_endpont.Url}/v1/ProductVersion/get-product-version-calculation-type/{productVersionId}/{profileId}";
                rawResponse = await _httpClient.GetAsync<RawRequest, RawResponse>(rawRequest.RequestUri, rawRequest);
                var response = JsonConvert.DeserializeObject<BaseDataResponseModel<IEnumerable<CalculationTypeModel?>>>(rawResponse.Conteudo);
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
        public async Task<CalculationTypeAcceptanceModel?> GetCalculationTypeAcceptanceAsync(int productVersionId, int profileId, int calculationTypeId)
        {
            var rawRequest = new RawRequest();
            var rawResponse = new RawResponse();
            try
            {
                var _httpClient = new RestClient(_httpClientFactory.CreateClient(_endpont.Name));

                rawRequest.RequestUri = $"{_endpont.Url}/v1/ProductVersion/get-product-version-calculation-type-acceptance/{productVersionId}/{profileId}/{calculationTypeId}";
                rawResponse = await _httpClient.GetAsync<RawRequest, RawResponse>(rawRequest.RequestUri, rawRequest);
                var response = JsonConvert.DeserializeObject<BaseDataResponseModel<CalculationTypeAcceptanceModel?>>(rawResponse.Conteudo);
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
        public async Task<IEnumerable<ConstructionTypeModel?>> GetConstructionTypeAsync(int productVersionId)
        {
            var rawRequest = new RawRequest();
            var rawResponse = new RawResponse();
            try
            {
                var _httpClient = new RestClient(_httpClientFactory.CreateClient(_endpont.Name));

                rawRequest.RequestUri = $"{_endpont.Url}/v1/ProductVersion/get-product-version-construction-type/{productVersionId}";
                rawResponse = await _httpClient.GetAsync<RawRequest, RawResponse>(rawRequest.RequestUri, rawRequest);
                var response = JsonConvert.DeserializeObject<BaseDataResponseModel<IEnumerable<ConstructionTypeModel?>>>(rawResponse.Conteudo);
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
        public async Task<IEnumerable<ActivityModel?>> GetActivityAsync(int productVersionId, int profileid, string? name)
        {
            var rawRequest = new RawRequest();
            var rawResponse = new RawResponse();
            try
            {
                var _httpClient = new RestClient(_httpClientFactory.CreateClient(_endpont.Name));

                rawRequest.RequestUri = $"{_endpont.Url}/v1/ProductVersion/get-product-version-activity/{productVersionId}/{profileid}";
                if (!string.IsNullOrEmpty(name))
                {
                    rawRequest.RequestUri = $"{rawRequest.RequestUri}?name={name}";
                }
                rawResponse = await _httpClient.GetAsync<RawRequest, RawResponse>(rawRequest.RequestUri, rawRequest);
                var response = JsonConvert.DeserializeObject<BaseDataResponseModel<IEnumerable<ActivityModel?>>>(rawResponse.Conteudo);
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
        public async Task<IEnumerable<ContractTypeModel?>> GetContractTypeAsync(int productVersionId)
        {
            var rawRequest = new RawRequest();
            var rawResponse = new RawResponse();
            try
            {
                var _httpClient = new RestClient(_httpClientFactory.CreateClient(_endpont.Name));

                rawRequest.RequestUri = $"{_endpont.Url}/v1/ProductVersion/get-product-version-contract-type/{productVersionId}";
                rawResponse = await _httpClient.GetAsync<RawRequest, RawResponse>(rawRequest.RequestUri, rawRequest);
                var response = JsonConvert.DeserializeObject<BaseDataResponseModel<IEnumerable<ContractTypeModel?>>>(rawResponse.Conteudo);
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
        public async Task<IEnumerable<PlanModel?>> GetPlanActivityAsync(int productVersionId, int activityId)
        {
            var rawRequest = new RawRequest();
            var rawResponse = new RawResponse();
            try
            {
                var _httpClient = new RestClient(_httpClientFactory.CreateClient(_endpont.Name));

                rawRequest.RequestUri = $"{_endpont.Url}/v1/ProductVersion/get-product-version-plan-activity/{productVersionId}/{activityId}";
                rawResponse = await _httpClient.GetAsync<RawRequest, RawResponse>(rawRequest.RequestUri, rawRequest);
                var response = JsonConvert.DeserializeObject<BaseDataResponseModel<IEnumerable<PlanModel?>>>(rawResponse.Conteudo);
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
        public async Task<IEnumerable<PlanCoverageModel?>> GetPlanCoverageAsync(int productVersionId, int planId)
        {
            var rawRequest = new RawRequest();
            var rawResponse = new RawResponse();
            try
            {
                var _httpClient = new RestClient(_httpClientFactory.CreateClient(_endpont.Name));

                rawRequest.RequestUri = $"{_endpont.Url}/v1/ProductVersion/get-product-version-plan-coverage/{productVersionId}/{planId}";
                rawResponse = await _httpClient.GetAsync<RawRequest, RawResponse>(rawRequest.RequestUri, rawRequest);
                var response = JsonConvert.DeserializeObject<BaseDataResponseModel<IEnumerable<PlanCoverageModel?>>>(rawResponse.Conteudo);
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
        public async Task<CoverageActivityLimitModel?> GetCoverageActivityLimitAsync(int productVersionId, int coverageId, int activityId, int profile)
        {
            var rawRequest = new RawRequest();
            var rawResponse = new RawResponse();
            try
            {
                var _httpClient = new RestClient(_httpClientFactory.CreateClient(_endpont.Name));

                rawRequest.RequestUri = $"{_endpont.Url}/v1/ProductVersion/get-product-version-coverage-activity-limit/{productVersionId}/{coverageId}/{activityId}/{profile}";
                rawResponse = await _httpClient.GetAsync<RawRequest, RawResponse>(rawRequest.RequestUri, rawRequest);
                var response = JsonConvert.DeserializeObject<BaseDataResponseModel<CoverageActivityLimitModel?>>(rawResponse.Conteudo);
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
        public async Task<IEnumerable<Localization?>> GetLocalizationAsync(int productVersionId)
        {
            var rawRequest = new RawRequest();
            var rawResponse = new RawResponse();
            try
            {
                var _httpClient = new RestClient(_httpClientFactory.CreateClient(_endpont.Name));

                rawRequest.RequestUri = $"{_endpont.Url}/v1/ProductVersion/get-product-version-localization/{productVersionId}";
                rawResponse = await _httpClient.GetAsync<RawRequest, RawResponse>(rawRequest.RequestUri, rawRequest);
                var response = JsonConvert.DeserializeObject<BaseDataResponseModel<IEnumerable<Localization>?>>(rawResponse.Conteudo);
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
        public async Task<IEnumerable<FranchiseModel?>> GetCoverageFranchiseAsync(int productVersionId, int coverageId)
        {
            var rawRequest = new RawRequest();
            var rawResponse = new RawResponse();
            try
            {
                var _httpClient = new RestClient(_httpClientFactory.CreateClient(_endpont.Name));

                rawRequest.RequestUri = $"{_endpont.Url}/v1/ProductVersion/get-product-version-coverage-franchise/{productVersionId}/{coverageId}";
                rawResponse = await _httpClient.GetAsync<RawRequest, RawResponse>(rawRequest.RequestUri, rawRequest);
                var response = JsonConvert.DeserializeObject<BaseDataResponseModel<IEnumerable<FranchiseModel>?>>(rawResponse.Conteudo);
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
