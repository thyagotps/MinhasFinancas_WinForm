using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ModuloCategoria
{
    public interface ICategoriaRepository
    {
        public List<Categoria> GetAll();
        public Categoria GetById(int id);
        public int Insert(Categoria categoria);
        public int Update(Categoria categoria);
        public int DeleteById(int id);
    }
}
