using Model.ModuloCategoria;

namespace Model.ModuloEntrada
{
    public class Entrada
    {
        public int Id { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataEntrada { get; set; }
        public decimal Valor { get; set; }
        public int IdCategoria { get; set; }
        public Categoria? Categoria { get; set; }
    }
}
