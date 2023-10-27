namespace Model.ModuloFaturaEmAberto
{
    public interface IFaturaEmAbertoRepository
    {
        public List<FaturaEmAberto> GetAll();
        public decimal GetTotal();
        public FaturaEmAberto GetById(int id);
        public int Insert(FaturaEmAberto faturaEmAberto);
        public int Update(FaturaEmAberto faturaEmAberto);
        public int DeleteById(int id);
    }
}
