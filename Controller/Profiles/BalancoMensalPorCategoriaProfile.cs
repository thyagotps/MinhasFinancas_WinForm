using AutoMapper;
using Controller.ModuloBalancoMensal;
using Model.ModuloBalancoMensal;

namespace Controller.Profiles
{
    public class BalancoMensalPorCategoriaProfile : Profile
    {
        public BalancoMensalPorCategoriaProfile()
        {
            CreateMap<BalancoMensalPorCategoria, BalancoMensalPorCategoriaDto>().ReverseMap();
        }
    }
}
