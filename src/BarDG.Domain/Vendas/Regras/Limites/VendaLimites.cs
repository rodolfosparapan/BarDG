using BarDG.Domain.Vendas.Dtos;
using BarDG.Domain.Vendas.Regras.Limites;
using BarDG.Domain.Vendas.Regras.Limites.Interfaces;
using Flunt.Notifications;
using System.Collections.Generic;
using System.Linq;

namespace BBarDG.Domain.Vendas.Regras.Limites
{
    public class VendaLimites : IVendaLimites
    {
        private readonly List<IItemLimite> itemLimites;
        private readonly List<Notification> notificacoes;

        public VendaLimites()
        {
            notificacoes = new List<Notification>();

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