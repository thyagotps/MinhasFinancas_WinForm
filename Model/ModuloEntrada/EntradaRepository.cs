using DAL;
using Dapper;
using Model.ModuloCategoria;

namespace Model.ModuloEntrada
{
    public class EntradaRepository : BaseRepository, IEntradaRepository
    {

        private readonly ICategoriaRepository _categoriaRepository;

        public EntradaRepository(
            Ado ado,
            ICategoriaRepository categoriaRepository) : base(ado)
        {
            _categoriaRepository = categoriaRepository;
        }

        public List<Entrada> GetAll()
        {
            string query = @"select 
                                Id, Descricao, DataEntrada, Valor, IdCategoria
                            from Entrada 
                            order by DataEntrada desc;";
            var source = base.ExecutarQuery<Entrada>(query, null);

            foreach (var item in source)
            {
                item.Categoria = _categoriaRepository.GetById(item.IdCategoria);
            }

            return source.ToList();
        }

        public Entrada GetById(int id)
        {
            string query = @"select 
	                            Id, Descricao, DataEntrada, Valor, IdCategoria
                            from Entrada
                            where Id = @id
                            order by DataEntrada desc";

            var filtros = new DynamicParameters();
            filtros.Add("id", id);

            var source = base.ExecutarQueryFirstOrDefault<Entrada>(query, filtros);

            source.Categoria = _categoriaRepository.GetById(source.IdCategoria);

            return source;
        }

        public int Insert(Entrada entrada)
        {
            string query = @"insert into Entrada (Descricao, DataEntrada, Valor, IdCategoria) 
                             values (@Descricao, @DataEntrada, @Valor, @IdCategoria);";

            var filtros = new DynamicParameters();
            filtros.Add("Descricao", entrada.Descricao);
            filtros.Add("DataEntrada", entrada.DataEntrada);
            filtros.Add("Valor", entrada.Valor);
            filtros.Add("IdCategoria", entrada.IdCategoria);

            var result = base.Executar(query: query, listaParametros: filtros);

            return result;
        }

        public int Update(Entrada entrada)
        {
            string query = @"update Entrada set
                             Descricao = @Descricao,
                             DataEntrada = @DataEntrada,
                             Valor = @Valor,
                             IdCategoria = @IdCategoria
                             where Id = @Id";

            var filtros = new DynamicParameters();
            filtros.Add("Id", entrada.Id);
            filtros.Add("Descricao", entrada.Descricao);
            filtros.Add("DataEntrada", entrada.DataEntrada);
            filtros.Add("Valor", entrada.Valor);
            filtros.Add("IdCategoria", entrada.IdCategoria);

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
    }
}
