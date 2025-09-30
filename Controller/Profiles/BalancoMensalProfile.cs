using AutoMapper;
using Controller.ModuloBalancoMensal;
using Model.ModuloBalancoMensal;

namespace Controller.Profiles
{
    public class BalancoMensalProfile : Profile
    {
        public BalancoMensalProfile()
        {
            CreateMap<BalancoMensal, BalancoMensalDto>().ReverseMap();
        }
    }
}
