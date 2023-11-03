using Base.Ninject;
using View.ModuloCartao;
using View.ModuloCategoria;
using View.ModuloEntrada;
using View.ModuloFaturaEmAberto;
using View.ModuloPagamento;
using View.ModuloRelatorios;
using View.ModuloSaida;

namespace View
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void btnCategoria_Click_1(object sender, EventArgs e)
        {
            var view = NinjectKernel.Resolve<CategoriaView>();
            view.MdiParent = this;
            view.Show();
        }

        private void btnCartao_Click(object sender, EventArgs e)
        {
            var view = NinjectKernel.Resolve<CartaoView>();
            view.MdiParent = this;
            view.Show();
        }

        private void btnEntrada_Click(object sender, EventArgs e)
        {
            var view = NinjectKernel.Resolve<EntradaView>();
            view.MdiParent = this;
            view.Show();
        }

        private void btnSaida_Click(object sender, EventArgs e)
        {
            var view = NinjectKernel.Resolve<SaidaView>();
            view.MdiParent = this;
            view.Show();
        }

        private void btnFaturaEmAberto_Click(object sender, EventArgs e)
        {
            var view = NinjectKernel.Resolve<FaturaEmAbertoView>();
            view.MdiParent = this;
            view.Show();
        }

        private void btnPagamento_Click(object sender, EventArgs e)
        {
            var view = NinjectKernel.Resolve<PagamentoView>();
            view.MdiParent = this;
            view.Show();
        }

        private void btnRelatorios_Click(object sender, EventArgs e)
        {
            var view = NinjectKernel.Resolve<RelatoriosView>();
            view.MdiParent = this;
            view.Show();
        }
    }
}