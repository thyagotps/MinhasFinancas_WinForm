using DAL;
using Dapper;

namespace Model.FormaPagamentos
{
    public class FormaPagamentoRepository : IFormaPagamentoRepository
    {

        private readonly Ado _ado;

        public FormaPagamentoRepository(Ado ado)
        {
            _ado = ado;
        }


        public List<FormaPagamento> GetAll()
        {
            using (var conn = _ado.Conectar())
            {
                string query = "select Id, Descricao from FormaPagamento";
                List<FormaPagamento> source = conn.Query<FormaPagamento>(sql: query).ToList();
                return source;
            }
        }

        public FormaPagamento GetById(int id)
        {
            using (var conn = _ado.Conectar())
            {
                string query = "select Id, Descricao from FormaPagamento where Id = @id";
                var pagamento = conn.QueryFirstOrDefault<FormaPagamento>(sql: query, param: new { id });
                return pagamento;
            }
        }

        public int Insert(FormaPagamento pagamento)
        {
            using (var conn = _ado.Conectar())
            {
                string query = "insert into FormaPagamento (Descricao) values (@Descricao)";
                var result = conn.Execute(sql: query, param: pagamento);
                return result;
            }
        }

        public int Update(FormaPagamento pagamento)
        {
            using (var conn = _ado.Conectar())
            {
                string query = @"update FormaPagamento 
                                 set Descricao = @Descricao
                                 where Id = @Id";
                var result = conn.Execute(sql: query, param: pagamento);
                return result;
            }
        }

        public int Delete(int id)
        {
            using (var conn = _ado.Conectar())
            {
                string query = "delete from FormaPagamento where Id = @id";
                var result = conn.Execute(sql: query, param: new { id });
                return result;
            }
        }
    }
}
