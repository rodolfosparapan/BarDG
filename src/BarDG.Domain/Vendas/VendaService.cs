using BarDG.Domain.Common;
using BarDG.Domain.Common.Interfaces;
using BarDG.Domain.Vendas.Dtos;
using BarDG.Domain.Vendas.Dtos.Request;
using BarDG.Domain.Vendas.Dtos.Response;
using BarDG.Domain.Vendas.Entities;
using BarDG.Domain.Vendas.Interfaces;
using BarDG.Domain.Vendas.Regras;
using System.Collections.Generic;
using System.Linq;

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

            var comandaItens = ListarComandaItens(vendaItemRequest);

            if (vendaRegras.Limites.Analisar(comandaItens))
            {
                AdicionarNotificacoes(vendaRegras.Limites.ListarMensagens());
                return null;
            }

            vendaRegras.Descontos.Aplicar(comandaItens);

            VendaItem vendaItem = SalvarItem(vendaItemRequest);

            return new AdicionarVendaItemResponse
            {
                ItemAdicionado = vendaItem,
                Brindes = vendaRegras.Brindes.Listar(comandaItens)
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

        private VendaItem SalvarItem(AdicionarVendaItemRequest vendaItemRequest)
        {
            var vendaItem = VendaItem.Novo(vendaItemRequest);
            vendaItemRepository.Inserir(vendaItem);
            unitOfWork.Commit();
            return vendaItem;
        }

        private IEnumerable<ComandaItemDto> ListarComandaItens(AdicionarVendaItemRequest vendaItemRequest)
        {
            var comandaItens = vendaItemRepository.ListarComandaItens(vendaItemRequest.VendaId);
            comandaItens.ToList().Add(ComandaItemDto.Novo(vendaItemRequest));
            return comandaItens;
        }
    }
}