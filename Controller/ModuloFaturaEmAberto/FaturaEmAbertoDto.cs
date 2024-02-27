using System.ComponentModel.DataAnnotations;

namespace Controller.ModuloFaturaEmAberto
{
    public class FaturaEmAbertoDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatório!", AllowEmptyStrings = false)]
        [Display(Name = "Descrição")]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "O valor é obrigatório!")]
        [Display(Name = "Valor")]
        public decimal? Valor { get; set; }

        [Required(ErrorMessage = "A data é obrigatório!")]
        [Display(Name = "Data Compra")]
        public DateTime DataCompra { get; set; }
    }
}
