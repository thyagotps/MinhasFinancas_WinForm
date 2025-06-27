using AutoMapper;
using Controller.Profiles;
using Model.ModuloCartao;
using Model.ModuloCategoria;
using Model.ModuloContaPadrao;

namespace Controller.ModuloContaPadrao
{
    public class ContaPadraoController : IContaPadraoController
    {
        private readonly IContaPadraoRepository _contaPadraoRepository;
        private readonly IMapper _mapper;
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly ICartaoRepository _cartaoRepository;

        public ContaPadraoController(
            IContaPadraoRepository contaPadraoRepository, 
            ICategoriaRepository categoriaRepository, 
            ICartaoRepository cartaoRepository)
        {
            _contaPadraoRepository = contaPadraoRepository;
            _categoriaRepository = categoriaRepository;
            _cartaoRepository = cartaoRepository;

            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ContaPadraoProfile());
            });
            _mapper = new Mapper(config);
        }

        public List<ContaPadraoDto> GetAll()
        {
            var source = _contaPadraoRepository.GetAll();
            var objDtos = _mapper.Map<IEnumerable<ContaPadraoDto>>(source).ToList();
            return objDtos;
        }

        public ContaPadraoDto GetById(int id)
        {
            var source = _contaPadraoRepository.GetById(id);
            var objDto = _mapper.Map<ContaPadraoDto>(source);
            return objDto;
        }

        public bool Insert(ContaPadraoDto contaPadraoDto)
        {
            var source = _mapper.Map<ContaPadrao>(contaPadraoDto);
            source.Categoria = null;
            source.Cartao = null;
            source.Id = 0;
            var result = _contaPadraoRepository.Insert(source);
            return result > 0 ? true : false;
        }

        public bool Update(ContaPadraoDto contaPadraoDto)
        {
            var source = _mapper.Map<ContaPadrao>(contaPadraoDto);
            source.Categoria = null;
            source.Cartao = null;
            var result = _contaPadraoRepository.Update(source);
            return result > 0 ? true : false;
        }

        public bool DeleteById(int id)
        {
            var result = _contaPadraoRepository.DeleteById(id);
            return result > 0 ? true : false;
        }
    }
}
