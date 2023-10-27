using Base.Ninject;
using Controller.ModuloCartao;
using Controller.ModuloCategoria;
using Controller.ModuloSaida;
using System.Data;
using System.Globalization;

namespace View.ModuloSaida
{
    public partial class SaidaView : BaseView
    {

        private readonly ICategoriaController _categoriaController;
        private readonly ICartaoController _cartaoController;
        private readonly ISaidaController _saidaController;


        public SaidaView(
            ICategoriaController categoriaController,
            ICartaoController cartaoController,
            ISaidaController saidaController)
        {
            InitializeComponent();

            _categoriaController = categoriaController;
            _cartaoController = cartaoController;
            _saidaController = saidaController;

            this.FormBorderStyle = FormBorderStyle.FixedDialog;

        }

        private void SaidaView_Load(object sender, EventArgs e)
        {
            popularListaCategoria();
            popularListaCartao();
            popularMes();
            setDataSaida();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            novo();
        }


        private void btnExcluir_Click(object sender, EventArgs e)
        {
            excluir();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            buscar();
        }

        private void btnLimparFiltro_Click(object sender, EventArgs e)
        {
            limparFiltro();
        }

        private void dgvSaida_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var _linhaIndice = e.RowIndex;
            var grid = (DataGridView)sender;
            SetIdGrid(grid, _linhaIndice);
        }

        private void dgvSaida_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var _linhaIndice = e.RowIndex;
            var grid = (DataGridView)sender;
            SetIdGrid(grid, _linhaIndice);
            editar();
        }


        private void popularListaCategoria()
        {
            var source = _categoriaController.GetAll().Where(x => x.Tipo == "Saída").OrderBy(x => x.Descricao);
            cboCategoriaFiltro.DataSource = source.ToList();
            cboCategoriaFiltro.DisplayMember = "Descricao";
            cboCategoriaFiltro.ValueMember = "Id";
            cboCategoriaFiltro.SelectedIndex = -1;
        }

        private void popularListaCartao()
        {
            var source = _cartaoController.GetAll().OrderBy(x => x.Descricao);
            cboCartaoFiltro.DataSource = source.ToList();
            cboCartaoFiltro.DisplayMember = "Descricao";
            cboCartaoFiltro.ValueMember = "Id";
            cboCartaoFiltro.SelectedIndex = -1;
        }

        private void popularMes()
        {
            var source = _saidaController.GetByMonth(DateTime.Now.Year, DateTime.Now.Month);
            setDataGridView(source);
            var filtro = setFiltros();
            calcularTotal(filtro);
        }

        private void setDataSaida()
        {
            dtpDataSaidaFiltro.Value = DateTime.Now;
            dtpDataSaidaFiltro.Format = DateTimePickerFormat.Custom;
            dtpDataSaidaFiltro.CustomFormat = "MM/yyyy";
        }

        private void setDataGridView(object source)
        {
            dgvSaida.DataSource = source;
            dgvSaida.ReadOnly = true;

            dgvSaida.Columns["Id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            dgvSaida.Columns["DataSaida"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvSaida.Columns["DataSaida"].HeaderText = "Data Saída";
            dgvSaida.Columns["DataSaida"].DefaultCellStyle.Format = "dd/MM/yyyy";

            dgvSaida.Columns["Descricao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvSaida.Columns["Descricao"].HeaderText = "Descrição";

            dgvSaida.Columns["Valor"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvSaida.Columns["Valor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvSaida.Columns["IdCategoria"].Visible = false;
            dgvSaida.Columns["CategoriaDescricao"].Visible = false;
            dgvSaida.Columns["CategoriaDisplayMember"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvSaida.Columns["CategoriaDisplayMember"].HeaderText = "Categoria";

            dgvSaida.Columns["IdCartao"].Visible = false;
            dgvSaida.Columns["CartaoDescricao"].Visible = false;
            dgvSaida.Columns["CartaoDisplayMember"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvSaida.Columns["CartaoDisplayMember"].HeaderText = "Cartão";

            dgvSaida.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvSaida.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dgvSaida.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

            dgvSaida.RowsDefaultCellStyle.SelectionBackColor = Color.NavajoWhite;
            dgvSaida.RowsDefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private SaidaFiltroDto setFiltros()
        {
            var filtro = new SaidaFiltroDto();
            filtro.DataSaida = dtpDataSaidaFiltro.Value;
            filtro.IdCategoria = Convert.ToInt16(cboCategoriaFiltro.SelectedValue?.ToString());
            filtro.IdCartao = Convert.ToInt16(cboCartaoFiltro.SelectedValue?.ToString());
            return filtro;
        }

        private void calcularTotal(SaidaFiltroDto filtro)
        {
            var total = _saidaController.GetTotal(filtro);
            lblTotal.Text = total.ToString("C", CultureInfo.CurrentCulture);
        }

        private void novo()
        {
            var form = NinjectKernel.Resolve<SaidaForm>();
            form.Id = -1;
            form.ShowDialog();
            popularMes();
        }

        private void editar()
        {
            var form = NinjectKernel.Resolve<SaidaForm>();
            form.Id = Id;
            form.ShowDialog();
            popularMes();
        }

        private void excluir()
        {
            var result = base.MessageDelete(Id);
            if (result == DialogResult.Yes)
                _saidaController.DeleteById(Id);
            popularMes();
        }

        private void buscar()
        {
            var filtro = setFiltros();
            var source = _saidaController.GetByFilter(filtro);
            setDataGridView(source);
            calcularTotal(filtro);
        }

        private void limparFiltro()
        {
            dtpDataSaidaFiltro.ResetText();
            cboCategoriaFiltro.SelectedIndex = -1;
            cboCartaoFiltro.SelectedIndex = -1;
            popularMes();
        }


    }
}
