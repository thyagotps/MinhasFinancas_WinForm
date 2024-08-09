using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.ModuloPagamento
{
    [Table("Pagamento")]
    public class Pagamento
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column(TypeName = "int")]
        public int NrIdentificador { get; set; }

        [StringLength(100)]
        public string? Descricao { get; set; }

        [Column(TypeName = "decimal(19,2)")]
        public decimal Valor { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime DataVencimento { get; set; }

        [StringLength(1)]
        public string? Situacao { get; set; }
    }
}
