using BarDG.Domain.Vendas.Dtos;
using BarDG.Domain.Vendas.Entities;
using Flunt.Notifications;
using System.Collections.Generic;

namespace BarDG.Domain.Vendas.Regras.Limites.Interfaces
{
    interface IItemLimite
    {
        bool Analisar(IEnumerable<ComandaItemDto> itens);
        Notification ObterNotificacao();
    }
}