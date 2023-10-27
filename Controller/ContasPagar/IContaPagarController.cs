namespace Controller.ContasPagar
{
    public interface IContaPagarController
    {
        public List<ContaPagarDto> Buscar(DateTime dtPeriodo);
        public decimal GetTotal(DateTime dtPeriodo);
        public ContaPagarDto GetById(int id);
        public bool Insert(ContaPagarDto contaPagarDto);
        public bool Update(ContaPagarDto contaPagarDto);
        public bool DeleteById(int id);
        public void CriarContasPagarAuto(DateTime periodo);
    }
}
