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
                cfg.AddProfile(new ReportMensalProfile());
                cfg.AddProfile(new ReportAnualProfile());
            });
            _mapper = new Mapper(config);
        }

        public List<RelatorioDto> GetAll()
        {
            var source = _relatorioRepository.GetAll();
            var dtos = _mapper.Map<IEnumerable<RelatorioDto>>(source).ToList();
            return dtos;
        }

        public List<ReportMensalDto> GetEntradasMensais(DateTime periodo)
        {
            var source = _relatorioRepository.GetEntradasMensais(periodo);
            var dtos = _mapper.Map<IEnumerable<ReportMensalDto>>(source).ToList();
            return dtos;
        }

        public List<ReportAnualDto> GetEntradasAnuais(DateTime periodo)
        {
            var source = _relatorioRepository.GetEntradasAnuais(periodo);
            var dtos = _mapper.Map<IEnumerable<ReportAnualDto>>(source).ToList();
            return dtos;
        }

        public List<ReportMensalDto> GetSaidasMensaisCategoria(DateTime periodo)
        {
            var source = _relatorioRepository.GetSaidasMensaisCategoria(periodo);
            var dtos = _mapper.Map<IEnumerable<ReportMensalDto>>(source).ToList();
            return dtos;
        }

        public List<ReportMensalDto> GetSaidasMensaisCartao(DateTime periodo)
        {
            var source = _relatorioRepository.GetSaidasMensaisCartao(periodo);
            var dtos = _mapper.Map<IEnumerable<ReportMensalDto>>(source).ToList();
            return dtos;
        }

        public List<ReportAnualDto> GetSaidasAnualCategoria(DateTime periodo)
        {
            var source = _relatorioRepository.GetSaidasAnualCategoria(periodo);
            var dtos = _mapper.Map<IEnumerable<ReportAnualDto>>(source).ToList();
            return dtos;
        }

        public List<ReportAnualDto> GetSaidasAnualCartao(DateTime periodo)
        {
            var source = _relatorioRepository.GetSaidasAnualCartao(periodo);
            var dtos = _mapper.Map<IEnumerable<ReportAnualDto>>(source).ToList();
            return dtos;
        }
    }
}
