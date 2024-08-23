using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Model.ModuloRelatorios
{
    public class ReportMensalMap : IEntityTypeConfiguration<ReportMensal>
    {
        public void Configure(EntityTypeBuilder<ReportMensal> builder)
        {
            builder.HasNoKey();
        }
    }
}
