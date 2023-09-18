using DAL;
using Dapper;
using Model.ContasPagar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ModuloFaturaEmAberto
{
    public class FaturaEmAbertoRepository : BaseRepository, IFaturaEmAbertoRepository
    {
        public FaturaEmAbertoRepository(Ado ado) : base(ado)
        {
        }

        public List<FaturaEmAberto> GetAll()
        {
            string query = @"select Id,Descricao,Valor,DataCompra from FaturaEmAberto order by DataCompra desc;";
            var source = base.ExecutarQuery<FaturaEmAberto>(query, null);
            return source.ToList();
        }

        public FaturaEmAberto GetById(int id)
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
            string query = @"select isnull(sum(Valor),0) as Total from FaturaEmAberto;";
            var total = base.ExecutarQueryFirstOrDefault<decimal>(query: query, listaParametros: null);
            return total;
        }

        public int Insert(FaturaEmAberto faturaEmAberto)
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
            string query = "delete from FaturaEmAberto where Id = @Id";

            var filtros = new DynamicParameters();
            filtros.Add("Id", id);

            var result = base.Executar(query: query, listaParametros: filtros);

            return result;
        }
    }
}
