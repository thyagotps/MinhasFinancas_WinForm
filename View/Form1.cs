using Base.Ninject;
using Controller.ModuloCategoria;
using Controller.ContasPagar;
using Controller.MovimentosAnaliticos;
using Model;
using View.ModuloCategoria;
using View.ContasPagar;
using View.ModuloFaturaEmAberto;
using View.ModuloSalario;
using View.MovimentosAnaliticos;
using View.ModuloCartao;
using Controller.ModuloCartao;
using System.Windows.Forms;

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


        /// <summary>
        /// Ação do botão Movimento
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

        private void btnSalario_Click(object sender, EventArgs e)
        {
            var view = NinjectKernel.Resolve<SalarioView>();
            view.ShowDialog();
        }

        
    }
}