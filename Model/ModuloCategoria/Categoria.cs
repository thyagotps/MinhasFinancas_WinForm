using Model.ModuloMovimentoFinanceiro;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.ModuloCategoria
{
    [Table("Categoria")]
    public class Categoria
    {
        [Key]
        [Column("Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(100)]
        public string? Descricao { get; set; }

        [StringLength(100)]
        public string? Tipo { get; set; }

        public ICollection<MovimentoFinanceiro> MovimentoFinanceiros { get; set; }

        //[IgnoreDataMember]
        public string DisplayMember => $"{Id} - {Descricao} - {Tipo}";
    }
}