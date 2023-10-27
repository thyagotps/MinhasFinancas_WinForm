namespace Model.ContasPagar
{
    public interface IContaPagarRepository
    {
        public List<ContaPagar> Buscar(DateTime dtPeriodo);
        public decimal GetTotal(DateTime dtPeriodo);
        public ContaPagar GetById(int id);
        public int Insert(ContaPagar contaPagar);
        public int Update(ContaPagar contaPagar);
        public int DeleteById(int id);
    }
}
