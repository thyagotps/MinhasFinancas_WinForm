namespace Controller.ModuloBalancoMensal
{
    public interface IBalancoMensalController
    {
        public BalancoMensalDto GetBalancoMensal(int idCartao, DateTime periodo);
        public List<BalancoMensalPorCategoriaDto> GetBalancoMensalPorCategoria(int idCartao, DateTime periodo, string tipoMovimento);
    }
}
