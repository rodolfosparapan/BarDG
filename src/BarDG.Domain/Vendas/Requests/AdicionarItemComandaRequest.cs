namespace BarDG.Domain.Vendas.Requests
{
    public class AdicionarItemComandaRequest
    {
        public string CodigoComanda { get; set; }

        public VendaItemRequest VendaItem { get; set; }
    }
}