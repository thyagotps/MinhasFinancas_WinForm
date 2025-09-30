using DAL;
using Microsoft.EntityFrameworkCore;

namespace Model.ModuloBalancoMensal
{
    public class BalancoMensalRepository : BaseRepositoryEF<BalancoMensal>, IBalancoMensalRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly IAdo _ado;

        public BalancoMensalRepository(AppDbContext context, IAdo ado) : base(context, ado)
        {
            _ado = ado;
            _appDbContext = context;
        }

        public BalancoMensal GetBalancoMensal(int idCartao, DateTime periodo)
        {
            var sourceMovFin = _appDbContext.MovimentoFinanceiro
                .Include(x => x.Cartao)
                .Where(x => x.IdCartao == idCartao
                && x.DataMovimento.Year == periodo.Year
                && x.DataMovimento.Month == periodo.Month).ToList();

            var CartaoDescricao = sourceMovFin.FirstOrDefault()?.Cartao?.Descricao ?? "Desconhecido";

            var ValorTotalReceita = sourceMovFin
                .Where(m => m.TipoMovimento == "Renda")
                .Sum(m => (decimal?)m.Valor) ?? 0;

            var ValorTotalDespesa = sourceMovFin
                .Where(m => m.TipoMovimento == "Despesa")
                .Sum(m => (decimal?)m.Valor) ?? 0;

            var dif = ValorTotalReceita - ValorTotalDespesa;

            var balanco = new BalancoMensal
            {
                CartaoDescricao = CartaoDescricao,
                ValorTotalReceita = ValorTotalReceita,
                ValorTotalDespesa = ValorTotalDespesa,
                SaldoFinal = dif
            };

            return balanco;
        }

        public List<BalancoMensalPorCategoria> GetBalancoMensalPorCategoria(int idCartao, DateTime periodo, string tipoMovimento)
        {
            var sourceMovFin = _appDbContext.MovimentoFinanceiro
                .Include(x => x.Categoria)
                .Where(x => x.IdCartao == idCartao
                && x.DataMovimento.Year == periodo.Year
                && x.DataMovimento.Month == periodo.Month
                && x.TipoMovimento == tipoMovimento)
                .GroupBy(x => x.Categoria)
                .Select(g => new BalancoMensalPorCategoria
                {
                    Categoria = g.Key.Descricao,
                    Valor = g.Sum(m => m.Valor)
                }).ToList();
            
            return sourceMovFin;
        }

    }
}
