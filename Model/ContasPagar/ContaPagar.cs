using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ContasPagar
{
    public class ContaPagar
    {
        public int Id { get; set; }
        public int NrOrdem { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        public string Situacao { get; set; }
    }
}
