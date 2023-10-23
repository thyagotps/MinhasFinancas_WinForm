namespace Controller.ModuloCartao
{
    public interface ICartaoController
    {
        public List<CartaoDto> GetAll();
        public CartaoDto GetById(int id);
        public bool Insert(CartaoDto cartaoDto);
        public bool Update(CartaoDto cartaoDto);
        public bool DeleteById(int id);
    }
}
