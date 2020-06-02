using BarDG.Domain.Enums;
using System.Collections.Generic;

namespace BarDG.Domain.Entities
{
    public class Venda
    {
        public int Id { get; private set; }
        public decimal ValorTotal { get; private set; }
        public decimal ValorDesconto { get; private set; }
        public VendaStatus Status { get; private set; }
        public IEnumerable<VendaItem> Itens { get; set; }

        protected Venda() { }

        public Venda(int id, decimal valorTotal, decimal valorDesconto, VendaStatus status, IEnumerable<VendaItem> itens)
        {
            Id = id;
            ValorTotal = valorTotal;
            ValorDesconto = valorDesconto;
            Status = status;
            Itens = itens;
        }

        public static Venda Nova()
        {
            var venda = new Venda();
            venda.Resetar();
            return venda;
        }

        public void Finalizar()
        {
            Status = VendaStatus.Finalizada;
        }

        public void Resetar()
        {
            Status = VendaStatus.Orcamento;
            Itens = new List<VendaItem>();
        }
    }
}