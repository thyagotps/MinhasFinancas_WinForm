using DAL;
using Dapper;

namespace Model
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly Ado _ado;

        public CategoriaRepository(Ado ado)
        {
            _ado = ado;
        }

        public List<Categoria> GetAll()
        {
            using (var conn = _ado.Conectar())
            {
                string query = "select Id, Descricao from Categoria order by Id;";
                List<Categoria> categorias = conn.Query<Categoria>(sql: query).ToList();
                return categorias;
            }
        }

        public Categoria GetById(int id)
        {
            using (var conn = _ado.Conectar())
            {
                string query = "select Id, Descricao from Categoria where Id = @id order by Id";
                var categoria = conn.QueryFirstOrDefault<Categoria>(sql: query, param: new { id });
                return categoria;
            }
        }

        public int Insert(Categoria categoria)
        {
            using (var conn = _ado.Conectar())
            {
                string query = "insert into Categoria (Descricao) values (@Descricao)";
                var result = conn.Execute(sql: query, param: categoria);
                return result;
            }
        }

        public int Update(Categoria categoria)
        {
            using (var conn = _ado.Conectar())
            {
                string query = @"update Categoria 
                                 set Descricao = @Descricao
                                 where Id = @Id";
                var result = conn.Execute(sql: query, param: categoria);
                return result;
            }
        }

        public int Delete(int id)
        {
            using (var conn = _ado.Conectar())
            {
                string query = "delete from Categoria where Id = @id";
                var result = conn.Execute(sql: query, param: new { id });
                return result;
            }
        }

    }
}
