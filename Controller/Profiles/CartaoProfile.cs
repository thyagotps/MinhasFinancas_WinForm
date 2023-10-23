using AutoMapper;
using Controller.ModuloCartao;
using Model.ModuloCartao;

namespace Controller.Profiles
{
    public class CartaoProfile : Profile
    {
        public CartaoProfile()
        {
            CreateMap<Cartao, CartaoDto>().ReverseMap();
        }
    }
}
