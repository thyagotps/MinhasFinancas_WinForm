using Model.ContasPagar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ModuloFaturaEmAberto
{
    public interface IFaturaEmAbertoRepository
    {
        public List<FaturaEmAberto> GetAll();
        public decimal GetTotal();
        public FaturaEmAberto GetById(int id);
        public int Insert(FaturaEmAberto faturaEmAberto);
        public int Update(FaturaEmAberto faturaEmAberto);
        public int DeleteById(int id);
    }
}
