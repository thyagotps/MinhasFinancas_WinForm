namespace Controller.ModuloFaturaEmAberto
{
    public class FaturaEmAbertoDto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataCompra { get; set; }
    }
}
