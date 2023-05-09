using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Dapper;

namespace Model
{
    public class MovimentoRepository : IMovimentoRepository
    {
        private readonly Ado _ado;
        private readonly CategoriaRepository _categoriaRepository;
        private readonly PagamentoRepository _pagamentoRepository;

        public MovimentoRepository(Ado ado, 
                                   CategoriaRepository categoriaRepository,
                                   PagamentoRepository pagamentoRepository)
        {
            _ado = ado;
            _categoriaRepository = categoriaRepository;
            _pagamentoRepository = pagamentoRepository;
        }

        public List<Movimento> GetAll()
        {
            using (var conn = _ado.Conectar())
            {
                var query = @"select 
                                Id,
                                DataCompra,
                                Descricao,
                                Parcelas,
                                Valor,
                                DataVencimento,
                                Situacao,
                                Categoria as CategoriaId,
                                Pagamento as PagamentoId 
                              from Movimento";

                List<Movimento> source = conn.Query<Movimento>(sql: query).ToList();

                foreach (var mov in source)
                {
                    mov.Categoria = _categoriaRepository.GetById(mov.CategoriaId);
                    mov.Pagamento = _pagamentoRepository.GetById(mov.PagamentoId);
                }

                return source;
            }
        }

        //Arrumar a query aqui
        public Movimento GetById(int Id)
        {
            using (var conn = _ado.Conectar())
            {
                string query = @"select
	                                mov.Id as Id,
	                                mov.DataCompra as DataCompra,
	                                mov.Descricao as Descricao,
	                                mov.Parcelas as Parcelas,
	                                mov.Valor as Valor,
	                                mov.DataVencimento as DataVencimento,
	                                mov.Situacao as Situacao,
	                                mov.Id as CategoriaId,
	                                mov.Pagamento as PagamentoId,

	                                cat.Id,
	                                cat.Descricao as Descricao,
	                                cat.Sinal,

	                                pag.Id,
	                                pag.Descricao
                                from Movimento mov
                                inner join Categoria cat on mov.Categoria = cat.Id
                                inner join Pagamento pag on mov.Pagamento = pag.Id
                                where mov.Id = @Id";
                //var movimento = conn.QueryFirstOrDefault<Movimento>(sql: query, param: new { id });
                //return movimento;
                var source = conn.Query<Movimento, Categoria, Pagamento, Movimento>(sql: query, (movimento, categoria, pagamento) =>
                {
                    movimento.Categoria = categoria;
                    movimento.Pagamento = pagamento;
                    return movimento;
                }, splitOn: "Id,Id"


                ,param: new { Id }).FirstOrDefault();
                return source;

            }
        }

        public int Insert(Movimento movimento)
        {
            using (var conn = _ado.Conectar())
            {
                string query = @"insert into Movimento 
                                (DataCompra, Descricao, Parcelas, Valor, DataVencimento, Situacao, Categoria, Pagamento)
                                values
                                (@DataCompra, @Descricao, @Parcelas, @Valor, @DataVencimento, @Situacao, @CategoriaId, @PagamentoId)";
                var result = conn.Execute(sql: query, param: movimento);
                return result;
            }
        }

        public int Update(Movimento movimento)
        {
            using (var conn = _ado.Conectar())
            {
                string query = @"update Movimento set 
                                 DataCompra = @DataCompra, 
                                 Descricao = @Descricao,
                                 Parcelas = @Parcelas,
                                 Valor = @Valor,
                                 DataVencimento = @DataVencimento,
                                 Situacao = @Situacao,
                                 Categoria = @CategoriaId,
                                 Pagamento = @PagamentoId
                                 where Id = @Id";
                var result = conn.Execute(sql: query, param: movimento);
                return result;
            }
        }

        public int Delete(int id)
        {
            using (var conn = _ado.Conectar())
            {
                string query = "delete from Movimento where Id = @id";
                var result = conn.Execute(sql: query, param: new { id });
                return result;
            }
        }

        public List<Movimento> BuscarMovimento(MovimentoFiltro movimentoFiltro)
        {
            using (var conn = _ado.Conectar())
            {
                var sql = "PROC_MOVIMENTO_BUSCAR";
                var param = new
                {
                    DataCompra = movimentoFiltro.DataCompra,
                    Categoria = movimentoFiltro.Categoria,
                    Pagamento = movimentoFiltro.Pagamento
                };
                var result = conn.Query<Movimento>(sql, param, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }
    }
}
