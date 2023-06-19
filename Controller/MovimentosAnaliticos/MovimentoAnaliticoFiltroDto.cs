using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.MovimentosAnaliticos
{
    public class MovimentoAnaliticoFiltroDto
    {
        public DateTime DataCompra { get; set; }
        public int? Categoria { get; set; }
        public int? Pagamento { get; set; }
    }
}
