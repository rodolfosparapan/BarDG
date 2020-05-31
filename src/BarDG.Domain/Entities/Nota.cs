using System;
using System.Collections.Generic;

namespace BarDG.Domain.Entities
{
    public class Nota
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public DateTime DataEmissao { get; set; }
        public IEnumerable<NotaItem> Itens { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal ValorDesconto { get; set; }
    }
}