using Model.ModuloMovimentoFinanceiro;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.ModuloCartao
{
    //[Table("Cartao")]
    public class Cartao
    {
        //[Key]
        //[Column("Id")]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        //[StringLength(100)]
        public string? Descricao { get; set; }

        //[StringLength(50)]
        public string? Tipo { get; set; }

        public ICollection<MovimentoFinanceiro> MovimentoFinanceiros { get; set; }

        public string DisplayMember => $"{Id} - {Descricao}";
    }
}
