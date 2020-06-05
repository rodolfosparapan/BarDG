using BarDG.Domain.Vendas.Dtos.Request;
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
        public IActionResult RegistrarItem(AdicionarVendaItemRequest adicionarVendaItemRequest)
        {
            var retorno = service.AdicionarItem(adicionarVendaItemRequest);
            return Response(retorno);
        }

        [HttpPost("finalizar")]
        public IActionResult FecharComanda(int vendaId)
        {
            var sucesso = service.Finalizar(vendaId);
            return Response(sucesso);
        }

        [HttpPut("resetar")]
        public IActionResult ResetarComanda(int vendaId)
        {
            var sucesso = service.Resetar(vendaId);
            return Response(sucesso);
        }
    }
}