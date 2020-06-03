using BarDG.Domain.Common;
using BarDG.Domain.Common.Interfaces;
using BarDG.Domain.Vendas.Dtos;
using BarDG.Domain.Vendas.Entities;
using BarDG.Domain.Vendas.Interfaces;

namespace BarDG.Domain.Vendas
{
    internal class VendaService : ServiceBase, IVendaService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IVendaRepository vendaRepository;
        private readonly IVendaItemRepository vendaItemRepository;

        public VendaService(
            IUnitOfWork unitOfWork,
            IVendaRepository vendaRepository, IVendaItemRepository vendaItemRepository)
        {
            this.unitOfWork = unitOfWork;
            this.vendaRepository = vendaRepository;
            this.vendaItemRepository = vendaItemRepository;
        }

        public int AdicionarItem(VendaItemRequest vendaItemRequest)
        {
            if (!ValidarRequest(vendaItemRequest))
                return 0;

            var vendaItem = new VendaItem(vendaItemRequest.VendaId, vendaItemRequest.ProdutoId, string.Empty, vendaItemRequest.Preco, vendaItemRequest.Desconto);

            var venda = Obter(vendaItem);

            venda.AdicionarItem(vendaItem);

            vendaItemRepository.Inserir(vendaItem);

            unitOfWork.Commit();

            return vendaItem.Id;
        }

        public bool Finalizar(int vendaId)
        {
            if (vendaId == 0)
            {
                AdicionarNotificacao(nameof(vendaId), "Campo obrigatório!");
                return false;
            }

            var venda = vendaRepository.ObterPorId(vendaId);

            venda.Finalizar();

            vendaRepository.Atualizar(venda);
            
            unitOfWork.Commit();
            
            return true;
        }

        public bool Resetar(int vendaId)
        {
            if (vendaId == 0)
            {
                AdicionarNotificacao(nameof(vendaId), "Campo obrigatório!");
                return false;

            }
            var venda = vendaRepository.ObterPorId(vendaId);

            venda.Resetar();

            vendaRepository.Atualizar(venda);
            
            unitOfWork.Commit();

            return true;
        }

        private Venda Obter(VendaItem vendaItem)
        {
            if (vendaItem.Id == 0)
            {
                var venda = Venda.Nova();
                vendaRepository.Inserir(venda);
                return venda;
            }

            return vendaRepository.ObterPorId(vendaItem.VendaId);
        }
    }
}