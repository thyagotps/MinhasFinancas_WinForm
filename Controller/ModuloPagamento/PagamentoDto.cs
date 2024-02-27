using System.ComponentModel.DataAnnotations;

namespace Controller.ModuloPagamento
{
    public class PagamentoDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O identificador é obrigatório!")]
        [Display(Name = "Data Movimento")]
        public int? NrIdentificador { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatório!", AllowEmptyStrings = false)]
        [Display(Name = "Descrição")]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "O valor é obrigatório!")]
        [Display(Name = "Valor")]
        public decimal? Valor { get; set; }

        [Required(ErrorMessage = "A data de vencimento é obrigatório!")]
        [Display(Name = "Data Vencimento")]
        public DateTime DataVencimento { get; set; }

        [Required(ErrorMessage = "A situação é obrigatório!", AllowEmptyStrings = false)]
        [Display(Name = "Situação")]
        public string? Situacao { get; set; }
    }
}
