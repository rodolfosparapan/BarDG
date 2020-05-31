﻿using BarDG.Domain.Entities;

namespace BarDG.Domain.Interfaces
{
    public interface IVendaService
    {
        int AdicionarItem(VendaItem vendaItem);
        bool Finalizar(int vendaId);
        bool Resetar(int vendaId);
    }
}