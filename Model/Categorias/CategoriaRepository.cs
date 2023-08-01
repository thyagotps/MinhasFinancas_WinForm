using DAL;
using Dapper;

namespace Model.Categorias
{
    public class CategoriaRepository : BaseRepository, ICategoriaRepository
    {
        private readonly Ado _ado;

        public CategoriaRepository(Ado ado) : base(ado)
        {
            _ado = ado;
        }

        public List<Categoria> GetAll()
        {
            string query = "select Id, Descricao from Categoria order by Id;";
            var source = base.ExecutarQuery<Categoria>(query, listaParametros: null).ToList();
            return source;
        }

        public Categoria GetById(int id)
        {
            string query = "select Id, Descricao from Categoria where Id = @id order by Id";

            var filtros = new DynamicParameters();
            filtros.Add("id", id);

            var source = base.ExecutarQueryFirstOrDefault<Categoria>(query, filtros);

            return source;
        }

        public int Insert(Categoria categoria)
        {
            string query = "insert into Categoria (Descricao) values (@Descricao)";
            
            var filtros = new DynamicParameters();
            filtros.Add("Descricao", categoria.Descricao);
            
            var result = base.Executar(query, filtros);

            return result;
        }

        public int Update(Categoria categoria)
        {
            string query = @"update Categoria 
                             set Descricao = @Descricao
                             where Id = @Id";

            var filtros = new DynamicParameters();
            filtros.Add("Descricao", categoria.Descricao);
            filtros.Add("Id", categoria.Id);

            var result = base.Executar(query, filtros);

            return result;
        }

        public int Delete(int id)
        {
            string query = "delete from Categoria where Id = @id";

            var filtros = new DynamicParameters();
            filtros.Add("id", id);

            var result = base.Executar(query, filtros);

            return result;
        }

    }
}
