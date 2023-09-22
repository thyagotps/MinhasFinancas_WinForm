using Base.Ninject;
using Controller.ContasPagar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View.FormaPagamentos;

namespace View.ContasPagar
{
    public partial class ContaPagarView : BaseView
    {
        private int _id { get; set; }
        private readonly IContaPagarController _controller;


        public ContaPagarView(IContaPagarController contaPagarController)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            _controller = contaPagarController;
        }

        private void ContaPagarView_Load(object sender, EventArgs e)
        {
            setDataCompra();
            buscar(DateTime.Now);
        }


        private void buscar(DateTime dtPeriodo)
        {
            var dataSource = _controller.Buscar(dtPeriodo);
            setupDataGridView(dataSource);
            getTotal(dtPeriodo);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var dtPeriodo = dtpPeriodoFiltro.Value;
            buscar(dtPeriodo);
            getTotal(dtPeriodo);

        }

        private void getTotal(DateTime dtPeriodo)
        {
            var total = _controller.GetTotal(dtPeriodo);
            lblTotal.Text = total.ToString("C", CultureInfo.CurrentCulture);
        }

        private void setupDataGridView(object dataSource)
        {
            dgvContaPagar.ReadOnly = true;
            dgvContaPagar.DataSource = dataSource;
            dgvContaPagar.Columns["Id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvContaPagar.Columns["NrIdentificador"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvContaPagar.Columns["NrIdentificador"].HeaderText = "Identificador";
            dgvContaPagar.Columns["Descricao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvContaPagar.Columns["Descricao"].HeaderText = "Descrição";
            dgvContaPagar.Columns["Valor"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvContaPagar.Columns["Valor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvContaPagar.Columns["DataVencimento"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvContaPagar.Columns["DataVencimento"].HeaderText = "Vencimento";
            dgvContaPagar.Columns["DataVencimento"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvContaPagar.Columns["Situacao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvContaPagar.Columns["Situacao"].HeaderText = "Pago";

            dgvContaPagar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvContaPagar.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dgvContaPagar.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

            dgvContaPagar.RowsDefaultCellStyle.SelectionBackColor = Color.NavajoWhite;
            dgvContaPagar.RowsDefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void dgvContaPagar_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRow r = dgvContaPagar.Rows[e.RowIndex];
            if (r.Cells[5].Value.ToString() == "S")
                r.DefaultCellStyle.BackColor = Color.LightGreen;
            else
                r.DefaultCellStyle.BackColor = Color.AliceBlue;
        }

        private void setDataCompra()
        {
            dtpPeriodoFiltro.Value = DateTime.Now;
            dtpPeriodoFiltro.Format = DateTimePickerFormat.Custom;
            dtpPeriodoFiltro.CustomFormat = "MM/yyyy";
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            var form = NinjectKernel.Resolve<ContaPagarForm>();
            form.Id = -1;
            form.ShowDialog();
            var dtPeriodo = dtpPeriodoFiltro.Value;
            buscar(dtPeriodo);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            var form = NinjectKernel.Resolve<ContaPagarForm>();
            form.Id = _id;
            form.ShowDialog();
            var dtPeriodo = dtpPeriodoFiltro.Value;
            buscar(dtPeriodo);
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            var result = base.MessageDelete(_id);
            if (result == DialogResult.Yes)
                _controller.DeleteById(_id);
            var dtPeriodo = dtpPeriodoFiltro.Value;
            buscar(dtPeriodo);
        }

        private void dgvContaPagar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Retorna o indice da linha no qual a célula foi clicada
            var _linhaIndice = e.RowIndex;

            //Se _linhaIndice é menor que -1 então retorna
            if (_linhaIndice == -1)
                return;

            //Cria um objeto DataGridViewRow de um indice particular
            DataGridViewRow rowData = dgvContaPagar.Rows[_linhaIndice];

            //obtém valor
            _id = Convert.ToInt32(rowData.Cells[0].Value.ToString());
        }

        private void btnCriarContasPagarAuto_Click(object sender, EventArgs e)
        {
            var resp = MessageBox.Show("Deseja criar contas à pagar padrão?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resp == DialogResult.Yes)
            {
                _controller.CriarContasPagarAuto(dtpPeriodoFiltro.Value);
                buscar(dtpPeriodoFiltro.Value);
            }
        }

    }
}
