using Model.MovimentosAnaliticos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.MovimentosAnaliticos
{
    public interface IMovimentoAnaliticoController
    {
        public List<MovimentoAnaliticoDto> GetAll();
        public MovimentoAnaliticoDto GetById(int id);
        public bool Insert(MovimentoAnaliticoDto movimentoDto);
        public bool Update(MovimentoAnaliticoDto movimentoDto);
        public bool Delete(int id);
        public List<MovimentoAnaliticoDto> BuscarMovimentosAnaliticos(MovimentoAnaliticoFiltroDto movimentoFiltro);
        public List<MovimentoAnaliticoDto> GetByMonth(int year, int month);
        public decimal GetTotal(MovimentoAnaliticoFiltroDto filtro);
    }
}
