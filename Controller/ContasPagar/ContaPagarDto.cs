using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.ContasPagar
{
    public class ContaPagarDto
    {
        public int Id { get; set; }
        public int NrIdentificador { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        public string Situacao { get; set; }
    }
}
