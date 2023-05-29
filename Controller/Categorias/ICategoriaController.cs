namespace Controller.Categorias
{
    public interface ICategoriaController
    {
        public List<CategoriaDto> GetAll();
        public CategoriaDto GetById(int id);
        public bool Insert(CategoriaDto categoriaDto);
        public bool Update(CategoriaDto categoriaDto);
        public bool Delete(int id);
    }
}
