using DAL;
using Dapper;
using Model.ModuloCategoria;

namespace Model.FormaPagamentos
{
    public class FormaPagamentoRepository : BaseRepository, IFormaPagamentoRepository
    {

        private readonly Ado _ado;

        public FormaPagamentoRepository(Ado ado) : base(ado)
        {
            _ado = ado;
        }


        public List<FormaPagamento> GetAll()
        {
            string query = "select Id, Descricao from FormaPagamento";
            var source = base.ExecutarQuery<FormaPagamento>(query: query, listaParametros: null).ToList();
            return source;
        }

        public FormaPagamento GetById(int id)
        {
            string query = "select Id, Descricao from FormaPagamento where Id = @id";

            var filtros = new DynamicParameters();
            filtros.Add("id", id);

            var source = base.ExecutarQueryFirstOrDefault<FormaPagamento>(query: query, listaParametros: filtros);

            return source;
        }

        public int Insert(FormaPagamento pagamento)
        {
            string query = "insert into FormaPagamento (Descricao) values (@Descricao)";

            var filtros = new DynamicParameters();
            filtros.Add("Descricao", pagamento.Descricao);

            var result = base.Executar(query, filtros);

            return result;
        }

        public int Update(FormaPagamento pagamento)
        {
            string query = @"update FormaPagamento 
                                 set Descricao = @Descricao
                                 where Id = @Id";

            var filtros = new DynamicParameters();
            filtros.Add("Descricao", pagamento.Descricao);
            filtros.Add("Id", pagamento.Id);

            var result = base.Executar(query, filtros);

            return result;
        }

        public int Delete(int id)
        {
            string query = "delete from FormaPagamento where Id = @id";

            var filtros = new DynamicParameters();
            filtros.Add("id", id);

            var result = base.Executar(query, filtros);

            return result;
        }
    }
}
