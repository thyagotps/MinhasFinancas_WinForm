using AutoMapper;
using Controller.ModuloPagamento;
using Model.ModuloPagamento;

namespace Controller.Profiles
{
    public class PagamentoProfile : Profile
    {
        public PagamentoProfile()
        {
            CreateMap<Pagamento, PagamentoDto>().ReverseMap();
        }
    }
}
