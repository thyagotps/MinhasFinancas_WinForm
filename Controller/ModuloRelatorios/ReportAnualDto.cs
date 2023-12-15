namespace Controller.ModuloRelatorios;

public class ReportAnualDto
{
    public int Ordem { get; set; }
    public int Id { get; set; }
    public string? Descricao { get; set; }
    public decimal? ValorJaneiro { get; set; }
    public decimal? ValorFevereiro { get; set; }
    public decimal? ValorMarco { get; set; }
    public decimal? ValorAbril { get; set; }
    public decimal? ValorMaio { get; set; }
    public decimal? ValorJunho { get; set; }
    public decimal? ValorJulho { get; set; }
    public decimal? ValorAgosto { get; set; }
    public decimal? ValorSetembro { get; set; }
    public decimal? ValorOutubro { get; set; }
    public decimal? ValorNovembro { get; set; }
    public decimal? ValorDezembro { get; set; }
    public decimal? ValorTotal { get; set; }
}
