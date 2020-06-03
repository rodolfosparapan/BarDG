using BarDG.Data.EFConfiguration.Mappings;
using BarDG.Domain.Fiscal.Entities;
using BarDG.Domain.Produtos.Entities;
using BarDG.Domain.Usuarios.Entities;
using BarDG.Domain.Vendas.Entities;
using Microsoft.EntityFrameworkCore;

namespace BarDG.Data.EFConfiguration
{
    public class BarDGContext : DbContext
    {
        public BarDGContext(DbContextOptions<BarDGContext> options) : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Venda> Vendas { get; set; }     
        public DbSet<Nota> Notas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>().ToTable("Produto");
            modelBuilder.Entity<Venda>().ToTable("Venda");
            modelBuilder.Entity<VendaItem>().ToTable("VendaItem");
            modelBuilder.Entity<Nota>().ToTable("Nota");
            modelBuilder.Entity<NotaItem>().ToTable("NotaItem");
            modelBuilder.Entity<Usuario>().ToTable("Usuario");

            modelBuilder.ApplyConfiguration(new NotaItemMap());
            modelBuilder.ApplyConfiguration(new NotaMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new VendaItemMap());
            modelBuilder.ApplyConfiguration(new VendaMap());
        }
    }
}