namespace Model.ModuloMovimentoFinanceiro
{
    public interface IMovimentoFinanceiroRepository
    {
        List<MovimentoFinanceiro> GetAll();
        List<MovimentoFinanceiro> GetAll_Dapper();

        MovimentoFinanceiro GetById(int id);
        MovimentoFinanceiro GetById_Dapper(int id);

        List<MovimentoFinanceiro> GetByMonth(int year, int month);
        List<MovimentoFinanceiro> GetByMonth_Dapper(int year, int month);

        decimal GetTotalRendaByMonth(int year, int month);
        decimal GetTotalRendaByMonth_Dapper(int year, int month);

        decimal GetTotalDespesaByMonth(int year, int month);
        decimal GetTotalDespesaByMonth_Dapper(int year, int month);

        int Insert(MovimentoFinanceiro movimentoFinanceiro);
        int Insert_Dapper(MovimentoFinanceiro movimentoFinanceiro);

        int Update(MovimentoFinanceiro movimentoFinanceiro);
        int Update_Dapper(MovimentoFinanceiro movimentoFinanceiro);

        int DeleteById(int id);
        int DeleteById_Dapper(int id);
    }
}
