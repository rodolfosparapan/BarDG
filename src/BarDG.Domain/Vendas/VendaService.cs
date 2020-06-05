using BarDG.Domain.Common;
using BarDG.Domain.Common.Interfaces;
using BarDG.Domain.Produtos.Interfaces;
using BarDG.Domain.Vendas.Dtos;
using BarDG.Domain.Vendas.Dtos.Request;
using BarDG.Domain.Vendas.Dtos.Response;
using BarDG.Domain.Vendas.Entities;
using BarDG.Domain.Vendas.Enums;
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
        private readonly IProdutoRepository produtoRepository;
        private readonly IVendaRegras vendaRegras;

        public VendaService(
            IUnitOfWork unitOfWork,
            IVendaRepository vendaRepository, 
            IVendaItemRepository vendaItemRepository,
            IProdutoRepository produtoRepository,
            IVendaRegras vendaRegras)
        {
            this.unitOfWork = unitOfWork;
            this.vendaRepository = vendaRepository;
            this.vendaItemRepository = vendaItemRepository;
            this.produtoRepository = produtoRepository;
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

            SalvarItens(comandaItens, vendaItemRequest);

            return new AdicionarVendaItemResponse
            {
                VendaId = comandaItens.First().VendaId,
                Brindes = vendaRegras.Brindes.Listar(comandaItens)
            };
        }

        public IEnumerable<ComandaItemResponse> Listar(int vendaId)
        {
            return vendaItemRepository.ListarComandaItensResponse(vendaId);
        }

        public Venda Obter(int vendaId)
        {
            return vendaRepository.ObterPorId(vendaId);
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
            vendaItemRepository.LimparItens(venda.Id);
            unitOfWork.Commit();

            return true;
        }

        private void SalvarItens(IEnumerable<ComandaItemDto> itens, AdicionarVendaItemRequest vendaItemRequest)
        {
            if(vendaItemRequest.VendaId == 0)
            {
                InserirVenda(itens);
            }

            var itensAtualizar = new List<VendaItem>();
            foreach (var item in itens.Where(i => i.State == Tracking.Modified))
            {
                itensAtualizar.Add(VendaItem.Novo(item));
            }

            var itensInserir = new List<VendaItem>();
            foreach (var item in itens.Where(i => i.State == Tracking.Inserted))
            {
                itensInserir.Add(VendaItem.Novo(item));
            }

            vendaItemRepository.Salvar(itensInserir, itensAtualizar);
            
            unitOfWork.Commit();
        }

        private void InserirVenda(IEnumerable<ComandaItemDto> itens)
        {
            var venda = Venda.Nova();
            vendaRepository.Inserir(venda);
            unitOfWork.Commit();
            itens.First().VendaId = venda.Id;
        }

        private IEnumerable<ComandaItemDto> ListarComandaItens(AdicionarVendaItemRequest vendaItemRequest)
        {
            var comandaItens = vendaItemRepository.ListarComandaItens(vendaItemRequest.VendaId).ToList();
            
            var produto = produtoRepository.ObterPorId(vendaItemRequest.ProdutoId);
            var itemExistente = comandaItens.FirstOrDefault(i => i.ProdutoId == vendaItemRequest.ProdutoId);
            if (itemExistente == null)
            {
                comandaItens.Add(ComandaItemDto.Novo(vendaItemRequest, produto));
            }
            else
            {
                itemExistente.Atualizar(vendaItemRequest, produto);
            }
            
            return comandaItens;
        }
    }
}