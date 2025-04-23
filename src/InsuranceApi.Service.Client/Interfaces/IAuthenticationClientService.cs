namespace InsuranceApi.Service.Client.Interfaces
{
    public interface IAuthenticationClientService
    {
        Task<string> GetAsync(string login, string password);
    }
}
