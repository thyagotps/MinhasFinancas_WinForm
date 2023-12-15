using AutoMapper;
using Controller.ModuloRelatorios;
using Model.ModuloRelatorios;

namespace Controller.Profiles;

public class ReportAnualProfile : Profile
{
    public ReportAnualProfile()
    {
        CreateMap<ReportAnual, ReportAnualDto>().ReverseMap();
    }
}
