namespace Model.ModuloBalancoMensal
{
    public interface IBalancoMensalRepository
    {
        public BalancoMensal GetBalancoMensal(int idCartao, DateTime periodo);
        public List<BalancoMensalPorCategoria> GetBalancoMensalPorCategoria(int idCartao, DateTime periodo, string tipoMovimento);
    }
}
