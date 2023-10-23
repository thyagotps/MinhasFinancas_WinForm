using AutoMapper;
using Controller.Profiles;
using Model.ModuloCartao;

namespace Controller.ModuloCartao
{
    public class CartaoController : ICartaoController
    {
        private readonly ICartaoRepository _cartaoRepository;
        private readonly IMapper _mapper;

        public CartaoController(ICartaoRepository cartaoRepository)
        {
            _cartaoRepository = cartaoRepository;
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new CartaoProfile());
            });
            _mapper = new Mapper(config);
        }

        public List<CartaoDto> GetAll()
        {
            var source = _cartaoRepository.GetAll();
            var dtos = _mapper.Map<IEnumerable<CartaoDto>>(source).ToList();
            return dtos;
        }

        public CartaoDto GetById(int id)
        {
            var source = _cartaoRepository.GetById(id);
            var dtos = _mapper.Map<CartaoDto>(source);
            return dtos;
        }

        public bool Insert(CartaoDto cartaoDto)
        {
            var source = _mapper.Map<Cartao>(cartaoDto);
            var result = _cartaoRepository.Insert(source);
            return result > 0 ? true : false;
        }

        public bool Update(CartaoDto cartaoDto)
        {
            var source = _mapper.Map<Cartao>(cartaoDto);
            var result = _cartaoRepository.Update(source);
            return result > 0 ? true : false;
        }

        public bool DeleteById(int id)
        {
            var result = _cartaoRepository.DeleteById(id);
            return result > 0 ? true : false;
        }
    }
}
