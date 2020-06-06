using BarDG.Domain.Vendas.Enums;
using System.Collections.Generic;

namespace BarDG.Domain.Vendas.Entities
{
    public class Venda
    {
        public int Id { get; private set; }
        public decimal ValorTotal { get; private set; }
        public decimal ValorDesconto { get; private set; }
        public VendaStatus Status { get; private set; }
        public IEnumerable<VendaItem> Itens { get; set; }
        public int NotaId { get; set; }

        protected Venda() { }

        public static Venda Nova()
        {
            var venda = new Venda();
            venda.Resetar();
            return venda;
        }

        public void Finalizar()
        {
            Status = VendaStatus.Fechada;
        }

        public void Resetar()
        {
            Status = VendaStatus.Aberta;
            Itens = new List<VendaItem>();
        }
    }
}