using DAL;
using Dapper;

namespace Model.ModuloCategoria
{
    public class CategoriaRepository : BaseRepositoryEF<Categoria>, ICategoriaRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly IAdo _ado;

        public CategoriaRepository(AppDbContext appDbContext, IAdo ado) : base(appDbContext, ado)
        {
            _appDbContext = appDbContext;
            _ado = ado;
        }

        public List<Categoria> GetAll()
        {
            var source = base.GetAll();
            return source.ToList();
        }

        public List<Categoria> GetAll_Dapper()
        {
            string query = "select Id, Descricao, Tipo from Categoria order by Tipo, Descricao;";
            var source = base.ExecutarQuery<Categoria>(query, listaParametros: null).ToList();
            return source;
        }

        public Categoria GetById(int id)
        {
            var source = base.GetById(id);
            return source;
        }

        public Categoria GetById_Dapper(int id)
        {
            string query = "select Id, Descricao, Tipo from Categoria where Id = @id;";

            var filtros = new DynamicParameters();
            filtros.Add("id", id);

            var source = base.ExecutarQueryFirstOrDefault<Categoria>(query, filtros);

            return source;
        }

        public int Insert(Categoria categoria)
        {
            return base.Insert(categoria);
        }

        public int Insert_Dapper(Categoria categoria)
        {
            string query = "insert into Categoria (Descricao, Tipo) values (@Descricao, @Tipo)";
            
            var filtros = new DynamicParameters();
            filtros.Add("Descricao", categoria.Descricao);
            filtros.Add("Tipo", categoria.Tipo);

            var result = base.Executar(query, filtros);

            return result;
        }

        public int Update(Categoria categoria)
        {
            return base.Update(categoria);
        }

        public int Update_Dapper(Categoria categoria)
        {
            string query = @"update Categoria 
                             set Descricao = @Descricao,
                             Tipo = @Tipo
                             where Id = @Id";

            var filtros = new DynamicParameters();
            filtros.Add("Descricao", categoria.Descricao);
            filtros.Add("Tipo", categoria.Tipo);
            filtros.Add("Id", categoria.Id);

            var result = base.Executar(query, filtros);

            return result;
        }

        public int DeleteById(int id)
        {
            var objDelete = GetById(id);
            return base.Delete(objDelete);
        }

        public int DeleteById_Dapper(int id)
        {
            string query = "delete from Categoria where Id = @id";

            var filtros = new DynamicParameters();
            filtros.Add("id", id);

            var result = base.Executar(query, filtros);

            return result;
        }

    }
}
