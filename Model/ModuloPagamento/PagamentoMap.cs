using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Model.ModuloPagamento
{
    public class PagamentoMap : IEntityTypeConfiguration<Pagamento>
    {
        public void Configure(EntityTypeBuilder<Pagamento> builder)
        {
            builder.ToTable("Pagamento");

            builder.HasKey(prop => prop.Id);
            builder.Property(prop => prop.Id)
                .HasColumnType("int")
                .UseIdentityColumn();

            builder.Property(prop => prop.NrIdentificador)
               .HasColumnType("int")
               .IsRequired();

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

            builder.Property(prop => prop.DataVencimento)
                .IsRequired()
                .HasColumnName("DataVencimento")
                .HasColumnType("datetime");

            builder.Property(prop => prop.Situacao)
                .IsRequired()
                .HasColumnName("Situacao")
                .HasColumnType("varchar")
                .HasMaxLength(1);
        }
    }
}
