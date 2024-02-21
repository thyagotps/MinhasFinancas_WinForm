namespace View.ModuloMovimentoFinanceiro
{
    partial class MovimentoFinanceiroForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MovimentoFinanceiroForm));
            panel2 = new Panel();
            lblErrorCartao = new Label();
            lblErrorCategoria = new Label();
            lblErrorValor = new Label();
            lblErrorDescricao = new Label();
            lblErrorDataMovimento = new Label();
            lblErrorTipoMovimento = new Label();
            cboTipoMovimento = new ComboBox();
            label7 = new Label();
            cboCartao = new ComboBox();
            label6 = new Label();
            cboCategoria = new ComboBox();
            label5 = new Label();
            txtValor = new TextBox();
            label4 = new Label();
            txtDescricao = new TextBox();
            label3 = new Label();
            dtpDataMovimento = new DateTimePicker();
            label1 = new Label();
            txtId = new TextBox();
            label2 = new Label();
            panel1 = new Panel();
            btnSalvar = new Button();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(lblErrorCartao);
            panel2.Controls.Add(lblErrorCategoria);
            panel2.Controls.Add(lblErrorValor);
            panel2.Controls.Add(lblErrorDescricao);
            panel2.Controls.Add(lblErrorDataMovimento);
            panel2.Controls.Add(lblErrorTipoMovimento);
            panel2.Controls.Add(cboTipoMovimento);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(cboCartao);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(cboCategoria);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(txtValor);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(txtDescricao);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(dtpDataMovimento);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(txtId);
            panel2.Controls.Add(label2);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 40);
            panel2.Name = "panel2";
            panel2.Size = new Size(255, 362);
            panel2.TabIndex = 14;
            // 
            // lblErrorCartao
            // 
            lblErrorCartao.AutoSize = true;
            lblErrorCartao.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblErrorCartao.ForeColor = Color.Red;
            lblErrorCartao.Location = new Point(64, 305);
            lblErrorCartao.Name = "lblErrorCartao";
            lblErrorCartao.Size = new Size(36, 15);
            lblErrorCartao.TabIndex = 24;
            lblErrorCartao.Text = "error";
            // 
            // lblErrorCategoria
            // 
            lblErrorCategoria.AutoSize = true;
            lblErrorCategoria.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblErrorCategoria.ForeColor = Color.Red;
            lblErrorCategoria.Location = new Point(80, 256);
            lblErrorCategoria.Name = "lblErrorCategoria";
            lblErrorCategoria.Size = new Size(36, 15);
            lblErrorCategoria.TabIndex = 23;
            lblErrorCategoria.Text = "error";
            // 
            // lblErrorValor
            // 
            lblErrorValor.AutoSize = true;
            lblErrorValor.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblErrorValor.ForeColor = Color.Red;
            lblErrorValor.Location = new Point(55, 206);
            lblErrorValor.Name = "lblErrorValor";
            lblErrorValor.Size = new Size(36, 15);
            lblErrorValor.TabIndex = 22;
            lblErrorValor.Text = "error";
            // 
            // lblErrorDescricao
            // 
            lblErrorDescricao.AutoSize = true;
            lblErrorDescricao.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblErrorDescricao.ForeColor = Color.Red;
            lblErrorDescricao.Location = new Point(80, 157);
            lblErrorDescricao.Name = "lblErrorDescricao";
            lblErrorDescricao.Size = new Size(36, 15);
            lblErrorDescricao.TabIndex = 21;
            lblErrorDescricao.Text = "error";
            // 
            // lblErrorDataMovimento
            // 
            lblErrorDataMovimento.AutoSize = true;
            lblErrorDataMovimento.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblErrorDataMovimento.ForeColor = Color.Red;
            lblErrorDataMovimento.Location = new Point(117, 108);
            lblErrorDataMovimento.Name = "lblErrorDataMovimento";
            lblErrorDataMovimento.Size = new Size(36, 15);
            lblErrorDataMovimento.TabIndex = 20;
            lblErrorDataMovimento.Text = "error";
            // 
            // lblErrorTipoMovimento
            // 
            lblErrorTipoMovimento.AutoSize = true;
            lblErrorTipoMovimento.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblErrorTipoMovimento.ForeColor = Color.Red;
            lblErrorTipoMovimento.Location = new Point(117, 62);
            lblErrorTipoMovimento.Name = "lblErrorTipoMovimento";
            lblErrorTipoMovimento.Size = new Size(36, 15);
            lblErrorTipoMovimento.TabIndex = 19;
            lblErrorTipoMovimento.Text = "error";
            // 
            // cboTipoMovimento
            // 
            cboTipoMovimento.FormattingEnabled = true;
            cboTipoMovimento.Location = new Point(13, 80);
            cboTipoMovimento.Name = "cboTipoMovimento";
            cboTipoMovimento.Size = new Size(222, 23);
            cboTipoMovimento.TabIndex = 14;
            cboTipoMovimento.SelectedIndexChanged += cboTipoMovimento_SelectedIndexChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(13, 62);
            label7.Name = "label7";
            label7.Size = new Size(98, 15);
            label7.TabIndex = 13;
            label7.Text = "Tipo Movimento:";
            // 
            // cboCartao
            // 
            cboCartao.FormattingEnabled = true;
            cboCartao.Location = new Point(13, 323);
            cboCartao.Name = "cboCartao";
            cboCartao.Size = new Size(222, 23);
            cboCartao.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(13, 305);
            label6.Name = "label6";
            label6.Size = new Size(45, 15);
            label6.TabIndex = 11;
            label6.Text = "Cartão:";
            // 
            // cboCategoria
            // 
            cboCategoria.FormattingEnabled = true;
            cboCategoria.Location = new Point(13, 274);
            cboCategoria.Name = "cboCategoria";
            cboCategoria.Size = new Size(222, 23);
            cboCategoria.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(13, 256);
            label5.Name = "label5";
            label5.Size = new Size(61, 15);
            label5.TabIndex = 9;
            label5.Text = "Categoria:";
            // 
            // txtValor
            // 
            txtValor.Location = new Point(13, 224);
            txtValor.Name = "txtValor";
            txtValor.Size = new Size(222, 23);
            txtValor.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 206);
            label4.Name = "label4";
            label4.Size = new Size(36, 15);
            label4.TabIndex = 7;
            label4.Text = "Valor:";
            // 
            // txtDescricao
            // 
            txtDescricao.Location = new Point(13, 175);
            txtDescricao.Name = "txtDescricao";
            txtDescricao.Size = new Size(222, 23);
            txtDescricao.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 157);
            label3.Name = "label3";
            label3.Size = new Size(61, 15);
            label3.TabIndex = 5;
            label3.Text = "Descrição:";
            // 
            // dtpDataMovimento
            // 
            dtpDataMovimento.Location = new Point(13, 126);
            dtpDataMovimento.Name = "dtpDataMovimento";
            dtpDataMovimento.Size = new Size(222, 23);
            dtpDataMovimento.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 9);
            label1.Name = "label1";
            label1.Size = new Size(49, 15);
            label1.TabIndex = 0;
            label1.Text = "Código:";
            // 
            // txtId
            // 
            txtId.Enabled = false;
            txtId.Location = new Point(13, 27);
            txtId.Name = "txtId";
            txtId.Size = new Size(222, 23);
            txtId.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 108);
            label2.Name = "label2";
            label2.Size = new Size(99, 15);
            label2.TabIndex = 1;
            label2.Text = "Data Movimento:";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(43, 76, 126);
            panel1.Controls.Add(btnSalvar);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(255, 40);
            panel1.TabIndex = 13;
            // 
            // btnSalvar
            // 
            btnSalvar.Cursor = Cursors.Hand;
            btnSalvar.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnSalvar.Image = (Image)resources.GetObject("btnSalvar.Image");
            btnSalvar.ImageAlign = ContentAlignment.MiddleLeft;
            btnSalvar.Location = new Point(6, 7);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(64, 27);
            btnSalvar.TabIndex = 2;
            btnSalvar.Text = "Salvar";
            btnSalvar.TextAlign = ContentAlignment.MiddleRight;
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // MovimentoFinanceiroForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(255, 402);
            Controls.Add(panel2);
            Controls.Add(panel1);
            MaximizeBox = false;
            Name = "MovimentoFinanceiroForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Formulário";
            Load += MovimentoFinanceiroForm_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private ComboBox cboTipoMovimento;
        private Label label7;
        private ComboBox cboCartao;
        private Label label6;
        private ComboBox cboCategoria;
        private Label label5;
        private TextBox txtValor;
        private Label label4;
        private TextBox txtDescricao;
        private Label label3;
        private DateTimePicker dtpDataMovimento;
        private Label label1;
        private TextBox txtId;
        private Label label2;
        private Panel panel1;
        private Button btnSalvar;
        private Label lblErrorTipoMovimento;
        private Label lblErrorDataMovimento;
        private Label lblErrorDescricao;
        private Label lblErrorValor;
        private Label lblErrorCategoria;
        private Label lblErrorCartao;
    }
}