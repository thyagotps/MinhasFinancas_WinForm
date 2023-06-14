using AutoMapper;
using Controller.Profiles;
using Model.MovimentosAnaliticos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.MovimentosAnaliticos
{
    public class MovimentoAnaliticoController : IMovimentoAnaliticoController
    {
        private readonly IMovimentoAnaliticoRepository _movimentoRepository;
        private readonly IMapper _mapper;

        public MovimentoAnaliticoController(IMovimentoAnaliticoRepository movimentoRepository)
        {
            _movimentoRepository = movimentoRepository;
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MovimentoProfile());
                cfg.AddProfile(new MovimentoFiltroProfile());
            });
            _mapper = new Mapper(config);
        }

        public List<MovimentoAnaliticoDto> GetAll()
        {
            var source = _movimentoRepository.GetAll();

            var movimentosDtos = _mapper.Map<IEnumerable<MovimentoAnaliticoDto>>(source).ToList();

            return movimentosDtos;
        }

        public MovimentoAnaliticoDto GetById(int id)
        {
            var movimento = _movimentoRepository.GetById(id);
            var movimentoDto = _mapper.Map<MovimentoAnaliticoDto>(movimento);
            return movimentoDto;
        }

        public bool Insert(MovimentoAnaliticoDto movimentoDto)
        {
            var movimento = _mapper.Map<MovimentoAnalitico>(movimentoDto);
            var result = _movimentoRepository.Insert(movimento);
            return result > 0 ? true : false;
        }


        public bool Update(MovimentoAnaliticoDto movimentoDto)
        {
            var movimento = _mapper.Map<MovimentoAnalitico>(movimentoDto);
            var result = _movimentoRepository.Update(movimento);
            return result > 0 ? true : false;
        }

        public bool Delete(int id)
        {
            var result = _movimentoRepository.Delete(id);
            return result > 0 ? true : false;
        }

        public List<MovimentoAnalitico> BuscarMovimentosAnaliticos(MovimentoAnaliticoFiltroDto movimentoFiltroDto)
        {
            var movimentoFiltro = _mapper.Map<MovimentoAnaliticoFiltro>(movimentoFiltroDto);
            var result = _movimentoRepository.BuscarMovimentosAnaliticos(movimentoFiltro);
            return result;
        }

        public List<MovimentoAnaliticoDto> GetByMonth(int month)
        {
            var source = _movimentoRepository.GetByMonth(month);
            var movimentosDtos = _mapper.Map<IEnumerable<MovimentoAnaliticoDto>>(source).ToList();
            return movimentosDtos;
        }
    }
}
