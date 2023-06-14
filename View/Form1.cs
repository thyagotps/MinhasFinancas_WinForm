using Base.Ninject;
using Controller.Categorias;
using Controller.FormaPagamentos;
using Controller.MovimentosAnaliticos;
using Model;
using View.Categorias;
using View.FormaPagamentos;
using View.MovimentosAnaliticos;

namespace View
{
    public partial class Form1 : Form
    {
        private readonly ICategoriaController _categoriaController;
        private readonly IFormaPagamentoController _pagamentoController;
        private readonly IMovimentoAnaliticoController _movimentoController;

        public Form1()
        {
            _categoriaController = NinjectKernel.Resolve<ICategoriaController>();
            _pagamentoController = NinjectKernel.Resolve<IFormaPagamentoController>();
            _movimentoController = NinjectKernel.Resolve<IMovimentoAnaliticoController>();
            InitializeComponent();
        }

        /// <summary>
        /// A��o do bot�o Categoria
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
        /// A��o do bot�o Pagamento
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
    }
}