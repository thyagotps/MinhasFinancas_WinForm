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
            btnRelatorios = new Button();
            btnEntrada = new Button();
            btnFaturaEmAberto = new Button();
            btnPagamento = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnCategoria
            // 
            btnCategoria.Cursor = Cursors.Hand;
            btnCategoria.ImageAlign = ContentAlignment.MiddleLeft;
            btnCategoria.Location = new Point(9, 8);
            btnCategoria.Name = "btnCategoria";
            btnCategoria.Size = new Size(120, 30);
            btnCategoria.TabIndex = 0;
            btnCategoria.Text = "Categoria";
            btnCategoria.UseVisualStyleBackColor = true;
            btnCategoria.Click += btnCategoria_Click_1;
            // 
            // btnCartao
            // 
            btnCartao.Cursor = Cursors.Hand;
            btnCartao.ImageAlign = ContentAlignment.MiddleLeft;
            btnCartao.Location = new Point(135, 8);
            btnCartao.Name = "btnCartao";
            btnCartao.Size = new Size(120, 30);
            btnCartao.TabIndex = 1;
            btnCartao.Text = "Cartão";
            btnCartao.UseVisualStyleBackColor = true;
            btnCartao.Click += btnCartao_Click;
            // 
            // btnSaida
            // 
            btnSaida.Cursor = Cursors.Hand;
            btnSaida.ImageAlign = ContentAlignment.MiddleLeft;
            btnSaida.Location = new Point(387, 8);
            btnSaida.Name = "btnSaida";
            btnSaida.Size = new Size(120, 30);
            btnSaida.TabIndex = 2;
            btnSaida.Text = "Saída";
            btnSaida.UseVisualStyleBackColor = true;
            btnSaida.Click += btnSaida_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(43, 76, 126);
            panel1.Controls.Add(btnRelatorios);
            panel1.Controls.Add(btnEntrada);
            panel1.Controls.Add(btnFaturaEmAberto);
            panel1.Controls.Add(btnPagamento);
            panel1.Controls.Add(btnCategoria);
            panel1.Controls.Add(btnSaida);
            panel1.Controls.Add(btnCartao);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(901, 50);
            panel1.TabIndex = 10;
            // 
            // btnRelatorios
            // 
            btnRelatorios.Cursor = Cursors.Hand;
            btnRelatorios.ImageAlign = ContentAlignment.MiddleLeft;
            btnRelatorios.Location = new Point(765, 8);
            btnRelatorios.Name = "btnRelatorios";
            btnRelatorios.Size = new Size(120, 30);
            btnRelatorios.TabIndex = 6;
            btnRelatorios.Text = "Relatórios";
            btnRelatorios.UseVisualStyleBackColor = true;
            btnRelatorios.Click += btnRelatorios_Click;
            // 
            // btnEntrada
            // 
            btnEntrada.Cursor = Cursors.Hand;
            btnEntrada.ImageAlign = ContentAlignment.MiddleLeft;
            btnEntrada.Location = new Point(261, 8);
            btnEntrada.Name = "btnEntrada";
            btnEntrada.Size = new Size(120, 30);
            btnEntrada.TabIndex = 5;
            btnEntrada.Text = "Entrada";
            btnEntrada.UseVisualStyleBackColor = true;
            btnEntrada.Click += btnEntrada_Click;
            // 
            // btnFaturaEmAberto
            // 
            btnFaturaEmAberto.Cursor = Cursors.Hand;
            btnFaturaEmAberto.ImageAlign = ContentAlignment.MiddleLeft;
            btnFaturaEmAberto.Location = new Point(513, 8);
            btnFaturaEmAberto.Name = "btnFaturaEmAberto";
            btnFaturaEmAberto.Size = new Size(120, 30);
            btnFaturaEmAberto.TabIndex = 4;
            btnFaturaEmAberto.Text = "Fatura Em Aberto";
            btnFaturaEmAberto.UseVisualStyleBackColor = true;
            btnFaturaEmAberto.Click += btnFaturaEmAberto_Click;
            // 
            // btnPagamento
            // 
            btnPagamento.Cursor = Cursors.Hand;
            btnPagamento.ImageAlign = ContentAlignment.MiddleLeft;
            btnPagamento.Location = new Point(639, 8);
            btnPagamento.Name = "btnPagamento";
            btnPagamento.Size = new Size(120, 30);
            btnPagamento.TabIndex = 3;
            btnPagamento.Text = "Pagamento";
            btnPagamento.UseVisualStyleBackColor = true;
            btnPagamento.Click += btnPagamento_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(901, 525);
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
        private Button btnRelatorios;
    }
}