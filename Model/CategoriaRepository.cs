using Ado;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly Ado.Ado _ado;

        public CategoriaRepository(Ado.Ado ado)
        {
            _ado = ado;
        }

      

        //public CategoriaRepository()
        //{
        //    _ado= new Ado.Ado();
        //}

        public List<Categoria> GetCategorias()
        {
            using (var conn = _ado.Conectar())
            {
                string query = "select * from Categoria";
                List<Categoria> categorias = conn.Query<Categoria>(sql: query).ToList();
                return categorias;
            }
        }

        public Categoria GetCategoriaById(int id)
        {
            using (var conn = _ado.Conectar())
            {
                string query = "select * from Categoria where Codigo = @id";
                var categoria = conn.QueryFirstOrDefault<Categoria>(sql: query, param: new { id });
                return categoria;
            }
        }

        public int Insert(Categoria categoria)
        {
            using (var conn = _ado.Conectar())
            {
                string query = "insert into Categoria (Descricao, Sinal) values (@Descricao, @Sinal)";
                var result = conn.Execute(sql: query, param: categoria);
                return result;
            }
        }

        public int Update(Categoria categoria)
        {
            using (var conn = _ado.Conectar())
            {
                string query = @"update Categoria 
                                 set Descricao = @Descricao,
                                     Sinal = @Sinal
                                 where Codigo = @Codigo";
                var result = conn.Execute(sql: query, param: categoria);
                return result;
            }
        }

        public int Delete(int id)
        {
            using (var conn = _ado.Conectar())
            {
                string query = "delete from Categoria where Codigo = @id";
                var result = conn.Execute(sql: query, param: new { id });
                return result;
            }
        }

    }
}
