using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Model.ModuloRelatorios
{
    public class ReportAnualMap : IEntityTypeConfiguration<ReportAnual>
    {
        public void Configure(EntityTypeBuilder<ReportAnual> builder)
        {
            builder.HasNoKey();
        }
    }
}
