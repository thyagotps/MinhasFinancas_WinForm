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
        public List<ReportMensal> GetRendasMensais(DateTime periodo);
        public List<ReportAnual> GetRendasAnuais(DateTime periodo);
        public List<ReportMensal> GetDespesasMensaisCategoria(DateTime periodo);
        List<ReportAnual> GetDespesasAnualCategoria(DateTime periodo);
        public List<ReportMensal> GetDespesasMensaisCartao(DateTime periodo);
        List<ReportAnual> GetDespesasAnualCartao(DateTime periodo);
        List<ReportBalancete> GetBalancete(DateTime periodo);
    }
}
