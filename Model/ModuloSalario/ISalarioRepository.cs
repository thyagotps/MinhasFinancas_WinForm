using Model.ModuloFaturaEmAberto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ModuloSalario
{
    public interface ISalarioRepository
    {
        public List<Salario> GetAll();
        public Salario GetById(int id);
        public int Insert(Salario salario);
        public int Update(Salario salario);
        public int DeleteById(int id);
    }
}
