using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Model.ModuloCartao
{
    public class CartaoMap : IEntityTypeConfiguration<Cartao>
    {
        public void Configure(EntityTypeBuilder<Cartao> builder)
        {
            builder.ToTable("Cartao");

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
                .HasMaxLength(50);

            builder.HasMany(prop => prop.MovimentoFinanceiros);
        }
    }
}
