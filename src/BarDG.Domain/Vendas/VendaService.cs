using BarDG.Domain.Common;
using BarDG.Domain.Common.Interfaces;
using BarDG.Domain.Vendas.Dtos;
using BarDG.Domain.Vendas.Dtos.Request;
using BarDG.Domain.Vendas.Dtos.Response;
using BarDG.Domain.Vendas.Entities;
using BarDG.Domain.Vendas.Interfaces;
using BarDG.Domain.Vendas.Regras;
using System.Collections.Generic;

namespace BarDG.Domain.Vendas
{
    internal class VendaService : ServiceBase, IVendaService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IVendaRepository vendaRepository;
        private readonly IVendaItemRepository vendaItemRepository;
        private readonly IVendaRegras vendaRegras;

        public VendaService(
            IUnitOfWork unitOfWork,
            IVendaRepository vendaRepository, 
            IVendaItemRepository vendaItemRepository,
            IVendaRegras vendaRegras)
        {
            this.unitOfWork = unitOfWork;
            this.vendaRepository = vendaRepository;
            this.vendaItemRepository = vendaItemRepository;
            this.vendaRegras = vendaRegras;
        }

        public AdicionarVendaItemResponse AdicionarItem(AdicionarVendaItemRequest vendaItemRequest)
        {
            if (!ValidarRequest(vendaItemRequest))
            {
                return null;
            }

            var itens = new List<ComandaItemDto>();

            if(vendaRegras.Limites.Analisar(itens))
            {
                AdicionarNotificacoes(vendaRegras.Limites.ListarMensagens());
                return null;
            }

            vendaRegras.Descontos.Aplicar(itens);

            var vendaItem = new VendaItem(vendaItemRequest.VendaId, vendaItemRequest.ProdutoId, string.Empty, vendaItemRequest.Preco, vendaItemRequest.Desconto);

            var venda = Obter(vendaItem);

            venda.AdicionarItem(vendaItem);

            vendaItemRepository.Inserir(vendaItem);

            unitOfWork.Commit();

            return new AdicionarVendaItemResponse
            {
                ItemAdicionado = vendaItem,
                Brindes = vendaRegras.Brindes.Listar(itens)
            };
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