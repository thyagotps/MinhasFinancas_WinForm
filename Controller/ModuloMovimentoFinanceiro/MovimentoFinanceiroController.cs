using AutoMapper;
using Controller.Profiles;
using Model.ModuloCartao;
using Model.ModuloCategoria;
using Model.ModuloContaPadrao;
using Model.ModuloMovimentoFinanceiro;

namespace Controller.ModuloMovimentoFinanceiro
{
    public class MovimentoFinanceiroController : IMovimentoFinanceiroController
    {
        private readonly IMovimentoFinanceiroRepository _movimentoFinanceiroRepository;
        private readonly IMapper _mapper;
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly ICartaoRepository _cartaoRepository;
        private readonly IContaPadraoRepository _contaPadraoRepository;

        public MovimentoFinanceiroController(
            IMovimentoFinanceiroRepository movimentoFinanceiroRepository, 
            ICategoriaRepository categoriaRepository, 
            ICartaoRepository cartaoRepository, 
            IContaPadraoRepository contaPadraoRepository)
        {
            _movimentoFinanceiroRepository = movimentoFinanceiroRepository;

            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MovimentoFinanceiroProfile());
            });
            _mapper = new Mapper(config);
            _categoriaRepository = categoriaRepository;
            _cartaoRepository = cartaoRepository;
            _contaPadraoRepository = contaPadraoRepository;
        }

        public List<MovimentoFinanceiroDto> GetAll()
        {
            var source = _movimentoFinanceiroRepository.GetAll();
            var objDtos = _mapper.Map<IEnumerable<MovimentoFinanceiroDto>>(source).ToList();
            return objDtos;
        }

        public MovimentoFinanceiroDto GetById(int id)
        {
            var source = _movimentoFinanceiroRepository.GetById(id);
            var objDto = _mapper.Map<MovimentoFinanceiroDto>(source);
            return objDto;
        }

        public List<MovimentoFinanceiroDto> GetByMonth(int year, int month)
        {
            var source = _movimentoFinanceiroRepository.GetByMonth(year, month);
            var objDtos = _mapper.Map<IEnumerable<MovimentoFinanceiroDto>>(source).ToList();
            return objDtos;
        }

        public decimal GetTotalDespesaByMonth(int year, int month)
        {
            var total = _movimentoFinanceiroRepository.GetTotalDespesaByMonth(year, month);
            return total;
        }

        public decimal GetTotalRendaByMonth(int year, int month)
        {
            var total = _movimentoFinanceiroRepository.GetTotalRendaByMonth(year, month);
            return total;
        }

        public bool Insert(MovimentoFinanceiroDto movimentoFinanceiro)
        {
            var source = _mapper.Map<MovimentoFinanceiro>(movimentoFinanceiro);
            source.Categoria = null;
            source.Cartao = null;
            source.Id = 0;
            var result = _movimentoFinanceiroRepository.Insert(source);
            return result > 0 ? true : false;
        }

        public bool Update(MovimentoFinanceiroDto movimentoFinanceiro)
        {
            var source = _mapper.Map<MovimentoFinanceiro>(movimentoFinanceiro);
            source.Categoria = null;
            source.Cartao = null;
            var result = _movimentoFinanceiroRepository.Update(source);
            return result > 0 ? true : false;
        }

        public bool DeleteById(int id)
        {
            var result = _movimentoFinanceiroRepository.DeleteById(id);
            return result > 0 ? true : false;
        }

        public void CriarPagamentosAutomaticos(DateTime periodo)
        {
            var source = _contaPadraoRepository.GetAll();
            foreach (var item in source)
            {
                item.DataMovimento = new DateTime(periodo.Year, periodo.Month, 1);
                item.DataVencimento = new DateTime(periodo.Year, periodo.Month, 1);
                var mv = _mapper.Map<MovimentoFinanceiroDto>(item);
                Insert(mv);
            }
        }
    }
}
