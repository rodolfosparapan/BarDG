using System;
using System.Collections.Generic;
using System.Text;

namespace BarDG.Domain.Vendas.Entities
{
    public class Venda
    {
        public int Id { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal ValorDesconto { get; set; }
    }
}