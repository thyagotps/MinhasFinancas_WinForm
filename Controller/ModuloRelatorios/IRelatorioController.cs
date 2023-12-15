using Model.ModuloRelatorios;

namespace Controller.ModuloRelatorios;

public interface IRelatorioController
{
    public List<RelatorioDto> GetAll();
    public List<ReportMensalDto> GetEntradasMensais(DateTime periodo);
    public List<ReportAnualDto> GetEntradasAnuais(DateTime periodo);
    public List<ReportMensalDto> GetSaidasMensaisCategoria(DateTime periodo);
    public List<ReportMensalDto> GetSaidasMensaisCartao(DateTime periodo);
    List<ReportAnualDto> GetSaidasAnualCategoria(DateTime periodo);
    List<ReportAnualDto> GetSaidasAnualCartao(DateTime periodo);
}
