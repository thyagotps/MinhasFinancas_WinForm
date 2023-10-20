using AutoMapper;
using Controller.ModuloCategoria;
using Controller.ContasPagar;
using Model.ModuloCategoria;
using Model.ContasPagar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Profiles
{
    public class ContaPagarProfile : Profile
    {
        public ContaPagarProfile()
        {
            CreateMap<ContaPagar, ContaPagarDto>().ReverseMap();
        }
    }
}
