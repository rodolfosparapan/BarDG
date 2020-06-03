using BarDG.Domain.Fiscal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BarDG.Data.EFConfiguration.Mappings
{
    internal class NotaMap : IEntityTypeConfiguration<Nota>
    {
        public void Configure(EntityTypeBuilder<Nota> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.Numero)
                .HasColumnType("varchar(20)")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(c => c.DataEmissao)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(c => c.ValorTotal)
                .HasColumnType("decimal(15,5)");

            builder.Property(c => c.ValorDesconto)
                .HasColumnType("decimal(15,5)");
        }
    }
}
