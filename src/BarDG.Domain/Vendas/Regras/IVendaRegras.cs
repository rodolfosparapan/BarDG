using BarDG.Domain.Vendas.Regras.Brindes.Interfaces;
using BarDG.Domain.Vendas.Regras.Descontos.Interfaces;
using BarDG.Domain.Vendas.Regras.Limites.Interfaces;

namespace BarDG.Domain.Vendas.Regras
{
    internal interface IVendaRegras
    {
        IVendaBrindes Brindes { get; }
        IVendaDescontos Descontos { get; }
        IVendaLimites Limites { get; }
    }
}