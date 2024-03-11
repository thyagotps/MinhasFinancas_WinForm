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

        public List<ReportMensalDto> GetRendasMensais(DateTime periodo)
        {
            var source = _relatorioRepository.GetRendasMensais(periodo);
            var dtos = _mapper.Map<IEnumerable<ReportMensalDto>>(source).ToList();
            return dtos;
        }

        public List<ReportAnualDto> GetRendasAnuais(DateTime periodo)
        {
            var source = _relatorioRepository.GetRendasAnuais(periodo);
            var dtos = _mapper.Map<IEnumerable<ReportAnualDto>>(source).ToList();
            return dtos;
        }

        public List<ReportMensalDto> GetDespesasMensaisCategoria(DateTime periodo)
        {
            var source = _relatorioRepository.GetDespesasMensaisCategoria(periodo);
            var dtos = _mapper.Map<IEnumerable<ReportMensalDto>>(source).ToList();
            return dtos;
        }

        public List<ReportAnualDto> GetDespesasAnualCategoria(DateTime periodo)
        {
            var source = _relatorioRepository.GetDespesasAnualCategoria(periodo);
            var dtos = _mapper.Map<IEnumerable<ReportAnualDto>>(source).ToList();
            return dtos;
        }



        public List<ReportMensalDto> GetDespesasMensaisCartao(DateTime periodo)
        {
            var source = _relatorioRepository.GetDespesasMensaisCartao(periodo);
            var dtos = _mapper.Map<IEnumerable<ReportMensalDto>>(source).ToList();
            return dtos;
        }

        

        public List<ReportAnualDto> GetDespesasAnualCartao(DateTime periodo)
        {
            var source = _relatorioRepository.GetDespesasAnualCartao(periodo);
            var dtos = _mapper.Map<IEnumerable<ReportAnualDto>>(source).ToList();
            return dtos;
        }
    }
}
