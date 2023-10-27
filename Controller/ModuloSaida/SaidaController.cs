using AutoMapper;
using Controller.Profiles;
using Model.ModuloSaida;

namespace Controller.ModuloSaida
{
    public class SaidaController : ISaidaController
    {

        private readonly ISaidaRepository _saidaRepository;
        private readonly IMapper _mapper;

        public SaidaController(ISaidaRepository saidaRepository)
        {
            _saidaRepository = saidaRepository;

            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new SaidaProfile());
                cfg.AddProfile(new SaidaFiltroProfile());
            });
            _mapper = new Mapper(config);
        }

        public List<SaidaDto> GetAll()
        {
            var source = _saidaRepository.GetAll();

            var objDtos = _mapper.Map<IEnumerable<SaidaDto>>(source).ToList();

            return objDtos;
        }

        public List<SaidaDto> GetByFilter(SaidaFiltroDto saidaFiltroDto)
        {
            var saidaFiltro = _mapper.Map<SaidaFiltro>(saidaFiltroDto);
            var result = _saidaRepository.GetByFilter(saidaFiltro);

            var objDtos = _mapper.Map<IEnumerable<SaidaDto>>(result).ToList();
            return objDtos;
        }

        public SaidaDto GetById(int id)
        {
            var saida = _saidaRepository.GetById(id);
            var objDto = _mapper.Map<SaidaDto>(saida);
            return objDto;
        }

        public List<SaidaDto> GetByMonth(int year, int month)
        {
            var source = _saidaRepository.GetByMonth(year, month);
            var objDtos = _mapper.Map<IEnumerable<SaidaDto>>(source).ToList();
            return objDtos;
        }

        public decimal GetTotal(SaidaFiltroDto saidaFiltro)
        {
            var filtro = _mapper.Map<SaidaFiltro>(saidaFiltro);
            var total = _saidaRepository.GetTotal(filtro);
            return total;
        }

        public bool Insert(SaidaDto saidaDto)
        {
            var saida = _mapper.Map<Saida>(saidaDto);
            var result = _saidaRepository.Insert(saida);
            return result > 0 ? true : false;
        }

        public bool Update(SaidaDto saidaDto)
        {
            var saida = _mapper.Map<Saida>(saidaDto);
            var result = _saidaRepository.Update(saida);
            return result > 0 ? true : false;
        }

        public bool DeleteById(int id)
        {
            var result = _saidaRepository.DeleteById(id);
            return result > 0 ? true : false;
        }
    }
}
