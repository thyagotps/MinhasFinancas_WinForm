using DAL;
using Dapper;
using Model.ModuloCartao;
using Model.ModuloCategoria;

namespace Model.ModuloEntrada
{
    public class EntradaRepository : BaseRepository, IEntradaRepository
    {

        private readonly ICategoriaRepository _categoriaRepository;
        private readonly ICartaoRepository _cartaoRepository;

        public EntradaRepository(
            Ado ado,
            ICategoriaRepository categoriaRepository,
            ICartaoRepository cartaoRepository) : base(ado)
        {
            _categoriaRepository = categoriaRepository;
            _cartaoRepository = cartaoRepository;
        }

        public List<Entrada> GetAll()
        {
            string query = @"select 
                                Id, Descricao, DataEntrada, Valor, IdCategoria, IdCartao
                            from Entrada 
                            order by DataEntrada desc;";
            var source = base.ExecutarQuery<Entrada>(query, null);

            foreach (var item in source)
            {
                item.Categoria = _categoriaRepository.GetById(item.IdCategoria);
                item.Cartao = _cartaoRepository.GetById(item.IdCartao);
            }

            return source.ToList();
        }

        public Entrada GetById(int id)
        {
            string query = @"select 
	                            Id, Descricao, DataEntrada, Valor, IdCategoria, IdCartao
                            from Entrada
                            where Id = @id
                            order by DataEntrada desc";

            var filtros = new DynamicParameters();
            filtros.Add("id", id);

            var source = base.ExecutarQueryFirstOrDefault<Entrada>(query, filtros);

            source.Categoria = _categoriaRepository.GetById(source.IdCategoria);
            source.Cartao = _cartaoRepository.GetById(source.IdCartao);

            return source;
        }

        public List<Entrada> GetByDate(DateTime periodo)
        {
            string query = @"select 
	                            Id, Descricao, DataEntrada, Valor, IdCategoria, IdCartao
                            from Entrada
                            where year(DataEntrada) = @ano
                            and month(DataEntrada) = @mes
                            order by DataEntrada desc";

            var filtros = new DynamicParameters();
            filtros.Add("ano", periodo.Year);
            filtros.Add("mes", periodo.Month);

            var source = base.ExecutarQuery<Entrada>(query, filtros);

            foreach (var item in source)
            {
                item.Categoria = _categoriaRepository.GetById(item.IdCategoria);
                item.Cartao = _cartaoRepository.GetById(item.IdCartao);
            }
            

            return source.ToList();
        }

        public int Insert(Entrada entrada)
        {
            string query = @"insert into Entrada (Descricao, DataEntrada, Valor, IdCategoria, IdCartao) 
                             values (@Descricao, @DataEntrada, @Valor, @IdCategoria, @IdCartao);";

            var filtros = new DynamicParameters();
            filtros.Add("Descricao", entrada.Descricao);
            filtros.Add("DataEntrada", entrada.DataEntrada);
            filtros.Add("Valor", entrada.Valor);
            filtros.Add("IdCategoria", entrada.IdCategoria);
            filtros.Add("IdCartao", entrada.IdCartao);

            var result = base.Executar(query: query, listaParametros: filtros);

            return result;
        }

        public int Update(Entrada entrada)
        {
            string query = @"update Entrada set
                             Descricao = @Descricao,
                             DataEntrada = @DataEntrada,
                             Valor = @Valor,
                             IdCategoria = @IdCategoria,
                             IdCartao = @IdCartao
                             where Id = @Id";

            var filtros = new DynamicParameters();
            filtros.Add("Id", entrada.Id);
            filtros.Add("Descricao", entrada.Descricao);
            filtros.Add("DataEntrada", entrada.DataEntrada);
            filtros.Add("Valor", entrada.Valor);
            filtros.Add("IdCategoria", entrada.IdCategoria);
            filtros.Add("IdCartao", entrada.IdCartao);

            var result = base.Executar(query: query, listaParametros: filtros);

            return result;
        }

        public int DeleteById(int id)
        {
            string query = "delete from Entrada where Id = @Id";

            var filtros = new DynamicParameters();
            filtros.Add("Id", id);

            var result = base.Executar(query: query, listaParametros: filtros);

            return result;
        }

        public decimal GetTotal(DateTime periodo)
        {
            string query = @"select
                                sum(Valor) as Valor
                            from Entrada
                            where convert(varchar(6), DataEntrada, 112) = convert(varchar(6), @periodo, 112)
                            group by convert(varchar(6), DataEntrada, 112);";

            var filtros = new DynamicParameters();
            filtros.Add("periodo", periodo);

            var total = base.ExecutarQueryFirstOrDefault<decimal>(query: query, listaParametros: filtros);

            return total;
        }


    }
}
