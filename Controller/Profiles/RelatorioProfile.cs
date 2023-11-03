using AutoMapper;
using Controller.ModuloCartao;
using Controller.ModuloRelatorios;
using Model.ModuloCartao;
using Model.ModuloRelatorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Profiles
{
    public class RelatorioProfile : Profile
    {
        public RelatorioProfile()
        {
            CreateMap<Relatorio, RelatorioDto>().ReverseMap();
        }
    }
}
