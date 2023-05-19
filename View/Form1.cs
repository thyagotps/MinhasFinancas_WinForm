using Base.Ninject;
using Controller;
using Controller.FormaPagamentos;
using Model;
using View.FormaPagamentos;

namespace View
{
    public partial class Form1 : Form
    {
        private readonly ICategoriaController _categoriaController;
        private readonly IFormaPagamentoController _pagamentoController;
        private readonly IMovimentoController _movimentoController;

        public Form1()
        {
            _categoriaController = NinjectKernel.Resolve<ICategoriaController>();
            _pagamentoController = NinjectKernel.Resolve<IFormaPagamentoController>();
            _movimentoController = NinjectKernel.Resolve<IMovimentoController>();
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
            MovimentoView movimentoView = new MovimentoView(_movimentoController, _categoriaController,_pagamentoController);
            movimentoView.ShowDialog();
        }
    }
}