using Model.ModuloRelatorios;

namespace Controller.ModuloRelatorios;

public interface IRelatorioController
{
    public List<RelatorioDto> GetAll();
    public List<ReportMensalDto> GetRendasMensais(DateTime periodo);
    public List<ReportAnualDto> GetRendasAnuais(DateTime periodo);
    public List<ReportMensalDto> GetDespesasMensaisCategoria(DateTime periodo);
    List<ReportAnualDto> GetDespesasAnualCategoria(DateTime periodo);
    List<ReportMensalDto> GetDespesasMensaisCartao(DateTime periodo);
    List<ReportAnualDto> GetDespesasAnualCartao(DateTime periodo);
}
