using Warranty.Mock.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Mock.Api.Models;
using System.Text.Json;

namespace Mock.Api.Controllers
{
    public class TomadorController : BaseController
    {

        [HttpPost]
        [Route("lista-tomador")]
        [ProducesResponseType(typeof(ListarTomadorModelResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ListarTomadorModelResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ListarTomadorModelResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ListarTomadorModelResponse>> ListaTomadorAsync([FromBody] ListarTomadorRequest request)
        {

            string currentDirectory = Directory.GetCurrentDirectory();
            string caminhoArquivo = Path.Combine($"{currentDirectory}\\App_Data", "Tomador_Listar.json");
            if (!System.IO.File.Exists(caminhoArquivo))
            {
                return NotFound("Arquivo JSON não encontrado.");
            }
            try
            {
                string json = await System.IO.File.ReadAllTextAsync(caminhoArquivo);
                ListarTomadorModelResponse? tomadores = JsonSerializer.Deserialize<ListarTomadorModelResponse>(json);

                var response = new ListarTomadorModelResponse()
                {
                    cd_retorno = 0,
                    ListaTomadorTable1 = new List<RetornoTomadorDetalheListaDTO>()
                };

                var list = tomadores.ListaTomadorTable1.Where(item => item.id_corretor.Equals(request.id_corretor)
                    && (string.IsNullOrEmpty(request.nm_tomador) || item.nm_tomador.ToUpper().Contains(request.nm_tomador.ToUpper()))
                    && (request.nr_cnpj == null || item.nr_cnpj.Equals(request.nr_cnpj))).ToList();                

                if (list.Count > 0)
                {
                    response.ListaTomadorTable1.AddRange(list);
                }

                return response is not null ? Ok(response) : BadRequest("Erro ao desserializar JSON.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("tomador-detalhe")]
        [ProducesResponseType(typeof(ListarTomadorModelResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ListarTomadorModelResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ListarTomadorModelResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TomadoDetalheModelResponse>> TomadorDetalheAsync([FromBody] int id_pessoa)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string caminhoArquivo = Path.Combine($"{currentDirectory}\\App_Data", "TomadorDetalhe.json");
            if (!System.IO.File.Exists(caminhoArquivo))
            {
                return NotFound("Arquivo JSON não encontrado.");
            }
            try
            {
                string json = await System.IO.File.ReadAllTextAsync(caminhoArquivo);
                IEnumerable<TomadoDetalheModelResponse>? tomadores = JsonSerializer.Deserialize<IEnumerable<TomadoDetalheModelResponse>>(json);

                var response = new TomadoDetalheModelResponse();
                foreach (var item in tomadores)
                {
                    var tomador = item.Tomador.Where(item => item.id_pessoa.Equals(id_pessoa)).FirstOrDefault();

                    if (tomador is not null)
                    {
                        response = item;
                        break;
                    }
                }
                return tomadores is not null ? Ok(response) : BadRequest("Erro ao desserializar JSON.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }
    }
}
