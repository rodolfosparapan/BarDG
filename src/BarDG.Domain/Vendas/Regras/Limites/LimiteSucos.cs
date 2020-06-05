using BarDG.Domain.Produtos.Enums;
using BarDG.Domain.Vendas.Dtos;
using BarDG.Domain.Vendas.Regras.Limites.Interfaces;
using Flunt.Notifications;
using System.Collections.Generic;
using System.Linq;

namespace BarDG.Domain.Vendas.Regras.Limites
{
    public class LimiteSucos : IItemLimite
    {
        public bool Analisar(IEnumerable<ComandaItemDto> itens)
        {
            var maximoSucos = 3;
            return itens.Where(i => i.ProdutoTipo == ProdutoTipo.Suco).Sum(i => i.Quantidade) > maximoSucos;
        }

        public Notification ObterNotificacao()
        {
            return new Notification("limite", "Não é permitido comprar mais de 3 sucos por comanda");
        }
    }
}