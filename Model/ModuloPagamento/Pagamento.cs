namespace Model.ModuloPagamento
{
    public class Pagamento
    {
        public int Id { get; set; }
        public int NrIdentificador { get; set; }
        public string? Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        public string? Situacao { get; set; }
    }
}
