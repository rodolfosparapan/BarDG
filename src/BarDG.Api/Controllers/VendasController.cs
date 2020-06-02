using BarDG.Application.Dtos;
using BarDG.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BarDG.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class VendasController : ApiBase
    {
        private readonly IVendaAppService appService;

        public VendasController(IVendaAppService appService) : base(appService)
        {
            this.appService = appService;
        }
        
        [HttpPost("adicionarItem")]
        public IActionResult RegistrarItem(AdicionarVendaItemRequest adicionarVendaItemRequest)
        {
            var id = appService.AdicionarItem(adicionarVendaItemRequest);   
            if(id > 0)
                return CreatedAtAction(nameof(adicionarVendaItemRequest), new { id }, adicionarVendaItemRequest);

            return BadRequest();
        }

        [HttpPost("finalizar")]
        public IActionResult FecharComanda(int vendaId)
        {
            var sucesso = appService.Finalizar(vendaId);
            if (sucesso)
                return Ok();
            
            return BadRequest();
        }

        [HttpPut("resetar")]
        public IActionResult ResetarComanda(int vendaId)
        {
            var sucesso = appService.Resetar(vendaId);
            if (sucesso)
                return Ok();

            return BadRequest();
        }
    }
}