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
        public List<ReportMensal> GetEntradasMensais(DateTime periodo);
        public List<ReportAnual> GetEntradasAnuais(DateTime periodo);
        public List<ReportMensal> GetSaidasMensaisCategoria(DateTime periodo);
        public List<ReportMensal> GetSaidasMensaisCartao(DateTime periodo);
        List<ReportAnual> GetSaidasAnualCategoria(DateTime periodo);
        List<ReportAnual> GetSaidasAnualCartao(DateTime periodo);
    }
}
