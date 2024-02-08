namespace Model.ModuloEntrada
{
    public interface IEntradaRepository
    {
        List<Entrada> GetAll();
        Entrada GetById(int id);
        List<Entrada> GetByDate(DateTime periodo);
        int Insert(Entrada salario);
        int Update(Entrada salario);
        int DeleteById(int id);
        decimal GetTotal(DateTime periodo);
    }
}
