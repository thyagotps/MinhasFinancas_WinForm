using DAL;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Model.ModuloCartao;
using Model.ModuloCategoria;

namespace Model.ModuloMovimentoFinanceiro
{
    public class MovimentoFinanceiroRepository : BaseRepositoryEF<MovimentoFinanceiro>, IMovimentoFinanceiroRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly IAdo _ado;
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly ICartaoRepository _cartaoRepository;

        public MovimentoFinanceiroRepository(
            AppDbContext appDbContext,
            IAdo ado, 
            ICategoriaRepository categoriaRepository, 
            ICartaoRepository cartaoRepository) : base(appDbContext, ado)
        {
            _appDbContext = appDbContext;
            _ado = ado;
            _categoriaRepository = categoriaRepository;
            _cartaoRepository = cartaoRepository;
        }

        public List<MovimentoFinanceiro> GetAll()
        {
            var source = base.GetAll();
            return source.ToList();
        }

        public List<MovimentoFinanceiro> GetAll_Dapper()
        {
            var query = @"select 
                            Id,
                            TipoMovimento,
                            DataMovimento,
                            Descricao,
                            Valor,
                            IdCategoria,
                            IdCartao
                          from MovimentoFinanceiro
                          order by DataMovimento desc";

            var source = base.ExecutarQuery<MovimentoFinanceiro>(query: query, listaParametros: null).ToList();

            foreach (var item in source)
            {
                item.Categoria = _categoriaRepository.GetById(item.IdCategoria);
                item.Cartao = _cartaoRepository.GetById(item.IdCartao);
            }

            return source;
        }

        public MovimentoFinanceiro GetById(int id)
        {
            var source = _appDbContext.MovimentoFinanceiro
                .Include(x => x.Cartao)
                .Include(x => x.Categoria)
                .Where(x => x.Id == id).FirstOrDefault();
            return source;
        }

        public MovimentoFinanceiro GetById_Dapper(int id)
        {
            string query = @"select
                                Id,
                                TipoMovimento,
                                DataMovimento,
                                Descricao,
                                Valor,
                                IdCategoria,
                                IdCartao
                             from MovimentoFinanceiro
                             where Id = @Id";

            var filtros = new DynamicParameters();
            filtros.Add("Id", id);

            var source = base.ExecutarQueryFirstOrDefault<MovimentoFinanceiro>(query, filtros);

            source.Categoria = _categoriaRepository.GetById(source.IdCategoria);
            source.Cartao = _cartaoRepository.GetById(source.IdCartao);

            return source;
        }

        public List<MovimentoFinanceiro> GetByMonth(int year, int month)
        {
            var source = _appDbContext.MovimentoFinanceiro
                .Include(x => x.Cartao)
                .Include(x => x.Categoria)
                .Where(x => x.DataMovimento.Year == year
                       && x.DataMovimento.Month == month)
                .OrderByDescending(x => x.DataMovimento);

            return source.ToList();
        }

        public List<MovimentoFinanceiro> GetByMonth_Dapper(int year, int month)
        {
            string query = @"select
	                            Id,
                                TipoMovimento,
                                DataMovimento,
                                Descricao,
                                Valor,
                                IdCategoria,
                                IdCartao
                             from MovimentoFinanceiro
                             where month(DataMovimento) = @month
                             and year(DataMovimento) = @year
                             order by DataMovimento desc";

            var filtros = new DynamicParameters();
            filtros.Add("year", year);
            filtros.Add("month", month);

            var source = base.ExecutarQuery<MovimentoFinanceiro>(query, filtros);

            foreach (var item in source)
            {
                item.Categoria = _categoriaRepository.GetById(item.IdCategoria);
                item.Cartao = _cartaoRepository.GetById(item.IdCartao);
            }

            return source.ToList();
        }

        public decimal GetTotalRendaByMonth(int year, int month)
        {
            var source = _appDbContext.MovimentoFinanceiro
                .Include(x => x.Cartao)
                .Include(x => x.Categoria)
                .Where(x => x.DataMovimento.Year == year
                       && x.DataMovimento.Month == month
                       && x.TipoMovimento == "Renda");
            return source.Sum(x => x.Valor);
        }

        public decimal GetTotalRendaByMonth_Dapper(int year, int month)
        {
            string query = @"select
                                sum(Valor) as Valor
                            from MovimentoFinanceiro
                            where month(DataMovimento) = @month
                            and year(DataMovimento) = @year
                            and TipoMovimento = 'Renda'
                            group by convert(varchar(6), DataMovimento, 112);";

            var filtros = new DynamicParameters();
            filtros.Add("year", year);
            filtros.Add("month", month);

            var total = base.ExecutarQueryFirstOrDefault<decimal>(query: query, listaParametros: filtros);

            return total;
        }

        public decimal GetTotalDespesaByMonth(int year, int month)
        {
            var source = _appDbContext.MovimentoFinanceiro
                .Include(x => x.Cartao)
                .Include(x => x.Categoria)
                .Where(x => x.DataMovimento.Year == year
                       && x.DataMovimento.Month == month
                       && x.TipoMovimento == "Despesa");
            return source.Sum(x => x.Valor);
        }

        public decimal GetTotalDespesaByMonth_Dapper(int year, int month)
        {
            string query = @"select
                                sum(Valor) as Valor
                            from MovimentoFinanceiro
                            where month(DataMovimento) = @month
                            and year(DataMovimento) = @year
                            and TipoMovimento = 'Despesa'
                            group by convert(varchar(6), DataMovimento, 112);";

            var filtros = new DynamicParameters();
            filtros.Add("year", year);
            filtros.Add("month", month);

            var total = base.ExecutarQueryFirstOrDefault<decimal>(query: query, listaParametros: filtros);

            return total;
        }

        public int Insert(MovimentoFinanceiro movimentoFinanceiro)
        {
            _appDbContext.ChangeTracker.Clear();
            _appDbContext.MovimentoFinanceiro.Add(movimentoFinanceiro);
            return _appDbContext.SaveChanges();
        }

        public int Insert_Dapper(MovimentoFinanceiro movimentoFinanceiro)
        {
            string query = @"insert into MovimentoFinanceiro
                            (TipoMovimento, DataMovimento, Descricao, Valor, IdCategoria, IdCartao)
                            values
                            (@TipoMovimento, @DataMovimento, @Descricao, @Valor, @IdCategoria, @IdCartao)";

            var filtros = new DynamicParameters();
            filtros.Add("TipoMovimento", movimentoFinanceiro.TipoMovimento);
            filtros.Add("DataMovimento", movimentoFinanceiro.DataMovimento);
            filtros.Add("Descricao", movimentoFinanceiro.Descricao);
            filtros.Add("Valor", movimentoFinanceiro.Valor);
            filtros.Add("IdCategoria", movimentoFinanceiro.IdCategoria);
            filtros.Add("IdCartao", movimentoFinanceiro.IdCartao);

            var result = base.Executar(query: query, listaParametros: filtros);

            return result;
        }

        public int Update(MovimentoFinanceiro movimentoFinanceiro)
        {
            return base.Update(movimentoFinanceiro);
        }

        public int Update_Dapper(MovimentoFinanceiro movimentoFinanceiro)
        {
            string query = @"update MovimentoFinanceiro set 
                            TipoMovimento = @TipoMovimento, 
                            DataMovimento = @DataMovimento, 
                            Descricao = @Descricao,
                            Valor = @Valor,
                            IdCategoria = @IdCategoria,
                            IdCartao = @IdCartao
                            where Id = @Id";

            var filtros = new DynamicParameters();
            filtros.Add("TipoMovimento", movimentoFinanceiro.TipoMovimento);
            filtros.Add("DataMovimento", movimentoFinanceiro.DataMovimento);
            filtros.Add("Descricao", movimentoFinanceiro.Descricao);
            filtros.Add("Valor", movimentoFinanceiro.Valor);
            filtros.Add("IdCategoria", movimentoFinanceiro.IdCategoria);
            filtros.Add("IdCartao", movimentoFinanceiro.IdCartao);
            filtros.Add("Id", movimentoFinanceiro.Id);

            var result = base.Executar(query: query, listaParametros: filtros);

            return result;
        }

        public int DeleteById(int id)
        {
            var objDelete = GetById(id);
            return base.Delete(objDelete);
        }

        public int DeleteById_Dapper(int id)
        {
            string query = "delete from MovimentoFinanceiro where Id = @id";

            var filtros = new DynamicParameters();
            filtros.Add("id", id);

            var result = base.Executar(query: query, listaParametros: filtros);

            return result;
        }
    }
}

