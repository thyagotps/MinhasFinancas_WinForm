using DAL;
using Dapper;

namespace Model.ModuloRelatorios;

public class RelatorioRepository : BaseRepository, IRelatorioRepository
{

    public RelatorioRepository(Ado ado) : base(ado)
    {
            
    }


    public List<Relatorio> GetAll()
    {
        var relatorio1 = new Relatorio() { Id = 1, Nome = "1 - Relatório Rendas Mensais", Descricao = "Este relatório tem a finalidade de exibir todas as rendas mensais"};
        var relatorio2 = new Relatorio() { Id = 2, Nome = "2 - Relatório Rendas Anual", Descricao = "Este relatório tem a finalidade de exibir todas as rendas anual" };
        var relatorio3 = new Relatorio() { Id = 3, Nome = "3 - Relatório Despesas Mensais por Categoria", Descricao = "Este relatório tem a finalidade de exibir todas as despesas mensais por categoria" };
        var relatorio4 = new Relatorio() { Id = 4, Nome = "4 - Relatório Despesas Anual por Categoria", Descricao = "Este relatório tem a finalidade de exibir todas as despesas anual por categoria" };
        var relatorio5 = new Relatorio() { Id = 5, Nome = "5 - Relatório Despesas Mensais por Cartão", Descricao = "Este relatório tem a finalidade de exibir todas as despesas mensais por cartão" };
        var relatorio6 = new Relatorio() { Id = 6, Nome = "6 - Relatório Despesas Anual por Cartão", Descricao = "Este relatório tem a finalidade de exibir todas as despesas anual por cartão" };

        var relatorios = new List<Relatorio>();
        relatorios.Add(relatorio1);
        relatorios.Add(relatorio2);
        relatorios.Add(relatorio3);
        relatorios.Add(relatorio4);
        relatorios.Add(relatorio5);
        relatorios.Add(relatorio6);

        return relatorios;
    }

    

    public List<ReportMensal> GetRendasMensais(DateTime periodo)
    {
        string procName = @"PROC_RELATORIO_RENDAS_MENSAIS";

        var filtros = new DynamicParameters();
        filtros.Add("pPeriodo", periodo);

        var source = base.ExecutarProcedure<ReportMensal>(procName,filtros).ToList();

        return source;
    }

    public List<ReportAnual> GetRendasAnuais(DateTime periodo)
    {
        string procName = @"PROC_RELATORIO_RENDAS_ANUAIS";

        var filtros = new DynamicParameters();
        filtros.Add("pAno", periodo.Year);

        var source = base.ExecutarProcedure<ReportAnual>(procName, filtros).ToList();

        return source;
    }

    public List<ReportMensal> GetDespesasMensaisCategoria(DateTime periodo)
    {
        string procName = @"PROC_RELATORIO_DESPESAS_MENSAIS_CATEGORIA";

        var filtros = new DynamicParameters();
        filtros.Add("pPeriodo", periodo);

        var source = base.ExecutarProcedure<ReportMensal>(procName, filtros).ToList();

        return source;
    }

    public List<ReportAnual> GetDespesasAnualCategoria(DateTime periodo)
    {
        string procName = @"PROC_RELATORIO_DESPESAS_ANUAIS_CATEGORIA";

        var filtros = new DynamicParameters();
        filtros.Add("pPeriodo", periodo.Year);

        var source = base.ExecutarProcedure<ReportAnual>(procName, filtros).ToList();

        return source;
    }

    public List<ReportMensal> GetDespesasMensaisCartao(DateTime periodo)
    {
        string procName = @"PROC_RELATORIO_DESPESAS_MENSAIS_CARTAO";

        var filtros = new DynamicParameters();
        filtros.Add("pPeriodo", periodo);

        var source = base.ExecutarProcedure<ReportMensal>(procName, filtros).ToList();

        return source;
    }

    

    public List<ReportAnual> GetDespesasAnualCartao(DateTime periodo)
    {
        string procName = @"PROC_RELATORIO_DESPESAS_ANUAIS_CARTAO";

        var filtros = new DynamicParameters();
        filtros.Add("pPeriodo", periodo.Year);

        var source = base.ExecutarProcedure<ReportAnual>(procName, filtros).ToList();

        return source;
    }
}
