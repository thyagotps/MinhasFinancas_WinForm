using DAL;
using Dapper;

namespace Model.ModuloFaturaEmAberto
{
    public class FaturaEmAbertoRepository : BaseRepositoryEF<FaturaEmAberto>, IFaturaEmAbertoRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly IAdo _ado;

        public FaturaEmAbertoRepository(AppDbContext appDbContext, IAdo ado) : base(appDbContext, ado)
        {
            _ado = ado;
            _appDbContext = appDbContext;
        }

        public List<FaturaEmAberto> GetAll()
        {
            var source = base.GetAll().OrderByDescending(x => x.DataCompra);
            return source.ToList();
        }

        public List<FaturaEmAberto> GetAll_Dapper()
        {
            string query = @"select Id,Descricao,Valor,DataCompra from FaturaEmAberto order by DataCompra desc;";
            var source = base.ExecutarQuery<FaturaEmAberto>(query, null);
            return source.ToList();
        }

        public FaturaEmAberto GetById(int id)
        {
            var source = base.GetById(id);
            return source;
        }

        public FaturaEmAberto GetById_Dapper(int id)
        {
            string query = @"select 
	                            Id,Descricao,Valor,DataCompra
                            from FaturaEmAberto
                            where Id = @id
                            order by DataCompra desc";

            var filtros = new DynamicParameters();
            filtros.Add("id", id);

            var source = base.ExecutarQueryFirstOrDefault<FaturaEmAberto>(query, filtros);
            return source;
        }

        public decimal GetTotal()
        {
            var source = GetAll();
            return source.Sum(x => x.Valor);
        }

        public decimal GetTotal_Dapper()
        {
            string query = @"select isnull(sum(Valor),0) as Total from FaturaEmAberto;";
            var total = base.ExecutarQueryFirstOrDefault<decimal>(query: query, listaParametros: null);
            return total;
        }

        public int Insert(FaturaEmAberto faturaEmAberto)
        {
            return base.Insert(faturaEmAberto);
        }

        public int Insert_Dapper(FaturaEmAberto faturaEmAberto)
        {
            string query = @"insert into FaturaEmAberto (Descricao,Valor,DataCompra) 
                             values (@Descricao,@Valor,@DataCompra);";

            var filtros = new DynamicParameters();
            filtros.Add("Descricao", faturaEmAberto.Descricao);
            filtros.Add("Valor", faturaEmAberto.Valor);
            filtros.Add("DataCompra", faturaEmAberto.DataCompra);

            var result = base.Executar(query: query, listaParametros: filtros);

            return result;
        }
        public int Update(FaturaEmAberto faturaEmAberto)
        {
            return base.Update(faturaEmAberto);
        }

        public int Update_Dapper(FaturaEmAberto faturaEmAberto)
        {
            string query = @"update FaturaEmAberto set
                             Descricao = @Descricao,
                             Valor = @Valor,
                             DataCompra = @DataCompra
                             where Id = @Id";


            var filtros = new DynamicParameters();
            filtros.Add("Id", faturaEmAberto.Id);
            filtros.Add("Descricao", faturaEmAberto.Descricao);
            filtros.Add("Valor", faturaEmAberto.Valor);
            filtros.Add("DataCompra", faturaEmAberto.DataCompra);

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
            string query = "delete from FaturaEmAberto where Id = @Id";

            var filtros = new DynamicParameters();
            filtros.Add("Id", id);

            var result = base.Executar(query: query, listaParametros: filtros);

            return result;
        }
    }
}
