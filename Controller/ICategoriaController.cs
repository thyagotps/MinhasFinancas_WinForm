namespace Controller
{
    public interface ICategoriaController
    {
        public List<CategoriaDto> GetAll();
        public CategoriaDto GetCategoriaById(int id);
        public bool Insert(CategoriaDto categoriaDto);
        public bool Update(CategoriaDto categoriaDto);
        public bool Delete(int id);
    }
}
