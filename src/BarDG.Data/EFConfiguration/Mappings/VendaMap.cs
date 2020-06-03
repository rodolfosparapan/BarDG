using BarDG.Domain.Vendas.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BarDG.Data.EFConfiguration.Mappings
{
    internal class VendaMap : IEntityTypeConfiguration<Venda>
    {
        public void Configure(EntityTypeBuilder<Venda> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.ValorTotal)
                .HasColumnType("decimal(15,5)")
                .IsRequired();

            builder.Property(c => c.ValorDesconto)
                .HasColumnType("decimal(15,5)");
        }
    }
}