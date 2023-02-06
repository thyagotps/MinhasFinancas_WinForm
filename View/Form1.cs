using Base.Ninject;
using Controller;
using Model;

namespace View
{
    public partial class Form1 : Form
    {
        private readonly ICategoriaController _categoriaController;
        private readonly IPagamentoController _pagamentoController;

        public Form1()
        {
            _categoriaController = NinjectKernel.Resolve<ICategoriaController>();
            _pagamentoController = NinjectKernel.Resolve<IPagamentoController>();
            InitializeComponent();
        }

        /// <summary>
        /// Ação do botão Categoria
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCategoria_Click_1(object sender, EventArgs e)
        {
            CategoriaView form = new CategoriaView(_categoriaController);
            form.ShowDialog();
        }

        /// <summary>
        /// Ação do botão Pagamento
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPagamento_Click(object sender, EventArgs e)
        {
            PagamentoView pagamentoView = new PagamentoView(_pagamentoController);
            pagamentoView.ShowDialog();
        }
    }
}