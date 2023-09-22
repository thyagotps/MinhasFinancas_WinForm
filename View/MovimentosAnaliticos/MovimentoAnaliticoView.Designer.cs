namespace View.MovimentosAnaliticos
{
    partial class MovimentoAnaliticoView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MovimentoAnaliticoView));
            panel1 = new Panel();
            btnNovo = new Button();
            btnExcluir = new Button();
            btnEditar = new Button();
            panel2 = new Panel();
            lblTotal = new Label();
            label4 = new Label();
            btnLimparFiltro = new Button();
            btnBuscar = new Button();
            cboFormaPagamento = new ComboBox();
            cboCategoriaFiltro = new ComboBox();
            dtpDataCompraFiltro = new DateTimePicker();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            dgvMovimentoAnalitico = new DataGridView();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMovimentoAnalitico).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(43, 76, 126);
            panel1.Controls.Add(btnNovo);
            panel1.Controls.Add(btnExcluir);
            panel1.Controls.Add(btnEditar);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(877, 40);
            panel1.TabIndex = 11;
            // 
            // btnNovo
            // 
            btnNovo.Cursor = Cursors.Hand;
            btnNovo.Image = Properties.Resources.novo;
            btnNovo.ImageAlign = ContentAlignment.MiddleLeft;
            btnNovo.Location = new Point(3, 5);
            btnNovo.Name = "btnNovo";
            btnNovo.Size = new Size(67, 28);
            btnNovo.TabIndex = 5;
            btnNovo.Text = "Novo";
            btnNovo.TextAlign = ContentAlignment.MiddleRight;
            btnNovo.UseVisualStyleBackColor = true;
            btnNovo.Click += btnNovo_Click;
            // 
            // btnExcluir
            // 
            btnExcluir.Cursor = Cursors.Hand;
            btnExcluir.Image = Properties.Resources.excluir;
            btnExcluir.ImageAlign = ContentAlignment.MiddleLeft;
            btnExcluir.Location = new Point(149, 5);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(67, 29);
            btnExcluir.TabIndex = 7;
            btnExcluir.Text = "Excluir";
            btnExcluir.TextAlign = ContentAlignment.MiddleRight;
            btnExcluir.UseVisualStyleBackColor = true;
            btnExcluir.Click += btnExcluir_Click;
            // 
            // btnEditar
            // 
            btnEditar.Cursor = Cursors.Hand;
            btnEditar.Image = Properties.Resources.editar;
            btnEditar.ImageAlign = ContentAlignment.MiddleLeft;
            btnEditar.Location = new Point(76, 5);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(67, 29);
            btnEditar.TabIndex = 6;
            btnEditar.Text = "Editar";
            btnEditar.TextAlign = ContentAlignment.MiddleRight;
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(96, 109, 128);
            panel2.Controls.Add(lblTotal);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(btnLimparFiltro);
            panel2.Controls.Add(btnBuscar);
            panel2.Controls.Add(cboFormaPagamento);
            panel2.Controls.Add(cboCategoriaFiltro);
            panel2.Controls.Add(dtpDataCompraFiltro);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(dgvMovimentoAnalitico);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 40);
            panel2.Name = "panel2";
            panel2.Size = new Size(877, 473);
            panel2.TabIndex = 12;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblTotal.ForeColor = Color.White;
            lblTotal.Location = new Point(711, 13);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(29, 21);
            lblTotal.TabIndex = 10;
            lblTotal.Text = "R$";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.White;
            label4.Location = new Point(664, 13);
            label4.Name = "label4";
            label4.Size = new Size(52, 21);
            label4.TabIndex = 9;
            label4.Text = "Total:";
            // 
            // btnLimparFiltro
            // 
            btnLimparFiltro.Image = Properties.Resources.borracha;
            btnLimparFiltro.Location = new Point(541, 49);
            btnLimparFiltro.Name = "btnLimparFiltro";
            btnLimparFiltro.Size = new Size(91, 38);
            btnLimparFiltro.TabIndex = 8;
            btnLimparFiltro.TextAlign = ContentAlignment.MiddleRight;
            btnLimparFiltro.UseVisualStyleBackColor = true;
            btnLimparFiltro.Click += btnLimparFiltro_Click;
            // 
            // btnBuscar
            // 
            btnBuscar.Cursor = Cursors.Hand;
            btnBuscar.Image = (Image)resources.GetObject("btnBuscar.Image");
            btnBuscar.ImageAlign = ContentAlignment.MiddleLeft;
            btnBuscar.Location = new Point(541, 4);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(91, 39);
            btnBuscar.TabIndex = 7;
            btnBuscar.Text = "Buscar";
            btnBuscar.TextAlign = ContentAlignment.MiddleRight;
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // cboFormaPagamento
            // 
            cboFormaPagamento.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFormaPagamento.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cboFormaPagamento.FormattingEnabled = true;
            cboFormaPagamento.Location = new Point(176, 65);
            cboFormaPagamento.Name = "cboFormaPagamento";
            cboFormaPagamento.Size = new Size(336, 25);
            cboFormaPagamento.TabIndex = 6;
            // 
            // cboCategoriaFiltro
            // 
            cboCategoriaFiltro.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategoriaFiltro.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cboCategoriaFiltro.FormattingEnabled = true;
            cboCategoriaFiltro.Location = new Point(176, 33);
            cboCategoriaFiltro.Name = "cboCategoriaFiltro";
            cboCategoriaFiltro.Size = new Size(336, 25);
            cboCategoriaFiltro.TabIndex = 5;
            // 
            // dtpDataCompraFiltro
            // 
            dtpDataCompraFiltro.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dtpDataCompraFiltro.Format = DateTimePickerFormat.Short;
            dtpDataCompraFiltro.Location = new Point(176, 2);
            dtpDataCompraFiltro.Name = "dtpDataCompraFiltro";
            dtpDataCompraFiltro.Size = new Size(176, 25);
            dtpDataCompraFiltro.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(10, 68);
            label3.Name = "label3";
            label3.Size = new Size(158, 19);
            label3.TabIndex = 3;
            label3.Text = "Forma de Pagamento:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(89, 36);
            label2.Name = "label2";
            label2.Size = new Size(79, 19);
            label2.TabIndex = 2;
            label2.Text = "Categoria:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(66, 5);
            label1.Name = "label1";
            label1.Size = new Size(102, 19);
            label1.TabIndex = 1;
            label1.Text = "Data Compra:";
            // 
            // dgvMovimentoAnalitico
            // 
            dgvMovimentoAnalitico.AllowUserToAddRows = false;
            dgvMovimentoAnalitico.AllowUserToDeleteRows = false;
            dgvMovimentoAnalitico.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMovimentoAnalitico.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMovimentoAnalitico.Dock = DockStyle.Bottom;
            dgvMovimentoAnalitico.Location = new Point(0, 96);
            dgvMovimentoAnalitico.Name = "dgvMovimentoAnalitico";
            dgvMovimentoAnalitico.ReadOnly = true;
            dgvMovimentoAnalitico.RowTemplate.Height = 25;
            dgvMovimentoAnalitico.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMovimentoAnalitico.Size = new Size(877, 377);
            dgvMovimentoAnalitico.TabIndex = 0;
            dgvMovimentoAnalitico.CellClick += dgvMovimentoAnalitico_CellClick;
            // 
            // MovimentoAnaliticoView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(877, 513);
            Controls.Add(panel2);
            Controls.Add(panel1);
            MaximizeBox = false;
            Name = "MovimentoAnaliticoView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Movimentação Analítica";
            Load += MovimentoAnaliticoView_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMovimentoAnalitico).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnNovo;
        private Button btnExcluir;
        private Button btnEditar;
        private Panel panel2;
        private DataGridView dgvMovimentoAnalitico;
        private DateTimePicker dtpDataCompraFiltro;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnBuscar;
        private ComboBox cboFormaPagamento;
        private ComboBox cboCategoriaFiltro;
        private Button btnLimparFiltro;
        private Label label4;
        private Label lblTotal;
    }
}