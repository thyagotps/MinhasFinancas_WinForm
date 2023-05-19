using AutoMapper;
using Controller.Profiles;
using Model.FormaPagamentos;

namespace Controller.FormaPagamentos
{
    public class FormaPagamentoController : IFormaPagamentoController
    {
        private readonly IFormaPagamentoRepository _pagamentoRepository;
        private readonly IMapper _mapper;

        public FormaPagamentoController(IFormaPagamentoRepository pagamentoRepository)
        {
            _pagamentoRepository = pagamentoRepository;
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new PagamentoProfile());
            });
            _mapper = new Mapper(config);
        }

        public List<FormaPagamentoDto> GetAll()
        {
            var source = _pagamentoRepository.GetAll();
            var pagamentosDtos = _mapper.Map<IEnumerable<FormaPagamentoDto>>(source).ToList();
            return pagamentosDtos;
        }

        public FormaPagamentoDto GetById(int id)
        {
            var pagamento = _pagamentoRepository.GetById(id);
            var pagamentoDto = _mapper.Map<FormaPagamentoDto>(pagamento);
            return pagamentoDto;
        }

        public bool Insert(FormaPagamentoDto pagamentoDto)
        {
            var pagamento = _mapper.Map<FormaPagamento>(pagamentoDto);
            var result = _pagamentoRepository.Insert(pagamento);
            return result > 0 ? true : false;
        }

        public bool Update(FormaPagamentoDto pagamentoDto)
        {
            var pagamento = _mapper.Map<FormaPagamento>(pagamentoDto);
            var result = _pagamentoRepository.Update(pagamento);
            return result > 0 ? true : false;
        }

        public bool Delete(int id)
        {
            var result = _pagamentoRepository.Delete(id);
            return result > 0 ? true : false;
        }
    }
}
