using Base.Ninject;
using Controller.ModuloCartao;
using Controller.ModuloSalario;

namespace View.ModuloSalario
{
    public partial class SalarioView : BaseView
    {
        private int _id;
        private readonly ISalarioController _salarioController;
        private readonly ICartaoController _formaPagamentoController;

        public SalarioView(
            ISalarioController salarioController,
            ICartaoController formaPagamentoController)
        {
            InitializeComponent();
            _salarioController = salarioController;
            _formaPagamentoController = formaPagamentoController;
        }

        private void SalarioView_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            buscar();
        }


        private void setupDataGridView(object dataSource)
        {
            dgvSalario.ReadOnly = true;
            dgvSalario.DataSource = dataSource;
            dgvSalario.Columns["Id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvSalario.Columns["Descricao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvSalario.Columns["Descricao"].HeaderText = "Descrição";
            dgvSalario.Columns["DataSalario"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvSalario.Columns["DataSalario"].HeaderText = "Data Salário";
            dgvSalario.Columns["DataSalario"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvSalario.Columns["Valor"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvSalario.Columns["Valor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvSalario.Columns["IdFormaPagamento"].Visible = false;

            dgvSalario.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvSalario.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dgvSalario.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

            dgvSalario.RowsDefaultCellStyle.SelectionBackColor = Color.NavajoWhite;
            dgvSalario.RowsDefaultCellStyle.SelectionForeColor = Color.Black;
        }


        private void buscar()
        {
            var dataSource = _salarioController.GetAll();
            setupDataGridView(dataSource);
        }

        private void dgvSalario_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Retorna o indice da linha no qual a célula foi clicada
            var _linhaIndice = e.RowIndex;

            //Se _linhaIndice é menor que -1 então retorna
            if (_linhaIndice == -1)
                return;

            //Cria um objeto DataGridViewRow de um indice particular
            DataGridViewRow rowData = dgvSalario.Rows[_linhaIndice];

            //obtém valor
            _id = Convert.ToInt32(rowData.Cells[0].Value.ToString());

            editar();
        }

        private void editar()
        {
            var form = NinjectKernel.Resolve<SalarioForm>();
            form.Id = _id;
            form.ShowDialog();
            buscar();
        }

        private void novo()
        {
            var form = NinjectKernel.Resolve<SalarioForm>();
            form.Id = -1;
            form.ShowDialog();
            buscar();
        }

        private void delete()
        {
            var result = base.MessageDelete(_id);
            if (result == DialogResult.Yes)
                _salarioController.DeleteById(_id);
            buscar();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            novo();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            delete();
        }
    }
}
