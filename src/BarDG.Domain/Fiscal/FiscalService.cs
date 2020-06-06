using BarDG.Domain.Fiscal.Interfaces;
using BarDG.Domain.Vendas.Entities;

namespace BarDG.Domain.Fiscal
{
    internal class FiscalService : IFiscalService
    {
        public bool GerarNota(Venda venda)
        {
            // Implementação aqui ...

            venda.NotaId = 1;
            return true;
        }
    }
}