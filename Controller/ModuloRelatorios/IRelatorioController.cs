using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.ModuloRelatorios
{
    public interface IRelatorioController
    {
        public List<RelatorioDto> GetAll();
        public List<EntradaMensalDto> GetEntradasMensais(DateTime periodo);
    }
}
