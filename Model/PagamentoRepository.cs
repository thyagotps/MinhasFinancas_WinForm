using DAL;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class PagamentoRepository : IPagamentoRepository
    {

        private readonly DAL.Ado _ado;

        public PagamentoRepository(DAL.Ado ado)
        {
            _ado = ado;
        }


        public List<Pagamento> GetAll()
        {
            using (var conn = _ado.Conectar())
            {
                string query = "select * from Pagamento";
                List<Pagamento> source = conn.Query<Pagamento>(sql: query).ToList();
                return source;
            }
        }

        public Pagamento GetById(int id)
        {
            using (var conn = _ado.Conectar())
            {
                string query = "select * from Pagamento where Id = @id";
                var pagamento = conn.QueryFirstOrDefault<Pagamento>(sql: query, param: new { id });
                return pagamento;
            }
        }

        public int Insert(Pagamento pagamento)
        {
            using (var conn = _ado.Conectar())
            {
                string query = "insert into Pagamento (Descricao) values (@Descricao)";
                var result = conn.Execute(sql: query, param: pagamento);
                return result;
            }
        }

        public int Update(Pagamento pagamento)
        {
            using (var conn = _ado.Conectar())
            {
                string query = @"update Pagamento 
                                 set Descricao = @Descricao
                                 where Codigo = @Codigo";
                var result = conn.Execute(sql: query, param: pagamento);
                return result;
            }
        }

        public int Delete(int id)
        {
            using (var conn = _ado.Conectar())
            {
                string query = "delete from Pagamento where Codigo = @id";
                var result = conn.Execute(sql: query, param: new { id });
                return result;
            }
        }
    }
}
