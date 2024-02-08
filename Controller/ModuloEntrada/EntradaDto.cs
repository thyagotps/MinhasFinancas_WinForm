using System.ComponentModel.DataAnnotations;

namespace Controller.ModuloEntrada
{
    public class EntradaDto
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "A descrição é obrigatório!", AllowEmptyStrings = false)]
        [Display(Name = "Descrição")]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "A data entrada é obrigatório!")]
        [Display(Name = "Data Entrada")]
        public DateTime DataEntrada { get; set; }

        [Required(ErrorMessage = "O valor é obrigatório!")]
        [Display(Name = "Valor")]
        public decimal? Valor { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "A categoria é obrigatório!")]
        public int IdCategoria { get; set; }
        public string? CategoriaDisplayMember { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "O cartão é obrigatório!")]
        public int IdCartao { get; set; }
        public string? CartaoDisplayMember { get; set; }
    }
}
