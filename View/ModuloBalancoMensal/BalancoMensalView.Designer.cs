namespace View.ModuloBalancoMensal
{
    partial class BalancoMensalView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BalancoMensalView));
            cboCartao = new ComboBox();
            label6 = new Label();
            dtpPeriodo = new DateTimePicker();
            label1 = new Label();
            btnBuscar = new Button();
            lbl_cartao = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txt_renda = new TextBox();
            txt_despesa = new TextBox();
            txt_saldo = new TextBox();
            listView_categorias_renda = new ListView();
            label2 = new Label();
            label7 = new Label();
            listView_categorias_despesa = new ListView();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // cboCartao
            // 
            cboCartao.FormattingEnabled = true;
            cboCartao.Location = new Point(19, 30);
            cboCartao.Name = "cboCartao";
            cboCartao.Size = new Size(120, 23);
            cboCartao.TabIndex = 14;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label6.ForeColor = Color.White;
            label6.Location = new Point(19, 12);
            label6.Name = "label6";
            label6.Size = new Size(46, 15);
            label6.TabIndex = 13;
            label6.Text = "Cartão:";
            // 
            // dtpPeriodo
            // 
            dtpPeriodo.Location = new Point(149, 29);
            dtpPeriodo.Name = "dtpPeriodo";
            dtpPeriodo.Size = new Size(105, 23);
            dtpPeriodo.TabIndex = 16;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(149, 12);
            label1.Name = "label1";
            label1.Size = new Size(50, 15);
            label1.TabIndex = 15;
            label1.Text = "Período";
            // 
            // btnBuscar
            // 
            btnBuscar.Cursor = Cursors.Hand;
            btnBuscar.Image = (Image)resources.GetObject("btnBuscar.Image");
            btnBuscar.Location = new Point(260, 20);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(50, 40);
            btnBuscar.TabIndex = 17;
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // lbl_cartao
            // 
            lbl_cartao.AutoSize = true;
            lbl_cartao.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lbl_cartao.Location = new Point(82, 106);
            lbl_cartao.Name = "lbl_cartao";
            lbl_cartao.Size = new Size(72, 25);
            lbl_cartao.TabIndex = 18;
            lbl_cartao.Text = "Cartão";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label3.ForeColor = Color.Green;
            label3.Location = new Point(27, 145);
            label3.Name = "label3";
            label3.Size = new Size(62, 21);
            label3.TabIndex = 19;
            label3.Text = "Renda:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label4.ForeColor = Color.Red;
            label4.Location = new Point(12, 174);
            label4.Name = "label4";
            label4.Size = new Size(77, 21);
            label4.TabIndex = 20;
            label4.Text = "Despesa:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(82, 199);
            label5.Name = "label5";
            label5.Size = new Size(127, 13);
            label5.TabIndex = 21;
            label5.Text = "________________________";
            label5.TextAlign = ContentAlignment.TopCenter;
            // 
            // txt_renda
            // 
            txt_renda.Enabled = false;
            txt_renda.Location = new Point(92, 144);
            txt_renda.Name = "txt_renda";
            txt_renda.Size = new Size(100, 23);
            txt_renda.TabIndex = 25;
            txt_renda.TextAlign = HorizontalAlignment.Right;
            // 
            // txt_despesa
            // 
            txt_despesa.Enabled = false;
            txt_despesa.Location = new Point(92, 173);
            txt_despesa.Name = "txt_despesa";
            txt_despesa.Size = new Size(100, 23);
            txt_despesa.TabIndex = 26;
            txt_despesa.TextAlign = HorizontalAlignment.Right;
            // 
            // txt_saldo
            // 
            txt_saldo.Enabled = false;
            txt_saldo.Location = new Point(92, 215);
            txt_saldo.Name = "txt_saldo";
            txt_saldo.Size = new Size(100, 23);
            txt_saldo.TabIndex = 27;
            txt_saldo.TextAlign = HorizontalAlignment.Right;
            // 
            // listView_categorias_renda
            // 
            listView_categorias_renda.Location = new Point(276, 144);
            listView_categorias_renda.Name = "listView_categorias_renda";
            listView_categorias_renda.Size = new Size(270, 218);
            listView_categorias_renda.TabIndex = 28;
            listView_categorias_renda.UseCompatibleStateImageBehavior = false;
            listView_categorias_renda.View = System.Windows.Forms.View.Details;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label2.Location = new Point(310, 106);
            label2.Name = "label2";
            label2.Size = new Size(195, 25);
            label2.TabIndex = 29;
            label2.Text = "Renda Por Categoria";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label7.Location = new Point(597, 106);
            label7.Name = "label7";
            label7.Size = new Size(211, 25);
            label7.TabIndex = 31;
            label7.Text = "Despesa Por Categoria";
            // 
            // listView_categorias_despesa
            // 
            listView_categorias_despesa.Location = new Point(574, 144);
            listView_categorias_despesa.Name = "listView_categorias_despesa";
            listView_categorias_despesa.Size = new Size(270, 218);
            listView_categorias_despesa.TabIndex = 30;
            listView_categorias_despesa.UseCompatibleStateImageBehavior = false;
            listView_categorias_despesa.View = System.Windows.Forms.View.Details;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(43, 76, 126);
            panel1.Controls.Add(cboCartao);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(dtpPeriodo);
            panel1.Controls.Add(btnBuscar);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(876, 80);
            panel1.TabIndex = 32;
            // 
            // BalancoMensalView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(876, 374);
            Controls.Add(panel1);
            Controls.Add(label7);
            Controls.Add(listView_categorias_despesa);
            Controls.Add(label2);
            Controls.Add(listView_categorias_renda);
            Controls.Add(txt_saldo);
            Controls.Add(txt_despesa);
            Controls.Add(txt_renda);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(lbl_cartao);
            Name = "BalancoMensalView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Balanço Mensal";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cboCartao;
        private Label label6;
        private DateTimePicker dtpPeriodo;
        private Label label1;
        private Button btnBuscar;
        private Label lbl_cartao;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txt_renda;
        private TextBox txt_despesa;
        private TextBox txt_saldo;
        private ListView listView_categorias_renda;
        private Label label2;
        private Label label7;
        private ListView listView_categorias_despesa;
        private Panel panel1;
    }
}