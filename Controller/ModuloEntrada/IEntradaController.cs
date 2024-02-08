using Controller.ModuloEntrada;

namespace Controller.ModuloSalario
{
    public interface IEntradaController
    {
        List<EntradaDto> GetAll();
        EntradaDto GetById(int id);
        List<EntradaDto> GetByDate(DateTime periodo);
        bool Insert(EntradaDto entradaDto);
        bool Update(EntradaDto entradaDto);
        bool DeleteById(int id);
        decimal GetTotal(DateTime periodo);
    }
}
