using static InsuranceApi.Service.Client.Models.TakerResponseModel;

namespace InsuranceApi.Service.Client.Interfaces
{
    public  interface ITakerClientService
    {
        Task<IEnumerable<RetornoTomadorDetalheListaDTO>?> ListAsync(int brokerId, string? name);
    }
}
