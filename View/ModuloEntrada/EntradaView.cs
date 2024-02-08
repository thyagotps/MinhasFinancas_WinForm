using Base.Ninject;
using Controller.ModuloSaida;
using Controller.ModuloSalario;
using System.Globalization;

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
            setDataFiltro();
            buscar(dtpDataFiltro.Value);
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            buscar(dtpDataFiltro.Value);
        }



        private void buscar(DateTime periodo)
        {
            var source = _entradaController.GetByDate(periodo);
            setDataGridView(source);
            calcularTotal(periodo);
        }

        private void novo()
        {
            var form = NinjectKernel.Resolve<EntradaForm>();
            form.Id = -1;
            form.ShowDialog();
            buscar(dtpDataFiltro.Value);
        }

        private void editar()
        {
            var form = NinjectKernel.Resolve<EntradaForm>();
            form.Id = Id;
            form.ShowDialog();
            buscar(dtpDataFiltro.Value);
        }

        private void excluir()
        {
            var result = base.MessageDelete(Id);
            if (result == DialogResult.Yes)
                _entradaController.DeleteById(Id);
            buscar(dtpDataFiltro.Value);
        }

        private void setDataFiltro()
        {
            dtpDataFiltro.Value = DateTime.Now;
            dtpDataFiltro.Format = DateTimePickerFormat.Custom;
            dtpDataFiltro.CustomFormat = "MM/yyyy";
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
            dgvEntrada.Columns["Valor"].DefaultCellStyle.Format = "c";
            dgvEntrada.Columns["Valor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvEntrada.Columns["CategoriaDisplayMember"].HeaderText = "Categoria";
            dgvEntrada.Columns["CartaoDisplayMember"].HeaderText = "Cartão";
            dgvEntrada.Columns["IdCategoria"].Visible = false;
            dgvEntrada.Columns["IdCartao"].Visible = false;

            dgvEntrada.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvEntrada.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dgvEntrada.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

            dgvEntrada.RowsDefaultCellStyle.SelectionBackColor = Color.NavajoWhite;
            dgvEntrada.RowsDefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void calcularTotal(DateTime periodo)
        {
            var total = _entradaController.GetTotal(periodo);
            lblTotal.Text = total.ToString("C", CultureInfo.CurrentCulture);
        }
    }
}
