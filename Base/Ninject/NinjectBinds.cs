using Controller;
using DAL;
using Model;
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

            Bind(typeof(IPagamentoController)).To(typeof(PagamentoController));
            Bind(typeof(IPagamentoRepository)).To(typeof(PagamentoRepository));

            Bind(typeof(IMovimentoController)).To(typeof(MovimentoController));
            Bind(typeof(IMovimentoRepository)).To(typeof(MovimentoRepository));
        }
    }
}
