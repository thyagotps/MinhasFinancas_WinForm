using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.FormaPagamentos
{
    public interface IFormaPagamentoController
    {
        public List<FormaPagamentoDto> GetAll();
        public FormaPagamentoDto GetById(int id);
        public bool Insert(FormaPagamentoDto pagamentoDto);
        public bool Update(FormaPagamentoDto pagamentoDto);
        public bool Delete(int id);
    }
}
