using Base.Ninject;
using Controller.Categorias;
using Controller.FormaPagamentos;
using Controller.MovimentosAnaliticos;
using Model.FormaPagamentos;
using Model.MovimentosAnaliticos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View.Categorias;

namespace View.MovimentosAnaliticos
{
    public partial class MovimentoAnaliticoView : BaseView
    {
        private int _id;
        private readonly ICategoriaController _categoriaController;
        private readonly IFormaPagamentoController _formaPagamentoController;
        private readonly IMovimentoAnaliticoController _movimentoAnaliticoController;

        public MovimentoAnaliticoView(ICategoriaController categoriaController,
                                      IFormaPagamentoController formaPagamentoController,
                                      IMovimentoAnaliticoController movimentoAnaliticoController)
        {
            InitializeComponent();
            _categoriaController = categoriaController;
            _formaPagamentoController = formaPagamentoController;
            _movimentoAnaliticoController = movimentoAnaliticoController;
        }

        private void MovimentoAnaliticoView_Load(object sender, EventArgs e)
        {
            popularListaCategoria();
            popularListaFormaPagamento();
            popularMes();
            setDataCompra();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        private void setDataCompra()
        {
            dtpDataCompraFiltro.Value = DateTime.Now;
            dtpDataCompraFiltro.Format = DateTimePickerFormat.Custom;
            dtpDataCompraFiltro.CustomFormat = "MM/yyyy";
        }

        private void setGrid()
        {
            dgvMovimentoAnalitico.ReadOnly = true;

            dgvMovimentoAnalitico.Columns["Id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            dgvMovimentoAnalitico.Columns["DataCompra"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvMovimentoAnalitico.Columns["DataCompra"].HeaderText = "Data Compra";
            dgvMovimentoAnalitico.Columns["DataCompra"].DefaultCellStyle.Format = "dd/MM/yyyy";

            dgvMovimentoAnalitico.Columns["Descricao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvMovimentoAnalitico.Columns["Descricao"].HeaderText = "Descrição";

            dgvMovimentoAnalitico.Columns["Valor"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvMovimentoAnalitico.Columns["Valor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //dgvMovimentoAnalitico.Columns["CategoriaId"].Width = 50;
            //dgvMovimentoAnalitico.Columns["CategoriaId"].HeaderText = "Id Categoria";
            dgvMovimentoAnalitico.Columns["CategoriaId"].Visible = false;

            dgvMovimentoAnalitico.Columns["CategoriaDescricao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvMovimentoAnalitico.Columns["CategoriaDescricao"].HeaderText = "Categoria";

            //dgvMovimentoAnalitico.Columns["PagamentoId"].Width = 70;
            //dgvMovimentoAnalitico.Columns["PagamentoId"].HeaderText = "Id Forma de Pagamento";
            dgvMovimentoAnalitico.Columns["FormaPagamentoId"].Visible = false;

            dgvMovimentoAnalitico.Columns["FormaPagamentoDescricao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvMovimentoAnalitico.Columns["FormaPagamentoDescricao"].HeaderText = "Forma de Pagamento";

            dgvMovimentoAnalitico.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvMovimentoAnalitico.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dgvMovimentoAnalitico.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

            dgvMovimentoAnalitico.RowsDefaultCellStyle.SelectionBackColor = Color.NavajoWhite;
            dgvMovimentoAnalitico.RowsDefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void popularListaCategoria()
        {
            var source = _categoriaController.GetAll();

            cboCategoriaFiltro.DataSource = source.ToList();
            cboCategoriaFiltro.DisplayMember = "Descricao";
            cboCategoriaFiltro.ValueMember = "Id";
            cboCategoriaFiltro.SelectedIndex = -1;
        }

        private void popularListaFormaPagamento()
        {
            var source = _formaPagamentoController.GetAll();
            cboFormaPagamento.DataSource = source.ToList();
            cboFormaPagamento.DisplayMember = "Descricao";
            cboFormaPagamento.ValueMember = "Id";

            cboFormaPagamento.SelectedIndex = -1;
        }

        private void popularMes()
        {
            var source = _movimentoAnaliticoController.GetByMonth(DateTime.Now.Year, DateTime.Now.Month);
            dgvMovimentoAnalitico.DataSource = source.ToList();
            setGrid();
            var filtro = setFiltros();
            calcularTotal(filtro);
        }

        private MovimentoAnaliticoFiltroDto setFiltros()
        {
            var filtro = new MovimentoAnaliticoFiltroDto();
            filtro.DataCompra = dtpDataCompraFiltro.Value;
            filtro.Pagamento = Convert.ToInt16(cboFormaPagamento.SelectedValue?.ToString());
            filtro.Categoria = Convert.ToInt16(cboCategoriaFiltro.SelectedValue?.ToString());
            return filtro;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var filtro = setFiltros();
            var source = _movimentoAnaliticoController.BuscarMovimentosAnaliticos(filtro);
            dgvMovimentoAnalitico.DataSource = source;
            if (source.Count > 0) setGrid();
            calcularTotal(filtro);
        }

        private void btnLimparFiltro_Click(object sender, EventArgs e)
        {
            dtpDataCompraFiltro.ResetText();
            cboCategoriaFiltro.SelectedIndex = -1;
            cboFormaPagamento.SelectedIndex = -1;
            popularMes();
        }

        private void calcularTotal(MovimentoAnaliticoFiltroDto filtro)
        {
            var total = _movimentoAnaliticoController.GetTotal(filtro);
            lblTotal.Text = String.Format("R$ {0}", total.ToString());
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            Novo();
        }

        private void Novo()
        {
            var form = NinjectKernel.Resolve<MovimentoAnaliticoForm>();
            form.Id = -1;
            form.ShowDialog();
            popularMes();

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            var form = NinjectKernel.Resolve<MovimentoAnaliticoForm>();
            form.Id = _id;
            form.ShowDialog();
            popularMes();
        }

        private void dgvMovimentoAnalitico_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Retorna o indice da linha no qual a célula foi clicada
            var _linhaIndice = e.RowIndex;

            //Se _linhaIndice é menor que -1 então retorna
            if (_linhaIndice == -1)
                return;

            //Cria um objeto DataGridViewRow de um indice particular
            DataGridViewRow rowData = dgvMovimentoAnalitico.Rows[_linhaIndice];

            //obtém valor
            _id = Convert.ToInt32(rowData.Cells[0].Value.ToString());
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            var result = base.MessageDelete(_id);
            if (result == DialogResult.Yes)
                _movimentoAnaliticoController.Delete(_id);
            popularMes();
        }
    }
}
