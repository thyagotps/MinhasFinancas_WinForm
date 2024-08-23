using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Model.ModuloFaturaEmAberto
{
    public class FaturaEmAbertoMap : IEntityTypeConfiguration<FaturaEmAberto>
    {
        public void Configure(EntityTypeBuilder<FaturaEmAberto> builder)
        {
            builder.ToTable("FaturaEmAberto");

            builder.HasKey(prop => prop.Id);
            builder.Property(prop => prop.Id)
                .HasColumnType("int")
                .UseIdentityColumn();

            builder.Property(prop => prop.Descricao)
               .IsRequired()
               .HasColumnName("Descricao")
               .HasColumnType("varchar")
               .HasMaxLength(100);

            builder.Property(prop => prop.Valor)
               .IsRequired()
               .HasColumnName("Valor")
               .HasColumnType("decimal")
               .HasPrecision(19, 2);

            builder.Property(prop => prop.DataCompra)
                .IsRequired()
                .HasColumnName("DataCompra")
                .HasColumnType("datetime");
        }
    }
}
