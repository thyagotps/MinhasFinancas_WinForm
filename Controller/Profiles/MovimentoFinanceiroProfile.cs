using AutoMapper;
using Controller.ModuloMovimentoFinanceiro;
using Model.ModuloMovimentoFinanceiro;

namespace Controller.Profiles
{
    public class MovimentoFinanceiroProfile : Profile
    {
        public MovimentoFinanceiroProfile()
        {
            CreateMap<MovimentoFinanceiro, MovimentoFinanceiroDto>().ReverseMap();

            CreateMap<MovimentoFinanceiro, MovimentoFinanceiroDto>()
                .ForMember(dto => dto.CategoriaDisplayMember, mov => mov.MapFrom(src => src.Categoria.DisplayMember))
                .ForMember(dto => dto.CartaoDisplayMember, mov => mov.MapFrom(src => src.Cartao.DisplayMember))
                .ForMember(dto => dto.CategoriaDescricao, mov => mov.MapFrom(src => src.Categoria.Descricao))
                .ForMember(dto => dto.CartaoDescricao, mov => mov.MapFrom(src => src.Cartao.Descricao))
                .ReverseMap();
        }
    }
}
