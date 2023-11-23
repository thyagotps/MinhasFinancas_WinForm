using AutoMapper;
using Controller.ModuloRelatorios;
using Model.ModuloRelatorios;

namespace Controller.Profiles;

public class EntradaAnuaisProfile : Profile
{
    public EntradaAnuaisProfile()
    {
        CreateMap<EntradaAnuais, EntradaAnuaisDto>().ReverseMap();
    }
}
