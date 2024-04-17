using AutoMapper;
using Controller.ModuloRelatorios;
using Model.ModuloRelatorios;

namespace Controller.Profiles
{
    public class ReportMensalProfile : Profile
    {
        public ReportMensalProfile()
        {
            CreateMap<ReportMensal, ReportMensalDto>().ReverseMap();
        }
    }
}
