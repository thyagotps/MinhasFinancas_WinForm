using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.ModuloSalario
{
    public class SalarioDto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataSalario { get; set; }
        public decimal Valor { get; set; }
        public int IdFormaPagamento { get; set; }
    }
}
