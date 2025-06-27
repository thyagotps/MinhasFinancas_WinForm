namespace Model.ModuloCartao
{
    public interface ICartaoRepository
    {
        List<Cartao> GetAll();
        List<Cartao> GetAll_Dapper();

        Cartao GetById(int? id);
        Cartao GetById_Dapper(int? id);

        int Insert(Cartao pagamento);
        int Insert_Dapper(Cartao pagamento);

        int Update(Cartao pagamento);
        int Update_Dapper(Cartao pagamento);

        int DeleteById(int id);
        int DeleteById_Dapper(int id);
    }
}
