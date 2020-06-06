using System.Collections.Generic;

namespace BarDG.Domain.Vendas.Dtos.Response
{
    public class AdicionarVendaItemResponse
    {
        public int VendaId { get; set; }
        public IEnumerable<ComandaItemDto> Brindes { get; set; }
    }
}