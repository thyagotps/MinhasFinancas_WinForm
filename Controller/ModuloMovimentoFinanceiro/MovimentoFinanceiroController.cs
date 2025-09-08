using Application.Interfaces;
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
        private readonly ICartaoService _cartaoService;

        public MovimentoFinanceiroController(
            IMovimentoFinanceiroRepository movimentoFinanceiroRepository, 
            ICategoriaRepository categoriaRepository, 
            ICartaoRepository cartaoRepository, 
            IContaPadraoRepository contaPadraoRepository,
            ICartaoService cartaoService)
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
            _cartaoService = cartaoService;
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
            var resultUpdateSaldoCartao = UpdateSaldoCartao("Insert", movimentoFinanceiro.Id, movimentoFinanceiro.IdCartao, movimentoFinanceiro.Valor, movimentoFinanceiro.TipoMovimento);
            var result = _movimentoFinanceiroRepository.Insert(source);
            return result > 0 ? true : false;
        }

        public bool Update(MovimentoFinanceiroDto movimentoFinanceiro)
        {
            var source = _mapper.Map<MovimentoFinanceiro>(movimentoFinanceiro);
            source.Categoria = null;
            source.Cartao = null;

            var resultUpdateSaldoCartao = UpdateSaldoCartao("Update", movimentoFinanceiro.Id, movimentoFinanceiro.IdCartao, movimentoFinanceiro.Valor, movimentoFinanceiro.TipoMovimento);
            var result = _movimentoFinanceiroRepository.Update(source);

            return result > 0 ? true : false;
        }

        public bool DeleteById(int id)
        {
            var movimentoFinanceiro = _movimentoFinanceiroRepository.GetById(id);
            var resultUpdateSaldoCartao = UpdateSaldoCartao("Delete", movimentoFinanceiro.Id, movimentoFinanceiro.IdCartao, movimentoFinanceiro.Valor, movimentoFinanceiro.TipoMovimento);
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

        private async Task<bool> UpdateSaldoCartao(string estado, int idMovimento, int? idCartao, decimal? valorAtual, string tipoMovimento)
        {
            var result = await _cartaoService.UpdateSaldoCartao(estado, idMovimento, idCartao, valorAtual, tipoMovimento);
            return result;
        }
    }
}
