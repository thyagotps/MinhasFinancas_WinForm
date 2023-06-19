﻿using Controller.Categorias;
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

        private void SetGrid()
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
            dgvMovimentoAnalitico.Columns["PagamentoId"].Visible = false;

            dgvMovimentoAnalitico.Columns["FormaPagamentoDescricao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvMovimentoAnalitico.Columns["FormaPagamentoDescricao"].HeaderText = "Forma de Pagamento";



            dgvMovimentoAnalitico.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvMovimentoAnalitico.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dgvMovimentoAnalitico.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

            dgvMovimentoAnalitico.RowsDefaultCellStyle.SelectionBackColor = Color.NavajoWhite;
            dgvMovimentoAnalitico.RowsDefaultCellStyle.SelectionForeColor = Color.Black;
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
            SetGrid();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var filtro = new MovimentoAnaliticoFiltroDto();
            filtro.DataCompra = dtpDataCompraFiltro.Value;
            filtro.Pagamento = Convert.ToInt16(cboFormaPagamento.SelectedValue?.ToString());
            filtro.Categoria = Convert.ToInt16(cboCategoriaFiltro.SelectedValue?.ToString());

            var source = _movimentoAnaliticoController.BuscarMovimentosAnaliticos(filtro);
            dgvMovimentoAnalitico.DataSource = source;
            if (source.Count > 0) SetGrid();
        }

        private void btnLimparFiltro_Click(object sender, EventArgs e)
        {
            dtpDataCompraFiltro.ResetText();
            cboCategoriaFiltro.SelectedIndex = -1;
            cboFormaPagamento.SelectedIndex = -1;
            PopularMes();
        }
    }
}
