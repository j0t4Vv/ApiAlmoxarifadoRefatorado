using AlmoxarifadoServices.DTO;
using AlmoxarifadoServices;
using Microsoft.AspNetCore.Mvc;

namespace AlmoxarifadoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItensNotaController : ControllerBase
    {
        private readonly ItensNotaService _itensNotaService;
        public ItensNotaController(ItensNotaService itensNotaService)
        {
            _itensNotaService = itensNotaService;
        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var itensNotas = _itensNotaService.ObterTodosItensNota();
                return Ok(itensNotas);
            }
            catch (Exception)
            {

                return StatusCode(500, "Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.");
            }

        }

        [HttpGet("{ItemNum}")]
        public IActionResult GetPorID(int id)
        {
            try
            {
                var itensNota= _itensNotaService.ObterItensNotaPorId(id);
                if (itensNota == null)
                {
                    return StatusCode(404, "Nenhum Usuario Encontrado com Esse Codigo");
                }
                return Ok(itensNota);
            }
            catch (Exception)
            {

                return StatusCode(500, "Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.");
            }

        }

        [HttpPost]
        public IActionResult CriarItensNota(ItensNotaPostDTO itensNota)
        {
            try
            {
                var itensNotaSalvo = _itensNotaService.CriarItensNota(itensNota);
                return Ok(itensNotaSalvo);
            }
            catch (Exception)
            {

                return StatusCode(500, "Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.");
            }
        }
    }
}
