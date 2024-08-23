using Model.ModuloCartao;
using Model.ModuloCategoria;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.ModuloMovimentoFinanceiro
{
    //[Table("MovimentoFinanceiro")]
    public class MovimentoFinanceiro
    {
        //[Key]
        //[Column("Id")]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //[StringLength(10)]
        public string? TipoMovimento { get; set; }

        //[Column(TypeName = "datetime")]
        //[DataType(DataType.DateTime)]
        public DateTime DataMovimento { get; set; }

        //[StringLength(100)]
        public string? Descricao { get; set; }

        //[Column(TypeName = "decimal(19,2)")]
        public decimal Valor { get; set; }


        //[ForeignKey("Id")]
        public Categoria? Categoria { get; set; }
        public int IdCategoria { get; set; }

        
        [ForeignKey("Id")]
        public Cartao? Cartao { get; set; }
        public int IdCartao { get; set; }


        public string DisplayMember => $"{Id} - {TipoMovimento} - {DataMovimento.ToString("dd/MM/yyyy")} - {Descricao} - {Valor.ToString()}";
    }
}
