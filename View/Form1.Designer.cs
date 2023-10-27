namespace View
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btnCategoria = new Button();
            btnCartao = new Button();
            btnSaida = new Button();
            panel1 = new Panel();
            btnEntrada = new Button();
            btnFaturaEmAberto = new Button();
            btnPagamento = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnCategoria
            // 
            btnCategoria.Cursor = Cursors.Hand;
            btnCategoria.Image = Properties.Resources.categoria1;
            btnCategoria.ImageAlign = ContentAlignment.MiddleLeft;
            btnCategoria.Location = new Point(9, 8);
            btnCategoria.Name = "btnCategoria";
            btnCategoria.Size = new Size(113, 34);
            btnCategoria.TabIndex = 0;
            btnCategoria.Text = "Categoria";
            btnCategoria.UseVisualStyleBackColor = true;
            btnCategoria.Click += btnCategoria_Click_1;
            // 
            // btnCartao
            // 
            btnCartao.Cursor = Cursors.Hand;
            btnCartao.Image = Properties.Resources.formaPagamento1;
            btnCartao.ImageAlign = ContentAlignment.MiddleLeft;
            btnCartao.Location = new Point(128, 8);
            btnCartao.Name = "btnCartao";
            btnCartao.Size = new Size(99, 34);
            btnCartao.TabIndex = 1;
            btnCartao.Text = "Cartão";
            btnCartao.UseVisualStyleBackColor = true;
            btnCartao.Click += btnCartao_Click;
            // 
            // btnSaida
            // 
            btnSaida.Cursor = Cursors.Hand;
            btnSaida.Image = Properties.Resources.movimento;
            btnSaida.ImageAlign = ContentAlignment.MiddleLeft;
            btnSaida.Location = new Point(334, 8);
            btnSaida.Name = "btnSaida";
            btnSaida.Size = new Size(119, 34);
            btnSaida.TabIndex = 2;
            btnSaida.Text = "Saída";
            btnSaida.UseVisualStyleBackColor = true;
            btnSaida.Click += btnSaida_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(43, 76, 126);
            panel1.Controls.Add(btnEntrada);
            panel1.Controls.Add(btnFaturaEmAberto);
            panel1.Controls.Add(btnPagamento);
            panel1.Controls.Add(btnCategoria);
            panel1.Controls.Add(btnSaida);
            panel1.Controls.Add(btnCartao);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(999, 50);
            panel1.TabIndex = 10;
            // 
            // btnEntrada
            // 
            btnEntrada.Cursor = Cursors.Hand;
            btnEntrada.Image = (Image)resources.GetObject("btnEntrada.Image");
            btnEntrada.ImageAlign = ContentAlignment.MiddleLeft;
            btnEntrada.Location = new Point(233, 8);
            btnEntrada.Name = "btnEntrada";
            btnEntrada.Size = new Size(95, 34);
            btnEntrada.TabIndex = 5;
            btnEntrada.Text = "Entrada";
            btnEntrada.UseVisualStyleBackColor = true;
            btnEntrada.Click += btnEntrada_Click;
            // 
            // btnFaturaEmAberto
            // 
            btnFaturaEmAberto.Cursor = Cursors.Hand;
            btnFaturaEmAberto.Image = (Image)resources.GetObject("btnFaturaEmAberto.Image");
            btnFaturaEmAberto.ImageAlign = ContentAlignment.MiddleLeft;
            btnFaturaEmAberto.Location = new Point(459, 8);
            btnFaturaEmAberto.Name = "btnFaturaEmAberto";
            btnFaturaEmAberto.Size = new Size(166, 34);
            btnFaturaEmAberto.TabIndex = 4;
            btnFaturaEmAberto.Text = "Fatura Em Aberto";
            btnFaturaEmAberto.UseVisualStyleBackColor = true;
            btnFaturaEmAberto.Click += btnFaturaEmAberto_Click;
            // 
            // btnPagamento
            // 
            btnPagamento.Cursor = Cursors.Hand;
            btnPagamento.Image = (Image)resources.GetObject("btnPagamento.Image");
            btnPagamento.ImageAlign = ContentAlignment.MiddleLeft;
            btnPagamento.Location = new Point(631, 8);
            btnPagamento.Name = "btnPagamento";
            btnPagamento.Size = new Size(166, 34);
            btnPagamento.TabIndex = 3;
            btnPagamento.Text = "Pagamento";
            btnPagamento.UseVisualStyleBackColor = true;
            btnPagamento.Click += btnPagamento_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(999, 450);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            IsMdiContainer = true;
            Name = "Form1";
            Text = "Minhas Finanças";
            WindowState = FormWindowState.Maximized;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }



        #endregion

        private Button btnCategoria;
        private Button btnCartao;
        private Button btnSaida;
        private Panel panel1;
        private Button btnPagamento;
        private Button btnFaturaEmAberto;
        private Button btnEntrada;
    }
}