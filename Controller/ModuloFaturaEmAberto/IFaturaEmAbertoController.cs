using Model.ModuloFaturaEmAberto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.ModuloFaturaEmAberto
{
    public interface IFaturaEmAbertoController
    {
        public List<FaturaEmAbertoDto> GetAll();
        public decimal GetTotal();
        public FaturaEmAbertoDto GetById(int id);
        public bool Insert(FaturaEmAbertoDto faturaEmAberto);
        public bool Update(FaturaEmAbertoDto faturaEmAberto);
        public bool DeleteById(int id);
    }
}
