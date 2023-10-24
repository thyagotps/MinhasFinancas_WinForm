using AutoMapper;
using Controller.ModuloEntrada;
using Model.ModuloEntrada;
using System.Linq.Expressions;

namespace Controller.Profiles
{
    public class EntradaProfile : Profile
    {
        public EntradaProfile()
        {
            CreateMap<Entrada, EntradaDto>().ReverseMap();

            CreateMap<Entrada, EntradaDto>()
                .ForMember(dto => dto.CategoriaDisplayMember, mov => mov.MapFrom(src => src.Categoria.DisplayMember))
                .ReverseMap();
        
        }

        
    }
}
