using Controller;
using Controller.Categorias;
using Controller.FormaPagamentos;
using Controller.MovimentosAnaliticos;
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
    public partial class MovimentoView : Form
    {
        private int _codigo { get; set; }
        private readonly IMovimentoAnaliticoController _movimentoController;
        private readonly ICategoriaController _categoriaController;
        private readonly IFormaPagamentoController _pagamentoController;

        public MovimentoView(IMovimentoAnaliticoController movimentoController,
            ICategoriaController categoriaController,IFormaPagamentoController pagamentoController)
        {
            InitializeComponent();
            _movimentoController = movimentoController;
            _categoriaController = categoriaController;
            _pagamentoController= pagamentoController;

            PopularListaCategoria();
            PopularListaPagamento();

        }

        private void PopularListaPagamento()
        {
            var source = _pagamentoController.GetAll();
            cboFormaPagamentoFiltro.DataSource = source.ToList();
            cboFormaPagamentoFiltro.DisplayMember = "Descricao";
            cboFormaPagamentoFiltro.ValueMember = "Id";
        }

        private void PopularListaCategoria()
        {
            var source = _categoriaController.GetAll();
            cboCategoriaFiltro.DataSource = source.ToList();
            cboCategoriaFiltro.DisplayMember = "Descricao";
            cboCategoriaFiltro.ValueMember = "Id";
        }


        #region Eventos da view
        /// <summary>
        /// Ação load do formulário
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MovimentoView_Load(object sender, EventArgs e)
        {
            Buscar();
        }
        #endregion

        #region Métodos
        private void Buscar()
        {
            var source = _movimentoController.GetAll();
            dgvMovimento.ReadOnly = true;
            dgvMovimento.DataSource = source;
        }
        
        #endregion

        private void btnNovo_Click(object sender, EventArgs e)
        {
            MovimentoForm form = new MovimentoForm(_movimentoController,_categoriaController,_pagamentoController);
            form.Codigo = -1;
            form.ShowDialog();
            if(form.DialogResult == DialogResult.OK)
                Buscar();
        }

        private void dgvMovimento_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Retorna o indice da linha no qual a célula foi clicada
            var _linhaIndice = e.RowIndex;

            //Se _linhaIndice é menor que -1 então retorna
            if (_linhaIndice == -1)
                return;

            //Cria um objeto DataGridViewRow de um indice particular
            DataGridViewRow rowData = dgvMovimento.Rows[_linhaIndice];

            //obtém valor
            _codigo = Convert.ToInt32(rowData.Cells[0].Value.ToString());
        }

       

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Editar();
        }
        private void Editar()
        {
            MovimentoForm form = new MovimentoForm(_movimentoController,_categoriaController,_pagamentoController);
            form.Codigo = _codigo;
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
                Buscar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Deseja realmente excluir o registro de código: " + _codigo.ToString() + "?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                _movimentoController.Delete(_codigo);
            Buscar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //var movimentoFiltroDto = new MovimentoFiltroDto() { DataCompra = new DateTime(2022, 01, 07) };

            //var movimentoFiltroDto = new MovimentoAnaliticoFiltroDto();
            //movimentoFiltroDto.DataCompra = new DateTime(dtpDataCompraFiltro.Value.Year, dtpDataCompraFiltro.Value.Month, dtpDataCompraFiltro.Value.Day);
            //movimentoFiltroDto.Categoria = cboCategoriaFiltro.SelectedValue.ToString();
            //movimentoFiltroDto.Pagamento = cboFormaPagamentoFiltro.SelectedValue.ToString();

            

            ////var source = _movimentoController.BuscarMovimento(movimentoFiltroDto);
            //dgvMovimento.ReadOnly = true;
            //dgvMovimento.DataSource = source;
        }
    }
}
