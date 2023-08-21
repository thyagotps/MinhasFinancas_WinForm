using Base.Ninject;
using Controller.Categorias;
using Controller.ContasPagar;
using Controller.FormaPagamentos;
using Controller.MovimentosAnaliticos;
using Model;
using View.Categorias;
using View.ContasPagar;
using View.FormaPagamentos;
using View.MovimentosAnaliticos;

namespace View
{
    public partial class Form1 : Form
    {
        private readonly ICategoriaController _categoriaController;
        private readonly IFormaPagamentoController _pagamentoController;
        private readonly IMovimentoAnaliticoController _movimentoController;
        private readonly IContaPagarController _contaPagarController;

        public Form1()
        {
            _categoriaController = NinjectKernel.Resolve<ICategoriaController>();
            _pagamentoController = NinjectKernel.Resolve<IFormaPagamentoController>();
            _movimentoController = NinjectKernel.Resolve<IMovimentoAnaliticoController>();
            _contaPagarController = NinjectKernel.Resolve<IContaPagarController>();
            InitializeComponent();
        }

        /// <summary>
        /// Ação do botão Categoria
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCategoria_Click_1(object sender, EventArgs e)
        {
            //CategoriaView form = new CategoriaView(_categoriaController);
            var form = NinjectKernel.Resolve<CategoriaView>();
            form.ShowDialog();
        }

        /// <summary>
        /// Ação do botão Pagamento
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPagamento_Click(object sender, EventArgs e)
        {
            //FormaPagamentoView pagamentoView = new FormaPagamentoView(_pagamentoController);
            var view = NinjectKernel.Resolve<FormaPagamentoView>();
            view.ShowDialog();
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
    }
}