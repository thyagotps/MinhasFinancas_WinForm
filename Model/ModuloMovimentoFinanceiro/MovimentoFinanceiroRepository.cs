using DAL;
using Dapper;
using Model.ModuloCartao;
using Model.ModuloCategoria;
using Model.ModuloSaida;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ModuloMovimentoFinanceiro
{
    public class MovimentoFinanceiroRepository : BaseRepository, IMovimentoFinanceiroRepository
    {
        private readonly Ado _ado;
        private readonly CategoriaRepository _categoriaRepository;
        private readonly CartaoRepository _cartaoRepository;

        public MovimentoFinanceiroRepository(
            Ado ado, 
            CategoriaRepository categoriaRepository, 
            CartaoRepository cartaoRepository) : base(ado)
        {
            _ado = ado;
            _categoriaRepository = categoriaRepository;
            _cartaoRepository = cartaoRepository;
        }

        public List<MovimentoFinanceiro> GetAll()
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
            string query = "delete from MovimentoFinanceiro where Id = @id";

            var filtros = new DynamicParameters();
            filtros.Add("id", id);

            var result = base.Executar(query: query, listaParametros: filtros);

            return result;
        }
    }
}
