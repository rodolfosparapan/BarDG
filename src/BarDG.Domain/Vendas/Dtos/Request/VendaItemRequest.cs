using BarDG.Domain.Common;
using BarDG.Domain.Common.Interfaces;
using BarDG.Domain.Common.Resources;
using Flunt.Validations;

namespace BarDG.Domain.Vendas.Dtos.Request
{
    public class AdicionarVendaItemRequest : RequestBase, IRequest
    {
        public int VendaId { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        
        public void Validate()
        {
            var contract = new Contract();

            contract.IsNotNull(ProdutoId, nameof(ProdutoId), string.Format(Traducao.Campo_Obrigatorio, nameof(ProdutoId)));
            contract.IsNotNull(Quantidade, nameof(Quantidade), string.Format(Traducao.Campo_Obrigatorio, nameof(Quantidade)));
            
            AddNotifications(contract);
        }
    }
}