using Base.Ninject;
using Controller;


namespace View
{
    public partial class Form1 : Form
    {
        private ICategoriaController categoriaController;

        public Form1()
        {
            this.categoriaController = NinjectKernel.Resolve<ICategoriaController>();
            InitializeComponent();
        }

        

        

        private void btnCategoria_Click_1(object sender, EventArgs e)
        {
            CategoriaView form = new CategoriaView(categoriaController);
            form.ShowDialog();
        }
    }
}