using AutoMapper;
using Controller.ModuloCategoria;
using Model.ModuloCategoria;

namespace Controller.Profiles
{
    public class CategoriaProfile : Profile
    {
        public CategoriaProfile()
        {
            CreateMap<Categoria, CategoriaDto>().ReverseMap();
        }
    }
}
