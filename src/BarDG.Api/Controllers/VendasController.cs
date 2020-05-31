using BarDG.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BarDG.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendasController : ControllerBase
    {
        public VendasController()
        {
        }
        
        [HttpPost("adicionarItem")]
        public async Task<IActionResult> Registrar(AdicionarVendaItemRequest adicionarVendaItemRequest)
        {
            await Task.CompletedTask;
            return CreatedAtAction(nameof(adicionarVendaItemRequest), new { id = 1 }, adicionarVendaItemRequest);
        }

        [HttpPost("finalizar")]
        public async Task <IActionResult> FecharComanda(string codigoComanda)
        {
            await Task.CompletedTask;
            return Ok();
        }

        [HttpPut("resetar")]
        public async Task<IActionResult> ResetarComanda(string codigoComanda)
        {
            await Task.CompletedTask;
            return Ok();
        }
    }
}