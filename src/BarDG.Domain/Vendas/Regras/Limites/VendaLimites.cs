using BarDG.Domain.Vendas.Dtos;
using BarDG.Domain.Vendas.Regras.Limites;
using BarDG.Domain.Vendas.Regras.Limites.Interfaces;
using Flunt.Notifications;
using System.Collections.Generic;
using System.Linq;

namespace BBarDG.Domain.Vendas.Regras.Limites
{
    internal class VendaLimites : IVendaLimites
    {
        private List<IItemLimite> itemLimites;
        private List<Notification> notificacoes;

        public VendaLimites()
        {
            itemLimites = new List<IItemLimite>
            {
                new LimiteSucos()
            };
        }

        public bool Analisar(IEnumerable<ComandaItemDto> itens)
        {
            notificacoes.Clear();

            foreach (var limite in itemLimites)
            {
                if(limite.Analisar(itens))
                {
                    notificacoes.Add(limite.ObterNotificacao());
                }
            }

            return notificacoes.Any();
        }

        public IEnumerable<Notification> ListarMensagens()
        {
            return notificacoes;
        }
    }
}