using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.MovimentosAnaliticos
{
    public interface IMovimentoAnaliticoRepository
    {
        public List<MovimentoAnalitico> GetAll();
        public MovimentoAnalitico GetById(int id);
        public int Insert(MovimentoAnalitico movimento);
        public int Update(MovimentoAnalitico movimento);
        public int Delete(int id);
        public List<MovimentoAnalitico> BuscarMovimentosAnaliticos(MovimentoAnaliticoFiltro movimentoFiltro);
        public List<MovimentoAnalitico> GetByMonth(int month);
    }
}
