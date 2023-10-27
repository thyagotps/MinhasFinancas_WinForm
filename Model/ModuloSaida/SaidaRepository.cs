using DAL;
using Dapper;
using Model.ModuloCartao;
using Model.ModuloCategoria;

namespace Model.ModuloSaida
{
    public class SaidaRepository : BaseRepository, ISaidaRepository
    {
        private readonly Ado _ado;
        private readonly CategoriaRepository _categoriaRepository;
        private readonly CartaoRepository _cartaoRepository;

        public SaidaRepository(
            Ado ado,
            CategoriaRepository categoriaRepository,
            CartaoRepository cartaoRepository) : base(ado)
        {
            _ado = ado;
            _categoriaRepository = categoriaRepository;
            _cartaoRepository = cartaoRepository;
        }

        public List<Saida> GetAll()
        {
            var query = @"select 
                            Id,
                            DataSaida,
                            Descricao,
                            Valor,
                            IdCategoria,
                            IdCartao
                          from Saida
                          order by DataSaida desc";

            var source = base.ExecutarQuery<Saida>(query: query, listaParametros: null).ToList();

            foreach (var item in source)
            {
                item.Categoria = _categoriaRepository.GetById(item.IdCategoria);
                item.Cartao = _cartaoRepository.GetById(item.IdCartao);
            }

            return source;
        }

        public List<Saida> GetByFilter(SaidaFiltro saidaFiltro)
        {
            var query = @"select
	                        Id,
	                        DataSaida,
	                        Descricao,
	                        Valor,
	                        IdCategoria,
	                        IdCartao
                          from Saida saida
                          where (@DataSaida is null or convert(varchar(6), DataSaida, 112) = convert(varchar(6), @DataSaida, 112))
                          and (@IdCategoria = 0 or IdCategoria = @IdCategoria)
                          and (@IdCartao = 0 or IdCartao = @IdCartao)
                          order by DataSaida desc;";

            var filtros = new DynamicParameters();
            filtros.Add("DataSaida", saidaFiltro.DataSaida);
            filtros.Add("IdCategoria", saidaFiltro.IdCategoria);
            filtros.Add("IdCartao", saidaFiltro.IdCartao);

            var source = base.ExecutarQuery<Saida>(query: query, listaParametros: filtros).ToList();

            foreach (var item in source)
            {
                item.Categoria = _categoriaRepository.GetById(item.IdCategoria);
                item.Cartao = _cartaoRepository.GetById(item.IdCartao);
            }

            return source;
        }

        public Saida GetById(int id)
        {
            string query = @"select
                                Id,
                                DataSaida,
                                Descricao,
                                Valor,
                                IdCategoria,
                                IdCartao
                             from Saida
                             where Id = @Id";

            var filtros = new DynamicParameters();
            filtros.Add("Id", id);

            var source = base.ExecutarQueryFirstOrDefault<Saida>(query, filtros);

            source.Categoria = _categoriaRepository.GetById(source.IdCategoria);
            source.Cartao = _cartaoRepository.GetById(source.IdCartao);

            return source;
        }

        public List<Saida> GetByMonth(int year, int month)
        {
            string query = @"select
	                            Id,
                                DataSaida,
                                Descricao,
                                Valor,
                                IdCategoria,
                                IdCartao
                            from Saida
                            where month(DataSaida) = @month
                            and year(DataSaida) = @year
                            order by DataSaida desc";

            var filtros = new DynamicParameters();
            filtros.Add("year", year);
            filtros.Add("month", month);

            var source = base.ExecutarQuery<Saida>(query, filtros);

            foreach (var item in source)
            {
                item.Categoria = _categoriaRepository.GetById(item.IdCategoria);
                item.Cartao = _cartaoRepository.GetById(item.IdCartao);
            }

            return source.ToList();
        }

        public decimal GetTotal(SaidaFiltro saidaFiltro)
        {
            string query = @"select
                                sum(Valor) as Valor
                            from Saida
                            where (@DataSaida is null or convert(varchar(6), DataSaida, 112) = convert(varchar(6), @DataSaida, 112))
                            and (@IdCategoria = 0 or IdCategoria = @IdCategoria)
                            and (@IdCartao = 0 or IdCartao = @IdCartao)
                            group by convert(varchar(6), DataSaida, 112);";

            var filtros = new DynamicParameters();
            filtros.Add("DataSaida", saidaFiltro.DataSaida);
            filtros.Add("IdCategoria", saidaFiltro.IdCategoria);
            filtros.Add("IdCartao", saidaFiltro.IdCartao);

            var total = base.ExecutarQueryFirstOrDefault<decimal>(query: query, listaParametros: filtros);

            return total;
        }

        public int Insert(Saida saida)
        {
            string query = @"insert into Saida
                            (DataSaida, Descricao, Valor, IdCategoria, IdCartao)
                            values
                            (@DataSaida, @Descricao, @Valor, @IdCategoria, @IdCartao)";

            var filtros = new DynamicParameters();
            filtros.Add("DataSaida", saida.DataSaida);
            filtros.Add("Descricao", saida.Descricao);
            filtros.Add("Valor", saida.Valor);
            filtros.Add("IdCategoria", saida.IdCategoria);
            filtros.Add("IdCartao", saida.IdCartao);

            var result = base.Executar(query: query, listaParametros: filtros);

            return result;
        }

        public int Update(Saida saida)
        {
            string query = @"update Saida set 
                            DataSaida = @DataSaida, 
                            Descricao = @Descricao,
                            Valor = @Valor,
                            IdCategoria = @IdCategoria,
                            IdCartao = @IdCartao
                            where Id = @Id";

            var filtros = new DynamicParameters();
            filtros.Add("DataSaida", saida.DataSaida);
            filtros.Add("Descricao", saida.Descricao);
            filtros.Add("Valor", saida.Valor);
            filtros.Add("IdCategoria", saida.IdCategoria);
            filtros.Add("IdCartao", saida.IdCartao);
            filtros.Add("Id", saida.Id);

            var result = base.Executar(query: query, listaParametros: filtros);

            return result;
        }

        public int DeleteById(int id)
        {
            string query = "delete from Saida where Id = @id";

            var filtros = new DynamicParameters();
            filtros.Add("id", id);

            var result = base.Executar(query: query, listaParametros: filtros);

            return result;
        }
    }
}
