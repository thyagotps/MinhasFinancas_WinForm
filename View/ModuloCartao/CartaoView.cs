using Base.Ninject;
using Controller.ModuloCartao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View.ModuloCategoria;

namespace View.ModuloCartao
{
    public partial class CartaoView : BaseView
    {

        private readonly ICartaoController _cartaoController;

        public CartaoView(ICartaoController cartaoController)
        {
            InitializeComponent();
            _cartaoController = cartaoController;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        private void CartaoView_Load(object sender, EventArgs e)
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

        private void dgvCartao_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var _linhaIndice = e.RowIndex;
            var grid = (DataGridView)sender;
            SetIdGrid(grid, _linhaIndice);
        }

        private void dgvCartao_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var _linhaIndice = e.RowIndex;
            var grid = (DataGridView)sender;
            SetIdGrid(grid, _linhaIndice);
            editar();
        }

        private void buscar()
        {
            var source = _cartaoController.GetAll();
            setDataGridView(source);
        }

        private void novo()
        {
            var form = NinjectKernel.Resolve<CartaoForm>();
            form.Id = -1;
            form.ShowDialog();
            buscar();
        }

        private void editar()
        {
            var form = NinjectKernel.Resolve<CartaoForm>();
            form.Id = Id;
            form.ShowDialog();
            buscar();
        }

        private void excluir()
        {
            var result = base.MessageDelete(Id);
            if (result == DialogResult.Yes)
                _cartaoController.DeleteById(Id);
            buscar();
        }

        private void setDataGridView(object source)
        {
            dgvCartao.DataSource = source;

            dgvCartao.ReadOnly = true;

            dgvCartao.Columns["Id"].Width = 50;
            dgvCartao.Columns["Descricao"].HeaderText = "Descrição";

            dgvCartao.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvCartao.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dgvCartao.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

            dgvCartao.RowsDefaultCellStyle.SelectionBackColor = Color.NavajoWhite;
            dgvCartao.RowsDefaultCellStyle.SelectionForeColor = Color.Black;
        }
    }
}
