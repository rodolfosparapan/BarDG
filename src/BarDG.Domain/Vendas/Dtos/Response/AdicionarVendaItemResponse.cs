using BarDG.Domain.Vendas.Entities;
using System.Collections.Generic;

namespace BarDG.Domain.Vendas.Dtos.Response
{
    public class AdicionarVendaItemResponse
    {
        public VendaItem ItemAdicionado { get; set; }
        public IEnumerable<ComandaItemDto> Brindes { get; set; }        
    }
}