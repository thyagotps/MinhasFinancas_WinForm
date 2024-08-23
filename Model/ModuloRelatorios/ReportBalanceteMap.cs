using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Model.ModuloRelatorios
{
    public class ReportBalanceteMap : IEntityTypeConfiguration<ReportBalancete>
    {
        public void Configure(EntityTypeBuilder<ReportBalancete> builder)
        {
            builder.HasNoKey();
        }
    }
}
