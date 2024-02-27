using System.ComponentModel.DataAnnotations;

namespace Controller.ModuloCategoria
{
    public class CategoriaDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatório!", AllowEmptyStrings = false)]
        [Display(Name = "Descrição")]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "O tipo é obrigatório!", AllowEmptyStrings = false)]
        [Display(Name = "Tipo")]
        public string? Tipo { get; set; }
    }
}
