using Application.Handlers;
using Application.Interfaces;
using MediatR;

namespace Application.Services
{
    public class CartaoService : ICartaoService
    {
        private readonly IMediator _mediator;

        public CartaoService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<bool> UpdateSaldoCartao(string estado, int idMovimento, int? idCartao, decimal? valorAtual, string tipoMovimento)
        {
            var command = new CalcularSaldoConta.Command()
            {
                Estado = estado,
                IdMovimento = idMovimento,
                IdCartao = idCartao,
                ValorAtual = valorAtual,
                TipoMovimento = tipoMovimento
            };

            var result = await _mediator.Send(command);

            return result;
        }
    }
}
