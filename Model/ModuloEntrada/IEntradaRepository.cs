namespace Model.ModuloEntrada
{
    public interface IEntradaRepository
    {
        public List<Entrada> GetAll();
        public Entrada GetById(int id);
        public int Insert(Entrada salario);
        public int Update(Entrada salario);
        public int DeleteById(int id);
    }
}
