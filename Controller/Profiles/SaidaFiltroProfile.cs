using AutoMapper;
using Controller.ModuloSaida;
using Model.ModuloSaida;

namespace Controller.Profiles
{
    public class SaidaFiltroProfile : Profile
    {
        public SaidaFiltroProfile()
        {
            CreateMap<SaidaFiltro, SaidaFiltroDto>().ReverseMap();
        }
    }
}
