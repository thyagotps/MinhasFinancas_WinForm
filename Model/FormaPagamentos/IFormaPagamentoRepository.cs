using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.FormaPagamentos
{
    public interface IFormaPagamentoRepository
    {
        public List<FormaPagamento> GetAll();
        public FormaPagamento GetById(int id);
        public int Insert(FormaPagamento pagamento);
        public int Update(FormaPagamento pagamento);
        public int Delete(int id);
    }
}
