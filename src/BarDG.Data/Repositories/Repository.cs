using BarDG.Data.EFConfiguration;
using BarDG.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BarDG.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly BarDGContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(BarDGContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual void Inserir(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public virtual TEntity ObterPorId(int id)
        {
            return DbSet.Find(id);
        }

        public virtual IQueryable<TEntity> Listar()
        {
            return DbSet;
        }

        public virtual void Atualizar(TEntity obj)
        {
            DbSet.Update(obj);
        }

        public virtual void Deletar(int id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public int Salvar()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
