namespace View.ModuloFaturaEmAberto
{
    partial class FaturaEmAbertoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FaturaEmAbertoForm));
            panel2 = new Panel();
            txtValor = new TextBox();
            label4 = new Label();
            txtDescricao = new TextBox();
            label3 = new Label();
            dtpDataCompra = new DateTimePicker();
            label1 = new Label();
            txtId = new TextBox();
            label2 = new Label();
            panel1 = new Panel();
            btnSalvar = new Button();
            lblErrorDataCompra = new Label();
            lblErrorDescricao = new Label();
            lblErrorValor = new Label();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(lblErrorValor);
            panel2.Controls.Add(lblErrorDescricao);
            panel2.Controls.Add(lblErrorDataCompra);
            panel2.Controls.Add(txtValor);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(txtDescricao);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(dtpDataCompra);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(txtId);
            panel2.Controls.Add(label2);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 40);
            panel2.Name = "panel2";
            panel2.Size = new Size(254, 217);
            panel2.TabIndex = 14;
            // 
            // txtValor
            // 
            txtValor.Location = new Point(13, 177);
            txtValor.Name = "txtValor";
            txtValor.Size = new Size(222, 23);
            txtValor.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 159);
            label4.Name = "label4";
            label4.Size = new Size(36, 15);
            label4.TabIndex = 7;
            label4.Text = "Valor:";
            // 
            // txtDescricao
            // 
            txtDescricao.Location = new Point(13, 128);
            txtDescricao.Name = "txtDescricao";
            txtDescricao.Size = new Size(222, 23);
            txtDescricao.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 110);
            label3.Name = "label3";
            label3.Size = new Size(61, 15);
            label3.TabIndex = 5;
            label3.Text = "Descrição:";
            // 
            // dtpDataCompra
            // 
            dtpDataCompra.Location = new Point(13, 77);
            dtpDataCompra.Name = "dtpDataCompra";
            dtpDataCompra.Size = new Size(222, 23);
            dtpDataCompra.TabIndex = 4;
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
            label2.Location = new Point(13, 59);
            label2.Name = "label2";
            label2.Size = new Size(53, 15);
            label2.TabIndex = 1;
            label2.Text = "Compra:";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(43, 76, 126);
            panel1.Controls.Add(btnSalvar);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(254, 40);
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
            // lblErrorDataCompra
            // 
            lblErrorDataCompra.AutoSize = true;
            lblErrorDataCompra.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblErrorDataCompra.ForeColor = Color.Red;
            lblErrorDataCompra.Location = new Point(72, 59);
            lblErrorDataCompra.Name = "lblErrorDataCompra";
            lblErrorDataCompra.Size = new Size(36, 15);
            lblErrorDataCompra.TabIndex = 21;
            lblErrorDataCompra.Text = "error";
            // 
            // lblErrorDescricao
            // 
            lblErrorDescricao.AutoSize = true;
            lblErrorDescricao.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblErrorDescricao.ForeColor = Color.Red;
            lblErrorDescricao.Location = new Point(80, 110);
            lblErrorDescricao.Name = "lblErrorDescricao";
            lblErrorDescricao.Size = new Size(36, 15);
            lblErrorDescricao.TabIndex = 22;
            lblErrorDescricao.Text = "error";
            // 
            // lblErrorValor
            // 
            lblErrorValor.AutoSize = true;
            lblErrorValor.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblErrorValor.ForeColor = Color.Red;
            lblErrorValor.Location = new Point(55, 159);
            lblErrorValor.Name = "lblErrorValor";
            lblErrorValor.Size = new Size(36, 15);
            lblErrorValor.TabIndex = 23;
            lblErrorValor.Text = "error";
            // 
            // FaturaEmAbertoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(254, 257);
            Controls.Add(panel2);
            Controls.Add(panel1);
            MaximizeBox = false;
            Name = "FaturaEmAbertoForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Formulário";
            Load += FaturaEmAbertoForm_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private Label label7;
        private TextBox txtOrdem;
        private ComboBox cboSituacao;
        private Label label5;
        private TextBox txtValor;
        private Label label4;
        private TextBox txtDescricao;
        private Label label3;
        private DateTimePicker dtpDataCompra;
        private Label label1;
        private TextBox txtId;
        private Label label2;
        private Panel panel1;
        private Button btnSalvar;
        private Label lblErrorValor;
        private Label lblErrorDescricao;
        private Label lblErrorDataCompra;
    }
}