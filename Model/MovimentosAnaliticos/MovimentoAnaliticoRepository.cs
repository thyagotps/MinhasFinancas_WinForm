using DAL;
using Dapper;
using Model.ModuloCategoria;
using Model.FormaPagamentos;

namespace Model.MovimentosAnaliticos
{
    public class MovimentoAnaliticoRepository : BaseRepository, IMovimentoAnaliticoRepository
    {
        private readonly Ado _ado;
        private readonly CategoriaRepository _categoriaRepository;
        private readonly FormaPagamentoRepository _pagamentoRepository;

        public MovimentoAnaliticoRepository(Ado ado,
                                            CategoriaRepository categoriaRepository,
                                            FormaPagamentoRepository pagamentoRepository) : base(ado)
        {
            _ado = ado;
            _categoriaRepository = categoriaRepository;
            _pagamentoRepository = pagamentoRepository;
        } 

        public List<MovimentoAnalitico> GetAll()
        {
            var query = @"select 
                            Id,
                            DataCompra,
                            Descricao,
                            Valor,
                            Categoria as CategoriaId,
                            Pagamento as FormaPagamentoId 
                          from MovimentoAnalitico
                          order by DataCompra desc";

            var sources = base.ExecutarQuery<MovimentoAnalitico>(query: query, listaParametros: null).ToList();

            foreach (var item in sources)
            {
                item.Categoria = _categoriaRepository.GetById(item.CategoriaId);
                item.FormaPagamento = _pagamentoRepository.GetById(item.FormaPagamentoId);
            }

            return sources;
        }

        public MovimentoAnalitico GetById(int Id)
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

            var filtros = new DynamicParameters();
            filtros.Add("Id", Id);

            var source = base.ExecutarQueryFirstOrDefault<MovimentoAnalitico>(query, filtros);

            source.Categoria = _categoriaRepository.GetById(source.CategoriaId);
            source.FormaPagamento = _pagamentoRepository.GetById(source.FormaPagamentoId);
            
            return source;
        }

        public List<MovimentoAnalitico> GetByMonth(int year, int month)
        {
            string query = @"select
	                            Id,
                                DataCompra,
                                Descricao,
                                Valor,
                                Categoria as CategoriaId,
                                Pagamento as FormaPagamentoId
                            from MovimentoAnalitico mov
                            where month(DataCompra) = @month
                            and year(DataCompra) = @year
                            order by DataCompra desc";

            var filtros = new DynamicParameters();
            filtros.Add("year", year);
            filtros.Add("month", month);

            var source = base.ExecutarQuery<MovimentoAnalitico>(query, filtros);

            foreach (var item in source)
            {
                item.Categoria = _categoriaRepository.GetById(item.CategoriaId);
                item.FormaPagamento = _pagamentoRepository.GetById(item.FormaPagamentoId);
            }

            return source.ToList();
        }

        public List<MovimentoAnalitico> BuscarMovimentosAnaliticos(MovimentoAnaliticoFiltro movimentoFiltro)
        {
            var nameProc = "PROC_MOVIMENTO_BUSCAR";

            var filtros = new DynamicParameters();
            filtros.Add("DataCompra", movimentoFiltro.DataCompra);
            filtros.Add("Categoria", movimentoFiltro.Categoria);
            filtros.Add("Pagamento", movimentoFiltro.Pagamento);

            var souces = base.ExecutarProcedure<MovimentoAnalitico>(nameProc: nameProc, listaParametros: filtros).ToList();

            foreach (var item in souces)
            {
                item.Categoria = _categoriaRepository.GetById(item.CategoriaId);
                item.FormaPagamento = _pagamentoRepository.GetById(item.FormaPagamentoId);
            }

            return souces;
        }

        public decimal GetTotal(MovimentoAnaliticoFiltro filtro)
        {
            string query = @"select
                                sum(Valor) as Valor
                            from MovimentoAnalitico mov
                            where (@DataCompra is null or convert(varchar(6), DataCompra, 112) = convert(varchar(6), @DataCompra, 112))
                            and (@Categoria = 0 or Categoria = @Categoria)
                            and (@Pagamento = 0 or Pagamento = @Pagamento)
                            group by convert(varchar(6), DataCompra, 112);";

            var filtros = new DynamicParameters();
            filtros.Add("DataCompra", filtro.DataCompra);
            filtros.Add("Categoria", filtro.Categoria);
            filtros.Add("Pagamento", filtro.Pagamento);

            var total = base.ExecutarQueryFirstOrDefault<decimal>(query: query, listaParametros: filtros);

            return total;
        }

        public int Insert(MovimentoAnalitico movimento)
        {
            string query = @"insert into MovimentoAnalitico
                            (DataCompra, Descricao, Valor, Categoria, Pagamento)
                            values
                            (@DataCompra, @Descricao, @Valor, @CategoriaId, @FormaPagamentoId)";

            var filtros = new DynamicParameters();
            filtros.Add("DataCompra", movimento.DataCompra);
            filtros.Add("Descricao", movimento.Descricao);
            filtros.Add("Valor", movimento.Valor);
            filtros.Add("CategoriaId", movimento.CategoriaId);
            filtros.Add("FormaPagamentoId", movimento.FormaPagamentoId);

            var result = base.Executar(query: query, listaParametros: filtros);

            return result;
        }

        public int Update(MovimentoAnalitico movimento)
        {
            string query = @"update MovimentoAnalitico set 
                            DataCompra = @DataCompra, 
                            Descricao = @Descricao,
                            Valor = @Valor,
                            Categoria = @CategoriaId,
                            Pagamento = @FormaPagamentoId
                            where Id = @Id";

            var filtros = new DynamicParameters();
            filtros.Add("DataCompra", movimento.DataCompra);
            filtros.Add("Descricao", movimento.Descricao);
            filtros.Add("Valor", movimento.Valor);
            filtros.Add("CategoriaId", movimento.CategoriaId);
            filtros.Add("FormaPagamentoId", movimento.FormaPagamentoId);
            filtros.Add("Id", movimento.Id);

            var result = base.Executar(query: query, listaParametros: filtros);

            return result;
        }

        public int Delete(int id)
        {
            string query = "delete from MovimentoAnalitico where Id = @id";
            
            var filtros = new DynamicParameters();
            filtros.Add("id", id);

            var result = base.Executar(query: query, listaParametros: filtros);

            return result;
        }

    }
}
