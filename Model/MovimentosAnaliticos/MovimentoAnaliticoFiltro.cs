﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.MovimentosAnaliticos
{
    public class MovimentoAnaliticoFiltro
    {
        public DateTime DataCompra { get; set; }
        public int? Categoria { get; set; }
        public int? Pagamento { get; set; }
    }
}
