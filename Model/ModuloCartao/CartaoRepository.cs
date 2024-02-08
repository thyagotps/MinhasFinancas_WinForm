using DAL;
using Dapper;

namespace Model.ModuloCartao
{
    public class CartaoRepository : BaseRepository, ICartaoRepository
    {

        private readonly Ado _ado;

        public CartaoRepository(Ado ado) : base(ado)
        {
            _ado = ado;
        }


        public List<Cartao> GetAll()
        {
            string query = "select Id, Descricao, Tipo from Cartao order by Descricao";
            var source = base.ExecutarQuery<Cartao>(query: query, listaParametros: null).ToList();
            return source;
        }

        public Cartao GetById(int? id)
        {
            string query = "select Id, Descricao, Tipo from Cartao where Id = @id";

            var filtros = new DynamicParameters();
            filtros.Add("id", id);

            var source = base.ExecutarQueryFirstOrDefault<Cartao>(query: query, listaParametros: filtros);

            return source;
        }

        public int Insert(Cartao cartao)
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
            string query = "delete from Cartao where Id = @id";

            var filtros = new DynamicParameters();
            filtros.Add("id", id);

            var result = base.Executar(query, filtros);

            return result;
        }
    }
}
