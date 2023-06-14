using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.MovimentosAnaliticos
{
    public class MovimentoAnaliticoDto
    {
        public int Id { get; set; }
        public DateTime DataCompra { get; set; }
        public string Descricao { get; set; }
        public string CategoriaId { get; set; }
        public string CategoriaDescricao { get; set; }
        public string PagamentoId { get; set; }
        public string FormaPagamentoDescricao { get; set; }
    }
}
