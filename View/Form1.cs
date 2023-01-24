using Base.Ninject;
using Controller;


namespace View
{
    public partial class Form1 : Form
    {
        private readonly ICategoriaController _categoriaController;

        public Form1()
        {
            _categoriaController = NinjectKernel.Resolve<ICategoriaController>();
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
    }
}