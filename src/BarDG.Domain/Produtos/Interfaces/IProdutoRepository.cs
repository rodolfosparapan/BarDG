using BarDG.Domain.Common.Interfaces;
using BarDG.Domain.Produtos.Entities;
using System.Collections.Generic;

namespace BarDG.Domain.Produtos.Interfaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Produto ObterPorCodigo(string codigo);
        IEnumerable<Produto> ListarConhaqueECervejas();
    }
}