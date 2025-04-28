
using Warranty.Mock.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Warranty.Mock.Api.Controllers
{
    public class CorretorController : Controller
    {
        [HttpPost]
        [Route("pesquisa-corretor")]
        [ProducesResponseType(typeof(PesquisaCorretorModelResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(PesquisaCorretorModelResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(PesquisaCorretorModelResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PesquisaCorretorModelResponse>> PesquisaCorretor([FromBody]PesquisaCorretorModelRequest request)
        {

            string currentDirectory = Directory.GetCurrentDirectory();
            string caminhoArquivo = Path.Combine($"{currentDirectory}\\App_Data", "corretor_Listar.json");
            if (!System.IO.File.Exists(caminhoArquivo))
            {
                return NotFound("Arquivo JSON não encontrado.");
            }
            try
            {
                string json = await System.IO.File.ReadAllTextAsync(caminhoArquivo);
                PesquisaCorretorModelResponse? corretores = JsonSerializer.Deserialize<PesquisaCorretorModelResponse>(json);

                var response = new PesquisaCorretorModelResponse()
                {
                    cd_retorno = 0,
                    Corretor = new List<Corretor>() 
                };
                var list = corretores.Corretor.Where(
                    item => (string.IsNullOrEmpty(request.nm_pessoa) || item.nm_pessoa.ToUpper().Contains(request.nm_pessoa.ToUpper()))
                    && (request.nr_cnpj_cpf == null || item.nr_cnpj_cpf.Equals(request.nr_cnpj_cpf))
                    && (request.id_pessoa == null || item.id_pessoa.Equals(request.id_pessoa))).ToList();

                if (list.Count > 0)
                {
                    response.Corretor.AddRange(list);
                }              

                return response is not null ? Ok(response) : BadRequest("Erro ao desserializar JSON.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }
    }
}
