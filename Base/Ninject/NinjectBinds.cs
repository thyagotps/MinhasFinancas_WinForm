using Controller.Categorias;
using Controller.ContasPagar;
using Controller.FormaPagamentos;
using Controller.ModuloFaturaEmAberto;
using Controller.MovimentosAnaliticos;
using DAL;
using Model.Categorias;
using Model.ContasPagar;
using Model.FormaPagamentos;
using Model.ModuloFaturaEmAberto;
using Model.MovimentosAnaliticos;
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

            Bind(typeof(IFormaPagamentoController)).To(typeof(FormaPagamentoController));
            Bind(typeof(IFormaPagamentoRepository)).To(typeof(FormaPagamentoRepository));

            Bind(typeof(IMovimentoAnaliticoController)).To(typeof(MovimentoAnaliticoController));
            Bind(typeof(IMovimentoAnaliticoRepository)).To(typeof(MovimentoAnaliticoRepository));

            Bind(typeof(IContaPagarController)).To(typeof(ContaPagarController));
            Bind(typeof(IContaPagarRepository)).To(typeof(ContaPagarRepository));

            Bind(typeof(IFaturaEmAbertoController)).To(typeof(FaturaEmAbertoController));
            Bind(typeof(IFaturaEmAbertoRepository)).To(typeof(FaturaEmAbertoRepository));
        }
    }
}
