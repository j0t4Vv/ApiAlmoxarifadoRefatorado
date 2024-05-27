using AlmoxarifadoDomain.Models;
using AlmoxarifadoServices;
using AlmoxarifadoServices.DTO;
using Microsoft.AspNetCore.Mvc;

namespace AlmoxarifadoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItensReqController : ControllerBase
    {
        private readonly ItensReqService _itensReqService;
        public ItensReqController(ItensReqService itensReqService)
        {
            _itensReqService = itensReqService;
        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var itensReqs = _itensReqService.ObterTodosItensReq();
                return Ok(itensReqs);
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
                var itensReq = _itensReqService.ObterItensReqPorId(id);
                if (itensReq == null)
                {
                    return StatusCode(404, "Nenhum Usuario Encontrado com Esse Codigo");
                }
                return Ok(itensReq);
            }
            catch (Exception)
            {

                return StatusCode(500, "Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.");
            }

        }

        [HttpPost]
        public IActionResult CriarItensReq(ItensReqPostDTO itensReq)
        {
            try
            {
                var itensReqSalvo = _itensReqService.CriarItensReq(itensReq);
                return Ok(itensReqSalvo);
            }
            catch (Exception)
            {

                return StatusCode(500, "Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.");
            }
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarItensReq(int id, ItensReqPutDTO itensReq)
        {
            try
            {
                var itensReqAtualizado = _itensReqService.AtualizarItensReq(id, itensReq);
                if (itensReqAtualizado == null)
                {
                    return StatusCode(404, "Nenhum item encontrado com este ID");
                }
                return Ok(itensReqAtualizado);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro ao acessar os dados.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult ExcluirItensReq(int id)
        {
            try
            {
                var itemReq = _itensReqService.ObterItensReqPorId(id);
                if (itemReq == null)
                {
                    return StatusCode(404, "Nenhum item encontrado com este ID");
                }

                var itemExcluido = _itensReqService.ExcluirItensReq(itemReq);
                if (itemExcluido == null)
                {
                    return StatusCode(404, "Ocorreu um erro ao excluir o item");
                }
                return Ok(itemExcluido);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro ao acessar os dados.");
            }
        }
    }
}
