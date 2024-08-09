namespace Model.ModuloRelatorios
{
    public interface IRelatorioRepository
    {
        public List<Relatorio> GetAll();

        List<ReportMensal> GetRendasMensais_Dapper(DateTime periodo);
        List<ReportMensal> GetRendasMensais(DateTime periodo);
        
        List<ReportAnual> GetRendasAnuais_Dapper(DateTime periodo);
        List<ReportAnual> GetRendasAnuais(DateTime periodo);

        List<ReportMensal> GetDespesasMensaisCategoria_Dapper(DateTime periodo);
        List<ReportMensal> GetDespesasMensaisCategoria(DateTime periodo);


        List<ReportAnual> GetDespesasAnualCategoria_Dapper(DateTime periodo);
        List<ReportAnual> GetDespesasAnualCategoria(DateTime periodo);

        public List<ReportMensal> GetDespesasMensaisCartao_Dapper(DateTime periodo);
        public List<ReportMensal> GetDespesasMensaisCartao(DateTime periodo);

        List<ReportAnual> GetDespesasAnualCartao_Dapper(DateTime periodo);
        List<ReportAnual> GetDespesasAnualCartao(DateTime periodo);

        List<ReportBalancete> GetBalancete_Dapper(DateTime periodo);
        List<ReportBalancete> GetBalancete(DateTime periodo);
    }
}
