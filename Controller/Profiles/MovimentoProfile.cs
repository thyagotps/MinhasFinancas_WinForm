using AutoMapper;
using Controller.MovimentosAnaliticos;
using Model.MovimentosAnaliticos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Profiles
{
    public class MovimentoProfile : Profile
    {
        public MovimentoProfile()
        {
            CreateMap<MovimentoAnalitico, MovimentoAnaliticoDto>().ReverseMap();

            CreateMap<MovimentoAnalitico, MovimentoAnaliticoDto>()
                .ForMember(dto => dto.CategoriaDescricao, mov => mov.MapFrom(src => src.Categoria.Descricao))
                .ForMember(dto => dto.FormaPagamentoDescricao, mov => mov.MapFrom(src => src.FormaPagamento.Descricao))
                .ReverseMap();

            CreateMap<MovimentoAnalitico, MovimentoAnaliticoDto>()
               .ForMember(dto => dto.CategoriaId, mov => mov.MapFrom(src => src.Categoria.Id))
               .ForMember(dto => dto.PagamentoId, mov => mov.MapFrom(src => src.FormaPagamento.Id))
               .ReverseMap();
        }
    }
}
