using BarDG.Domain.Entities;
using BarDG.Domain.Interfaces;
using System;

namespace BarDG.Domain.Services
{
    internal class VendaService : ServiceBase, IVendaService
    {
        public int AdicionarItem(VendaItem vendaItem)
        {
            throw new NotImplementedException();
        }

        public bool Finalizar(int vendaId)
        {
            throw new NotImplementedException();
        }

        public bool Resetar(int vendaId)
        {
            throw new NotImplementedException();
        }
    }
}