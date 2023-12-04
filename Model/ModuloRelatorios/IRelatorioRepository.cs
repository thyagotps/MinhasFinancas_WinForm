using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ModuloRelatorios
{
    public interface IRelatorioRepository
    {
        public List<Relatorio> GetAll();
        public List<EntradaMensal> GetEntradasMensais(DateTime periodo);
        public List<EntradaAnuais> GetEntradasAnuais(DateTime periodo);
        public List<SaidaMensalCategoria> GetSaidasMensaisCategoria(DateTime periodo);
        public List<SaidaMensalCartao> GetSaidasMensaisCartao(DateTime periodo);
    }
}
