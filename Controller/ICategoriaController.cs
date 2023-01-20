using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public interface ICategoriaController
    {
        public List<CategoriaDto> GetAll();
        public CategoriaDto GetCategoriaById(int id);
        public bool Insert(CategoriaDto categoriaDto);
        public bool Update(CategoriaDto categoriaDto);
        public bool Delete(int id);
    }
}
