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
        var relatorio2 = new Relatorio() { Id = 2, Nome = "Relatório Entradas Anuais", Descricao = "Este relatório tem a finalidade de exibir todas as entradas anuais" };
        var relatorio3 = new Relatorio() { Id = 3, Nome = "Relatório Saídas Mensais por Categoria", Descricao = "Este relatório tem a finalidade de exibir todas as saídas mensais por categoria" };
        var relatorio4 = new Relatorio() { Id = 4, Nome = "Relatório Saídas Mensais por Cartão", Descricao = "Este relatório tem a finalidade de exibir todas as saídas mensais por cartão" };

        var relatorios = new List<Relatorio>();
        relatorios.Add(relatorio1);
        relatorios.Add(relatorio2);
        relatorios.Add(relatorio3);
        relatorios.Add(relatorio4);

        return relatorios;
    }

    

    public List<EntradaMensal> GetEntradasMensais(DateTime periodo)
    {
        string procName = @"PROC_RELATORIO_ENTRADAS_MENSAIS";

        var filtros = new DynamicParameters();
        filtros.Add("pPeriodo", periodo);

        var source = base.ExecutarProcedure<EntradaMensal>(procName,filtros).ToList();

        return source;
    }

    public List<EntradaAnuais> GetEntradasAnuais(DateTime periodo)
    {
        string procName = @"PROC_RELATORIO_ENTRADAS_ANUAIS";

        var filtros = new DynamicParameters();
        filtros.Add("pAno", periodo.Year);

        var source = base.ExecutarProcedure<EntradaAnuais>(procName, filtros).ToList();

        return source;
    }

    public List<SaidaMensalCategoria> GetSaidasMensaisCategoria(DateTime periodo)
    {
        string procName = @"PROC_RELATORIO_SAIDAS_MENSAIS_CATEGORIA";

        var filtros = new DynamicParameters();
        filtros.Add("pPeriodo", periodo);

        var source = base.ExecutarProcedure<SaidaMensalCategoria>(procName, filtros).ToList();

        return source;
    }

    public List<SaidaMensalCartao> GetSaidasMensaisCartao(DateTime periodo)
    {
        string procName = @"PROC_RELATORIO_SAIDAS_MENSAIS_CARTAO";

        var filtros = new DynamicParameters();
        filtros.Add("pPeriodo", periodo);

        var source = base.ExecutarProcedure<SaidaMensalCartao>(procName, filtros).ToList();

        return source;
    }
}
