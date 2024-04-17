using Controller.ModuloCartao;
using Controller.ModuloCategoria;
using Controller.ModuloFaturaEmAberto;
using Controller.ModuloMovimentoFinanceiro;
using Controller.ModuloPagamento;
using Controller.ModuloRelatorios;
using DAL;
using Model.ModuloCartao;
using Model.ModuloCategoria;
using Model.ModuloFaturaEmAberto;
using Model.ModuloMovimentoFinanceiro;
using Model.ModuloPagamento;
using Model.ModuloRelatorios;
using Ninject.Modules;


namespace Base.Ninject
{
    public class NinjectBinds : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IAdo)).To(typeof(Ado));
            Bind(typeof(DAL.IAdo)).To(typeof(DAL.Ado));

            Bind(typeof(ICategoriaController)).To(typeof(CategoriaController));
            Bind(typeof(ICategoriaRepository)).To(typeof(CategoriaRepository));

            Bind(typeof(ICartaoController)).To(typeof(CartaoController));
            Bind(typeof(ICartaoRepository)).To(typeof(CartaoRepository));

           

            Bind(typeof(IFaturaEmAbertoController)).To(typeof(FaturaEmAbertoController));
            Bind(typeof(IFaturaEmAbertoRepository)).To(typeof(FaturaEmAbertoRepository));

            Bind(typeof(IPagamentoController)).To(typeof(PagamentoController));
            Bind(typeof(IPagamentoRepository)).To(typeof(PagamentoRepository));

            Bind(typeof(IRelatorioController)).To(typeof(RelatorioController));
            Bind(typeof(IRelatorioRepository)).To(typeof(RelatorioRepository));

            Bind(typeof(IMovimentoFinanceiroController)).To(typeof(MovimentoFinanceiroController));
            Bind(typeof(IMovimentoFinanceiroRepository)).To(typeof(MovimentoFinanceiroRepository));
        }
    }
}
