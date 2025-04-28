namespace Warranty.Mock.Api.Models
{
    public class ListarTomadorRequest
    {
        public int? id_corretor { get; set; }
        public int? id_pessoa { get; set; }
        public string? nm_tomador { get; set; }
        public decimal? nr_cnpj { get; set; }        

    }
}