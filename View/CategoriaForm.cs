using Controller;

namespace View
{
    public partial class CategoriaForm : BaseView
    {

        public int Id { get; set; }
        private readonly ICategoriaController _categoriaController;

        public CategoriaForm(ICategoriaController categoriaController)
        {
            InitializeComponent();
            _categoriaController = categoriaController;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        #region Eventos da view

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (Id == -1)
                Novo();
            else
                Editar();
        }

        private void CategoriaForm_Load(object sender, EventArgs e)
        {
            if (Id != -1)
            {
                var categoriaDto = _categoriaController.GetById(Id); ;
                PopularComponentesFormulario(categoriaDto);
            }
        }

        #endregion

        #region Métodos
        private void Novo()
        {
            var categoriaDto = PopularCategoriaDto();
            var result = _categoriaController.Insert(categoriaDto);
            base.Message(result);
            this.Close();
        }

        private void Editar()
        {
            var categoriaDto = PopularCategoriaDto();
            var result = _categoriaController.Update(categoriaDto);
            base.Message(result);
            this.Close();
        }

        private CategoriaDto PopularCategoriaDto()
        {
            CategoriaDto categoriaDto = new CategoriaDto();
            categoriaDto.Id = Id;
            categoriaDto.Descricao = txtDescricao.Text;
            return categoriaDto;
        }

        private void PopularComponentesFormulario(CategoriaDto categoriaDto)
        {
            txtId.Text = categoriaDto.Id.ToString();
            txtDescricao.Text = categoriaDto.Descricao;
        }

        
        #endregion


    }
}
