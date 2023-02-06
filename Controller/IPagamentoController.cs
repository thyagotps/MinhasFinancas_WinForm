using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public interface IPagamentoController
    {
        public List<PagamentoDto> GetAll();
        public PagamentoDto GetById(int id);
        public bool Insert(PagamentoDto pagamentoDto);
        public bool Update(PagamentoDto pagamentoDto);
        public bool Delete(int id);
    }
}
