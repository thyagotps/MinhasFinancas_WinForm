using DAL;
using Dapper;
using Model.ModuloFaturaEmAberto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ModuloSalario
{
    public class SalarioRepository : BaseRepository, ISalarioRepository
    {

        public SalarioRepository(Ado ado) : base(ado)
        {
                
        }

        public List<Salario> GetAll()
        {
            string query = @"select 
                                Id, Descricao, DataSalario, Valor, IdFormaPagamento
                            from Salario 
                            order by DataSalario desc;";
            var source = base.ExecutarQuery<Salario>(query, null);
            return source.ToList();
        }

        public Salario GetById(int id)
        {
            string query = @"select 
	                            Id, Descricao, DataSalario, Valor, IdFormaPagamento
                            from Salario
                            where Id = @id
                            order by DataSalario desc";

            var filtros = new DynamicParameters();
            filtros.Add("id", id);

            var source = base.ExecutarQueryFirstOrDefault<Salario>(query, filtros);
            return source;
        }

        public int Insert(Salario salario)
        {
            string query = @"insert into Salario (Descricao, DataSalario, Valor, IdFormaPagamento) 
                             values (@Descricao, @DataSalario, @Valor, @IdFormaPagamento);";

            var filtros = new DynamicParameters();
            filtros.Add("Descricao", salario.Descricao);
            filtros.Add("DataSalario", salario.DataSalario);
            filtros.Add("Valor", salario.Valor);
            filtros.Add("IdFormaPagamento", salario.IdFormaPagamento);

            var result = base.Executar(query: query, listaParametros: filtros);

            return result;
        }

        public int Update(Salario salario)
        {
            string query = @"update Salario set
                             Descricao = @Descricao,
                             DataSalario = @DataSalario,
                             Valor = @Valor,
                             IdFormaPagamento = @IdFormaPagamento
                             where Id = @Id";

            var filtros = new DynamicParameters();
            filtros.Add("Id", salario.Id);
            filtros.Add("Descricao", salario.Descricao);
            filtros.Add("DataSalario", salario.DataSalario);
            filtros.Add("Valor", salario.Valor);
            filtros.Add("IdFormaPagamento", salario.IdFormaPagamento);

            var result = base.Executar(query: query, listaParametros: filtros);

            return result;
        }

        public int DeleteById(int id)
        {
            string query = "delete from Salario where Id = @Id";

            var filtros = new DynamicParameters();
            filtros.Add("Id", id);

            var result = base.Executar(query: query, listaParametros: filtros);

            return result;
        }
    }
}
