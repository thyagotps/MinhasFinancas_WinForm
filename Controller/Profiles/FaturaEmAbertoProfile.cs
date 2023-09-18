using AutoMapper;
using Controller.ModuloFaturaEmAberto;
using Model.ModuloFaturaEmAberto;

namespace Controller.Profiles
{
    public class FaturaEmAbertoProfile : Profile
    {
        public FaturaEmAbertoProfile()
        {
            CreateMap<FaturaEmAberto, FaturaEmAbertoDto>().ReverseMap();
        }
    }
}
