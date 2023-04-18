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
    public class MovimentoController : IMovimentoController
    {
        private readonly IMovimentoRepository _movimentoRepository;
        private readonly IMapper _mapper;

        public MovimentoController(IMovimentoRepository movimentoRepository)
        {
            _movimentoRepository = movimentoRepository;
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MovimentoProfile());
                cfg.AddProfile(new MovimentoFiltroProfile());
            });
            _mapper = new Mapper(config);
        }

        public List<MovimentoDto> GetAll()
        {
            var source = _movimentoRepository.GetAll();

            var movimentosDtos = _mapper.Map<IEnumerable<MovimentoDto>>(source).ToList();

            return movimentosDtos;
        }

        public MovimentoDto GetById(int id)
        {
            var movimento = _movimentoRepository.GetById(id);
            var movimentoDto = _mapper.Map<MovimentoDto>(movimento);
            return movimentoDto;
        }

        public bool Insert(MovimentoDto movimentoDto)
        {
            var movimento = _mapper.Map<Movimento>(movimentoDto);
            var result = _movimentoRepository.Insert(movimento);
            return result > 0 ? true : false;
        }

        
        public bool Update(MovimentoDto movimentoDto)
        {
            var movimento = _mapper.Map<Movimento>(movimentoDto);
            var result = _movimentoRepository.Update(movimento);
            return result > 0 ? true : false;
        }

        public bool Delete(int id)
        {
            var result = _movimentoRepository.Delete(id);
            return result > 0 ? true : false;
        }

        public List<Movimento> BuscarMovimento(MovimentoFiltroDto movimentoFiltroDto)
        {
            var movimentoFiltro = _mapper.Map<MovimentoFiltro>(movimentoFiltroDto);
            var result = _movimentoRepository.BuscarMovimento(movimentoFiltro);
            return result;
        }
    }
}
