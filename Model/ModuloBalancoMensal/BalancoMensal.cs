namespace Model.ModuloBalancoMensal
{
    public class BalancoMensal
    {
        public string CartaoDescricao { get; set; }
        public decimal? ValorTotalReceita { get; set; }
        public decimal? ValorTotalDespesa { get; set; }
        public decimal? SaldoFinal { get; set; }
    }
}
