namespace Controller.ModuloMovimentoFinanceiro
{
    public interface IMovimentoFinanceiroController
    {
        List<MovimentoFinanceiroDto> GetAll();
        MovimentoFinanceiroDto GetById(int id);
        List<MovimentoFinanceiroDto> GetByMonth(int year, int month);
        decimal GetTotalRendaByMonth(int year, int month);
        decimal GetTotalDespesaByMonth(int year, int month);
        public bool Insert(MovimentoFinanceiroDto movimentoFinanceiro);
        public bool Update(MovimentoFinanceiroDto movimentoFinanceiro);
        public bool DeleteById(int id);
        public void CriarPagamentosAutomaticos(DateTime periodo);
    }
}
