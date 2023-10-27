namespace Controller.ModuloPagamento
{
    public interface IPagamentoController
    {
        public List<PagamentoDto> GetByDate(DateTime dtPeriodo);
        public decimal GetTotalByDate(DateTime dtPeriodo);
        public PagamentoDto GetById(int id);
        public bool Insert(PagamentoDto pagamentoDto);
        public bool Update(PagamentoDto pagamentoDto);
        public bool DeleteById(int id);
        public void CriarPagamentosAutomaticos(DateTime periodo);
    }
}
