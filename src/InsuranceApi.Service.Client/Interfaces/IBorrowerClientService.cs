using static InsuranceApi.Service.Client.Models.TakerResponseModel;

namespace InsuranceApi.Service.Client.Interfaces
{
    public  interface IBorrowerClientService
    {
        Task<IEnumerable<RetornoTomadorDetalheListaDTO>?> ListAsync(int brokerId, string? name);
    }
}
