using AutoMapper;
using Controller.Profiles;
using Model.ModuloCategoria;

namespace Controller.ModuloCategoria
{
    public class CategoriaController : ICategoriaController
    {

        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;

        public CategoriaController(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new CategoriaProfile());

            });
            _mapper = new Mapper(config);
        }


        public List<CategoriaDto> GetAll()
        {
            var categorias = _categoriaRepository.GetAll();
            var categoriasDtos = _mapper.Map<IEnumerable<CategoriaDto>>(categorias).ToList();
            return categoriasDtos;
        }

        public CategoriaDto GetById(int id)
        {
            var categoria = _categoriaRepository.GetById(id);
            var categoriaDto = _mapper.Map<CategoriaDto>(categoria);
            return categoriaDto;
        }

        public bool Insert(CategoriaDto categoriaDto)
        {
            var categoria = _mapper.Map<Categoria>(categoriaDto);
            var result = _categoriaRepository.Insert(categoria);
            return result > 0 ? true : false;
        }

        public bool Update(CategoriaDto categoriaDto)
        {
            var categoria = _mapper.Map<Categoria>(categoriaDto);
            var result = _categoriaRepository.Update(categoria);
            return result > 0 ? true : false;
        }

        public bool DeleteById(int id)
        {
            var result = _categoriaRepository.DeleteById(id);
            return result > 0 ? true : false;
        }


    }
}