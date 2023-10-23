namespace Model.ModuloCartao
{
    public interface ICartaoRepository
    {
        public List<Cartao> GetAll();
        public Cartao GetById(int id);
        public int Insert(Cartao pagamento);
        public int Update(Cartao pagamento);
        public int DeleteById(int id);
    }
}
