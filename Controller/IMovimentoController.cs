using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public interface IMovimentoController
    {
        public List<MovimentoDto> GetAll();
        public MovimentoDto GetById(int id);
        public bool Insert(MovimentoDto movimentoDto);
        public bool Update(MovimentoDto movimentoDto);
        public bool Delete(int id);
        public List<Movimento> BuscarMovimento(MovimentoFiltroDto movimentoFiltro);
    }
}
