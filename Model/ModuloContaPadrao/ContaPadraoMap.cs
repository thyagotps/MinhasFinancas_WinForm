using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Model.ModuloContaPadrao
{
    public class ContaPadraoMap : IEntityTypeConfiguration<ContaPadrao>
    {
        public void Configure(EntityTypeBuilder<ContaPadrao> builder)
        {
            builder.ToTable("ContaPadrao");

            builder.HasKey(prop => prop.Id);
            builder.Property(prop => prop.Id)
                .HasColumnType("int")
                .UseIdentityColumn();

            builder.Property(prop => prop.TipoMovimento)
               .IsRequired()
               .HasColumnName("TipoMovimento")
               .HasColumnType("varchar")
               .HasMaxLength(10);

            builder.Property(prop => prop.DataMovimento)
                .IsRequired()
                .HasColumnName("DataMovimento")
                .HasColumnType("datetime");

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

            builder.HasOne(prop => prop.Cartao)
                .WithMany(p => p.ContasPadrao)
                .HasForeignKey(p => p.IdCartao);

            builder.HasOne(prop => prop.Categoria)
                .WithMany(p => p.ContasPadrao)
                .HasForeignKey(p => p.IdCategoria);

            builder.Property(prop => prop.DataVencimento)
                .HasColumnName("DataVencimento")
                .HasColumnType("datetime");

            builder.Property(prop => prop.Situacao)
                .HasColumnName("Situacao")
                .HasColumnType("varchar")
                .HasMaxLength(1);
        }
    }
}
