namespace Application.Interfaces
{
    public interface ICartaoService
    {
        Task<bool> UpdateSaldoCartao(string estado, int idMovimento, int? idCartao, decimal? valorAtual, string tipoMovimento);
    }
}
