using Controller.ModuloEntrada;

namespace Controller.ModuloSalario
{
    public interface IEntradaController
    {
        public List<EntradaDto> GetAll();
        public EntradaDto GetById(int id);
        public bool Insert(EntradaDto entradaDto);
        public bool Update(EntradaDto entradaDto);
        public bool DeleteById(int id);
    }
}
