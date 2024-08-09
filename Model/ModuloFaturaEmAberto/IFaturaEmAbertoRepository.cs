namespace Model.ModuloFaturaEmAberto
{
    public interface IFaturaEmAbertoRepository
    {
        List<FaturaEmAberto> GetAll();
        List<FaturaEmAberto> GetAll_Dapper();

        FaturaEmAberto GetById(int id);
        FaturaEmAberto GetById_Dapper(int id);

        decimal GetTotal();
        decimal GetTotal_Dapper();

        int Insert(FaturaEmAberto faturaEmAberto);
        int Insert_Dapper(FaturaEmAberto faturaEmAberto);

        int Update(FaturaEmAberto faturaEmAberto);
        int Update_Dapper(FaturaEmAberto faturaEmAberto);

        int DeleteById(int id);
        int DeleteById_Dapper(int id);
    }
}
