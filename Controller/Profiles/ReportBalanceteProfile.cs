using AutoMapper;
using Controller.ModuloRelatorios;
using Model.ModuloRelatorios;

namespace Controller.Profiles;

public class ReportBalanceteProfile : Profile
{
    public ReportBalanceteProfile()
    {
        CreateMap<ReportBalancete, ReportBalanceteDto>().ReverseMap();
    }
}
