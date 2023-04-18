using AutoMapper;
using Model;
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
            CreateMap<Movimento, MovimentoDto>().ReverseMap();

            CreateMap<Movimento, MovimentoDto>()
                .ForMember(dto => dto.CategoriaDescricao, mov => mov.MapFrom(src => src.Categoria.Descricao))
                .ForMember(dto => dto.PagamentoDescricao, mov => mov.MapFrom(src => src.Pagamento.Descricao))
                .ReverseMap();

            CreateMap<Movimento, MovimentoDto>()
               .ForMember(dto => dto.CategoriaId, mov => mov.MapFrom(src => src.Categoria.Id))
               .ForMember(dto => dto.PagamentoId, mov => mov.MapFrom(src => src.Pagamento.Id))
               .ReverseMap();
        }
    }
}
