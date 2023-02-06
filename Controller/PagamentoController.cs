using AutoMapper;
using Controller.Profiles;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class PagamentoController : IPagamentoController
    {
        private readonly IPagamentoRepository _pagamentoRepository;
        private readonly IMapper _mapper;

        public PagamentoController(IPagamentoRepository pagamentoRepository)
        {
            _pagamentoRepository = pagamentoRepository;
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new PagamentoProfile());
            });
            _mapper = new Mapper(config);
        }

        public List<PagamentoDto> GetAll()
        {
            var source = _pagamentoRepository.GetAll();

            var pagamentosDtos = _mapper.Map<IEnumerable<PagamentoDto>>(source).ToList();

            return pagamentosDtos;
        }

        public PagamentoDto GetById(int id)
        {
            var pagamento = _pagamentoRepository.GetById(id);
            var pagamentoDto = _mapper.Map<PagamentoDto>(pagamento);
            return pagamentoDto;
        }

        public bool Insert(PagamentoDto pagamentoDto)
        {
            var pagamento = _mapper.Map<Pagamento>(pagamentoDto);
            var result = _pagamentoRepository.Insert(pagamento);
            return result > 0 ? true : false;
        }

        public bool Update(PagamentoDto pagamentoDto)
        {
            var pagamento = _mapper.Map<Pagamento>(pagamentoDto);
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
