using Newtonsoft.Json;

namespace Warranty.Mock.Api.Models
{
    public class PesquisaCorretorModelRequest
    {
        [JsonProperty("id_pessoa")]
        public int? id_pessoa { get;set; }

        [JsonProperty("nm_pessoa")]
        public string? nm_pessoa { get; set; }

        [JsonProperty("nr_cnpj_cpf")]
        public decimal? nr_cnpj_cpf { get; set; }  
    }
}
