using BarDG.Application.Dtos;
using BarDG.Application.Interfaces;
using BarDG.Domain.Entities;
using BarDG.Domain.Interfaces.Services;
using System.Threading.Tasks;

namespace BarDG.Application.Services
{
    internal class VendaAppService : AppServiceBase, IVendaAppService
    {
        private readonly IVendaService vendaService;

        public VendaAppService(IVendaService vendaService)
        {
            this.vendaService = vendaService;
        }

        public int AdicionarItem(AdicionarVendaItemRequest vendaItemRequest)
        {
            if (!ValidarRequest(vendaItemRequest))
                return 0;

            var vendaItem = new VendaItem(vendaItemRequest.VendaId, vendaItemRequest.ProdutoId, string.Empty, vendaItemRequest.Preco, vendaItemRequest.Desconto);
            return vendaService.AdicionarItem(vendaItem);
        }

        public bool Finalizar(int vendaId)
        {
            if (vendaId == 0)
            {
                AdicionarNotificacao(nameof(vendaId), "Campo obrigatório!");
                return false;
            }
            
            return vendaService.Finalizar(vendaId);
        }

        public bool Resetar(int vendaId)
        {
            if (vendaId == 0)
            {
                AdicionarNotificacao(nameof(vendaId), "Campo obrigatório!");
                return false;
            }
            
            return vendaService.Resetar(vendaId);
        }
    }
}