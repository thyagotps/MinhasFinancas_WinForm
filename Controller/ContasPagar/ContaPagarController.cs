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
    }
}
