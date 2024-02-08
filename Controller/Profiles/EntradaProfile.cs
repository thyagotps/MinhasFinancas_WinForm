using AutoMapper;
using Controller.ModuloEntrada;
using Model.ModuloEntrada;

namespace Controller.Profiles
{
    public class EntradaProfile : Profile
    {
        public EntradaProfile()
        {
            CreateMap<Entrada, EntradaDto>().ReverseMap();

            CreateMap<Entrada, EntradaDto>()
                .ForMember(dto => dto.CategoriaDisplayMember, mov => mov.MapFrom(src => src.Categoria.DisplayMember))
                .ForMember(dto => dto.CartaoDisplayMember, mov => mov.MapFrom(src => src.Cartao.DisplayMember))
                .ReverseMap();
        }
    }
}
