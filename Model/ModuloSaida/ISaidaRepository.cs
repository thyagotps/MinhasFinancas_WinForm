namespace Model.ModuloSaida
{
    public interface ISaidaRepository
    {
        public List<Saida> GetAll();
        public Saida GetById(int id);
        public int Insert(Saida saida);
        public int Update(Saida saida);
        public int DeleteById(int id);
        public List<Saida> GetByFilter(SaidaFiltro saidaFiltro);
        public List<Saida> GetByMonth(int year, int month);
        public decimal GetTotal(SaidaFiltro saidaFiltro);
    }
}
