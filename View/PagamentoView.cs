using Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    public partial class PagamentoView : Form
    {
        private int _codigo { get; set; }
        private readonly IPagamentoController _controller;

        public PagamentoView(IPagamentoController controller)
        {
            InitializeComponent();
            _controller = controller;
        }

        #region Eventos da view
        /// <summary>
        /// Ação load do formulário
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PagamentoView_Load(object sender, EventArgs e)
        {
            Buscar();
        }

        /// <summary>
        /// Ação novo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNovo_Click(object sender, EventArgs e)
        {
            PagamentoForm form = new PagamentoForm(_controller);
            form.Codigo = -1;
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
                Buscar();
        }

        /// <summary>
        /// Ação editar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditar_Click(object sender, EventArgs e)
        {
            PagamentoForm form = new PagamentoForm(_controller);
            form.Codigo = _codigo;
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
                Buscar();
        }

        /// <summary>
        /// Ação excluir
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Deseja realmente excluir o registro de código: " + _codigo.ToString() + "?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                _controller.Delete(_codigo);
            Buscar();
        }

        /// <summary>
        /// Evento cell click do dataGridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            _codigo = Convert.ToInt32(rowData.Cells[0].Value.ToString());
        }

        #endregion

        #region Métodos
        /// <summary>
        /// Busca todos os registros
        /// </summary>
        private void Buscar()
        {
            var source = _controller.GetAll();
            dgvPagamento.ReadOnly = true;
            dgvPagamento.DataSource = source;
        }



        #endregion

       
    }
}
