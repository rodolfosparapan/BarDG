using BarDG.Application.Interfaces;

namespace BarDG.Application.Dtos
{
    public class VendaItemRequest : RequestBase, IRequest
    {
        public int ProdutoId { get; set; }
        public decimal Preco { get; set; }
        public decimal Desconto { get; set; }

        public void Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}