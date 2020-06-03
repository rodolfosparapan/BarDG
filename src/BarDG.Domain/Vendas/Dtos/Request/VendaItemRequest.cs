using BarDG.Domain.Common;
using BarDG.Domain.Common.Interfaces;
using BarDG.Domain.Common.Resources;
using BarDG.Domain.Produtos.Enums;
using Flunt.Validations;

namespace BarDG.Domain.Vendas.Dtos.Request
{
    public class AdicionarVendaItemRequest : RequestBase, IRequest
    {
        public string Comanda { get; set; }
        public int VendaId { get; set; }
        public int ProdutoId { get; set; }
        public ProdutoTipo ProdutoTipo { get; set; }
        public decimal Preco { get; set; }
        public decimal Desconto { get; set; }

        public void Validate()
        {
            var contract = new Contract();

            contract.IsNull(Comanda, nameof(Comanda), string.Format(Traducao.Campo_Obrigatorio, nameof(Comanda)));
            contract.IsNull(VendaId, nameof(VendaId), string.Format(Traducao.Campo_Obrigatorio, nameof(VendaId)));
            contract.IsNull(ProdutoId, nameof(ProdutoId), string.Format(Traducao.Campo_Obrigatorio, nameof(ProdutoId)));
            contract.IsNull(ProdutoTipo, nameof(ProdutoTipo), string.Format(Traducao.Campo_Obrigatorio, nameof(ProdutoTipo)));

            AddNotifications(contract);
        }
    }
}