namespace Controller.ModuloRelatorios;

public interface IRelatorioController
{
    public List<RelatorioDto> GetAll();
    public List<EntradaMensalDto> GetEntradasMensais(DateTime periodo);
    public List<EntradaAnuaisDto> GetEntradasAnuais(DateTime periodo);
}
