using DAL;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Model.ModuloRelatorios;

public class RelatorioRepository : BaseRepositoryEF<Relatorio>, IRelatorioRepository
{
    private readonly AppDbContext _appDbContext;
    private readonly IAdo _ado;

    public RelatorioRepository(AppDbContext appDbContext, IAdo ado) : base(appDbContext, ado)
    {
        _ado = ado;
        _appDbContext = appDbContext;
    }


    public List<Relatorio> GetAll()
    {
        var relatorio1 = new Relatorio() { Id = 1, Nome = "1 - Relatório Rendas Mensais", Descricao = "Este relatório tem a finalidade de exibir todas as rendas mensais"};
        var relatorio2 = new Relatorio() { Id = 2, Nome = "2 - Relatório Rendas Anual", Descricao = "Este relatório tem a finalidade de exibir todas as rendas anual" };
        var relatorio3 = new Relatorio() { Id = 3, Nome = "3 - Relatório Despesas Mensais por Categoria", Descricao = "Este relatório tem a finalidade de exibir todas as despesas mensais por categoria" };
        var relatorio4 = new Relatorio() { Id = 4, Nome = "4 - Relatório Despesas Anual por Categoria", Descricao = "Este relatório tem a finalidade de exibir todas as despesas anual por categoria" };
        var relatorio5 = new Relatorio() { Id = 5, Nome = "5 - Relatório Despesas Mensais por Cartão", Descricao = "Este relatório tem a finalidade de exibir todas as despesas mensais por cartão" };
        var relatorio6 = new Relatorio() { Id = 6, Nome = "6 - Relatório Despesas Anual por Cartão", Descricao = "Este relatório tem a finalidade de exibir todas as despesas anual por cartão" };
        var relatorio7 = new Relatorio() { Id = 7, Nome = "7 - Relatório Balancete", Descricao = "Este relatório tem a finalidade de exibir o balancete" };

        var relatorios = new List<Relatorio>();
        relatorios.Add(relatorio1);
        relatorios.Add(relatorio2);
        relatorios.Add(relatorio3);
        relatorios.Add(relatorio4);
        relatorios.Add(relatorio5);
        relatorios.Add(relatorio6);
        relatorios.Add(relatorio7);

        return relatorios;
    }

    public List<ReportMensal> GetRendasMensais_Dapper(DateTime periodo)
    {
        string procName = @"PROC_RELATORIO_RENDAS_MENSAIS";

        var filtros = new DynamicParameters();
        filtros.Add("pPeriodo", periodo);

        var source = base.ExecutarProcedure<ReportMensal>(procName, filtros).ToList();

        return source;
    }

    public List<ReportMensal> GetRendasMensais(DateTime periodo)
    {
        var param = new SqlParameter()
        {
            ParameterName = "@pPeriodo",
            SqlDbType = System.Data.SqlDbType.DateTime,
            Direction = System.Data.ParameterDirection.Input,
            Value = periodo
        };

        var source = _appDbContext.ReportMensal.FromSqlRaw("PROC_RELATORIO_RENDAS_MENSAIS @pPeriodo", param).ToList();

        return source;
    }

    public List<ReportAnual> GetRendasAnuais_Dapper(DateTime periodo)
    {
        string procName = @"PROC_RELATORIO_RENDAS_ANUAIS";

        var filtros = new DynamicParameters();
        filtros.Add("pAno", periodo.Year);

        var source = base.ExecutarProcedure<ReportAnual>(procName, filtros).ToList();

        return source;
    }

    public List<ReportAnual> GetRendasAnuais(DateTime periodo)
    {
        var param = new SqlParameter()
        {
            ParameterName = "@pPeriodo",
            SqlDbType = System.Data.SqlDbType.Int,
            Direction = System.Data.ParameterDirection.Input,
            Value = periodo.Year
        };

        var source = _appDbContext.ReportAnual.FromSqlRaw("PROC_RELATORIO_RENDAS_ANUAIS @pPeriodo", param).ToList();

        return source;
    }

    public List<ReportMensal> GetDespesasMensaisCategoria_Dapper(DateTime periodo)
    {
        string procName = @"PROC_RELATORIO_DESPESAS_MENSAIS_CATEGORIA";

        var filtros = new DynamicParameters();
        filtros.Add("pPeriodo", periodo);

        var source = base.ExecutarProcedure<ReportMensal>(procName, filtros).ToList();

        return source;
    }

    public List<ReportMensal> GetDespesasMensaisCategoria(DateTime periodo)
    {
        var param = new SqlParameter()
        {
            ParameterName = "@pPeriodo",
            SqlDbType = System.Data.SqlDbType.DateTime,
            Direction = System.Data.ParameterDirection.Input,
            Value = periodo
        };

        var source = _appDbContext.ReportMensal.FromSqlRaw("PROC_RELATORIO_DESPESAS_MENSAIS_CATEGORIA @pPeriodo", param).ToList();

        return source;
    }

    public List<ReportAnual> GetDespesasAnualCategoria_Dapper(DateTime periodo)
    {
        string procName = @"PROC_RELATORIO_DESPESAS_ANUAIS_CATEGORIA";

        var filtros = new DynamicParameters();
        filtros.Add("pPeriodo", periodo.Year);

        var source = base.ExecutarProcedure<ReportAnual>(procName, filtros).ToList();

        return source;
    }

    public List<ReportAnual> GetDespesasAnualCategoria(DateTime periodo)
    {
        var param = new SqlParameter()
        {
            ParameterName = "@pPeriodo",
            SqlDbType = System.Data.SqlDbType.Int,
            Direction = System.Data.ParameterDirection.Input,
            Value = periodo.Year
        };

        var source = _appDbContext.ReportAnual.FromSqlRaw("PROC_RELATORIO_DESPESAS_ANUAIS_CATEGORIA @pPeriodo", param).ToList();

        return source;
    }

    public List<ReportMensal> GetDespesasMensaisCartao_Dapper(DateTime periodo)
    {
        string procName = @"PROC_RELATORIO_DESPESAS_MENSAIS_CARTAO";

        var filtros = new DynamicParameters();
        filtros.Add("pPeriodo", periodo);

        var source = base.ExecutarProcedure<ReportMensal>(procName, filtros).ToList();

        return source;
    }

    public List<ReportMensal> GetDespesasMensaisCartao(DateTime periodo)
    {
        var param = new SqlParameter()
        {
            ParameterName = "@pPeriodo",
            SqlDbType = System.Data.SqlDbType.DateTime,
            Direction = System.Data.ParameterDirection.Input,
            Value = periodo
        };

        var source = _appDbContext.ReportMensal.FromSqlRaw("PROC_RELATORIO_DESPESAS_MENSAIS_CARTAO @pPeriodo", param).ToList();

        return source;
    }

    public List<ReportAnual> GetDespesasAnualCartao_Dapper(DateTime periodo)
    {
        string procName = @"PROC_RELATORIO_DESPESAS_ANUAIS_CARTAO";

        var filtros = new DynamicParameters();
        filtros.Add("pPeriodo", periodo.Year);

        var source = base.ExecutarProcedure<ReportAnual>(procName, filtros).ToList();

        return source;
    }

    public List<ReportAnual> GetDespesasAnualCartao(DateTime periodo)
    {
        var param = new SqlParameter()
        {
            ParameterName = "@pPeriodo",
            SqlDbType = System.Data.SqlDbType.Int,
            Direction = System.Data.ParameterDirection.Input,
            Value = periodo.Year
        };

        var source = _appDbContext.ReportAnual.FromSqlRaw("PROC_RELATORIO_DESPESAS_ANUAIS_CARTAO @pPeriodo", param).ToList();

        return source;
    }

    public List<ReportBalancete> GetBalancete_Dapper(DateTime periodo)
    {
        string procName = @"PROC_RELATORIO_BALANCETE";

        var filtros = new DynamicParameters();
        filtros.Add("pPeriodo", periodo);

        var source = base.ExecutarProcedure<ReportBalancete>(procName, filtros).ToList();

        return source;
    }

    public List<ReportBalancete> GetBalancete(DateTime periodo)
    {
        var param = new SqlParameter()
        {
            ParameterName = "@pPeriodo",
            SqlDbType = System.Data.SqlDbType.DateTime,
            Direction = System.Data.ParameterDirection.Input,
            Value = periodo
        };

        var source = _appDbContext.ReportBalancete.FromSqlRaw("PROC_RELATORIO_BALANCETE @pPeriodo", param).ToList();

        return source;
    }


}
