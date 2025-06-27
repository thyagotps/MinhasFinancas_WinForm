namespace Model.ModuloContaPadrao
{
    public interface IContaPadraoRepository
    {
        List<ContaPadrao> GetAll();
        ContaPadrao GetById(int id);
        int Insert(ContaPadrao contaPadrao);
        int Update(ContaPadrao contaPadrao);
        int DeleteById(int id);
    }
}
