using InsuranceApi.Application.Interfaces;
using InsuranceApi.Core.Models;
using InsuranceApi.Service.Client.Interfaces;

namespace InsuranceApi.Application.Services
{
    internal class AuthenticationAppService(IAuthenticationService authenticationService) : IAuthenticationAppService
    {
        private readonly IAuthenticationService _authenticationService = authenticationService;

        public async Task<TokenModelResponse> GetAsync(string login, string password)
        {
            var response = await _authenticationService.GetAsync(login, password);

            return new TokenModelResponse
            {
                AccessToken = response                
            };  
        }
    }
}
