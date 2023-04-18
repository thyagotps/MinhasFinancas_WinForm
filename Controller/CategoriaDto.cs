using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class CategoriaDto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Sinal { get; set; }

        public string DisplayMember => $"{Id} - {Descricao}";
    }
}
