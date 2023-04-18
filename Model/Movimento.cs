using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Movimento
    {
        public int Id { get; set; }
        public DateTime DataCompra { get; set; }
        public string Descricao { get; set; }
        public string Parcelas { get; set; }
        public decimal Valor { get; set; }
        public DateTime? DataVencimento { get; set; }
        public int Situacao { get; set; }

        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        public int PagamentoId { get; set; }
        public Pagamento Pagamento { get; set; }
    }
}
