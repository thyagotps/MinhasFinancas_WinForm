using DAL;
using Dapper;
using Model.MovimentosAnaliticos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ContasPagar
{
    public class ContaPagarRepository : BaseRepository, IContaPagarRepository
    {
        public ContaPagarRepository(Ado ado) : base(ado)
        {
        }

        public List<ContaPagar> Buscar(DateTime dtPeriodo)
        {
            string query = @"select 
                                Id, 
                                NrOrdem, 
                                Descricao, 
                                Valor, 
                                DataVencimento, 
                                Situacao 
                             from ContasPagar 
                             where convert(varchar(6),DataVencimento,112) = convert(varchar(6),@DataVencimento,112);";

            var filtros = new DynamicParameters();
            filtros.Add("DataVencimento", dtPeriodo);

            var source = base.ExecutarQuery<ContaPagar>(query, filtros);

            return source.ToList();
        }

       

        public ContaPagar GetById(int id)
        {
            string query = @"select 
	                            Id, NrOrdem, Descricao, Valor, DataVencimento, Situacao 
                            from ContasPagar
                            where Id = @id";

            var filtros = new DynamicParameters();
            filtros.Add("id", id);

            var source = base.ExecutarQueryFirstOrDefault<ContaPagar>(query, filtros);
            return source;
        }

        public decimal GetTotal(DateTime dtPeriodo)
        {
            string query = @"select 
                                sum(Valor) as Total 
                             from ContasPagar 
                             where convert(varchar(6),DataVencimento,112) = convert(varchar(6),@Periodo,112);";

            var filtros = new DynamicParameters();
            filtros.Add("Periodo", dtPeriodo);

            var total = base.ExecutarQueryFirstOrDefault<decimal>(query: query, listaParametros: filtros);

            return total;
        }

        public int Insert(ContaPagar contaPagar)
        {
            string query = @"insert into ContasPagar 
                             (NrOrdem, Descricao, Valor, DataVencimento, Situacao) 
                             values 
                             (@NrOrdem,@Descricao,@Valor,@DataVencimento,@Situacao);";

            var filtros = new DynamicParameters();
            filtros.Add("NrOrdem", contaPagar.NrOrdem);
            filtros.Add("Descricao", contaPagar.Descricao);
            filtros.Add("Valor", contaPagar.Valor);
            filtros.Add("DataVencimento", contaPagar.DataVencimento);
            filtros.Add("Situacao", contaPagar.Situacao);

            var result = base.Executar(query: query, listaParametros: filtros);

            return result;
        }

        public int Update(ContaPagar contaPagar)
        {
            string query = @"update ContasPagar set
                             NrOrdem = @NrOrdem,
                             Descricao = @Descricao,
                             Valor = @Valor,
                             DataVencimento = @DataVencimento,
                             Situacao = @Situacao
                             where Id = @Id";


            var filtros = new DynamicParameters();
            filtros.Add("Id", contaPagar.Id);
            filtros.Add("NrOrdem", contaPagar.NrOrdem);
            filtros.Add("Descricao", contaPagar.Descricao);
            filtros.Add("Valor", contaPagar.Valor);
            filtros.Add("DataVencimento", contaPagar.DataVencimento);
            filtros.Add("Situacao", contaPagar.Situacao);

            var result = base.Executar(query: query, listaParametros: filtros);

            return result;
        }

        public int DeleteById(int id)
        {
            string query = "delete from ContasPagar where Id = @Id";

            var filtros = new DynamicParameters();
            filtros.Add("Id", id);

            var result = base.Executar(query: query, listaParametros: filtros);

            return result;
        }
    }
}
