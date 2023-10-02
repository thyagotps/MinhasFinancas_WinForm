using AutoMapper;
using Controller.ModuloFaturaEmAberto;
using Controller.Profiles;
using Model.ModuloFaturaEmAberto;
using Model.ModuloSalario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.ModuloSalario
{
    public class SalarioController : ISalarioController
    {
        private readonly ISalarioRepository _salarioRepository;
        private readonly IMapper _mapper;

        public SalarioController(
            ISalarioRepository salarioRepository)
        {
            _salarioRepository = salarioRepository;

            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new SalarioProfile());
            });
            _mapper = new Mapper(config);
        }


        public List<SalarioDto> GetAll()
        {
            var source = _salarioRepository.GetAll();
            var obj = _mapper.Map<IEnumerable<SalarioDto>>(source).ToList();
            return obj;
        }

        public SalarioDto GetById(int id)
        {
            var source = _salarioRepository.GetById(id);
            var obj = _mapper.Map<SalarioDto>(source);
            return obj;
        }

        public bool Insert(SalarioDto salarioDto)
        {
            var obj = _mapper.Map<Salario>(salarioDto);
            var result = _salarioRepository.Insert(obj);
            return result > 0 ? true : false;
        }

        public bool Update(SalarioDto salarioDto)
        {
            var obj = _mapper.Map<Salario>(salarioDto);
            var result = _salarioRepository.Update(obj);
            return result > 0 ? true : false;
        }

        public bool DeleteById(int id)
        {
            var result = _salarioRepository.DeleteById(id);
            return result > 0 ? true : false;
        }
    }
}
