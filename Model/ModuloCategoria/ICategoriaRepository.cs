namespace Model.ModuloCategoria
{
    public interface ICategoriaRepository
    {
        List<Categoria> GetAll();
        List<Categoria> GetAll_Dapper();

        Categoria GetById(int id);
        Categoria GetById_Dapper(int id);

        int Insert(Categoria categoria);
        int Insert_Dapper(Categoria categoria);

        int Update(Categoria categoria);
        int Update_Dapper(Categoria categoria);

        int DeleteById(int id);
        int DeleteById_Dapper(int id);
    }
}
