namespace Controller.ModuloContaPadrao
{
    public interface IContaPadraoController
    {
        List<ContaPadraoDto> GetAll();
        ContaPadraoDto GetById(int id);
        public bool Insert(ContaPadraoDto contaPadraoDto);
        public bool Update(ContaPadraoDto contaPadraoDto);
        public bool DeleteById(int id);
    }
}
