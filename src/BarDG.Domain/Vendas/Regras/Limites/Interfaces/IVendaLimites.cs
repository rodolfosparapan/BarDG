using BarDG.Domain.Vendas.Dtos;
using Flunt.Notifications;
using System.Collections.Generic;

namespace BarDG.Domain.Vendas.Regras.Limites.Interfaces
{
    public interface IVendaLimites
    {
        bool Analisar(IEnumerable<ComandaItemDto> itens);
        IEnumerable<Notification> ListarMensagens();
    }
}