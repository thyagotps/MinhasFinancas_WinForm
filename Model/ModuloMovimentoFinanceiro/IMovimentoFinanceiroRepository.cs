using Model.ModuloSaida;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ModuloMovimentoFinanceiro
{
    public interface IMovimentoFinanceiroRepository
    {
        List<MovimentoFinanceiro> GetAll();
        MovimentoFinanceiro GetById(int id);
        List<MovimentoFinanceiro> GetByMonth(int year, int month);
        decimal GetTotalRendaByMonth(int year, int month);
        decimal GetTotalDespesaByMonth(int year, int month);
        public int Insert(MovimentoFinanceiro movimentoFinanceiro);
        public int Update(MovimentoFinanceiro movimentoFinanceiro);
        public int DeleteById(int id);
    }
}
