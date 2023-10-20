using Base.Ninject;
using Controller.ContasPagar;
using Controller.ModuloFaturaEmAberto;
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
using View.ModuloCategoria;
using View.ContasPagar;

namespace View.ModuloFaturaEmAberto
{
    public partial class FaturaEmAbertoView : BaseView
    {
        private int _id { get; set; }
        private readonly IFaturaEmAbertoController _controller;

        public FaturaEmAbertoView(IFaturaEmAbertoController controller)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            _controller = controller;
        }

        private void FaturaEmAbertoView_Load(object sender, EventArgs e)
        {
            buscar();
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

        private void btnNovo_Click(object sender, EventArgs e)
        {
            novo();
        }

        private void novo()
        {
            var form = NinjectKernel.Resolve<FaturaEmAbertoForm>();
            form.Id = -1;
            form.ShowDialog();
            buscar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            editar();
        }

        private void editar()
        {
            var form = NinjectKernel.Resolve<FaturaEmAbertoForm>();
            form.Id = _id;
            form.ShowDialog();
            buscar();
        }

        //TODO: Refatorar
        private void dgvFaturaEmAberto_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Retorna o indice da linha no qual a célula foi clicada
            var _linhaIndice = e.RowIndex;

            //Se _linhaIndice é menor que -1 então retorna
            if (_linhaIndice == -1)
                return;

            //Cria um objeto DataGridViewRow de um indice particular
            DataGridViewRow rowData = dgvFaturaEmAberto.Rows[_linhaIndice];

            //obtém valor
            _id = Convert.ToInt32(rowData.Cells[0].Value.ToString());
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            excluir();
        }

        private void excluir()
        {
            var result = base.MessageDelete(_id);
            if (result == DialogResult.Yes)
                _controller.DeleteById(_id);
            buscar();
        }
    }
}
