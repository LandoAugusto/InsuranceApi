using Component.Log.Interfaces;
using InsuranceApi.Core.Infrastructure.Configuration;
using InsuranceApi.Core.Infrastructure.Exceptions;
using InsuranceApi.Core.Infrastructure.Http;
using InsuranceApi.Core.Models;
using InsuranceApi.Service.Client.Interfaces;
using InsuranceApi.Service.Client.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace InsuranceApi.Service.Client.Services
{
    internal class AuthenticationService(ILogWriter logWriter, IHttpClientFactory httpClientFactory, IOptions<ApiConfig> option)
        : IAuthenticationService
    {
        private readonly ILogWriter _logWriter = logWriter;
        private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
        private readonly HttpConfig _endpont = option.Value.Configurations.First(x => x.Name.Equals("Authentication"));
        public async Task<string> GetAsync(string login, string password)
        {
            var rawRequest = new RawRequest();
            var rawResponse = new RawResponse();
            try
            {
                var _httpClient = new RestClient(_httpClientFactory.CreateClient(_endpont.Name));

                rawRequest.RequestUri = $"{_endpont.Url}/v1/auth/token";
                rawRequest.BodyObject = new
                {
                    login,
                    password
                };
                rawResponse = await _httpClient.PostAsync<RawRequest, RawResponse>(rawRequest.RequestUri, rawRequest);
                var response = JsonConvert.DeserializeObject<BaseDataResponseModel<TokenResponse>>(rawResponse.Conteudo);
                if (!response.TransactionStatus.Sucess)
                {
                    throw new BusinessException(response.TransactionStatus.Message);
                }
                return response.Data.AccessToken;
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
        public async Task<ListMenuModel> GetMenuAsync(string roleName)
        {
            var rawRequest = new RawRequest();
            var rawResponse = new RawResponse();
            try
            {
                var _httpClient = new RestClient(_httpClientFactory.CreateClient(_endpont.Name));

                rawRequest.RequestUri = $"{_endpont.Url}/v1/Menu/get-role-menu?roleName={roleName}";
                rawResponse = await _httpClient.GetAsync<RawRequest, RawResponse>(rawRequest.RequestUri, rawRequest);
                var response = JsonConvert.DeserializeObject<BaseDataResponseModel<ListMenuModel>>(rawResponse.Conteudo);
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
        public async Task<IEnumerable<MenuModel>> GetMenuAllAsync()
        {
            var rawRequest = new RawRequest();
            var rawResponse = new RawResponse();
            try
            {
                var _httpClient = new RestClient(_httpClientFactory.CreateClient(_endpont.Name));

                rawRequest.RequestUri = $"{_endpont.Url}/v1/Menu/get-menu-all";
                rawResponse = await _httpClient.GetAsync<RawRequest, RawResponse>(rawRequest.RequestUri, rawRequest);
                var response = JsonConvert.DeserializeObject<BaseDataResponseModel<IEnumerable<MenuModel>>>(rawResponse.Conteudo);
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
        public async Task<bool> SaveMenuRoleAsync(SaveMenuRoleModel request)
        {
            var rawRequest = new RawRequest();
            var rawResponse = new RawResponse();
            try
            {
                var _httpClient = new RestClient(_httpClientFactory.CreateClient(_endpont.Name));

                rawRequest.RequestUri = $"{_endpont.Url}/v1/Menu/save-role-menu";
                rawRequest.BodyObject = new
                {
                    request.RoleName,
                    request.MenuIds
                };
                rawResponse = await _httpClient.PostAsync<RawRequest, RawResponse>(rawRequest.RequestUri, rawRequest);
                var response = JsonConvert.DeserializeObject<BaseDataResponseModel<bool>>(rawResponse.Conteudo);
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
        public async Task<IEnumerable<UseModel>?> GetUserAsync(UserFilterModel request)
        {
            var rawRequest = new RawRequest();
            var rawResponse = new RawResponse();
            try
            {
                var _httpClient = new RestClient(_httpClientFactory.CreateClient(_endpont.Name));
                rawRequest.RequestUri = $"{_endpont.Url}/v1/User/get-users";
                rawRequest.BodyObject = request;
                rawResponse = await _httpClient.PostAsync<RawRequest, RawResponse>(rawRequest.RequestUri, rawRequest);
                var response = JsonConvert.DeserializeObject<BaseDataResponseModel<IEnumerable<UseModel>?>>(rawResponse.Conteudo);
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
        public async Task<UseModel> GetUserByIdAsync(string? userId)
        {
            var rawRequest = new RawRequest();
            var rawResponse = new RawResponse();
            try
            {
                var _httpClient = new RestClient(_httpClientFactory.CreateClient(_endpont.Name));

                rawRequest.RequestUri = $"{_endpont.Url}/v1/User/get-user/{userId}";
                rawResponse = await _httpClient.GetAsync<RawRequest, RawResponse>(rawRequest.RequestUri, rawRequest);
                var response = JsonConvert.DeserializeObject<BaseDataResponseModel<UseModel>>(rawResponse.Conteudo);
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
        public async Task<int> SaveUserAsync(SaveUserModel request)
        {
            var rawRequest = new RawRequest();
            var rawResponse = new RawResponse();
            try
            {
                var _httpClient = new RestClient(_httpClientFactory.CreateClient(_endpont.Name));

                rawRequest.RequestUri = $"{_endpont.Url}/v1/User/save-user";
                rawRequest.BodyObject = new
                {
                    request.RoleId,
                    request.ProfileId,
                    request.Login,
                    request.Email,
                    request.Password
                };
                rawResponse = await _httpClient.PostAsync<RawRequest, RawResponse>(rawRequest.RequestUri, rawRequest);
                var response = JsonConvert.DeserializeObject<BaseDataResponseModel<int?>>(rawResponse.Conteudo);
                if (!response.TransactionStatus.Sucess)
                {
                    throw new BusinessException(response.TransactionStatus.Message);
                }
                return response.Data.Value;
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
        public async Task<bool> UpdateUserAsync(UpdateUserModel request)
        {
            var rawRequest = new RawRequest();
            var rawResponse = new RawResponse();
            try
            {
                var _httpClient = new RestClient(_httpClientFactory.CreateClient(_endpont.Name));

                rawRequest.RequestUri = $"{_endpont.Url}/v1/User/update-user";
                rawRequest.BodyObject = new
                {
                    request.Id,
                    request.RoleId,                    
                    request.Email,

                };
                rawResponse = await _httpClient.PostAsync<RawRequest, RawResponse>(rawRequest.RequestUri, rawRequest);
                var response = JsonConvert.DeserializeObject<BaseDataResponseModel<bool>>(rawResponse.Conteudo);
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
        public async Task<bool> UpdateUserPasswordAsync(UpdatePasswordUserModel request)
        {
            var rawRequest = new RawRequest();
            var rawResponse = new RawResponse();
            try
            {
                var _httpClient = new RestClient(_httpClientFactory.CreateClient(_endpont.Name));

                rawRequest.RequestUri = $"{_endpont.Url}/v1/User/update-password";
                rawRequest.BodyObject = new
                {
                    request.Id,
                    request.NewPassword,
                    request.OldPassword,

                };
                rawResponse = await _httpClient.GetAsync<RawRequest, RawResponse>(rawRequest.RequestUri, rawRequest);
                var response = JsonConvert.DeserializeObject<BaseDataResponseModel<bool>>(rawResponse.Conteudo);
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
        public async Task<ListMenuModel> UpdateUserStatusAsync(string? userId)
        {
            var rawRequest = new RawRequest();
            var rawResponse = new RawResponse();
            try
            {
                var _httpClient = new RestClient(_httpClientFactory.CreateClient(_endpont.Name));

                rawRequest.RequestUri = $"{_endpont.Url}/v1/User/get-user/{userId}";
                rawResponse = await _httpClient.GetAsync<RawRequest, RawResponse>(rawRequest.RequestUri, rawRequest);
                var response = JsonConvert.DeserializeObject<BaseDataResponseModel<ListMenuModel>>(rawResponse.Conteudo);
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
        public async Task<RoleModel> GetRoleByIdAsync(int roleId)
        {
            var rawRequest = new RawRequest();
            var rawResponse = new RawResponse();
            try
            {
                var _httpClient = new RestClient(_httpClientFactory.CreateClient(_endpont.Name));

                rawRequest.RequestUri = $"{_endpont.Url}/v1/User/get-role-by-id/{roleId}";
                rawResponse = await _httpClient.GetAsync<RawRequest, RawResponse>(rawRequest.RequestUri, rawRequest);
                var response = JsonConvert.DeserializeObject<BaseDataResponseModel<RoleModel>>(rawResponse.Conteudo);
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
        public async Task<IEnumerable<RoleModel>?> GetRoleAsync(int? id, string? name)
        {
            var rawRequest = new RawRequest();
            var rawResponse = new RawResponse();
            try
            {
                var _httpClient = new RestClient(_httpClientFactory.CreateClient(_endpont.Name));
                rawRequest.RequestUri = $"{_endpont.Url}/v1/User/get-roles";
                rawRequest.BodyObject = new
                {
                    id,
                    name
                };

                rawResponse = await _httpClient.PostAsync<RawRequest, RawResponse>(rawRequest.RequestUri, rawRequest);
                var response = JsonConvert.DeserializeObject<BaseDataResponseModel<IEnumerable<RoleModel>>>(rawResponse.Conteudo);
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
        public async Task<string> SaveRoleAsync(SaveRoleModel request)
        {
            var rawRequest = new RawRequest();
            var rawResponse = new RawResponse();
            try
            {
                var _httpClient = new RestClient(_httpClientFactory.CreateClient(_endpont.Name));

                rawRequest.RequestUri = $"{_endpont.Url}/v1/User/save-role";
                rawRequest.BodyObject = new
                {
                    request.Id,
                    request.Name,
                    request.Description,

                };
                rawResponse = await _httpClient.PostAsync<RawRequest, RawResponse>(rawRequest.RequestUri, rawRequest);
                var response = JsonConvert.DeserializeObject<BaseDataResponseModel<string>>(rawResponse.Conteudo);
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

