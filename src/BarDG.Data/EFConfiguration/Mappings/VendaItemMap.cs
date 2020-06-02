using BarDG.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BarDG.Data.EFConfiguration.Mappings
{
    internal class VendaItemMap : IEntityTypeConfiguration<VendaItem>
    {
        public void Configure(EntityTypeBuilder<VendaItem> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.ProdutoDescricao)
                .HasColumnType("varchar(255)")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(c => c.Preco)
                .HasColumnType("decimal(15,5)")
                .IsRequired();

            builder.Property(c => c.Desconto)
                .HasColumnType("decimal(15,5)");
        }
    }
}