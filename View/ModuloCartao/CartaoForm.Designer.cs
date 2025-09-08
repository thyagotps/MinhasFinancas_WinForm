namespace View.ModuloCartao
{
    partial class CartaoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CartaoForm));
            panel2 = new Panel();
            lblErrorTipo = new Label();
            lblErrorDescricao = new Label();
            cboTipo = new ComboBox();
            label3 = new Label();
            label1 = new Label();
            txtId = new TextBox();
            label2 = new Label();
            txtDescricao = new TextBox();
            panel1 = new Panel();
            btnSalvar = new Button();
            txtValorSaldo = new TextBox();
            label4 = new Label();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(txtValorSaldo);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(lblErrorTipo);
            panel2.Controls.Add(lblErrorDescricao);
            panel2.Controls.Add(cboTipo);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(txtId);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(txtDescricao);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 40);
            panel2.Name = "panel2";
            panel2.Size = new Size(271, 235);
            panel2.TabIndex = 11;
            // 
            // lblErrorTipo
            // 
            lblErrorTipo.AutoSize = true;
            lblErrorTipo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblErrorTipo.ForeColor = Color.Red;
            lblErrorTipo.Location = new Point(51, 115);
            lblErrorTipo.Name = "lblErrorTipo";
            lblErrorTipo.Size = new Size(36, 15);
            lblErrorTipo.TabIndex = 22;
            lblErrorTipo.Text = "error";
            // 
            // lblErrorDescricao
            // 
            lblErrorDescricao.AutoSize = true;
            lblErrorDescricao.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblErrorDescricao.ForeColor = Color.Red;
            lblErrorDescricao.Location = new Point(79, 62);
            lblErrorDescricao.Name = "lblErrorDescricao";
            lblErrorDescricao.Size = new Size(36, 15);
            lblErrorDescricao.TabIndex = 21;
            lblErrorDescricao.Text = "error";
            // 
            // cboTipo
            // 
            cboTipo.FormattingEnabled = true;
            cboTipo.Location = new Point(12, 133);
            cboTipo.Name = "cboTipo";
            cboTipo.Size = new Size(244, 23);
            cboTipo.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 115);
            label3.Name = "label3";
            label3.Size = new Size(34, 15);
            label3.TabIndex = 6;
            label3.Text = "Tipo:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(49, 15);
            label1.TabIndex = 0;
            label1.Text = "Código:";
            // 
            // txtId
            // 
            txtId.Enabled = false;
            txtId.Location = new Point(12, 27);
            txtId.Name = "txtId";
            txtId.Size = new Size(244, 23);
            txtId.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 62);
            label2.Name = "label2";
            label2.Size = new Size(61, 15);
            label2.TabIndex = 1;
            label2.Text = "Descrição:";
            // 
            // txtDescricao
            // 
            txtDescricao.Location = new Point(12, 80);
            txtDescricao.Name = "txtDescricao";
            txtDescricao.Size = new Size(244, 23);
            txtDescricao.TabIndex = 5;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(43, 76, 126);
            panel1.Controls.Add(btnSalvar);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(271, 40);
            panel1.TabIndex = 10;
            // 
            // btnSalvar
            // 
            btnSalvar.Cursor = Cursors.Hand;
            btnSalvar.Font = new Font("Segoe UI", 9F);
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
            // txtValorSaldo
            // 
            txtValorSaldo.Location = new Point(12, 190);
            txtValorSaldo.Name = "txtValorSaldo";
            txtValorSaldo.Size = new Size(244, 23);
            txtValorSaldo.TabIndex = 24;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 172);
            label4.Name = "label4";
            label4.Size = new Size(68, 15);
            label4.TabIndex = 23;
            label4.Text = "Valor Saldo:";
            // 
            // CartaoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(271, 275);
            Controls.Add(panel2);
            Controls.Add(panel1);
            MaximizeBox = false;
            Name = "CartaoForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Formulário";
            Load += CartaoForm_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private Label label1;
        private TextBox txtId;
        private Label label2;
        private TextBox txtDescricao;
        private Panel panel1;
        private Button btnSalvar;
        private ComboBox cboTipo;
        private Label label3;
        private Label lblErrorTipo;
        private Label lblErrorDescricao;
        private TextBox txtValorSaldo;
        private Label label4;
    }
}