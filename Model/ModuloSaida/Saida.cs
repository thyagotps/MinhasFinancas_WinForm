using Model.ModuloCartao;
using Model.ModuloCategoria;

namespace Model.ModuloSaida
{
    public class Saida
    {
        public int Id { get; set; }
        public DateTime DataSaida { get; set; }
        public string? Descricao { get; set; }
        public decimal Valor { get; set; }
        public int IdCategoria { get; set; }
        public Categoria? Categoria { get; set; }
        public int IdCartao { get; set; }
        public Cartao? Cartao { get; set; }

        public string DisplayMember => $"{Id} - {DataSaida.ToString("dd/MM/yyyy")} - {Descricao} - {Valor.ToString()}";
    }
}
