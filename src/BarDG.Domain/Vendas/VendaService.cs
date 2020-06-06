using BarDG.Domain.Common;
using BarDG.Domain.Common.Interfaces;
using BarDG.Domain.Fiscal.Interfaces;
using BarDG.Domain.Produtos.Interfaces;
using BarDG.Domain.Vendas.Dtos;
using BarDG.Domain.Vendas.Dtos.Request;
using BarDG.Domain.Vendas.Dtos.Response;
using BarDG.Domain.Vendas.Entities;
using BarDG.Domain.Vendas.Enums;
using BarDG.Domain.Vendas.Interfaces;
using BarDG.Domain.Vendas.Regras;
using System;
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
        private readonly IFiscalService fiscalService;
        private readonly IVendaRegras vendaRegras;

        public VendaService(
            IUnitOfWork unitOfWork,
            IVendaRepository vendaRepository, 
            IVendaItemRepository vendaItemRepository,
            IProdutoRepository produtoRepository,
            IFiscalService fiscalService,
            IVendaRegras vendaRegras)
        {
            this.unitOfWork = unitOfWork;
            this.vendaRepository = vendaRepository;
            this.vendaItemRepository = vendaItemRepository;
            this.produtoRepository = produtoRepository;
            this.fiscalService = fiscalService;
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
            vendaRegras.Brindes.Adicionar(comandaItens);
            
            SalvarItens(comandaItens, vendaItemRequest);

            return new AdicionarVendaItemResponse
            {
                VendaId = comandaItens.First().VendaId,
                Brindes = comandaItens.Where(i => i.Brinde && i.State == Tracking.Inserted)
            };
        }

        public bool RemoverItem(int vendaItemId)
        {
            try
            {
                vendaItemRepository.Deletar(vendaItemId);
                unitOfWork.Commit();
            }
            catch
            {
                AdicionarNotificacao("removerItem", "Não foi possível remover o item");
                return false;
            }
            
            return true;
        }

        public IEnumerable<ComandaItemResponse> Listar(int vendaId)
        {
            return vendaItemRepository.ListarComandaItensResponse(vendaId);
        }

        public Venda Obter(int vendaId)
        {
            return vendaRepository.ObterPorId(vendaId);
        }

        public VendaStatus? Finalizar(int vendaId)
        {
            if (vendaId == 0)
            {
                AdicionarNotificacao(nameof(vendaId), "Campo obrigatório!");
                return null;
            }

            var venda = vendaRepository.ObterPorId(vendaId);
            venda.Finalizar();

            try
            {
                fiscalService.GerarNota(venda);
                vendaRepository.Atualizar(venda);
                unitOfWork.Commit();
            }
            catch(Exception ex)
            {
                AdicionarNotificacao("finalizarVenda", "Erro ao Finalizar a venda. Ex:" + ex.Message);
            }

            return venda.Status;
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

            try
            {
                vendaRepository.Atualizar(venda);
                vendaItemRepository.LimparItens(venda.Id);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                AdicionarNotificacao("resetarVenda", "Erro ao Resetar a venda. Ex:" + ex.Message);
            }

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
                var vendaItem = VendaItem.Novo(item);
                itensInserir.Add(vendaItem);
                item.VendaItemId = vendaItem.Id;
            }

            vendaItemRepository.Salvar(itensInserir, itensAtualizar);
            unitOfWork.Commit();

            PreencherVendaItemIds(itens, itensInserir);
        }

        private void PreencherVendaItemIds(IEnumerable<ComandaItemDto> itens, List<VendaItem> itensInserir)
        {
            foreach (var item in itens.Where(i => i.State == Tracking.Inserted))
            {
                var vendaItemId = itensInserir.FirstOrDefault(vi => vi.ProdutoId == item.ProdutoId);
                item.VendaItemId = vendaItemId != null ? vendaItemId.Id : 0;
            }
        }

        private void InserirVenda(IEnumerable<ComandaItemDto> itens)
        {
            var venda = Venda.Nova();
            vendaRepository.Inserir(venda);
            unitOfWork.Commit();
            itens.First().VendaId = venda.Id;
        }

        private IList<ComandaItemDto> ListarComandaItens(AdicionarVendaItemRequest vendaItemRequest)
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