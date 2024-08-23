using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Model.ModuloCategoria
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("Categoria");

            builder.HasKey(prop => prop.Id);
            builder.Property(prop => prop.Id)
                .HasColumnType("int")
                .UseIdentityColumn();

            builder.Property(prop => prop.Descricao)
                .IsRequired()
                .HasColumnName("Descricao")
                .HasColumnType("varchar")
                .HasMaxLength(100);

            builder.Property(prop => prop.Tipo)
                .HasColumnName("Tipo")
                .HasColumnType("varchar")
                .HasMaxLength(10);

            builder.HasMany(prop => prop.MovimentoFinanceiros);
        }
    }
}
