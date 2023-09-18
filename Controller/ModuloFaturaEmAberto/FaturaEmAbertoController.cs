using AutoMapper;
using Controller.Profiles;
using Model.ModuloFaturaEmAberto;

namespace Controller.ModuloFaturaEmAberto
{
    public class FaturaEmAbertoController : IFaturaEmAbertoController
    {

        private readonly IFaturaEmAbertoRepository _faturaEmAbertoRepository;
        private readonly IMapper _mapper;

        public FaturaEmAbertoController(IFaturaEmAbertoRepository faturaEmAbertoRepository)
        {
            _faturaEmAbertoRepository = faturaEmAbertoRepository;
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new FaturaEmAbertoProfile());
            });
            _mapper = new Mapper(config);
        }

        public List<FaturaEmAbertoDto> GetAll()
        {
            var source = _faturaEmAbertoRepository.GetAll();
            var obj = _mapper.Map<IEnumerable<FaturaEmAbertoDto>>(source).ToList();
            return obj;
        }

        public FaturaEmAbertoDto GetById(int id)
        {
            var source = _faturaEmAbertoRepository.GetById(id);
            var obj = _mapper.Map<FaturaEmAbertoDto>(source);
            return obj;
        }

        public decimal GetTotal()
        {
            var total = _faturaEmAbertoRepository.GetTotal();
            return total;
        }

        public bool Insert(FaturaEmAbertoDto faturaEmAberto)
        {
            var obj = _mapper.Map<FaturaEmAberto>(faturaEmAberto);
            var result = _faturaEmAbertoRepository.Insert(obj);
            return result > 0 ? true : false;
        }

        public bool Update(FaturaEmAbertoDto faturaEmAberto)
        {
            var obj = _mapper.Map<FaturaEmAberto>(faturaEmAberto);
            var result = _faturaEmAbertoRepository.Update(obj);
            return result > 0 ? true : false;
        }

        public bool DeleteById(int id)
        {
            var result = _faturaEmAbertoRepository.DeleteById(id);
            return result > 0 ? true : false;
        }
    }
}
