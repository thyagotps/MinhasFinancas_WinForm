using Base;
using Base.Ninject;
using Controller.ModuloMovimentoFinanceiro;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using System.Windows.Forms;
using View.ModuloBalancoMensal;
using View.ModuloCartao;
using View.ModuloCategoria;
using View.ModuloContaPadrao;
using View.ModuloFaturaEmAberto;
using View.ModuloPagamento;
using View.ModuloRelatorios;

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
            toolTipContasPadrao.SetToolTip(btnCriarContasPagarAuto, "Criar Contas Padrão");
            toolTipGerenciarContasPadrao.SetToolTip(btnGerenciarContasPadrao, "Gerenciar Contas Padrão");
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
            dgvMovimentoFinanceiro.Columns["DataMovimento"].HeaderText = "Data Movimento";
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

            dgvMovimentoFinanceiro.Columns["DataVencimento"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvMovimentoFinanceiro.Columns["DataVencimento"].HeaderText = "Data Vencimento";
            dgvMovimentoFinanceiro.Columns["DataVencimento"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvMovimentoFinanceiro.Columns["DataVencimento"].DisplayIndex = 7;

            dgvMovimentoFinanceiro.Columns["Situacao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvMovimentoFinanceiro.Columns["Situacao"].HeaderText = "Pago";
            dgvMovimentoFinanceiro.Columns["Situacao"].DisplayIndex = 8;

            dgvMovimentoFinanceiro.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvMovimentoFinanceiro.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dgvMovimentoFinanceiro.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

            //dgvMovimentoFinanceiro.RowsDefaultCellStyle.SelectionBackColor = Color.NavajoWhite;
            //dgvMovimentoFinanceiro.RowsDefaultCellStyle.SelectionForeColor = Color.Black;

            // Remove a cor na seleção da linha
            dgvMovimentoFinanceiro.DefaultCellStyle.SelectionBackColor = dgvMovimentoFinanceiro.DefaultCellStyle.BackColor;
            dgvMovimentoFinanceiro.DefaultCellStyle.SelectionForeColor = dgvMovimentoFinanceiro.DefaultCellStyle.ForeColor;
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
            //var form = NinjectKernel.Resolve<MovimentoFinanceiroForm>();
            var form = Program.ServiceProvider.GetRequiredService<MovimentoFinanceiroForm>();
            form.Id = 0;
            form.Estado = Estado.Insert;
            form.ShowDialog();
            popularMes(dtpDataMovimentoFiltro.Value.Year, dtpDataMovimentoFiltro.Value.Month);
        }

        private void editar()
        {
            var form = Program.ServiceProvider.GetRequiredService<MovimentoFinanceiroForm>();
            form.Id = Id;
            form.Estado = Estado.Update;
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
            //var view = NinjectKernel.Resolve<CategoriaView>();
            //view.MdiParent = this;
            var view = Program.ServiceProvider.GetRequiredService<CategoriaView>();
            view.Show();
        }

        private void btnCartao_Click(object sender, EventArgs e)
        {
            //var view = NinjectKernel.Resolve<CartaoView>();
            //view.MdiParent = this;

            var view = Program.GetService<CartaoView>();
            view.Show();
        }

        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            //var view = NinjectKernel.Resolve<RelatoriosView>();
            //view.MdiParent = this;
            var view = Program.GetService<RelatoriosView>();
            view.Show();
        }

        private void btnFaturaEmAberto_Click(object sender, EventArgs e)
        {
            //var view = NinjectKernel.Resolve<FaturaEmAbertoView>();
            //view.MdiParent = this;
            var view = Program.GetService<FaturaEmAbertoView>();
            view.Show();
        }

        private void btnPagamentos_Click(object sender, EventArgs e)
        {
            //var view = NinjectKernel.Resolve<PagamentoView>();
            //view.MdiParent = this;
            //var view = Program.GetService<PagamentoView>();
            //view.Show();

            var view = Program.GetService<ContaPadraoView>();
            view.Show();
        }

        private void btnBalancoMensal_Click(object sender, EventArgs e)
        {
            var view = Program.ServiceProvider.GetRequiredService<BalancoMensalView>();
            view.Show();
        }

        private void dgvMovimentoFinanceiro_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRow r = dgvMovimentoFinanceiro.Rows[e.RowIndex];

            if (r.Cells["Situacao"].Value == null) return;

            if (r.Cells["Situacao"].Value.ToString() == "S")
                r.Cells["Situacao"].Style.BackColor = Color.LightGreen;
            else
                r.Cells["Situacao"].Style.BackColor = Color.AliceBlue;
        }

        private void btnCriarContasPagarAuto_Click(object sender, EventArgs e)
        {
            var resp = MessageBox.Show("Deseja criar contas à pagar padrão?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resp == DialogResult.Yes)
            {
                _movimentoFinanceiroController.CriarPagamentosAutomaticos(dtpDataMovimentoFiltro.Value);
                buscar();
            }
        }

        private void dgvMovimentoFinanceiro_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 12) // substitua por sua lógica
            {
                e.Handled = true; // Impede o desenho padrão

                // Fundo personalizado mesmo em seleção
                var isSelected = dgvMovimentoFinanceiro.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected;
                var backgroundColor = isSelected
                    ? e.CellStyle.BackColor // mantém a cor original mesmo selecionada
                    : e.CellStyle.BackColor;

                using (SolidBrush brush = new SolidBrush(backgroundColor))
                {
                    e.Graphics.FillRectangle(brush, e.CellBounds);
                }



                // Conteúdo com estilo próprio (exemplo: texto em negrito e azul)
                TextRenderer.DrawText(
                    e.Graphics,
                    e.FormattedValue?.ToString() ?? "",
                    new Font(e.CellStyle.Font, FontStyle.Regular),
                    e.CellBounds,
                    Color.Black,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
                );

                // Borda opcional
                using (Pen borderPen = new Pen(Color.DarkGray, 0))
                {
                    e.Graphics.DrawRectangle(borderPen, e.CellBounds);
                }
            }
        }

        
    }
}
