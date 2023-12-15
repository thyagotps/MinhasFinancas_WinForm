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
        var relatorio1 = new Relatorio() { Id = 1, Nome = "Relatório Entradas Mensais", Descricao = "Este relatório tem a finalidade de exibir todas as entradas mensais"};
        var relatorio2 = new Relatorio() { Id = 2, Nome = "Relatório Entradas Anual", Descricao = "Este relatório tem a finalidade de exibir todas as entradas anual" };
        var relatorio3 = new Relatorio() { Id = 3, Nome = "Relatório Saídas Mensais por Categoria", Descricao = "Este relatório tem a finalidade de exibir todas as saídas mensais por categoria" };
        var relatorio4 = new Relatorio() { Id = 4, Nome = "Relatório Saídas Mensais por Cartão", Descricao = "Este relatório tem a finalidade de exibir todas as saídas mensais por cartão" };
        var relatorio5 = new Relatorio() { Id = 5, Nome = "Relatório Saídas Anual por Categoria", Descricao = "Este relatório tem a finalidade de exibir todas as saídas anual por categoria" };
        var relatorio6 = new Relatorio() { Id = 6, Nome = "Relatório Saídas Anual por Cartão", Descricao = "Este relatório tem a finalidade de exibir todas as saídas anual por cartão" };

        var relatorios = new List<Relatorio>();
        relatorios.Add(relatorio1);
        relatorios.Add(relatorio2);
        relatorios.Add(relatorio3);
        relatorios.Add(relatorio4);
        relatorios.Add(relatorio5);
        relatorios.Add(relatorio6);

        return relatorios;
    }

    

    public List<ReportMensal> GetEntradasMensais(DateTime periodo)
    {
        string procName = @"PROC_RELATORIO_ENTRADAS_MENSAIS";

        var filtros = new DynamicParameters();
        filtros.Add("pPeriodo", periodo);

        var source = base.ExecutarProcedure<ReportMensal>(procName,filtros).ToList();

        return source;
    }

    public List<ReportAnual> GetEntradasAnuais(DateTime periodo)
    {
        string procName = @"PROC_RELATORIO_ENTRADAS_ANUAIS";

        var filtros = new DynamicParameters();
        filtros.Add("pAno", periodo.Year);

        var source = base.ExecutarProcedure<ReportAnual>(procName, filtros).ToList();

        return source;
    }

    public List<ReportMensal> GetSaidasMensaisCategoria(DateTime periodo)
    {
        string procName = @"PROC_RELATORIO_SAIDAS_MENSAIS_CATEGORIA";

        var filtros = new DynamicParameters();
        filtros.Add("pPeriodo", periodo);

        var source = base.ExecutarProcedure<ReportMensal>(procName, filtros).ToList();

        return source;
    }

    public List<ReportMensal> GetSaidasMensaisCartao(DateTime periodo)
    {
        string procName = @"PROC_RELATORIO_SAIDAS_MENSAIS_CARTAO";

        var filtros = new DynamicParameters();
        filtros.Add("pPeriodo", periodo);

        var source = base.ExecutarProcedure<ReportMensal>(procName, filtros).ToList();

        return source;
    }

    public List<ReportAnual> GetSaidasAnualCategoria(DateTime periodo)
    {
        string procName = @"PROC_RELATORIO_SAIDAS_ANUAIS_CATEGORIA";

        var filtros = new DynamicParameters();
        filtros.Add("pPeriodo", periodo.Year);

        var source = base.ExecutarProcedure<ReportAnual>(procName, filtros).ToList();

        return source;
    }

    public List<ReportAnual> GetSaidasAnualCartao(DateTime periodo)
    {
        string procName = @"PROC_RELATORIO_SAIDAS_ANUAIS_CARTAO";

        var filtros = new DynamicParameters();
        filtros.Add("pPeriodo", periodo.Year);

        var source = base.ExecutarProcedure<ReportAnual>(procName, filtros).ToList();

        return source;
    }
}
