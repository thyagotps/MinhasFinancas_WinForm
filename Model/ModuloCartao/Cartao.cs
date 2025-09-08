using Model.ModuloContaPadrao;
using Model.ModuloMovimentoFinanceiro;

namespace Model.ModuloCartao
{
    public class Cartao
    {
        public int Id { get; set; }
        
        public string? Descricao { get; set; }

        public string? Tipo { get; set; }

        public decimal ValorSaldo { get; set; }

        public ICollection<MovimentoFinanceiro> MovimentoFinanceiros { get; set; }

        public ICollection<ContaPadrao> ContasPadrao { get; set; }

        public string DisplayMember => $"{Id} - {Descricao}";
    }
}
