namespace Model.ModuloPagamento
{
    public interface IPagamentoRepository
    {
        List<Pagamento> GetByDate(DateTime dtPeriodo);
        List<Pagamento> GetByDate_Dapper(DateTime dtPeriodo);

        Pagamento GetById(int id);
        Pagamento GetById_Dapper(int id);

        decimal GetTotalByDate(DateTime dtPeriodo);
        decimal GetTotalByDate_Dapper(DateTime dtPeriodo);

        int Insert(Pagamento pagamento);
        int Insert_Dapper(Pagamento pagamento);

        int Update(Pagamento pagamento);
        int Update_Dapper(Pagamento pagamento);

        int DeleteById(int id);
        int DeleteById_Dapper(int id);
    }
}
