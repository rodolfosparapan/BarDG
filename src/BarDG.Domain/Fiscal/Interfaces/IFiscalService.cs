using BarDG.Domain.Vendas.Entities;

namespace BarDG.Domain.Fiscal.Interfaces
{
    public interface IFiscalService
    {
        bool GerarNota(Venda venda);
    }
}