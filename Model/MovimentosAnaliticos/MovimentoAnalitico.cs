using Model.ModuloCartao;
using Model.ModuloCategoria;

namespace Model.MovimentosAnaliticos
{
    public class MovimentoAnalitico
    {
        public int Id { get; set; }
        public DateTime DataCompra { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
        public int FormaPagamentoId { get; set; }
        public Cartao FormaPagamento { get; set; }
    }
}
