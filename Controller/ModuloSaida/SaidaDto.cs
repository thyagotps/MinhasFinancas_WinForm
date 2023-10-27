namespace Controller.ModuloSaida
{
    public class SaidaDto
    {
        public int Id { get; set; }
        public DateTime DataSaida { get; set; }
        public string? Descricao { get; set; }
        public decimal Valor { get; set; }

        public int IdCategoria { get; set; }
        public string? CategoriaDescricao { get; set; }
        public string? CategoriaDisplayMember { get; set; }
        
        public int IdCartao { get; set; }
        public string? CartaoDescricao { get; set; }
        public string? CartaoDisplayMember { get; set; }
    }
}
