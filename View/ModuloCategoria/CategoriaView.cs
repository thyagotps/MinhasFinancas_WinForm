using Base.Ninject;
using Controller.ModuloCategoria;

namespace View.ModuloCategoria
{
    public partial class CategoriaView : BaseView
    {

        private readonly ICategoriaController _categoriaController;

        public CategoriaView(ICategoriaController categoriaController)
        {
            InitializeComponent();
            _categoriaController = categoriaController;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        private void CategoriaView_Load(object sender, EventArgs e)
        {
            buscar();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            novo();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            excluir();
        }

        private void dgvCategoria_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var _linhaIndice = e.RowIndex;
            var grid = (DataGridView)sender;
            SetIdGrid(grid, _linhaIndice);
        }

        private void dgvCategoria_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var _linhaIndice = e.RowIndex;
            var grid = (DataGridView)sender;
            SetIdGrid(grid, _linhaIndice);
            editar();
        }


        private void buscar()
        {
            var source = _categoriaController.GetAll();
            setDataGridView(source);
        }

        private void novo()
        {
            var form = NinjectKernel.Resolve<CategoriaForm>();
            form.Id = -1;
            form.ShowDialog();
            buscar();
        }

        private void editar()
        {
            var form = NinjectKernel.Resolve<CategoriaForm>();
            form.Id = Id;
            form.ShowDialog();
            buscar();
        }

        private void excluir()
        {
            var result = base.MessageDelete(Id);
            if (result == DialogResult.Yes)
                _categoriaController.DeleteById(Id);
            buscar();
        }

        private void setDataGridView(object source)
        {
            dgvCategoria.DataSource = source;

            dgvCategoria.ReadOnly = true;

            dgvCategoria.Columns["Id"].Width = 50;
            dgvCategoria.Columns["Descricao"].HeaderText = "Descrição";
            dgvCategoria.Columns["Tipo"].HeaderText = "Tipo";

            dgvCategoria.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvCategoria.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dgvCategoria.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

            dgvCategoria.RowsDefaultCellStyle.SelectionBackColor = Color.NavajoWhite;
            dgvCategoria.RowsDefaultCellStyle.SelectionForeColor = Color.Black;
        }

        
    }
}
