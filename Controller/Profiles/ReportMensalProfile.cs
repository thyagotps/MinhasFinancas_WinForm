using AutoMapper;
using Controller.ModuloEntrada;
using Controller.ModuloRelatorios;
using Model.ModuloRelatorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
