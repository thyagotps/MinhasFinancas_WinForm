using Controller.ModuloContaPadrao;
using Microsoft.Extensions.DependencyInjection;

namespace View.ModuloContaPadrao
{
    public partial class ContaPadraoView : BaseView
    {
        private readonly IContaPadraoController _contaPadraoController;

        public ContaPadraoView(IContaPadraoController contaPadraoController)
        {
            InitializeComponent();
            _contaPadraoController = contaPadraoController;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        private void ContaPadraoView_Load(object sender, EventArgs e)
        {
            buscar();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            novo();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            var result = base.MessageDelete(Id);
            if (result == DialogResult.Yes)
                _contaPadraoController.DeleteById(Id);
            buscar();
        }

        private void dgvContaPadrao_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var _linhaIndice = e.RowIndex;
            var grid = (DataGridView)sender;
            SetIdGrid(grid, _linhaIndice);
        }

        private void dgvContaPadrao_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var _linhaIndice = e.RowIndex;
            var grid = (DataGridView)sender;
            SetIdGrid(grid, _linhaIndice);
            editar();
        }


        private void buscar()
        {
            var source = _contaPadraoController.GetAll();
            setDataGridView(source);
        }

        private void setDataGridView(object source)
        {
            dgvContaPadrao.DataSource = source;
            dgvContaPadrao.ReadOnly = true;

            dgvContaPadrao.Columns["Id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvContaPadrao.Columns["Id"].DisplayIndex = 0;

            dgvContaPadrao.Columns["DataMovimento"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvContaPadrao.Columns["DataMovimento"].HeaderText = "Data Movimento";
            dgvContaPadrao.Columns["DataMovimento"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvContaPadrao.Columns["DataMovimento"].DisplayIndex = 1;

            dgvContaPadrao.Columns["TipoMovimento"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvContaPadrao.Columns["TipoMovimento"].HeaderText = "Tipo";
            dgvContaPadrao.Columns["TipoMovimento"].DisplayIndex = 2;

            dgvContaPadrao.Columns["Descricao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvContaPadrao.Columns["Descricao"].HeaderText = "Descrição";
            dgvContaPadrao.Columns["Descricao"].DisplayIndex = 3;

            dgvContaPadrao.Columns["Valor"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvContaPadrao.Columns["Valor"].DefaultCellStyle.Format = "c";
            dgvContaPadrao.Columns["Valor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvContaPadrao.Columns["Valor"].DisplayIndex = 4;

            dgvContaPadrao.Columns["IdCategoria"].Visible = false;
            dgvContaPadrao.Columns["CategoriaDescricao"].Visible = false;
            dgvContaPadrao.Columns["CategoriaDisplayMember"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvContaPadrao.Columns["CategoriaDisplayMember"].HeaderText = "Categoria";
            dgvContaPadrao.Columns["CategoriaDisplayMember"].DisplayIndex = 5;

            dgvContaPadrao.Columns["IdCartao"].Visible = false;
            dgvContaPadrao.Columns["CartaoDescricao"].Visible = false;
            dgvContaPadrao.Columns["CartaoDisplayMember"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvContaPadrao.Columns["CartaoDisplayMember"].HeaderText = "Cartão";
            dgvContaPadrao.Columns["CartaoDisplayMember"].DisplayIndex = 6;

            dgvContaPadrao.Columns["DataVencimento"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvContaPadrao.Columns["DataVencimento"].HeaderText = "Data Vencimento";
            dgvContaPadrao.Columns["DataVencimento"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvContaPadrao.Columns["DataVencimento"].DisplayIndex = 7;

            dgvContaPadrao.Columns["Situacao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvContaPadrao.Columns["Situacao"].HeaderText = "Pago";
            dgvContaPadrao.Columns["Situacao"].DisplayIndex = 8;

            dgvContaPadrao.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvContaPadrao.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dgvContaPadrao.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

            dgvContaPadrao.RowsDefaultCellStyle.SelectionBackColor = Color.NavajoWhite;
            dgvContaPadrao.RowsDefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void novo()
        {
            var form = Program.ServiceProvider.GetRequiredService<ContaPadraoForm>();
            form.Id = 0;
            form.Estado = Estado.Insert;
            form.ShowDialog();
            buscar();
        }

        private void editar()
        {
            var form = Program.ServiceProvider.GetRequiredService<ContaPadraoForm>();
            form.Id = Id;
            form.Estado = Estado.Update;
            form.ShowDialog();
            buscar();
        }


    }
}
