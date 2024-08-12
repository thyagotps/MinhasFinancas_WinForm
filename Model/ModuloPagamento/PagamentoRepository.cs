using DAL;
using Dapper;
using Model.ModuloCartao;

namespace Model.ModuloPagamento
{
    public class PagamentoRepository : BaseRepositoryEF<Pagamento>, IPagamentoRepository
    {

        private readonly AppDbContext _appDbContext;
        private readonly IAdo _ado;

        public PagamentoRepository(AppDbContext appDbContext, IAdo ado) : base(appDbContext, ado)
        {
            _ado = ado;
            _appDbContext = appDbContext;
        }

        public List<Pagamento> GetByDate(DateTime dtPeriodo)
        {
            var source = _appDbContext.Pagamento.Where
                (x => x.DataVencimento.Year == dtPeriodo.Year
                && x.DataVencimento.Month == dtPeriodo.Month
                ).OrderBy(x => x.NrIdentificador);
            return source.ToList();
        }

        public List<Pagamento> GetByDate_Dapper(DateTime dtPeriodo)
        {
            string query = @"select 
                                Id, 
                                NrIdentificador, 
                                Descricao, 
                                Valor, 
                                DataVencimento, 
                                Situacao 
                             from Pagamento 
                             where convert(varchar(6),DataVencimento,112) = convert(varchar(6),@DataVencimento,112)
                             order by NrIdentificador;";

            var filtros = new DynamicParameters();
            filtros.Add("DataVencimento", dtPeriodo);

            var source = base.ExecutarQuery<Pagamento>(query, filtros);

            return source.ToList();
        }

        public Pagamento GetById(int id)
        {
            var source = base.GetById(id);
            return source;
        }

        public Pagamento GetById_Dapper(int id)
        {
            string query = @"select 
	                            Id, NrIdentificador, Descricao, Valor, DataVencimento, Situacao 
                            from Pagamento
                            where Id = @id";

            var filtros = new DynamicParameters();
            filtros.Add("id", id);

            var source = base.ExecutarQueryFirstOrDefault<Pagamento>(query, filtros);
            return source;
        }

        public decimal GetTotalByDate(DateTime dtPeriodo)
        {
            var source = GetByDate(dtPeriodo);
            return source.Sum(x => x.Valor);
        }

        public decimal GetTotalByDate_Dapper(DateTime dtPeriodo)
        {
            string query = @"select 
                                isnull(sum(Valor),0) as Total 
                             from Pagamento 
                             where convert(varchar(6),DataVencimento,112) = convert(varchar(6),@Periodo,112);";

            var filtros = new DynamicParameters();
            filtros.Add("Periodo", dtPeriodo);

            var total = base.ExecutarQueryFirstOrDefault<decimal>(query: query, listaParametros: filtros);

            return total;
        }

        public int Insert(Pagamento pagamento)
        {
            return base.Insert(pagamento);
        }

        public int Insert_Dapper(Pagamento pagamento)
        {
            string query = @"insert into Pagamento 
                             (NrIdentificador, Descricao, Valor, DataVencimento, Situacao) 
                             values 
                             (@NrIdentificador,@Descricao,@Valor,@DataVencimento,@Situacao);";

            var filtros = new DynamicParameters();
            filtros.Add("NrIdentificador", pagamento.NrIdentificador);
            filtros.Add("Descricao", pagamento.Descricao);
            filtros.Add("Valor", pagamento.Valor);
            filtros.Add("DataVencimento", pagamento.DataVencimento);
            filtros.Add("Situacao", pagamento.Situacao);

            var result = base.Executar(query: query, listaParametros: filtros);

            return result;
        }

        public int Update(Pagamento pagamento)
        {
            return base.Update(pagamento);
        }

        public int Update_Dapper(Pagamento pagamento)
        {
            string query = @"update Pagamento set
                             NrIdentificador = @NrIdentificador,
                             Descricao = @Descricao,
                             Valor = @Valor,
                             DataVencimento = @DataVencimento,
                             Situacao = @Situacao
                             where Id = @Id";


            var filtros = new DynamicParameters();
            filtros.Add("Id", pagamento.Id);
            filtros.Add("NrIdentificador", pagamento.NrIdentificador);
            filtros.Add("Descricao", pagamento.Descricao);
            filtros.Add("Valor", pagamento.Valor);
            filtros.Add("DataVencimento", pagamento.DataVencimento);
            filtros.Add("Situacao", pagamento.Situacao);

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
            string query = "delete from Pagamento where Id = @Id";

            var filtros = new DynamicParameters();
            filtros.Add("Id", id);

            var result = base.Executar(query: query, listaParametros: filtros);

            return result;
        }
    }
}
