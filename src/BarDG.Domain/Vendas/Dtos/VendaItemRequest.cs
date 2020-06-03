using BarDG.Domain.Common;
using BarDG.Domain.Common.Interfaces;
using Flunt.Validations;

namespace BarDG.Domain.Vendas.Dtos
{
    public class VendaItemRequest : RequestBase, IRequest
    {
        public string Comanda { get; set; }
        public int VendaId { get; set; }
        public int ProdutoId { get; set; }
        public decimal Preco { get; set; }
        public decimal Desconto { get; set; }

        public void Validate()
        {
            var contract = new Contract();

            contract.IsNull(Comanda, nameof(Comanda), "Campo Comanda é obrigatório");
            contract.IsNull(VendaId, nameof(VendaId), "Campo vendaId é obrigatório");
            contract.IsNull(ProdutoId, nameof(ProdutoId), "Campo ProdutoId é obrigatório");

            AddNotifications(contract);
        }
    }
}