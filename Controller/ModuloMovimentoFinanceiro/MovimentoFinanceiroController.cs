using AutoMapper;
using Controller.ModuloSaida;
using Controller.Profiles;
using Model.ModuloMovimentoFinanceiro;
using Model.ModuloSaida;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.ModuloMovimentoFinanceiro
{
    public class MovimentoFinanceiroController : IMovimentoFinanceiroController
    {
        private readonly IMovimentoFinanceiroRepository _movimentoFinanceiroRepository;
        private readonly IMapper _mapper;

        public MovimentoFinanceiroController(IMovimentoFinanceiroRepository movimentoFinanceiroRepository)
        {
            _movimentoFinanceiroRepository = movimentoFinanceiroRepository;

            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MovimentoFinanceiroProfile());
            });
            _mapper = new Mapper(config);
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
            var result = _movimentoFinanceiroRepository.Insert(source);
            return result > 0 ? true : false;
        }

        public bool Update(MovimentoFinanceiroDto movimentoFinanceiro)
        {
            var source = _mapper.Map<MovimentoFinanceiro>(movimentoFinanceiro);
            var result = _movimentoFinanceiroRepository.Update(source);
            return result > 0 ? true : false;
        }

        public bool DeleteById(int id)
        {
            var result = _movimentoFinanceiroRepository.DeleteById(id);
            return result > 0 ? true : false;
        }
    }
}
