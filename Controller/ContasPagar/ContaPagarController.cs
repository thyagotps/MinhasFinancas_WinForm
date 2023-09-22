using AutoMapper;
using Controller.MovimentosAnaliticos;
using Controller.Profiles;
using Model.ContasPagar;
using Model.MovimentosAnaliticos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.ContasPagar
{
    public class ContaPagarController : IContaPagarController
    {
        private readonly IContaPagarRepository _contaPagarRepository;
        private readonly IMapper _mapper;

        public ContaPagarController(IContaPagarRepository contaPagarRepository)
        {
            _contaPagarRepository = contaPagarRepository;
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ContaPagarProfile());
            });
            _mapper = new Mapper(config);
        }

        public List<ContaPagarDto> Buscar(DateTime dtPeriodo)
        {
            var source = _contaPagarRepository.Buscar(dtPeriodo);

            var obj = _mapper.Map<IEnumerable<ContaPagarDto>>(source).ToList();

            return obj;
        }

        public ContaPagarDto GetById(int id)
        {
            var source = _contaPagarRepository.GetById(id);
            var obj = _mapper.Map<ContaPagarDto>(source);
            return obj;
        }

        public decimal GetTotal(DateTime dtPeriodo)
        {
            var total = _contaPagarRepository.GetTotal(dtPeriodo);
            return total;
        }

        public bool Insert(ContaPagarDto contaPagarDto)
        {
            var contaPagar = _mapper.Map<ContaPagar>(contaPagarDto);
            var result = _contaPagarRepository.Insert(contaPagar);
            return result > 0 ? true : false;
        }

        public bool Update(ContaPagarDto contaPagarDto)
        {
            var contaPagar = _mapper.Map<ContaPagar>(contaPagarDto);
            var result = _contaPagarRepository.Update(contaPagar);
            return result > 0 ? true : false;
        }

        public bool DeleteById(int id)
        {
            var result = _contaPagarRepository.DeleteById(id);
            return result > 0 ? true : false;
        }

        public void CriarContasPagarAuto(DateTime periodo)
        {
            var contaCondominio = new ContaPagarDto() { NrIdentificador = 10, Descricao = "Condomínio", Valor = 0, DataVencimento = new DateTime(periodo.Year, periodo.Month, 1), Situacao = "N" };
            var contaAgua = new ContaPagarDto() { NrIdentificador = 20, Descricao = "Água", Valor = 0, DataVencimento = new DateTime(periodo.Year, periodo.Month, 1), Situacao = "N" };
            var contaLuz = new ContaPagarDto() { NrIdentificador = 30, Descricao = "Luz", Valor = 0, DataVencimento = new DateTime(periodo.Year, periodo.Month, 1), Situacao = "N" };
            var contaFinancApto = new ContaPagarDto() { NrIdentificador = 40, Descricao = "Financiamento Apartamento", Valor = 0, DataVencimento = new DateTime(periodo.Year, periodo.Month, 1), Situacao = "N" };
            var contaPortoSeguro = new ContaPagarDto() { NrIdentificador = 50, Descricao = "Porto Seguro", Valor = 0, DataVencimento = new DateTime(periodo.Year, periodo.Month, 1), Situacao = "N" };
            var contaNetT = new ContaPagarDto() { NrIdentificador = 60, Descricao = "NET Thyago", Valor = 0, DataVencimento = new DateTime(periodo.Year, periodo.Month, 1), Situacao = "N" };
            var contaNetM = new ContaPagarDto() { NrIdentificador = 70, Descricao = "NET Miriam", Valor = 0, DataVencimento = new DateTime(periodo.Year, periodo.Month, 1), Situacao = "N" };
            var contaTim = new ContaPagarDto() { NrIdentificador = 80, Descricao = "TIM", Valor = 0, DataVencimento = new DateTime(periodo.Year, periodo.Month, 1), Situacao = "N" };
            var contaPgtoSaldoDev = new ContaPagarDto() { NrIdentificador = 90, Descricao = "Pagamento Saldo Devedor", Valor = 0, DataVencimento = new DateTime(periodo.Year, periodo.Month, 1), Situacao = "N" };
            var contaPixThyago = new ContaPagarDto() { NrIdentificador = 100, Descricao = "PIX Thyago", Valor = 0, DataVencimento = new DateTime(periodo.Year, periodo.Month, 1), Situacao = "N" };
            var contaAcoes = new ContaPagarDto() { NrIdentificador = 110, Descricao = "Ações", Valor = 0, DataVencimento = new DateTime(periodo.Year, periodo.Month, 1), Situacao = "N" };
            var contaFiis = new ContaPagarDto() { NrIdentificador = 120, Descricao = "FIIs", Valor = 0, DataVencimento = new DateTime(periodo.Year, periodo.Month, 1), Situacao = "N" };
            var contaPixRebecca = new ContaPagarDto() { NrIdentificador = 130, Descricao = "PIX Rebecca", Valor = 0, DataVencimento = new DateTime(periodo.Year, periodo.Month, 1), Situacao = "N" };
            var contaPixMiriam = new ContaPagarDto() { NrIdentificador = 140, Descricao = "PIX Miriam", Valor = 0, DataVencimento = new DateTime(periodo.Year, periodo.Month, 1), Situacao = "N" };
            var contaColeta = new ContaPagarDto() { NrIdentificador = 150, Descricao = "PIX Coleta", Valor = 0, DataVencimento = new DateTime(periodo.Year, periodo.Month, 1), Situacao = "N" };

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
