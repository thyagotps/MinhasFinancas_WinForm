namespace Controller.ModuloSaida
{
    public interface ISaidaController
    {
        public List<SaidaDto> GetAll();
        public SaidaDto GetById(int id);
        public bool Insert(SaidaDto saidaDto);
        public bool Update(SaidaDto saidaDto);
        public bool DeleteById(int id);
        public List<SaidaDto> GetByFilter(SaidaFiltroDto saidaFiltroDto);
        public List<SaidaDto> GetByMonth(int year, int month);
        public decimal GetTotal(SaidaFiltroDto saidaFiltro);
    }
}
