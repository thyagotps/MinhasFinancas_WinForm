using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class MovimentoDto
    {
        public int Id { get; set; }
        public DateTime DataCompra { get; set; }
        public string Descricao { get; set; }
        public string Parcelas { get; set; }
        public decimal Valor { get; set; }
        public DateTime? DataVencimento { get; set; }
        public int Situacao { get; set; }
        public string CategoriaId { get; set; }
        public string CategoriaDescricao { get; set; }
        public string PagamentoId { get; set; }
        public string PagamentoDescricao { get; set; }
    }
}
