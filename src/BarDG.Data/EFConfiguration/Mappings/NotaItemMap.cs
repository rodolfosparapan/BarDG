using BarDG.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BarDG.Data.EFConfiguration.Mappings
{
    internal class NotaItemMap : IEntityTypeConfiguration<NotaItem>
    {
        public void Configure(EntityTypeBuilder<NotaItem> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.Descricao)
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