using AutoMapper;
using Controller.ModuloCartao;
using Controller.Profiles;
using Model.ModuloRelatorios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.ModuloRelatorios
{
    public class RelatorioController : IRelatorioController
    {

        private readonly IRelatorioRepository _relatorioRepository;
        private readonly IMapper _mapper;

        public RelatorioController(
            IRelatorioRepository relatorioRepository)
        {
            _relatorioRepository = relatorioRepository;

            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new RelatorioProfile());
                cfg.AddProfile(new EntradaMensalProfile());
                cfg.AddProfile(new EntradaAnuaisProfile());
            });
            _mapper = new Mapper(config);
        }

        public List<RelatorioDto> GetAll()
        {
            var source = _relatorioRepository.GetAll();
            var dtos = _mapper.Map<IEnumerable<RelatorioDto>>(source).ToList();
            return dtos;
        }

        public List<EntradaMensalDto> GetEntradasMensais(DateTime periodo)
        {
            var source = _relatorioRepository.GetEntradasMensais(periodo);
            var dtos = _mapper.Map<IEnumerable<EntradaMensalDto>>(source).ToList();
            return dtos;
        }

        public List<EntradaAnuaisDto> GetEntradasAnuais(DateTime periodo)
        {
            var source = _relatorioRepository.GetEntradasAnuais(periodo);
            var dtos = _mapper.Map<IEnumerable<EntradaAnuaisDto>>(source).ToList();
            return dtos;
        }
    }
}
