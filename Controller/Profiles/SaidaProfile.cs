using AutoMapper;
using Controller.ModuloSaida;
using Model.ModuloSaida;

namespace Controller.Profiles
{
    public class SaidaProfile : Profile
    {
        public SaidaProfile()
        {
            CreateMap<Saida, SaidaDto>().ReverseMap();

            CreateMap<Saida, SaidaDto>()
                .ForMember(dto => dto.CategoriaDisplayMember, mov => mov.MapFrom(src => src.Categoria.DisplayMember))
                .ForMember(dto => dto.CartaoDisplayMember, mov => mov.MapFrom(src => src.Cartao.DisplayMember))
                .ForMember(dto => dto.CategoriaDescricao, mov => mov.MapFrom(src => src.Categoria.Descricao))
                .ForMember(dto => dto.CartaoDescricao, mov => mov.MapFrom(src => src.Cartao.Descricao))
                .ReverseMap();
        }
    }
}
