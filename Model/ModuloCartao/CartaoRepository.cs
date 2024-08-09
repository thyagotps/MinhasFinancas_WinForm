using DAL;
using Dapper;

namespace Model.ModuloCartao
{
    public class CartaoRepository : BaseRepositoryEF<Cartao>, ICartaoRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly IAdo _ado;

        public CartaoRepository(AppDbContext appDbContext, IAdo ado) : base(appDbContext, ado)
        {
            _ado = ado;
            _appDbContext = appDbContext;
        }

        public List<Cartao> GetAll()
        {
            var source = base.GetAll();
            return source.ToList();
        }

        public List<Cartao> GetAll_Dapper()
        {
            string query = "select Id, Descricao, Tipo from Cartao order by Descricao";
            var source = base.ExecutarQuery<Cartao>(query: query, listaParametros: null).ToList();
            return source;
        }

        public Cartao GetById(int id)
        {
            var source = base.GetById(id);
            return source;
        }

        public Cartao GetById_Dapper(int? id)
        {
            string query = "select Id, Descricao, Tipo from Cartao where Id = @id";

            var filtros = new DynamicParameters();
            filtros.Add("id", id);

            var source = base.ExecutarQueryFirstOrDefault<Cartao>(query: query, listaParametros: filtros);

            return source;
        }

        public int Insert(Cartao cartao)
        {
            return base.Insert(cartao);
        }

        public int Insert_Dapper(Cartao cartao)
        {
            string query = "insert into Cartao (Descricao, Tipo) values (@Descricao, @Tipo)";

            var filtros = new DynamicParameters();
            filtros.Add("Descricao", cartao.Descricao);
            filtros.Add("Tipo", cartao.Tipo);

            var result = base.Executar(query, filtros);

            return result;
        }

        public int Update(Cartao cartao)
        {
            return base.Update(cartao);
        }

        public int Update_Dapper(Cartao cartao)
        {
            string query = @"update Cartao set 
                             Descricao = @Descricao,
                             Tipo = @Tipo
                             where Id = @Id";

            var filtros = new DynamicParameters();
            filtros.Add("Descricao", cartao.Descricao);
            filtros.Add("Tipo", cartao.Tipo);
            filtros.Add("Id", cartao.Id);

            var result = base.Executar(query, filtros);

            return result;
        }

        public int DeleteById(int id)
        {
            var cartaoDelete = GetById(id);
            return base.Delete(cartaoDelete);
        }

        public int DeleteById_Dapper(int id)
        {
            string query = "delete from Cartao where Id = @id";

            var filtros = new DynamicParameters();
            filtros.Add("id", id);

            var result = base.Executar(query, filtros);

            return result;
        }
    }
}
