using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface ICategoriaRepository
    {
        public List<Categoria> GetCategorias();
        public Categoria GetCategoriaById(int id);
        public int Insert(Categoria categoria);
        public int Update(Categoria categoria);
        public int Delete(int id);
    }
}
