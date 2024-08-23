using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.ModuloFaturaEmAberto
{
    [Table("FaturaEmAberto")]
    public class FaturaEmAberto
    {
        //[Key]
        //[Column("Id")]
        public int Id { get; set; }

        //[StringLength(100)]
        public string Descricao { get; set; }

        //[Column(TypeName = "decimal(19, 2)")]
        public decimal Valor { get; set; }

        //[Column(TypeName = "datetime")]
        public DateTime DataCompra { get; set; }
    }
}
