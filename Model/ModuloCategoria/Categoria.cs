using Model.ModuloContaPadrao;
using Model.ModuloMovimentoFinanceiro;

namespace Model.ModuloCategoria
{
    public class Categoria
    {
        public int Id { get; set; }

        public string? Descricao { get; set; }

        public string? Tipo { get; set; }

        public ICollection<MovimentoFinanceiro> MovimentoFinanceiros { get; set; }

        public ICollection<ContaPadrao> ContasPadrao { get; set; }

        public string DisplayMember => $"{Id} - {Descricao} - {Tipo}";
    }
}