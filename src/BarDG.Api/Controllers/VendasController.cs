using BarDG.Domain.Vendas.Dtos;
using BarDG.Domain.Vendas.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BarDG.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class VendasController : ApiBase
    {
        private readonly IVendaService service;

        public VendasController(IVendaService service) : base(service)
        {
            this.service = service;
        }
        
        [HttpPost("adicionarItem")]
        public IActionResult RegistrarItem(VendaItemRequest adicionarVendaItemRequest)
        {
            var id = service.AdicionarItem(adicionarVendaItemRequest);   
            if(id > 0)
                return CreatedAtAction(nameof(adicionarVendaItemRequest), new { id }, adicionarVendaItemRequest);

            return BadRequest();
        }

        [HttpPost("finalizar")]
        public IActionResult FecharComanda(int vendaId)
        {
            var sucesso = service.Finalizar(vendaId);
            if (sucesso)
                return Ok();
            
            return BadRequest();
        }

        [HttpPut("resetar")]
        public IActionResult ResetarComanda(int vendaId)
        {
            var sucesso = service.Resetar(vendaId);
            if (sucesso)
                return Ok();

            return BadRequest();
        }
    }
}