using AutoMapper;
using Controller.ModuloSalario;
using Controller.Profiles;
using Model.ModuloEntrada;

namespace Controller.ModuloEntrada
{
    public class EntradaController : IEntradaController
    {
        private readonly IEntradaRepository _entradaRepository;
        private readonly IMapper _mapper;

        public EntradaController(
            IEntradaRepository entradaRepository)
        {
            _entradaRepository = entradaRepository;

            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new EntradaProfile());
            });
            _mapper = new Mapper(config);
        }


        public List<EntradaDto> GetAll()
        {
            var source = _entradaRepository.GetAll();
            var obj = _mapper.Map<IEnumerable<EntradaDto>>(source).ToList();
            return obj;
        }

        public EntradaDto GetById(int id)
        {
            var source = _entradaRepository.GetById(id);
            var obj = _mapper.Map<EntradaDto>(source);
            return obj;
        }

        public List<EntradaDto> GetByDate(DateTime periodo)
        {
            var source = _entradaRepository.GetByDate(periodo);
            var obj = _mapper.Map<IEnumerable<EntradaDto>>(source).ToList();
            return obj;
        }

        public bool Insert(EntradaDto entradaDto)
        {
            var obj = _mapper.Map<Entrada>(entradaDto);
            var result = _entradaRepository.Insert(obj);
            return result > 0 ? true : false;
        }

        public bool Update(EntradaDto entradaDto)
        {
            var obj = _mapper.Map<Entrada>(entradaDto);
            var result = _entradaRepository.Update(obj);
            return result > 0 ? true : false;
        }

        public bool DeleteById(int id)
        {
            var result = _entradaRepository.DeleteById(id);
            return result > 0 ? true : false;
        }

        public decimal GetTotal(DateTime periodo)
        {
            var total = _entradaRepository.GetTotal(periodo);
            return total;
        }


    }
}
