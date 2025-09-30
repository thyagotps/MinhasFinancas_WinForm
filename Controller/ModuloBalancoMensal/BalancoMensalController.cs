using AutoMapper;
using Controller.Profiles;
using Model.ModuloBalancoMensal;

namespace Controller.ModuloBalancoMensal
{
    public class BalancoMensalController : IBalancoMensalController
    {
        private readonly IBalancoMensalRepository _balancoMensalRepository;
        private readonly IMapper _mapper;

        public BalancoMensalController(IBalancoMensalRepository balancoMensalRepository)
        {
            _balancoMensalRepository = balancoMensalRepository;
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new BalancoMensalProfile());
                cfg.AddProfile(new BalancoMensalPorCategoriaProfile());
            });
            _mapper = new Mapper(config);
        }

        public BalancoMensalDto GetBalancoMensal(int idCartao, DateTime periodo)
        {
            var source = _balancoMensalRepository.GetBalancoMensal(idCartao, periodo);
            var dtos = _mapper.Map<BalancoMensalDto>(source);
            return dtos;
        }

        public List<BalancoMensalPorCategoriaDto>GetBalancoMensalPorCategoria(int idCartao, DateTime periodo, string tipoMovimento)
        {
            var source = _balancoMensalRepository.GetBalancoMensalPorCategoria(idCartao, periodo, tipoMovimento);
            var dtos = _mapper.Map<IEnumerable<BalancoMensalPorCategoriaDto>>(source).ToList();
            return dtos;
        }
    }
}
