using AutoMapper;
using Controller.MovimentosAnaliticos;
using Model.MovimentosAnaliticos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Profiles
{
    public class MovimentoFiltroProfile : Profile
    {
        public MovimentoFiltroProfile()
        {
            CreateMap<MovimentoAnaliticoFiltro, MovimentoAnaliticoFiltroDto>().ReverseMap();
        }
    }
}
