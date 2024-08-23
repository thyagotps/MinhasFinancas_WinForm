using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Model.ModuloMovimentoFinanceiro
{
    public class MovimentoFinanceiroMap : IEntityTypeConfiguration<MovimentoFinanceiro>
    {
        public void Configure(EntityTypeBuilder<MovimentoFinanceiro> builder)
        {
            builder.ToTable("MovimentoFinanceiro");

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
                .WithMany(p => p.MovimentoFinanceiros)
                .HasForeignKey(p => p.IdCartao);

            builder.HasOne(prop => prop.Categoria)
                .WithMany(p => p.MovimentoFinanceiros)
                .HasForeignKey(p => p.IdCategoria);
        }
    }
}
