using AutoMapper;
using Controller.ModuloContaPadrao;
using Model.ModuloContaPadrao;

namespace Controller.Profiles
{
    public class ContaPadraoProfile : Profile
    {
        
        public ContaPadraoProfile()
        {

            CreateMap<ContaPadrao, ContaPadraoDto>().ReverseMap();

            CreateMap<ContaPadrao, ContaPadraoDto>()
                .ForMember(dto => dto.CategoriaDisplayMember, mov => mov.MapFrom(src => src.Categoria.DisplayMember))
                .ForMember(dto => dto.CartaoDisplayMember, mov => mov.MapFrom(src => src.Cartao.DisplayMember))
                .ForMember(dto => dto.CategoriaDescricao, mov => mov.MapFrom(src => src.Categoria.Descricao))
                .ForMember(dto => dto.CartaoDescricao, mov => mov.MapFrom(src => src.Cartao.Descricao))
                .ForMember(dto => dto.IdCartao, mov => mov.MapFrom(src => src.Cartao.Id))
                .ForMember(dto => dto.IdCategoria, mov => mov.MapFrom(src => src.Categoria.Id))
                .ReverseMap();
        }
    }
}
