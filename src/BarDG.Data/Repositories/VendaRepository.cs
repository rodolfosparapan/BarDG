﻿using BarDG.Data.EFConfiguration;
using BarDG.Domain.Entities;
using BarDG.Domain.Interfaces.Repositories;

namespace BarDG.Data.Repositories
{
    internal class VendaRepository : Repository<Venda>, IVendaRepository
    {
        public VendaRepository(BarDGContext context) : base(context)
        {
        }
    }
}