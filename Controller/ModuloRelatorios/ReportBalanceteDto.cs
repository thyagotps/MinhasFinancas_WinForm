using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.ModuloRelatorios
{
    public class ReportBalanceteDto
    {
        public string? Descricao { get; set; }
        public decimal ValorRenda { get; set; }
        public decimal ValorDespesa { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
