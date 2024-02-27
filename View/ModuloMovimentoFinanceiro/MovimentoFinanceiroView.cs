using Base.Ninject;
using Controller.ModuloCategoria;
using Controller.ModuloMovimentoFinanceiro;
using Model.ModuloMovimentoFinanceiro;
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
using View.ModuloCartao;
using View.ModuloCategoria;
using View.ModuloFaturaEmAberto;
using View.ModuloPagamento;
using View.ModuloRelatorios;
using View.ModuloSaida;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace View.ModuloMovimentoFinanceiro
{
    public partial class MovimentoFinanceiroView : BaseView
    {

        private readonly IMovimentoFinanceiroController _movimentoFinanceiroController;

        public decimal TotalRenda { get; set; }
        public decimal TotalDespesa { get; set; }
        public decimal TotalSaldo { get; set; }


        public MovimentoFinanceiroView(IMovimentoFinanceiroController movimentoFinanceiroController)
        {
            InitializeComponent();
            _movimentoFinanceiroController = movimentoFinanceiroController;
        }

        private void MovimentoFinanceiroView_Load(object sender, EventArgs e)
        {
            setDataMovimento();
            popularMes(DateTime.Now.Year, DateTime.Now.Month);

            toolTip1.SetToolTip(btnNovoMovimentoFinanceiro, "Inserir Renda/Despesa");
            toolTipDelete.SetToolTip(btnDeletarMovimentoFinanceiro, "Deletar Renda/Despesa");
            toolTipBuscar.SetToolTip(btnBuscar, "Buscar Registros por Mês");
            toolTipCategoria.SetToolTip(btnCategoria, "Gerenciar Categorias");
            toolTipCartao.SetToolTip(btnCartao, "Gerenciar Cartão");
            toolTipRelatorio.SetToolTip(btnRelatorio, "Gerar Relatórios");
        }

        private void btnNovoMovimentoFinanceiro_Click(object sender, EventArgs e)
        {
            novo();
        }

        private void btnDeletarMovimentoFinanceiro_Click(object sender, EventArgs e)
        {
            excluir();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            buscar();
        }

        private void dgvMovimentoFinanceiro_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var _linhaIndice = e.RowIndex;
            var grid = (DataGridView)sender;
            SetIdGrid(grid, _linhaIndice);
        }

        private void dgvMovimentoFinanceiro_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var _linhaIndice = e.RowIndex;
            var grid = (DataGridView)sender;
            SetIdGrid(grid, _linhaIndice);
            editar();
        }







        private void setDataMovimento()
        {
            dtpDataMovimentoFiltro.Value = DateTime.Now;
            dtpDataMovimentoFiltro.Format = DateTimePickerFormat.Custom;
            dtpDataMovimentoFiltro.CustomFormat = "MM/yyyy";
        }

        private void popularMes(int year, int month)
        {
            var source = _movimentoFinanceiroController.GetByMonth(year, month);
            setDataGridView(source);
            getTotalRenda(year, month);
            getTotalDespesa(year, month);
            getTotalSaldo(year, month);
        }



        private void setDataGridView(object source)
        {
            dgvMovimentoFinanceiro.DataSource = source;
            dgvMovimentoFinanceiro.ReadOnly = true;

            dgvMovimentoFinanceiro.Columns["Id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvMovimentoFinanceiro.Columns["Id"].DisplayIndex = 0;

            dgvMovimentoFinanceiro.Columns["DataMovimento"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvMovimentoFinanceiro.Columns["DataMovimento"].HeaderText = "Data Saída";
            dgvMovimentoFinanceiro.Columns["DataMovimento"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvMovimentoFinanceiro.Columns["DataMovimento"].DisplayIndex = 1;

            dgvMovimentoFinanceiro.Columns["TipoMovimento"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvMovimentoFinanceiro.Columns["TipoMovimento"].HeaderText = "Tipo";
            dgvMovimentoFinanceiro.Columns["TipoMovimento"].DisplayIndex = 2;

            dgvMovimentoFinanceiro.Columns["Descricao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvMovimentoFinanceiro.Columns["Descricao"].HeaderText = "Descrição";
            dgvMovimentoFinanceiro.Columns["Descricao"].DisplayIndex = 3;

            dgvMovimentoFinanceiro.Columns["Valor"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvMovimentoFinanceiro.Columns["Valor"].DefaultCellStyle.Format = "c";
            dgvMovimentoFinanceiro.Columns["Valor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvMovimentoFinanceiro.Columns["Valor"].DisplayIndex = 4;

            dgvMovimentoFinanceiro.Columns["IdCategoria"].Visible = false;
            dgvMovimentoFinanceiro.Columns["CategoriaDescricao"].Visible = false;
            dgvMovimentoFinanceiro.Columns["CategoriaDisplayMember"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvMovimentoFinanceiro.Columns["CategoriaDisplayMember"].HeaderText = "Categoria";
            dgvMovimentoFinanceiro.Columns["CategoriaDisplayMember"].DisplayIndex = 5;

            dgvMovimentoFinanceiro.Columns["IdCartao"].Visible = false;
            dgvMovimentoFinanceiro.Columns["CartaoDescricao"].Visible = false;
            dgvMovimentoFinanceiro.Columns["CartaoDisplayMember"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvMovimentoFinanceiro.Columns["CartaoDisplayMember"].HeaderText = "Cartão";
            dgvMovimentoFinanceiro.Columns["CartaoDisplayMember"].DisplayIndex = 6;

            dgvMovimentoFinanceiro.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvMovimentoFinanceiro.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dgvMovimentoFinanceiro.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

            dgvMovimentoFinanceiro.RowsDefaultCellStyle.SelectionBackColor = Color.NavajoWhite;
            dgvMovimentoFinanceiro.RowsDefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void getTotalRenda(int year, int month)
        {
            TotalRenda = _movimentoFinanceiroController.GetTotalRendaByMonth(year, month);
            lblTotalRenda.Text = TotalRenda.ToString("C", CultureInfo.CurrentCulture);
        }

        private void getTotalDespesa(int year, int month)
        {
            TotalDespesa = _movimentoFinanceiroController.GetTotalDespesaByMonth(year, month);
            lblTotalDespesa.Text = TotalDespesa.ToString("C", CultureInfo.CurrentCulture);
        }

        private void getTotalSaldo(int year, int month)
        {
            TotalSaldo = TotalRenda - TotalDespesa;
            lblTotalSaldo.Text = TotalSaldo.ToString("C", CultureInfo.CurrentCulture);
        }

        private void novo()
        {
            var form = NinjectKernel.Resolve<MovimentoFinanceiroForm>();
            form.Id = -1;
            form.ShowDialog();
            popularMes(dtpDataMovimentoFiltro.Value.Year, dtpDataMovimentoFiltro.Value.Month);
        }

        private void editar()
        {
            var form = NinjectKernel.Resolve<MovimentoFinanceiroForm>();
            form.Id = Id;
            form.ShowDialog();
            popularMes(dtpDataMovimentoFiltro.Value.Year, dtpDataMovimentoFiltro.Value.Month);
        }

        private void excluir()
        {
            var result = base.MessageDelete(Id);
            if (result == DialogResult.Yes)
                _movimentoFinanceiroController.DeleteById(Id);
            popularMes(dtpDataMovimentoFiltro.Value.Year, dtpDataMovimentoFiltro.Value.Month);
        }

        private void buscar()
        {
            popularMes(dtpDataMovimentoFiltro.Value.Year, dtpDataMovimentoFiltro.Value.Month);
        }

        private void btnCategoria_Click(object sender, EventArgs e)
        {
            var view = NinjectKernel.Resolve<CategoriaView>();
            //view.MdiParent = this;
            view.Show();
        }

        private void btnCartao_Click(object sender, EventArgs e)
        {
            var view = NinjectKernel.Resolve<CartaoView>();
            //view.MdiParent = this;
            view.Show();
        }

        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            var view = NinjectKernel.Resolve<RelatoriosView>();
            //view.MdiParent = this;
            view.Show();
        }

        private void btnFaturaEmAberto_Click(object sender, EventArgs e)
        {
            var view = NinjectKernel.Resolve<FaturaEmAbertoView>();
            //view.MdiParent = this;
            view.Show();
        }

        private void btnPagamentos_Click(object sender, EventArgs e)
        {
            var view = NinjectKernel.Resolve<PagamentoView>();
            //view.MdiParent = this;
            view.Show();
        }
    }
}
