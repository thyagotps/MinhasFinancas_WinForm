using Base.Ninject;
using Controller.ModuloSalario;

namespace View.ModuloEntrada
{
    public partial class EntradaView : BaseView
    {

        private readonly IEntradaController _entradaController;

        public EntradaView(IEntradaController entradaController)
        {
            InitializeComponent();
            _entradaController = entradaController;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        private void EntradaView_Load(object sender, EventArgs e)
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

        private void dgvEntrada_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var _linhaIndice = e.RowIndex;
            var grid = (DataGridView)sender;
            SetIdGrid(grid, _linhaIndice);
        }

        private void dgvEntrada_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var _linhaIndice = e.RowIndex;
            var grid = (DataGridView)sender;
            SetIdGrid(grid, _linhaIndice);
            editar();
        }

        private void buscar()
        {
            var source = _entradaController.GetAll();
            setDataGridView(source);
        }

        private void novo()
        {
            var form = NinjectKernel.Resolve<EntradaForm>();
            form.Id = -1;
            form.ShowDialog();
            buscar();
        }

        private void editar()
        {
            var form = NinjectKernel.Resolve<EntradaForm>();
            form.Id = Id;
            form.ShowDialog();
            buscar();
        }

        private void excluir()
        {
            var result = base.MessageDelete(Id);
            if (result == DialogResult.Yes)
                _entradaController.DeleteById(Id);
            buscar();
        }

        private void setDataGridView(object source)
        {
            dgvEntrada.DataSource = source;

            dgvEntrada.ReadOnly = true;

            dgvEntrada.Columns["Id"].Width = 50;
            dgvEntrada.Columns["Descricao"].HeaderText = "Descrição";
            dgvEntrada.Columns["DataEntrada"].HeaderText = "Data Entrada";
            dgvEntrada.Columns["DataEntrada"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvEntrada.Columns["Valor"].HeaderText = "Valor";
            dgvEntrada.Columns["CategoriaDisplayMember"].HeaderText = "Categoria";
            dgvEntrada.Columns["IdCategoria"].Visible = false;

            dgvEntrada.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvEntrada.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dgvEntrada.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

            dgvEntrada.RowsDefaultCellStyle.SelectionBackColor = Color.NavajoWhite;
            dgvEntrada.RowsDefaultCellStyle.SelectionForeColor = Color.Black;
        }
    }
}
