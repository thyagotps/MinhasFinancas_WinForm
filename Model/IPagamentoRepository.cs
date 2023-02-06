using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IPagamentoRepository
    {
        public List<Pagamento> GetAll();
        public Pagamento GetById(int id);
        public int Insert(Pagamento pagamento);
        public int Update(Pagamento pagamento);
        public int Delete(int id);
    }
}
