using Microsoft.EntityFrameworkCore;
using Model.ModuloCartao;
using Model.ModuloCategoria;
using Model.ModuloFaturaEmAberto;
using Model.ModuloMovimentoFinanceiro;
using Model.ModuloPagamento;
using Model.ModuloRelatorios;


namespace Model
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            //ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            //ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<Cartao> Cartao { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<FaturaEmAberto> FaturaEmAberto { get; set; }
        public DbSet<Pagamento> Pagamento { get; set; }
        public DbSet<MovimentoFinanceiro> MovimentoFinanceiro { get; set; }
        public DbSet<ReportMensal> ReportMensal { get; set; }
        public DbSet<ReportAnual> ReportAnual { get; set; }
        public DbSet<ReportBalancete> ReportBalancete { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cartao>(entity =>
            {
                entity.HasKey(prop => prop.Id);
                entity.Property(p => p.Id).UseIdentityColumn();
                entity.HasMany(prop => prop.MovimentoFinanceiros);
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(prop => prop.Id);
                entity.Property(p => p.Id).UseIdentityColumn();
                entity.HasMany(prop => prop.MovimentoFinanceiros);
            });

            modelBuilder.Entity<MovimentoFinanceiro>(entity =>
            {
                entity.HasKey(prop => prop.Id);
                entity.Property(p => p.Id).UseIdentityColumn();

                entity.HasOne(prop => prop.Cartao)
                .WithMany(p => p.MovimentoFinanceiros)
                .HasForeignKey(p => p.IdCartao);

                entity.HasOne(prop => prop.Categoria)
                .WithMany(p => p.MovimentoFinanceiros)
                .HasForeignKey(p => p.IdCategoria);
            });

            modelBuilder.Entity<ReportMensal>().HasNoKey();
            modelBuilder.Entity<ReportAnual>().HasNoKey();
            modelBuilder.Entity<ReportBalancete>().HasNoKey();
        }
    }
}
