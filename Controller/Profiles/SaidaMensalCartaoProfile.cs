using AutoMapper;
using Controller.ModuloRelatorios;
using Model.ModuloRelatorios;

namespace Controller.Profiles;

public class SaidaMensalCartaoProfile : Profile
{
    public SaidaMensalCartaoProfile()
    {
        CreateMap<SaidaMensalCartao, SaidaMensalCartaoDto>().ReverseMap();
    }
}
