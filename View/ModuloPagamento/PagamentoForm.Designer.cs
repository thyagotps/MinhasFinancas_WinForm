namespace View.ModuloPagamento
{
    partial class PagamentoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PagamentoForm));
            panel2 = new Panel();
            lblErrorSituacao = new Label();
            lblErrorValor = new Label();
            lblErrorDescricao = new Label();
            lblErrorDataVencimento = new Label();
            lblErrorIdentificador = new Label();
            label7 = new Label();
            txtNrIdentificador = new TextBox();
            cboSituacao = new ComboBox();
            label5 = new Label();
            txtValor = new TextBox();
            label4 = new Label();
            txtDescricao = new TextBox();
            label3 = new Label();
            dtpDataVencimento = new DateTimePicker();
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
            panel2.Controls.Add(lblErrorSituacao);
            panel2.Controls.Add(lblErrorValor);
            panel2.Controls.Add(lblErrorDescricao);
            panel2.Controls.Add(lblErrorDataVencimento);
            panel2.Controls.Add(lblErrorIdentificador);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(txtNrIdentificador);
            panel2.Controls.Add(cboSituacao);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(txtValor);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(txtDescricao);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(dtpDataVencimento);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(txtId);
            panel2.Controls.Add(label2);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 40);
            panel2.Name = "panel2";
            panel2.Size = new Size(305, 311);
            panel2.TabIndex = 12;
            // 
            // lblErrorSituacao
            // 
            lblErrorSituacao.AutoSize = true;
            lblErrorSituacao.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblErrorSituacao.ForeColor = Color.Red;
            lblErrorSituacao.Location = new Point(74, 253);
            lblErrorSituacao.Name = "lblErrorSituacao";
            lblErrorSituacao.Size = new Size(36, 15);
            lblErrorSituacao.TabIndex = 26;
            lblErrorSituacao.Text = "error";
            // 
            // lblErrorValor
            // 
            lblErrorValor.AutoSize = true;
            lblErrorValor.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblErrorValor.ForeColor = Color.Red;
            lblErrorValor.Location = new Point(50, 203);
            lblErrorValor.Name = "lblErrorValor";
            lblErrorValor.Size = new Size(36, 15);
            lblErrorValor.TabIndex = 25;
            lblErrorValor.Text = "error";
            // 
            // lblErrorDescricao
            // 
            lblErrorDescricao.AutoSize = true;
            lblErrorDescricao.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblErrorDescricao.ForeColor = Color.Red;
            lblErrorDescricao.Location = new Point(80, 154);
            lblErrorDescricao.Name = "lblErrorDescricao";
            lblErrorDescricao.Size = new Size(36, 15);
            lblErrorDescricao.TabIndex = 24;
            lblErrorDescricao.Text = "error";
            // 
            // lblErrorDataVencimento
            // 
            lblErrorDataVencimento.AutoSize = true;
            lblErrorDataVencimento.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblErrorDataVencimento.ForeColor = Color.Red;
            lblErrorDataVencimento.Location = new Point(92, 105);
            lblErrorDataVencimento.Name = "lblErrorDataVencimento";
            lblErrorDataVencimento.Size = new Size(36, 15);
            lblErrorDataVencimento.TabIndex = 23;
            lblErrorDataVencimento.Text = "error";
            // 
            // lblErrorIdentificador
            // 
            lblErrorIdentificador.AutoSize = true;
            lblErrorIdentificador.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblErrorIdentificador.ForeColor = Color.Red;
            lblErrorIdentificador.Location = new Point(96, 58);
            lblErrorIdentificador.Name = "lblErrorIdentificador";
            lblErrorIdentificador.Size = new Size(36, 15);
            lblErrorIdentificador.TabIndex = 22;
            lblErrorIdentificador.Text = "error";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(13, 58);
            label7.Name = "label7";
            label7.Size = new Size(77, 15);
            label7.TabIndex = 13;
            label7.Text = "Identificador:";
            // 
            // txtNrIdentificador
            // 
            txtNrIdentificador.Location = new Point(13, 76);
            txtNrIdentificador.Name = "txtNrIdentificador";
            txtNrIdentificador.Size = new Size(280, 23);
            txtNrIdentificador.TabIndex = 14;
            // 
            // cboSituacao
            // 
            cboSituacao.FormattingEnabled = true;
            cboSituacao.Location = new Point(13, 271);
            cboSituacao.Name = "cboSituacao";
            cboSituacao.Size = new Size(280, 23);
            cboSituacao.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(13, 253);
            label5.Name = "label5";
            label5.Size = new Size(55, 15);
            label5.TabIndex = 9;
            label5.Text = "Situação:";
            // 
            // txtValor
            // 
            txtValor.Location = new Point(13, 221);
            txtValor.Name = "txtValor";
            txtValor.Size = new Size(280, 23);
            txtValor.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 203);
            label4.Name = "label4";
            label4.Size = new Size(36, 15);
            label4.TabIndex = 7;
            label4.Text = "Valor:";
            // 
            // txtDescricao
            // 
            txtDescricao.Location = new Point(13, 172);
            txtDescricao.Name = "txtDescricao";
            txtDescricao.Size = new Size(280, 23);
            txtDescricao.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 154);
            label3.Name = "label3";
            label3.Size = new Size(61, 15);
            label3.TabIndex = 5;
            label3.Text = "Descrição:";
            // 
            // dtpDataVencimento
            // 
            dtpDataVencimento.Location = new Point(13, 123);
            dtpDataVencimento.Name = "dtpDataVencimento";
            dtpDataVencimento.Size = new Size(280, 23);
            dtpDataVencimento.TabIndex = 4;
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
            txtId.Size = new Size(280, 23);
            txtId.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 105);
            label2.Name = "label2";
            label2.Size = new Size(73, 15);
            label2.TabIndex = 1;
            label2.Text = "Vencimento:";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(43, 76, 126);
            panel1.Controls.Add(btnSalvar);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(305, 40);
            panel1.TabIndex = 11;
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
            // PagamentoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(305, 351);
            Controls.Add(panel2);
            Controls.Add(panel1);
            MaximizeBox = false;
            Name = "PagamentoForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Formulário";
            Load += ContaPagarForm_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private ComboBox cboSituacao;
        private Label label5;
        private TextBox txtValor;
        private Label label4;
        private TextBox txtDescricao;
        private Label label3;
        private DateTimePicker dtpDataVencimento;
        private Label label1;
        private TextBox txtId;
        private Label label2;
        private Panel panel1;
        private Button btnSalvar;
        private Label label7;
        private TextBox txtNrIdentificador;
        private Label lblErrorSituacao;
        private Label lblErrorValor;
        private Label lblErrorDescricao;
        private Label lblErrorDataVencimento;
        private Label lblErrorIdentificador;
    }
}