using AutoMapper;
using Controller.Profiles;
using Model.ModuloPagamento;

namespace Controller.ModuloPagamento
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

        public List<PagamentoDto> GetByDate(DateTime dtPeriodo)
        {
            var source = _pagamentoRepository.GetByDate(dtPeriodo);
            var obj = _mapper.Map<IEnumerable<PagamentoDto>>(source).ToList();
            return obj;
        }

        public PagamentoDto GetById(int id)
        {
            var source = _pagamentoRepository.GetById(id);
            var obj = _mapper.Map<PagamentoDto>(source);
            return obj;
        }

        public decimal GetTotalByDate(DateTime dtPeriodo)
        {
            var total = _pagamentoRepository.GetTotalByDate(dtPeriodo);
            return total;
        }

        public bool Insert(PagamentoDto pagamentoDto)
        {
            var pgto = _mapper.Map<Pagamento>(pagamentoDto);
            var result = _pagamentoRepository.Insert(pgto);
            return result > 0 ? true : false;
        }

        public bool Update(PagamentoDto pagamentoDto)
        {
            var pgto = _mapper.Map<Pagamento>(pagamentoDto);
            var result = _pagamentoRepository.Update(pgto);
            return result > 0 ? true : false;
        }

        public bool DeleteById(int id)
        {
            var result = _pagamentoRepository.DeleteById(id);
            return result > 0 ? true : false;
        }

        public void CriarPagamentosAutomaticos(DateTime periodo)
        {
            var contaCondominio = new PagamentoDto() { NrIdentificador = 10, Descricao = "Condomínio", Valor = 0, DataVencimento = new DateTime(periodo.Year, periodo.Month, 1), Situacao = "N" };
            var contaAgua = new PagamentoDto() { NrIdentificador = 20, Descricao = "Água", Valor = 0, DataVencimento = new DateTime(periodo.Year, periodo.Month, 1), Situacao = "N" };
            var contaLuz = new PagamentoDto() { NrIdentificador = 30, Descricao = "Luz", Valor = 0, DataVencimento = new DateTime(periodo.Year, periodo.Month, 1), Situacao = "N" };
            var contaFinancApto = new PagamentoDto() { NrIdentificador = 40, Descricao = "Financiamento Apartamento", Valor = 0, DataVencimento = new DateTime(periodo.Year, periodo.Month, 1), Situacao = "N" };
            var contaPortoSeguro = new PagamentoDto() { NrIdentificador = 50, Descricao = "Porto Seguro", Valor = 0, DataVencimento = new DateTime(periodo.Year, periodo.Month, 1), Situacao = "N" };
            var contaNetT = new PagamentoDto() { NrIdentificador = 60, Descricao = "NET Thyago", Valor = 0, DataVencimento = new DateTime(periodo.Year, periodo.Month, 1), Situacao = "N" };
            var contaNetM = new PagamentoDto() { NrIdentificador = 70, Descricao = "NET Miriam", Valor = 0, DataVencimento = new DateTime(periodo.Year, periodo.Month, 1), Situacao = "N" };
            var contaTim = new PagamentoDto() { NrIdentificador = 80, Descricao = "TIM", Valor = 0, DataVencimento = new DateTime(periodo.Year, periodo.Month, 1), Situacao = "N" };
            var contaPgtoSaldoDev = new PagamentoDto() { NrIdentificador = 90, Descricao = "Pagamento Saldo Devedor", Valor = 0, DataVencimento = new DateTime(periodo.Year, periodo.Month, 1), Situacao = "N" };
            var contaPixThyago = new PagamentoDto() { NrIdentificador = 100, Descricao = "PIX Thyago", Valor = 0, DataVencimento = new DateTime(periodo.Year, periodo.Month, 1), Situacao = "N" };
            var contaAcoes = new PagamentoDto() { NrIdentificador = 110, Descricao = "Ações", Valor = 0, DataVencimento = new DateTime(periodo.Year, periodo.Month, 1), Situacao = "N" };
            var contaFiis = new PagamentoDto() { NrIdentificador = 120, Descricao = "FIIs", Valor = 0, DataVencimento = new DateTime(periodo.Year, periodo.Month, 1), Situacao = "N" };
            var contaPixRebecca = new PagamentoDto() { NrIdentificador = 130, Descricao = "PIX Rebecca", Valor = 0, DataVencimento = new DateTime(periodo.Year, periodo.Month, 1), Situacao = "N" };
            var contaPixMiriam = new PagamentoDto() { NrIdentificador = 140, Descricao = "PIX Miriam", Valor = 0, DataVencimento = new DateTime(periodo.Year, periodo.Month, 1), Situacao = "N" };
            var contaColeta = new PagamentoDto() { NrIdentificador = 150, Descricao = "PIX Coleta", Valor = 0, DataVencimento = new DateTime(periodo.Year, periodo.Month, 1), Situacao = "N" };

            Insert(contaCondominio);
            Insert(contaAgua);
            Insert(contaLuz);
            Insert(contaFinancApto);
            Insert(contaPortoSeguro);
            Insert(contaNetT);
            Insert(contaNetM);
            Insert(contaTim);
            Insert(contaPgtoSaldoDev);
            Insert(contaPixThyago);
            Insert(contaAcoes);
            Insert(contaFiis);
            Insert(contaPixRebecca);
            Insert(contaPixMiriam);
            Insert(contaColeta);
        }
    }
}
