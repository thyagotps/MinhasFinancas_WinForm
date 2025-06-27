using Model.ModuloCartao;
using Model.ModuloCategoria;

namespace Model.ModuloContaPadrao
{
    public class ContaPadrao
    {
        public int Id { get; set; }

        public string? TipoMovimento { get; set; }

        public DateTime DataMovimento { get; set; }

        public string? Descricao { get; set; }

        public decimal Valor { get; set; }

        public Categoria? Categoria { get; set; }
        public int? IdCategoria { get; set; }

        public Cartao? Cartao { get; set; }
        public int? IdCartao { get; set; }

        public DateTime? DataVencimento { get; set; }

        public string? Situacao { get; set; }

        public string DisplayMember => $"{Id} - {TipoMovimento} - {DataMovimento.ToString("dd/MM/yyyy")} - {Descricao} - {Valor.ToString()}";
    }
}
