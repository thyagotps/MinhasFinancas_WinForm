namespace View.ModuloMovimentoFinanceiro
{
    partial class MovimentoFinanceiroView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MovimentoFinanceiroView));
            panel1 = new Panel();
            panel3 = new Panel();
            btnCategoria = new Button();
            btnCartao = new Button();
            label12 = new Label();
            btnRelatorio = new Button();
            btnGerenciarContasPadrao = new Button();
            label8 = new Label();
            label11 = new Label();
            label9 = new Label();
            btnFaturaEmAberto = new Button();
            label10 = new Label();
            panel2 = new Panel();
            btnNovoMovimentoFinanceiro = new Button();
            btnDeletarMovimentoFinanceiro = new Button();
            label13 = new Label();
            label5 = new Label();
            btnCriarContasPagarAuto = new Button();
            label6 = new Label();
            label7 = new Label();
            btnBuscar = new Button();
            lblTotalSaldo = new Label();
            lblTotalDespesa = new Label();
            lblTotalRenda = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            dtpDataMovimentoFiltro = new DateTimePicker();
            label1 = new Label();
            dgvMovimentoFinanceiro = new DataGridView();
            toolTip1 = new ToolTip(components);
            toolTipDelete = new ToolTip(components);
            toolTipBuscar = new ToolTip(components);
            toolTipCategoria = new ToolTip(components);
            toolTipCartao = new ToolTip(components);
            toolTipRelatorio = new ToolTip(components);
            toolTipContasPadrao = new ToolTip(components);
            toolTipGerenciarContasPadrao = new ToolTip(components);
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMovimentoFinanceiro).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(43, 76, 126);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(btnBuscar);
            panel1.Controls.Add(lblTotalSaldo);
            panel1.Controls.Add(lblTotalDespesa);
            panel1.Controls.Add(lblTotalRenda);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(dtpDataMovimentoFiltro);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1051, 105);
            panel1.TabIndex = 11;
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.Fixed3D;
            panel3.Controls.Add(btnCategoria);
            panel3.Controls.Add(btnCartao);
            panel3.Controls.Add(label12);
            panel3.Controls.Add(btnRelatorio);
            panel3.Controls.Add(btnGerenciarContasPadrao);
            panel3.Controls.Add(label8);
            panel3.Controls.Add(label11);
            panel3.Controls.Add(label9);
            panel3.Controls.Add(btnFaturaEmAberto);
            panel3.Controls.Add(label10);
            panel3.Location = new Point(697, 10);
            panel3.Name = "panel3";
            panel3.Size = new Size(347, 85);
            panel3.TabIndex = 27;
            // 
            // btnCategoria
            // 
            btnCategoria.Cursor = Cursors.Hand;
            btnCategoria.Image = Properties.Resources.Cateoria;
            btnCategoria.Location = new Point(7, 13);
            btnCategoria.Name = "btnCategoria";
            btnCategoria.Size = new Size(50, 40);
            btnCategoria.TabIndex = 6;
            btnCategoria.UseVisualStyleBackColor = true;
            btnCategoria.Click += btnCategoria_Click;
            // 
            // btnCartao
            // 
            btnCartao.Cursor = Cursors.Hand;
            btnCartao.Image = Properties.Resources.Cartao;
            btnCartao.Location = new Point(71, 13);
            btnCartao.Name = "btnCartao";
            btnCartao.Size = new Size(50, 40);
            btnCartao.TabIndex = 7;
            btnCartao.UseVisualStyleBackColor = true;
            btnCartao.Click += btnCartao_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            label12.ForeColor = Color.Gainsboro;
            label12.Location = new Point(287, 58);
            label12.Name = "label12";
            label12.Size = new Size(49, 12);
            label12.TabIndex = 23;
            label12.Text = "Gerenciar";
            label12.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnRelatorio
            // 
            btnRelatorio.Cursor = Cursors.Hand;
            btnRelatorio.Image = Properties.Resources.Grafico;
            btnRelatorio.Location = new Point(219, 13);
            btnRelatorio.Name = "btnRelatorio";
            btnRelatorio.Size = new Size(50, 40);
            btnRelatorio.TabIndex = 8;
            btnRelatorio.UseVisualStyleBackColor = true;
            btnRelatorio.Click += btnRelatorio_Click;
            // 
            // btnGerenciarContasPadrao
            // 
            btnGerenciarContasPadrao.Cursor = Cursors.Hand;
            btnGerenciarContasPadrao.Image = Properties.Resources.ContasPadrao;
            btnGerenciarContasPadrao.Location = new Point(287, 13);
            btnGerenciarContasPadrao.Name = "btnGerenciarContasPadrao";
            btnGerenciarContasPadrao.Size = new Size(50, 40);
            btnGerenciarContasPadrao.TabIndex = 22;
            btnGerenciarContasPadrao.UseVisualStyleBackColor = true;
            btnGerenciarContasPadrao.Click += btnPagamentos_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            label8.ForeColor = Color.Gainsboro;
            label8.Location = new Point(7, 58);
            label8.Name = "label8";
            label8.Size = new Size(49, 12);
            label8.TabIndex = 17;
            label8.Text = "Categoria";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            label11.ForeColor = Color.Gainsboro;
            label11.Location = new Point(126, 58);
            label11.Name = "label11";
            label11.Size = new Size(86, 12);
            label11.TabIndex = 21;
            label11.Text = "Fatura Em Aberto";
            label11.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            label9.ForeColor = Color.Gainsboro;
            label9.Location = new Point(77, 58);
            label9.Name = "label9";
            label9.Size = new Size(35, 12);
            label9.TabIndex = 18;
            label9.Text = "Cartão";
            label9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnFaturaEmAberto
            // 
            btnFaturaEmAberto.Cursor = Cursors.Hand;
            btnFaturaEmAberto.Image = Properties.Resources.Grafico;
            btnFaturaEmAberto.Location = new Point(142, 13);
            btnFaturaEmAberto.Name = "btnFaturaEmAberto";
            btnFaturaEmAberto.Size = new Size(50, 40);
            btnFaturaEmAberto.TabIndex = 20;
            btnFaturaEmAberto.UseVisualStyleBackColor = true;
            btnFaturaEmAberto.Click += btnFaturaEmAberto_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            label10.ForeColor = Color.Gainsboro;
            label10.Location = new Point(219, 58);
            label10.Name = "label10";
            label10.Size = new Size(52, 12);
            label10.TabIndex = 19;
            label10.Text = "Relatórios";
            label10.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.Fixed3D;
            panel2.Controls.Add(btnNovoMovimentoFinanceiro);
            panel2.Controls.Add(btnDeletarMovimentoFinanceiro);
            panel2.Controls.Add(label13);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(btnCriarContasPagarAuto);
            panel2.Controls.Add(label6);
            panel2.Location = new Point(448, 10);
            panel2.Name = "panel2";
            panel2.Size = new Size(242, 85);
            panel2.TabIndex = 26;
            // 
            // btnNovoMovimentoFinanceiro
            // 
            btnNovoMovimentoFinanceiro.Cursor = Cursors.Hand;
            btnNovoMovimentoFinanceiro.Image = Properties.Resources.Novo2;
            btnNovoMovimentoFinanceiro.Location = new Point(18, 11);
            btnNovoMovimentoFinanceiro.Name = "btnNovoMovimentoFinanceiro";
            btnNovoMovimentoFinanceiro.Size = new Size(50, 40);
            btnNovoMovimentoFinanceiro.TabIndex = 0;
            btnNovoMovimentoFinanceiro.UseVisualStyleBackColor = true;
            btnNovoMovimentoFinanceiro.Click += btnNovoMovimentoFinanceiro_Click;
            // 
            // btnDeletarMovimentoFinanceiro
            // 
            btnDeletarMovimentoFinanceiro.Cursor = Cursors.Hand;
            btnDeletarMovimentoFinanceiro.Image = Properties.Resources.Excluir2;
            btnDeletarMovimentoFinanceiro.Location = new Point(96, 11);
            btnDeletarMovimentoFinanceiro.Name = "btnDeletarMovimentoFinanceiro";
            btnDeletarMovimentoFinanceiro.Size = new Size(50, 40);
            btnDeletarMovimentoFinanceiro.TabIndex = 12;
            btnDeletarMovimentoFinanceiro.UseVisualStyleBackColor = true;
            btnDeletarMovimentoFinanceiro.Click += btnDeletarMovimentoFinanceiro_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            label13.ForeColor = Color.Gainsboro;
            label13.Location = new Point(162, 57);
            label13.Name = "label13";
            label13.Size = new Size(71, 12);
            label13.TabIndex = 25;
            label13.Text = "Contas Padrão";
            label13.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            label5.ForeColor = Color.Gainsboro;
            label5.Location = new Point(6, 51);
            label5.Name = "label5";
            label5.Size = new Size(74, 24);
            label5.TabIndex = 14;
            label5.Text = "Inserir\r\nRenda/Despesa";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnCriarContasPagarAuto
            // 
            btnCriarContasPagarAuto.Cursor = Cursors.Hand;
            btnCriarContasPagarAuto.Image = Properties.Resources.ContasPadrao;
            btnCriarContasPagarAuto.Location = new Point(169, 11);
            btnCriarContasPagarAuto.Name = "btnCriarContasPagarAuto";
            btnCriarContasPagarAuto.Size = new Size(50, 40);
            btnCriarContasPagarAuto.TabIndex = 24;
            btnCriarContasPagarAuto.UseVisualStyleBackColor = true;
            btnCriarContasPagarAuto.Click += btnCriarContasPagarAuto_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            label6.ForeColor = Color.Gainsboro;
            label6.Location = new Point(86, 51);
            label6.Name = "label6";
            label6.Size = new Size(74, 24);
            label6.TabIndex = 15;
            label6.Text = "Deletar \nRenda/Despesa";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            label7.ForeColor = Color.Gainsboro;
            label7.Location = new Point(129, 53);
            label7.Name = "label7";
            label7.Size = new Size(35, 12);
            label7.TabIndex = 16;
            label7.Text = "Buscar";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnBuscar
            // 
            btnBuscar.Cursor = Cursors.Hand;
            btnBuscar.Image = (Image)resources.GetObject("btnBuscar.Image");
            btnBuscar.Location = new Point(122, 10);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(50, 40);
            btnBuscar.TabIndex = 13;
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // lblTotalSaldo
            // 
            lblTotalSaldo.AutoSize = true;
            lblTotalSaldo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTotalSaldo.ForeColor = Color.White;
            lblTotalSaldo.Location = new Point(354, 33);
            lblTotalSaldo.Name = "lblTotalSaldo";
            lblTotalSaldo.Size = new Size(37, 15);
            lblTotalSaldo.TabIndex = 11;
            lblTotalSaldo.Text = "Saldo";
            lblTotalSaldo.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTotalDespesa
            // 
            lblTotalDespesa.AutoSize = true;
            lblTotalDespesa.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTotalDespesa.ForeColor = Color.White;
            lblTotalDespesa.Location = new Point(271, 33);
            lblTotalDespesa.Name = "lblTotalDespesa";
            lblTotalDespesa.Size = new Size(53, 15);
            lblTotalDespesa.TabIndex = 10;
            lblTotalDespesa.Text = "Despesa";
            lblTotalDespesa.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTotalRenda
            // 
            lblTotalRenda.AutoSize = true;
            lblTotalRenda.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTotalRenda.ForeColor = Color.White;
            lblTotalRenda.Location = new Point(188, 33);
            lblTotalRenda.Name = "lblTotalRenda";
            lblTotalRenda.Size = new Size(42, 15);
            lblTotalRenda.TabIndex = 9;
            lblTotalRenda.Text = "Renda";
            lblTotalRenda.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.ForeColor = Color.White;
            label4.Location = new Point(354, 10);
            label4.Name = "label4";
            label4.Size = new Size(37, 15);
            label4.TabIndex = 5;
            label4.Text = "Saldo";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(271, 10);
            label3.Name = "label3";
            label3.Size = new Size(53, 15);
            label3.TabIndex = 4;
            label3.Text = "Despesa";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(188, 10);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 3;
            label2.Text = "Renda";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dtpDataMovimentoFiltro
            // 
            dtpDataMovimentoFiltro.Location = new Point(12, 27);
            dtpDataMovimentoFiltro.Name = "dtpDataMovimentoFiltro";
            dtpDataMovimentoFiltro.Size = new Size(105, 23);
            dtpDataMovimentoFiltro.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 10);
            label1.Name = "label1";
            label1.Size = new Size(50, 15);
            label1.TabIndex = 1;
            label1.Text = "Período";
            // 
            // dgvMovimentoFinanceiro
            // 
            dgvMovimentoFinanceiro.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMovimentoFinanceiro.Dock = DockStyle.Fill;
            dgvMovimentoFinanceiro.Location = new Point(0, 105);
            dgvMovimentoFinanceiro.Name = "dgvMovimentoFinanceiro";
            dgvMovimentoFinanceiro.Size = new Size(1051, 345);
            dgvMovimentoFinanceiro.TabIndex = 12;
            dgvMovimentoFinanceiro.CellClick += dgvMovimentoFinanceiro_CellClick;
            dgvMovimentoFinanceiro.CellFormatting += dgvMovimentoFinanceiro_CellFormatting;
            dgvMovimentoFinanceiro.CellMouseDoubleClick += dgvMovimentoFinanceiro_CellMouseDoubleClick;
            dgvMovimentoFinanceiro.CellPainting += dgvMovimentoFinanceiro_CellPainting;
            // 
            // MovimentoFinanceiroView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1051, 450);
            Controls.Add(dgvMovimentoFinanceiro);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MovimentoFinanceiroView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gerenciador Financeiro - Versão 4.2";
            WindowState = FormWindowState.Maximized;
            Load += MovimentoFinanceiroView_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMovimentoFinanceiro).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label4;
        private Label label3;
        private Label label2;
        private DateTimePicker dtpDataMovimentoFiltro;
        private Label label1;
        private Button btnNovoMovimentoFinanceiro;
        private Button btnRelatorio;
        private Button btnCartao;
        private Button btnCategoria;
        private DataGridView dgvMovimentoFinanceiro;
        private Label lblTotalRenda;
        private Label lblTotalSaldo;
        private Label lblTotalDespesa;
        private Button btnDeletarMovimentoFinanceiro;
        private Button btnBuscar;
        private ToolTip toolTip1;
        private Label label5;
        private Label label6;
        private ToolTip toolTipDelete;
        private Label label7;
        private ToolTip toolTipBuscar;
        private Label label8;
        private ToolTip toolTipCategoria;
        private Label label9;
        private ToolTip toolTipCartao;
        private Label label10;
        private ToolTip toolTipRelatorio;
        private Label label12;
        private Button btnGerenciarContasPadrao;
        private Label label11;
        private Button btnFaturaEmAberto;
        private Label label13;
        private Button btnCriarContasPagarAuto;
        private ToolTip toolTipContasPadrao;
        private ToolTip toolTipGerenciarContasPadrao;
        private Panel panel2;
        private Panel panel3;
    }
}