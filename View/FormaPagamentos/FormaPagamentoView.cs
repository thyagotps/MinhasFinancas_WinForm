using Base.Ninject;
using Controller.FormaPagamentos;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View.FormaPagamentos
{
    public partial class FormaPagamentoView : BaseView
    {
        private int _id { get; set; }
        private readonly IFormaPagamentoController _controller;

        public FormaPagamentoView(IFormaPagamentoController controller)
        {
            InitializeComponent();
            _controller = controller;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        #region Eventos da view

        private void PagamentoView_Load(object sender, EventArgs e)
        {
            Buscar();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            Novo();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Editar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Excluir();
        }

        private void dgvPagamento_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Retorna o indice da linha no qual a célula foi clicada
            var _linhaIndice = e.RowIndex;

            //Se _linhaIndice é menor que -1 então retorna
            if (_linhaIndice == -1)
                return;

            //Cria um objeto DataGridViewRow de um indice particular
            DataGridViewRow rowData = dgvPagamento.Rows[_linhaIndice];

            //obtém valor
            _id = Convert.ToInt32(rowData.Cells[0].Value.ToString());
        }

        #endregion

        #region Métodos

        private void Buscar()
        {
            var source = _controller.GetAll();
            dgvPagamento.ReadOnly = true;
            dgvPagamento.DataSource = source;
            dgvPagamento.Columns["Id"].Width = 50;
            dgvPagamento.Columns["Descricao"].HeaderText = "Descrição";
            dgvPagamento.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvPagamento.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dgvPagamento.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

            dgvPagamento.RowsDefaultCellStyle.SelectionBackColor = Color.NavajoWhite;
            dgvPagamento.RowsDefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void Novo()
        {
            //FormaPagamentoForm form = new FormaPagamentoForm(_controller);
            var form = NinjectKernel.Resolve<FormaPagamentoForm>();
            form.Id = -1;
            form.ShowDialog();
            Buscar();
        }

        private void Editar()
        {
            //FormaPagamentoForm form = new FormaPagamentoForm(_controller);
            var form = NinjectKernel.Resolve<FormaPagamentoForm>();
            form.Id = _id;
            form.ShowDialog();
            Buscar();
        }

        private void Excluir()
        {
            var result = base.MessageDelete(_id);
            if (result == DialogResult.Yes)
                _controller.Delete(_id);
            Buscar();
        }


        #endregion
    }
}
