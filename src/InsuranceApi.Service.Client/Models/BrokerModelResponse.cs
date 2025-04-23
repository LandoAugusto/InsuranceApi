using Newtonsoft.Json;

namespace InsuranceApi.Service.Client.Models
{
    public class BrokerModelResponse : BaseResponse
    {
        [JsonProperty("Corretor")]
        public List<Corretor> Corretor { get; set; }
    }


    public class Corretor
    {
        [JsonProperty("id_pessoa")]
        public int id_pessoa { get; set; }

        [JsonProperty("nm_pessoa")]
        public string nm_pessoa { get; set; }

        [JsonProperty("nr_cnpj_cpf")]
        public decimal nr_cnpj_cpf { get; set; }

        [JsonProperty("cd_susep_re")]
        public string cd_susep_re { get; set; }

        [JsonProperty("nm_email")]
        public string nm_email { get; set; }

        [JsonProperty("fl_ativo")]
        public bool fl_ativo { get; set; }
    }
}