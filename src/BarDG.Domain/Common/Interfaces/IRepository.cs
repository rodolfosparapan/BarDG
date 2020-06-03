using System;
using System.Linq;

namespace BarDG.Domain.Common.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        void Inserir(TEntity obj);
        TEntity ObterPorId(int id);
        IQueryable<TEntity> Listar();
        void Atualizar(TEntity obj);
        void Deletar(int id);
        int Salvar();
    }
}