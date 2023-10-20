using Controller.ModuloCategoria;

namespace View.ModuloCategoria
{
    public partial class CategoriaForm : BaseView
    {

        private readonly ICategoriaController _categoriaController;

        public CategoriaForm(ICategoriaController categoriaController)
        {
            InitializeComponent();
            _categoriaController = categoriaController;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
        }


        private void CategoriaForm_Load(object sender, EventArgs e)
        {
            if (Id != -1)
            {
                var categoriaDto = _categoriaController.GetById(Id);
                popularComponentesFormulario(categoriaDto);
            }
        }


        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (Id == -1)
                novo();
            else
                editar();
        }

        private void novo()
        {
            var categoriaDto = popularCategoriaDto();
            var result = _categoriaController.Insert(categoriaDto);
            base.Message(result);
            this.Close();
        }

        private void editar()
        {
            var categoriaDto = popularCategoriaDto();
            var result = _categoriaController.Update(categoriaDto);
            base.Message(result);
            this.Close();
        }

        private CategoriaDto popularCategoriaDto()
        {
            CategoriaDto categoriaDto = new CategoriaDto();
            categoriaDto.Id = Id;
            categoriaDto.Descricao = txtDescricao.Text;
            categoriaDto.Tipo = cbo_Tipo.Text;
            return categoriaDto;
        }

        private void popularComponentesFormulario(CategoriaDto categoriaDto)
        {
            txtId.Text = categoriaDto.Id.ToString();
            txtDescricao.Text = categoriaDto.Descricao;
            cbo_Tipo.SelectedItem = categoriaDto.Tipo;
        }


    }
}
