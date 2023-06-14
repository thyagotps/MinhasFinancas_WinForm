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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View.MovimentosAnaliticos
{
    public partial class MovimentoAnaliticoView : Form
    {
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
            dtpDataCompraFiltro.Value = DateTime.Now;
            PopularListaCategoria();
            PopularListaFormaPagamento();
            PopularMes();
        }




        private void PopularListaCategoria()
        {
            var source = _categoriaController.GetAll();
            cboCategoriaFiltro.DataSource = source.ToList();
            cboCategoriaFiltro.DisplayMember = "Descricao";
            cboCategoriaFiltro.ValueMember = "Id";
        }

        private void PopularListaFormaPagamento()
        {
            var source = _formaPagamentoController.GetAll();
            cboFormaPagamento.DataSource = source.ToList();
            cboFormaPagamento.DisplayMember = "Descricao";
            cboFormaPagamento.ValueMember = "Id";
        }

        private void PopularMes()
        {
            var source = _movimentoAnaliticoController.GetByMonth(DateTime.Now.Month);
            dgvMovimentoAnalitico.DataSource = source.ToList();
        }
    }
}
