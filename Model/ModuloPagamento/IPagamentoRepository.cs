namespace Model.ModuloPagamento
{
    public interface IPagamentoRepository
    {
        public List<Pagamento> GetByDate(DateTime dtPeriodo);
        public decimal GetTotalByDate(DateTime dtPeriodo);
        public Pagamento GetById(int id);
        public int Insert(Pagamento pagamento);
        public int Update(Pagamento pagamento);
        public int DeleteById(int id);
    }
}
