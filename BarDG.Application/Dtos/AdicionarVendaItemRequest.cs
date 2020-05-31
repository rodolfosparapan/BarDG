using BarDG.Application.Interfaces;

namespace BarDG.Application.Dtos
{
    public class AdicionarVendaItemRequest : RequestBase, IRequest
    {
        public string Comanda { get; set; }
        public VendaItemRequest Item { get; set; }

        public void Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}