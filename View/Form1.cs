using Base.Ninject;
using Controller.ContasPagar;
using Controller.ModuloCartao;
using Controller.ModuloCategoria;
using Controller.MovimentosAnaliticos;
using View.ContasPagar;
using View.ModuloCartao;
using View.ModuloCategoria;
using View.ModuloEntrada;
using View.ModuloFaturaEmAberto;
using View.MovimentosAnaliticos;

namespace View
{
    public partial class Form1 : Form
    {
        private readonly ICategoriaController _categoriaController;
        private readonly ICartaoController _pagamentoController;
        private readonly IMovimentoAnaliticoController _movimentoController;
        private readonly IContaPagarController _contaPagarController;

        public Form1()
        {
            _categoriaController = NinjectKernel.Resolve<ICategoriaController>();
            _pagamentoController = NinjectKernel.Resolve<ICartaoController>();
            _movimentoController = NinjectKernel.Resolve<IMovimentoAnaliticoController>();
            _contaPagarController = NinjectKernel.Resolve<IContaPagarController>();
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





        /// <summary>
        /// A��o do bot�o Movimento
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMovimento_Click(object sender, EventArgs e)
        {
            var view = NinjectKernel.Resolve<MovimentoAnaliticoView>();
            view.ShowDialog();
            //MovimentoAnaliticoView movimentoView = new MovimentoView(_movimentoController, _categoriaController,_pagamentoController);
            //movimentoView.ShowDialog();
        }

        private void btnContasPagar_Click(object sender, EventArgs e)
        {
            var view = NinjectKernel.Resolve<ContaPagarView>();
            view.ShowDialog();
        }

        private void btnFaturaEmAberto_Click(object sender, EventArgs e)
        {
            var view = NinjectKernel.Resolve<FaturaEmAbertoView>();
            view.ShowDialog();
        }

        

        
    }
}