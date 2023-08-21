using AutoMapper;
using Controller.Categorias;
using Controller.ContasPagar;
using Model.Categorias;
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
