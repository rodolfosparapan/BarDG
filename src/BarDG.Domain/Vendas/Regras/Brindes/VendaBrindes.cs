using BarDG.Domain.Vendas.Entities;
using System.Collections.Generic;

namespace BarDG.Domain.Vendas.Regras.Brindes
{
    internal class VendaBrindes : IVendaRegra
    {
        private List<IVendaBrinde> brindes;

        public VendaBrindes()
        {
            brindes = new List<IVendaBrinde>{
                //new BrindeAgua()
            };
        }

        public void Aplicar(IEnumerable<VendaItem> vendaItens, VendaItem novoItem)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<VendaItem> Listar(IEnumerable<VendaItem> itens, VendaItem novoItem)
        {
            var produtoBrindes = new List<VendaItem>();
            
            foreach(var brinde in brindes)
            {
                if(brinde.Analisar(itens, novoItem))
                {
                    produtoBrindes.Add(brinde.Obter());
                }
            }

            return produtoBrindes;
        }
    }
}