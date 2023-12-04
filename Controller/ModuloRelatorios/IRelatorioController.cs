using Model.ModuloRelatorios;

namespace Controller.ModuloRelatorios;

public interface IRelatorioController
{
    public List<RelatorioDto> GetAll();
    public List<EntradaMensalDto> GetEntradasMensais(DateTime periodo);
    public List<EntradaAnuaisDto> GetEntradasAnuais(DateTime periodo);
    public List<SaidaMensalCategoriaDto> GetSaidasMensaisCategoria(DateTime periodo);
    public List<SaidaMensalCartaoDto> GetSaidasMensaisCartao(DateTime periodo);
}
