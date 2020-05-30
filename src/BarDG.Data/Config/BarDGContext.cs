using BarDG.Domain.Fiscal.Entities;
using BarDG.Domain.Produtos.Entity;
using BarDG.Domain.Vendas.Entities;
using Microsoft.EntityFrameworkCore;

namespace BarDG.Data.Config
{
    public class BarDGContext : DbContext
    {
        public BarDGContext(DbContextOptions<BarDGContext> options) : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Venda> Vendas { get; set; }     
        public DbSet<Nota> Notas { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>().ToTable("Produto");
            modelBuilder.Entity<Venda>().ToTable("Venda");
            modelBuilder.Entity<VendaItem>().ToTable("VendaItem");
            modelBuilder.Entity<Nota>().ToTable("Nota");
            modelBuilder.Entity<NotaItem>().ToTable("NotaItem");
        }

    }
}