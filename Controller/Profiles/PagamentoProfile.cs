using AutoMapper;
using Controller.FormaPagamentos;
using Model.FormaPagamentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Profiles
{
    public class PagamentoProfile : Profile
    {
        public PagamentoProfile()
        {
            CreateMap<FormaPagamento, FormaPagamentoDto>().ReverseMap();
        }
    }
}
