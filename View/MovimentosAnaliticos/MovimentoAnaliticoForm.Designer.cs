namespace View.MovimentosAnaliticos
{
    partial class MovimentoAnaliticoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MovimentoAnaliticoForm));
            panel1 = new Panel();
            btnSalvar = new Button();
            panel2 = new Panel();
            cboFormaPagamento = new ComboBox();
            label6 = new Label();
            cboCategoria = new ComboBox();
            label5 = new Label();
            txtValor = new TextBox();
            label4 = new Label();
            txtDescricao = new TextBox();
            label3 = new Label();
            dtpDataCompra = new DateTimePicker();
            label1 = new Label();
            txtId = new TextBox();
            label2 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(43, 76, 126);
            panel1.Controls.Add(btnSalvar);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(247, 40);
            panel1.TabIndex = 9;
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
            // panel2
            // 
            panel2.Controls.Add(cboFormaPagamento);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(cboCategoria);
            panel2.Controls.Add(label5);
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
            panel2.Size = new Size(247, 314);
            panel2.TabIndex = 10;
            // 
            // cboFormaPagamento
            // 
            cboFormaPagamento.FormattingEnabled = true;
            cboFormaPagamento.Location = new Point(13, 273);
            cboFormaPagamento.Name = "cboFormaPagamento";
            cboFormaPagamento.Size = new Size(222, 23);
            cboFormaPagamento.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(13, 255);
            label6.Name = "label6";
            label6.Size = new Size(108, 15);
            label6.TabIndex = 11;
            label6.Text = "Forma Pagamento:";
            // 
            // cboCategoria
            // 
            cboCategoria.FormattingEnabled = true;
            cboCategoria.Location = new Point(13, 224);
            cboCategoria.Name = "cboCategoria";
            cboCategoria.Size = new Size(222, 23);
            cboCategoria.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(13, 206);
            label5.Name = "label5";
            label5.Size = new Size(61, 15);
            label5.TabIndex = 9;
            label5.Text = "Categoria:";
            // 
            // txtValor
            // 
            txtValor.Location = new Point(13, 174);
            txtValor.Name = "txtValor";
            txtValor.Size = new Size(222, 23);
            txtValor.TabIndex = 8;
            txtValor.KeyPress += txtValor_KeyPress;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 156);
            label4.Name = "label4";
            label4.Size = new Size(36, 15);
            label4.TabIndex = 7;
            label4.Text = "Valor:";
            // 
            // txtDescricao
            // 
            txtDescricao.Location = new Point(13, 125);
            txtDescricao.Name = "txtDescricao";
            txtDescricao.Size = new Size(222, 23);
            txtDescricao.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 107);
            label3.Name = "label3";
            label3.Size = new Size(61, 15);
            label3.TabIndex = 5;
            label3.Text = "Descrição:";
            // 
            // dtpDataCompra
            // 
            dtpDataCompra.Location = new Point(13, 76);
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
            label2.Location = new Point(13, 58);
            label2.Name = "label2";
            label2.Size = new Size(80, 15);
            label2.TabIndex = 1;
            label2.Text = "Data Compra:";
            // 
            // MovimentoAnaliticoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(247, 354);
            Controls.Add(panel2);
            Controls.Add(panel1);
            MaximizeBox = false;
            Name = "MovimentoAnaliticoForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Formulário";
            Load += MovimentoAnaliticoForm_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnSalvar;
        private Panel panel2;
        private Label label1;
        private TextBox txtId;
        private Label label2;
        private Label label4;
        private TextBox txtDescricao;
        private Label label3;
        private DateTimePicker dtpDataCompra;
        private ComboBox cboFormaPagamento;
        private Label label6;
        private ComboBox cboCategoria;
        private Label label5;
        private TextBox txtValor;
    }
}