using MediatR;
using Model.ModuloCartao;
using Model.ModuloMovimentoFinanceiro;

namespace Application.Handlers
{
    public class CalcularSaldoConta 
    {
        public class Command : IRequest<bool>
        {
            public string Estado { get; set; }
            public int IdMovimento { get; set; }
            public int? IdCartao { get; set; }
            public decimal? ValorAtual { get; set; }
            public string TipoMovimento { get; set; }
        }

        public class CommandHandler : IRequestHandler<Command, bool>
        {
            private readonly ICartaoRepository _cartaoRepository;
            private readonly IMovimentoFinanceiroRepository _movFinancRepository;

            public CommandHandler(ICartaoRepository cartaoRepository, 
                IMovimentoFinanceiroRepository movFinancRepository)
            {
                _cartaoRepository = cartaoRepository;
                _movFinancRepository = movFinancRepository;
            }

            public Task<bool> Handle(Command request, CancellationToken cancellationToken)
            {
                var cartao = _cartaoRepository.GetById(request.IdCartao);

                if(request.Estado == "Insert")
                {
                    if (request.TipoMovimento == "Renda")
                        cartao.ValorSaldo = (decimal)(cartao.ValorSaldo + request.ValorAtual);

                    if (request.TipoMovimento == "Despesa")
                        cartao.ValorSaldo = (decimal)(cartao.ValorSaldo - request.ValorAtual);
                }

                if (request.Estado == "Update")
                {
                    var valorAntigo = _movFinancRepository.GetById(request.IdMovimento).Valor;
                    if (request.TipoMovimento == "Renda")
                    {
                        cartao.ValorSaldo = (decimal)(cartao.ValorSaldo - valorAntigo);
                        cartao.ValorSaldo = (decimal)(cartao.ValorSaldo + request.ValorAtual);
                    }

                    if (request.TipoMovimento == "Despesa")
                    {
                        cartao.ValorSaldo = (decimal)(cartao.ValorSaldo - valorAntigo);
                        cartao.ValorSaldo = (decimal)(cartao.ValorSaldo - request.ValorAtual);
                    }
                }

                if (request.Estado == "Delete")
                {
                    cartao.ValorSaldo = (decimal)(cartao.ValorSaldo + request.ValorAtual);
                }

                _cartaoRepository.Update(cartao);
                return Task.FromResult(true);

            }
        }
    }
}
