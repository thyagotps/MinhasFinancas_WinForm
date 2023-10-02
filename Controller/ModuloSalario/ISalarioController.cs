using Controller.ModuloFaturaEmAberto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.ModuloSalario
{
    public interface ISalarioController
    {
        public List<SalarioDto> GetAll();
        public SalarioDto GetById(int id);
        public bool Insert(SalarioDto salarioDto);
        public bool Update(SalarioDto salarioDto);
        public bool DeleteById(int id);
    }
}
