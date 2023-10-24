using Controller.ContasPagar;
using Controller.ModuloCartao;
using Controller.ModuloCategoria;
using Controller.ModuloEntrada;
using Controller.ModuloFaturaEmAberto;
using Controller.ModuloSalario;
using Controller.MovimentosAnaliticos;
using DAL;
using Model.ContasPagar;
using Model.ModuloCartao;
using Model.ModuloCategoria;
using Model.ModuloEntrada;
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

            Bind(typeof(ICartaoController)).To(typeof(CartaoController));
            Bind(typeof(ICartaoRepository)).To(typeof(CartaoRepository));

            Bind(typeof(IEntradaController)).To(typeof(EntradaController));
            Bind(typeof(IEntradaRepository)).To(typeof(EntradaRepository));



            Bind(typeof(IMovimentoAnaliticoController)).To(typeof(MovimentoAnaliticoController));
            Bind(typeof(IMovimentoAnaliticoRepository)).To(typeof(MovimentoAnaliticoRepository));

            Bind(typeof(IContaPagarController)).To(typeof(ContaPagarController));
            Bind(typeof(IContaPagarRepository)).To(typeof(ContaPagarRepository));

            Bind(typeof(IFaturaEmAbertoController)).To(typeof(FaturaEmAbertoController));
            Bind(typeof(IFaturaEmAbertoRepository)).To(typeof(FaturaEmAbertoRepository));

         
        }
    }
}
