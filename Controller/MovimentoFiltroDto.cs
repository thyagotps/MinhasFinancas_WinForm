using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class MovimentoFiltroDto
    {
        public DateTime DataCompra { get; set; }
        public DateTime? DataVencimento { get; set; }
        public int? Situacao { get; set; }
        public int? Categoria { get; set; }
        public int? Pagamento { get; set; }
    }
}
