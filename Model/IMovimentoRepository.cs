using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IMovimentoRepository
    {
        public List<Movimento> GetAll();
        public Movimento GetById(int id);
        public int Insert(Movimento movimento);
        public int Update(Movimento movimento);
        public int Delete(int id);
        public List<Movimento> BuscarMovimento(MovimentoFiltro movimentoFiltro);
    }
}
