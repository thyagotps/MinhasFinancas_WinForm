namespace Model.ModuloCartao
{
    public interface ICartaoRepository
    {
        List<Cartao> GetAll();
        Cartao GetById(int? id);
        int Insert(Cartao pagamento);
        int Update(Cartao pagamento);
        int DeleteById(int id);
    }
}
