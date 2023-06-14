using DAL;
using Dapper;
using Model.Categorias;
using Model.FormaPagamentos;
using System.Data;

namespace Model.MovimentosAnaliticos
{
    public class MovimentoAnaliticoRepository : IMovimentoAnaliticoRepository
    {
        private readonly Ado _ado;
        private readonly CategoriaRepository _categoriaRepository;
        private readonly FormaPagamentoRepository _pagamentoRepository;

        public MovimentoAnaliticoRepository(Ado ado,
                                            CategoriaRepository categoriaRepository,
                                            FormaPagamentoRepository pagamentoRepository)
        {
            _ado = ado;
            _categoriaRepository = categoriaRepository;
            _pagamentoRepository = pagamentoRepository;
        }

        public List<MovimentoAnalitico> GetAll()
        {
            using (var conn = _ado.Conectar())
            {
                var query = @"select 
                                Id,
                                DataCompra,
                                Descricao,
                                Valor,
                                Categoria as CategoriaId,
                                Pagamento as FormaPagamentoId 
                              from MovimentoAnalitico";

                List<MovimentoAnalitico> source = conn.Query<MovimentoAnalitico>(sql: query).ToList();

                foreach (var mov in source)
                {
                    mov.Categoria = _categoriaRepository.GetById(mov.CategoriaId);
                    mov.FormaPagamento = _pagamentoRepository.GetById(mov.FormaPagamentoId);
                }

                return source;
            }
        }

        
        public MovimentoAnalitico GetById(int Id)
        {
            using (var conn = _ado.Conectar())
            {
                string query = @"select
	                                Id,
                                    DataCompra,
                                    Descricao,
                                    Valor,
                                    Categoria as CategoriaId,
                                    Pagamento as FormaPagamentoId
                                from MovimentoAnalitico mov
                                where mov.Id = @Id";
                var movimento = conn.QueryFirstOrDefault<MovimentoAnalitico>(sql: query, param: new { Id });
                
                
                movimento.Categoria = _categoriaRepository.GetById(movimento.CategoriaId);
                movimento.FormaPagamento = _pagamentoRepository.GetById(movimento.FormaPagamentoId);
                return movimento;
            }
        }

        public int Insert(MovimentoAnalitico movimento)
        {
            using (var conn = _ado.Conectar())
            {
                string query = @"insert into MovimentoAnalitico
                                (DataCompra, Descricao, Vlor, Categoria, Pagamento)
                                values
                                (@DataCompra, @Descricao, @Valor, @CategoriaId, @PagamentoId)";
                var result = conn.Execute(sql: query, param: movimento);
                return result;
            }
        }

        public int Update(MovimentoAnalitico movimento)
        {
            using (var conn = _ado.Conectar())
            {
                string query = @"update MovimentoAnalitico set 
                                 DataCompra = @DataCompra, 
                                 Descricao = @Descricao,
                                 Valor = @Valor,
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
                string query = "delete from MovimentoAnalitico where Id = @id";
                var result = conn.Execute(sql: query, param: new { id });
                return result;
            }
        }

        public List<MovimentoAnalitico> BuscarMovimentosAnaliticos(MovimentoAnaliticoFiltro movimentoFiltro)
        {
            using (var conn = _ado.Conectar())
            {
                var sql = "PROC_MOVIMENTO_BUSCAR";
                var param = new
                {
                    movimentoFiltro.DataCompra,
                    movimentoFiltro.Categoria,
                    movimentoFiltro.Pagamento
                };
                var result = conn.Query<MovimentoAnalitico>(sql, param, commandType: CommandType.StoredProcedure).ToList();
                return result;
            }
        }

        public List<MovimentoAnalitico> GetByMonth(int month)
        {
            using (var conn = _ado.Conectar())
            {
                string query = @"select
	                                Id,
                                    DataCompra,
                                    Descricao,
                                    Valor,
                                    Categoria as CategoriaId,
                                    Pagamento as FormaPagamentoId
                                from MovimentoAnalitico mov
                                where month(DataCompra) = @month";
                var movimentos = conn.Query<MovimentoAnalitico>(sql: query, param: new { month }).ToList();

                foreach (var item in movimentos)
                {
                    item.Categoria = _categoriaRepository.GetById(item.CategoriaId);
                    item.FormaPagamento = _pagamentoRepository.GetById(item.FormaPagamentoId);
                }

                return movimentos;
            }
        }
    }
}
