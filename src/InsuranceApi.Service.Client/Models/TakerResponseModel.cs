using Newtonsoft.Json;

namespace InsuranceApi.Service.Client.Models
{
    public class TakerResponseModel : BaseResponse
    {
        [JsonProperty("ListaTomadorTable1")]
        public List<RetornoTomadorDetalheListaDTO> ListaTomadorTable1 { get; set; }


        public class RetornoTomadorDetalheListaDTO
        {
            [JsonProperty("nm_tomador")]
            public string nm_tomador { get; set; }

            [JsonProperty("nr_cnpj")]
            public decimal nr_cnpj { get; set; }

            [JsonProperty("nm_corretor")]
            public string nm_corretor { get; set; }

            [JsonProperty("id_corretor")]
            public int id_corretor { get; set; }

            [JsonProperty("dt_validade")]
            public DateTime dt_validade { get; set; }

            [JsonProperty("vl_limite_aprovado")]
            public decimal? vl_limite_aprovado { get; set; }

            [JsonProperty("vl_limite_disponivel")]
            public decimal? vl_limite_disponivel { get; set; }

            [JsonProperty("vl_acumulo")]
            public decimal? vl_acumulo { get; set; }

            [JsonProperty("vl_acumulo_expirado")]
            public decimal? vl_acumulo_expirado { get; set; }

            [JsonProperty("id_pessoa")]
            public int id_pessoa { get; set; }

            [JsonProperty("CCGTable1")]
            public List<RetornoTomadorDetalheCcgListaDTO> CCGTable1 { get; set; }

        }
        public class RetornoTomadorDetalheCcgListaDTO
        {
            [JsonProperty("nm_ccg")]
            public string nm_ccg { get; set; }

            [JsonProperty("dt_recebimento")]
            public DateTime? dt_recebimento { get; set; }

            [JsonProperty("dt_solicitacao")]
            public DateTime? dt_solicitacao { get; set; }

            [JsonProperty("nm_status_ccg")]
            public string nm_status_ccg { get; set; }

        }
    }
}
