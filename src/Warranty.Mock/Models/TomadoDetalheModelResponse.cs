using Warranty.Mock.Api.Models.Base;
using Newtonsoft.Json;

namespace Mock.Api.Models
{
    public class TomadoDetalheModelResponse : BaseResponse
    {
        [JsonProperty("Tomador")]
        public List<TomadorDetalheResponse> Tomador { get; set; }
    }
    public class TomadorDetalheResponse
    {
        [JsonProperty("id_pessoa")]
        public int id_pessoa { get; set; }

        [JsonProperty("nr_cnpj_cpf")]
        public decimal nr_cnpj_cpf { get; set; }

        [JsonProperty("nm_pessoa")]
        public string nm_pessoa { get; set; }

        [JsonProperty("nm_tipo_pessoa")]
        public string nm_tipo_pessoa { get; set; }

        [JsonProperty("nm_status")]
        public string nm_status { get; set; }

        [JsonProperty("dv_ppe")]
        public string dv_ppe { get; set; }

        [JsonProperty("nm_fantasia")]
        public string nm_fantasia { get; set; }

        [JsonProperty("id_ramo_atividade")]
        public string id_ramo_atividade { get; set; }

        [JsonProperty("nm_ramo_atividade")]
        public string nm_ramo_atividade { get; set; }

        [JsonProperty("nm_tp_estabelecimento")]
        public string nm_tp_estabelecimento { get; set; }

        [JsonProperty("nm_tipo_empresa")]
        public string nm_tipo_empresa { get; set; }
        [JsonProperty("TomadorDetalharEndereco")]
        public RetornoPessoaDetalharEnderecoDTO TomadorDetalharEndereco { get; set; }

        [JsonProperty("TomadorDetalharCCG")]
        public RetornoTomadorDetalharCCGDTO TomadorDetalharCCG { get; set; }

        [JsonProperty("TomadorDetalharSituacao")]
        public RetornoTomadorDetalharSituacaoDTO TomadorDetalharSituacao { get; set; }

        [JsonProperty("TomadorDetalharSubLimite")]
        public RetornoTomadorDetalharSubLimiteDTO TomadorDetalharSubLimite { get; set; }

        [JsonProperty("TomadorDetalharCorretores")]
        public RetornoTomadorDetalharCorretoresDTO TomadorDetalharCorretores { get; set; }
    }

    public class RetornoPessoaDetalharEnderecoDTO
    {
        [JsonProperty("Endereco")]
        public List<RetornoPessoaConteudoEnderecoDetalheDTO> Endereco { get; set; }
    }
    public class RetornoPessoaConteudoEnderecoDetalheDTO
    {
        [JsonProperty("id_endereco")]
        public int id_endereco { get; set; }

        [JsonProperty("nm_endereco")]
        public string nm_endereco { get; set; }

        [JsonProperty("nr_rua_endereco")]
        public string nr_rua_endereco { get; set; }

        [JsonProperty("nm_bairro")]
        public string nm_bairro { get; set; }

        [JsonProperty("nm_cidade")]
        public string nm_cidade { get; set; }

        [JsonProperty("cd_pais")]
        public Int16 cd_pais { get; set; }

        [JsonProperty("nm_pais")]
        public string nm_pais { get; set; }

        [JsonProperty("cd_uf")]
        public int cd_uf { get; set; }

        [JsonProperty("nm_uf")]
        public string nm_uf { get; set; }

        [JsonProperty("id_tp_endereco")]
        public string id_tp_endereco { get; set; }

        [JsonProperty("nm_cep")]
        public string nm_cep { get; set; }

        [JsonProperty("dv_endereco_padrao")]
        public bool dv_endereco_padrao { get; set; }

        [JsonProperty("nm_complemento")]
        public string nm_complemento { get; set; }


    }

    public class RetornoTomadorDetalharSituacaoDTO
    {
        [JsonProperty("id_tomador")]
        public int id_tomador { get; set; }

        [JsonProperty("id_classe_risco")]
        public int? id_classe_risco { get; set; }

        [JsonProperty("nm_classe_risco")]
        public string nm_classe_risco { get; set; }

        [JsonProperty("nr_qualidade_risco")]
        public string nr_qualidade_risco { get; set; }

        [JsonProperty("vl_lim_credito_interno")]
        public decimal? vl_lim_credito_interno { get; set; }

        [JsonProperty("dt_validade")]
        public DateTime? dt_validade { get; set; }

        [JsonProperty("vl_taxa_risco")]
        public decimal? vl_taxa_risco { get; set; }

        [JsonProperty("vl_premio_minimo")]
        public decimal? vl_premio_minimo { get; set; }

        [JsonProperty("vl_acumulo")]
        public decimal? vl_acumulo { get; set; }

        [JsonProperty("vl_retencao")]
        public decimal? vl_retencao { get; set; }

        [JsonProperty("cd_status")]
        public int? cd_status { get; set; }

        [JsonProperty("nm_status")]
        public string nm_status { get; set; }

    }

    public class RetornoTomadorDetalharSubLimiteDTO
    {
        [JsonProperty("SubLimite")]
        public List<RetornoTomadorConteudoDetalharSubLimiteDTO> SubLimite { get; set; }
    }

    public class RetornoTomadorConteudoDetalharSubLimiteDTO
    {
        [JsonProperty("id_grp_sub_limite_tomador")]
        public int? id_grp_sub_limite_tomador { get; set; }

        [JsonProperty("id_grp_cobertura")]
        public int id_grp_cobertura { get; set; }

        [JsonProperty("nm_grp_cobertura")]
        public string nm_grp_cobertura { get; set; }

        [JsonProperty("vl_limite_credito")]
        public decimal? vl_limite_credito { get; set; }

        [JsonProperty("vl_acumulo_modalidade")]
        public decimal? vl_acumulo_modalidade { get; set; }

        [JsonProperty("vl_taxa")]
        public decimal? vl_taxa { get; set; }

        [JsonProperty("vl_limite_is")]
        public decimal? vl_limite_is { get; set; }
    }

    public class RetornoTomadorDetalharCCGDTO
    {
        [JsonProperty("CCG")]
        public List<RetornoTomadorConteudoDetalharCCGDTO> CCG { get; set; }
    }

    public class RetornoTomadorConteudoDetalharCCGDTO
    {

        [JsonProperty("id_tomador_documento")]
        public int id_tomador_documento { get; set; }

        [JsonProperty("id_documento")]
        public int id_documento { get; set; }

        [JsonProperty("nm_documento")]
        public string nm_documento { get; set; }

        [JsonProperty("dt_recebimento")]
        public string dt_recebimento { get; set; }

        [JsonProperty("dt_solicitacao")]
        public string dt_solicitacao { get; set; }

        [JsonProperty("cd_modelo")]
        public int cd_modelo { get; set; }

        [JsonProperty("nm_modelo")]
        public string nm_modelo { get; set; }

        [JsonProperty("cd_status")]
        public int cd_status { get; set; }

        [JsonProperty("nm_status")]
        public string nm_status { get; set; }

        [JsonProperty("nm_texto_ccg")]
        public string nm_texto_ccg { get; set; }

        [JsonProperty("nm_obs_juridico")]
        public string nm_obs_juridico { get; set; }

        [JsonProperty("nm_obs_emissao")]
        public string nm_obs_emissao { get; set; }

        [JsonProperty("id_pessoa_testemunha1")]
        public int id_pessoa_testemunha1 { get; set; }

        [JsonProperty("nm_testemunha")]
        public string nm_testemunha { get; set; }

        [JsonProperty("id_pessoa_testemunha2")]
        public int id_pessoa_testemunha2 { get; set; }

        [JsonProperty("nm_testemunha2")]
        public string nm_testemunha2 { get; set; }

        [JsonProperty("id_pessoa_fiador1")]
        public int id_pessoa_fiador1 { get; set; }

        [JsonProperty("nm_fiador1")]
        public string nm_fiador1 { get; set; }

        [JsonProperty("id_pessoa_fiador1_conjuge")]
        public int id_pessoa_fiador1_conjuge { get; set; }

        [JsonProperty("nm_fiador1_conjuge")]
        public string nm_fiador1_conjuge { get; set; }

        [JsonProperty("id_pessoa_fiador2")]
        public int id_pessoa_fiador2 { get; set; }

        [JsonProperty("nm_fiador2")]
        public string nm_fiador2 { get; set; }

        [JsonProperty("id_pessoa_fiador2_conjuge")]
        public int id_pessoa_fiador2_conjuge { get; set; }

        [JsonProperty("nm_fiador2_conjuge")]
        public string nm_fiador2_conjuge { get; set; }

        [JsonProperty("nr_dias_ccg")]
        public int? nr_dias_ccg { get; set; }

    }

    public class RetornoTomadorDetalharCorretoresDTO
    {
        [JsonProperty("Corretores")]
        public List<RetornoTomadorConteudoDetalharCorretoresDTO> Corretores { get; set; }
    }

    public class RetornoTomadorConteudoDetalharCorretoresDTO
    {
        [JsonProperty("id_garant_tomador_corretor")]
        public int id_garant_tomador_corretor { get; set; }

        [JsonProperty("id_pessoa_corretor")]
        public int id_pessoa_corretor { get; set; }

        [JsonProperty("nm_pessoa_corretor")]
        public string nm_pessoa_corretor { get; set; }

        [JsonProperty("cd_tp_comissao")]
        public int cd_tp_comissao { get; set; }

        [JsonProperty("nm_tp_comissao")]
        public string nm_tp_comissao { get; set; }

        [JsonProperty("pe_comissao")]
        public decimal? pe_comissao { get; set; }

        [JsonProperty("dv_lider")]
        public bool dv_lider { get; set; }
    }
}

