using AutoMapper;
using Controller.ContasPagar;
using Controller.ModuloSalario;
using Model.ContasPagar;
using Model.ModuloSalario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Profiles
{
    public class SalarioProfile : Profile
    {
        public SalarioProfile()
        {
            CreateMap<Salario, SalarioDto>().ReverseMap();
        }
    }
}
