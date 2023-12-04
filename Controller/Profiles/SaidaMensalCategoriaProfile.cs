using AutoMapper;
using Controller.ModuloRelatorios;
using Model.ModuloRelatorios;

namespace Controller.Profiles;

public class SaidaMensalCategoriaProfile : Profile
{
    public SaidaMensalCategoriaProfile()
    {
        CreateMap<SaidaMensalCategoria, SaidaMensalCategoriaDto>().ReverseMap();
    }
}
