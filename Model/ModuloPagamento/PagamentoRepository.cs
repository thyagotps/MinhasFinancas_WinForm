using DAL;
using Dapper;

namespace Model.ModuloPagamento
{
    public class PagamentoRepository : BaseRepository, IPagamentoRepository
    {
        public PagamentoRepository(Ado ado) : base(ado)
        {
        }

        public List<Pagamento> GetByDate(DateTime dtPeriodo)
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
            string query = "delete from Pagamento where Id = @Id";

            var filtros = new DynamicParameters();
            filtros.Add("Id", id);

            var result = base.Executar(query: query, listaParametros: filtros);

            return result;
        }
    }
}
