using Base.Ninject;
using Controller.ModuloPagamento;
using System.Globalization;

namespace View.ModuloPagamento
{
    public partial class PagamentoView : BaseView
    {
        private readonly IPagamentoController _controller;

        public PagamentoView(IPagamentoController pagamentoController)
        {
            InitializeComponent();
            _controller = pagamentoController;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        private void ContaPagarView_Load(object sender, EventArgs e)
        {
            setDataCompra();
            buscar(DateTime.Now);
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            var form = NinjectKernel.Resolve<PagamentoForm>();
            form.Id = -1;
            form.ShowDialog();
            var dtPeriodo = dtpPeriodoFiltro.Value;
            buscar(dtPeriodo);
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            var result = base.MessageDelete(Id);
            if (result == DialogResult.Yes)
                _controller.DeleteById(Id);
            var dtPeriodo = dtpPeriodoFiltro.Value;
            buscar(dtPeriodo);
        }

        private void btnCriarContasPagarAuto_Click(object sender, EventArgs e)
        {
            var resp = MessageBox.Show("Deseja criar contas à pagar padrão?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resp == DialogResult.Yes)
            {
                _controller.CriarPagamentosAutomaticos(dtpPeriodoFiltro.Value);
                buscar(dtpPeriodoFiltro.Value);
            }
        }

        private void dgvPagamento_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var _linhaIndice = e.RowIndex;
            var grid = (DataGridView)sender;
            SetIdGrid(grid, _linhaIndice);
        }

        private void dgvPagamento_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var _linhaIndice = e.RowIndex;
            var grid = (DataGridView)sender;
            SetIdGrid(grid, _linhaIndice);
            editar();
        }

        private void dgvPagamento_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRow r = dgvPagamento.Rows[e.RowIndex];
            if (r.Cells[5].Value.ToString() == "S")
                r.DefaultCellStyle.BackColor = Color.LightGreen;
            else
                r.DefaultCellStyle.BackColor = Color.AliceBlue;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var dtPeriodo = dtpPeriodoFiltro.Value;
            buscar(dtPeriodo);
            getTotal(dtPeriodo);

        }



        private void buscar(DateTime dtPeriodo)
        {
            var dataSource = _controller.GetByDate(dtPeriodo);
            setupDataGridView(dataSource);
            getTotal(dtPeriodo);
        }

        private void getTotal(DateTime dtPeriodo)
        {
            var total = _controller.GetTotalByDate(dtPeriodo);
            lblTotal.Text = total.ToString("C", CultureInfo.CurrentCulture);
        }

        private void setupDataGridView(object dataSource)
        {
            dgvPagamento.ReadOnly = true;
            dgvPagamento.DataSource = dataSource;
            dgvPagamento.Columns["Id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvPagamento.Columns["NrIdentificador"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvPagamento.Columns["NrIdentificador"].HeaderText = "Identificador";
            dgvPagamento.Columns["Descricao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvPagamento.Columns["Descricao"].HeaderText = "Descrição";
            dgvPagamento.Columns["Valor"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvPagamento.Columns["Valor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPagamento.Columns["DataVencimento"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvPagamento.Columns["DataVencimento"].HeaderText = "Vencimento";
            dgvPagamento.Columns["DataVencimento"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvPagamento.Columns["Situacao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvPagamento.Columns["Situacao"].HeaderText = "Pago";

            dgvPagamento.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvPagamento.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dgvPagamento.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

            dgvPagamento.RowsDefaultCellStyle.SelectionBackColor = Color.NavajoWhite;
            dgvPagamento.RowsDefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void setDataCompra()
        {
            dtpPeriodoFiltro.Value = DateTime.Now;
            dtpPeriodoFiltro.Format = DateTimePickerFormat.Custom;
            dtpPeriodoFiltro.CustomFormat = "MM/yyyy";
        }

        private void editar()
        {
            var form = NinjectKernel.Resolve<PagamentoForm>();
            form.Id = Id;
            form.ShowDialog();
            var dtPeriodo = dtpPeriodoFiltro.Value;
            buscar(dtPeriodo);
        }


    }
}
