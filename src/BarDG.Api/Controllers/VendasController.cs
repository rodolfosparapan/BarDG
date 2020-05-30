using BarDG.Domain.Vendas.Requests;
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
        public async Task<IActionResult> Registrar(AdicionarItemComandaRequest adicionarItemComandaRequest)
        {
            await Task.CompletedTask;
            return CreatedAtAction(nameof(adicionarItemComandaRequest), new { id = 1 }, adicionarItemComandaRequest);
        }

        [HttpPut("fecharComanda")]
        public async Task <IActionResult> FecharComanda(string codigoComanda)
        {
            await Task.CompletedTask;
            return Ok();
        }

        [HttpPut("resetarComanda")]
        public async Task<IActionResult> ResetarComanda(string codigoComanda)
        {
            await Task.CompletedTask;
            return Ok();
        }
    }
}