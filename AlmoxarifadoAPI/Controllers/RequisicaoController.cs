using AlmoxarifadoDomain.Models;
using AlmoxarifadoServices;
using AlmoxarifadoServices.DTO;
using Microsoft.AspNetCore.Mvc;

namespace AlmoxarifadoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RequisicaoController : ControllerBase
    {
        private readonly RequisicaoService _requisicaoService;
        public RequisicaoController(RequisicaoService requisicaoService)
        {
            _requisicaoService = requisicaoService;
        }

  
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var requisicoes = _requisicaoService.ObterTudoRequisicao();
                return Ok(requisicoes);
            }
            catch (Exception)
            {

                return StatusCode(500, "Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.");
            }
         
        }

        [HttpGet("{id}")]
        public IActionResult GetPorID(int id)
        {
            try
            {
                var requisicao = _requisicaoService.ObterRequisicaoPorID(id);
                if (requisicao == null)
                {
                    return StatusCode(404, "Nenhum Usuario Encontrado com Esse Codigo");
                }
                return Ok(requisicao);
            }
            catch (Exception)
            {

                return StatusCode(500, "Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.");
            }

        }

        [HttpPost]
        public IActionResult CriarRequisicao(RequisicaoPostDTO requisicao)
        {
            try
            {
                 var requisicaoSalva = _requisicaoService.CriarRequisicao(requisicao);
                  return Ok(requisicaoSalva);
            }
            catch (Exception)
            {

                return StatusCode(500, "Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.");
            }
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarRequisicao(int id, RequisicaoPutDTO requisicao)
        {
            try
            {
                var requisicaoAtualizada = _requisicaoService.AtualizarRequisicao(id, requisicao);
                if (requisicaoAtualizada == null)
                {
                    return StatusCode(404, "Nenhuma Requisicao Encontrada com Este ID");
                }
                return Ok(requisicaoAtualizada);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro ao atualizar a requisição. Por favor, tente novamente mais tarde.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult ExcluirRequisicao(int id)
        {
            try
            {
                var requisicaoExcluida = _requisicaoService.ExcluirRequisicao(id);
                if (requisicaoExcluida == null)
                {
                    return StatusCode(404, "Nenhuma Requisicao Encontrada com Este ID");
                }
                return Ok(requisicaoExcluida);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro ao excluir a requisição. Por favor, tente novamente mais tarde.");
            }
        }

    }
}
