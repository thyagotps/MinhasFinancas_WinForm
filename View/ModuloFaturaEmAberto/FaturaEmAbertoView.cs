using Base.Ninject;
using Controller.ModuloFaturaEmAberto;
using System.Globalization;

namespace View.ModuloFaturaEmAberto
{
    public partial class FaturaEmAbertoView : BaseView
    {

        private readonly IFaturaEmAbertoController _controller;

        public FaturaEmAbertoView(IFaturaEmAbertoController controller)
        {
            InitializeComponent();

            _controller = controller;

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        private void FaturaEmAbertoView_Load(object sender, EventArgs e)
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

        private void dgvFaturaEmAberto_CellMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            var _linhaIndice = e.RowIndex;
            var grid = (DataGridView)sender;
            SetIdGrid(grid, _linhaIndice);
        }

        private void dgvFaturaEmAberto_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var _linhaIndice = e.RowIndex;
            var grid = (DataGridView)sender;
            SetIdGrid(grid, _linhaIndice);
            editar();
        }



        private void buscar()
        {
            var dataSource = _controller.GetAll();
            setupDataGridView(dataSource);
            getTotal();
        }

        private void setupDataGridView(object dataSource)
        {
            dgvFaturaEmAberto.ReadOnly = true;
            dgvFaturaEmAberto.DataSource = dataSource;
            dgvFaturaEmAberto.Columns["Id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvFaturaEmAberto.Columns["Descricao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvFaturaEmAberto.Columns["Descricao"].HeaderText = "Descrição";
            dgvFaturaEmAberto.Columns["Valor"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvFaturaEmAberto.Columns["Valor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvFaturaEmAberto.Columns["DataCompra"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvFaturaEmAberto.Columns["DataCompra"].HeaderText = "Vencimento";
            dgvFaturaEmAberto.Columns["DataCompra"].DefaultCellStyle.Format = "dd/MM/yyyy";

            dgvFaturaEmAberto.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvFaturaEmAberto.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dgvFaturaEmAberto.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

            dgvFaturaEmAberto.RowsDefaultCellStyle.SelectionBackColor = Color.NavajoWhite;
            dgvFaturaEmAberto.RowsDefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void getTotal()
        {
            var total = _controller.GetTotal();
            lblTotal.Text = total.ToString("C", CultureInfo.CurrentCulture);
        }

        private void novo()
        {
            var form = NinjectKernel.Resolve<FaturaEmAbertoForm>();
            form.Id = -1;
            form.ShowDialog();
            buscar();
        }

        private void editar()
        {
            var form = NinjectKernel.Resolve<FaturaEmAbertoForm>();
            form.Id = Id;
            form.ShowDialog();
            buscar();
        }

        private void excluir()
        {
            var result = base.MessageDelete(Id);
            if (result == DialogResult.Yes)
                _controller.DeleteById(Id);
            buscar();
        }


    }
}
