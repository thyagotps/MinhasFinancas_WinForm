namespace Controller.ModuloEntrada
{
    public class EntradaDto
    {
        public int Id { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataEntrada { get; set; }
        public decimal Valor { get; set; }
        public int IdCategoria { get; set; }
        public string? CategoriaDisplayMember { get; set; }
    }
}
