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
            btnMovimento = new Button();
            panel1 = new Panel();
            btnEntrada = new Button();
            btnFaturaEmAberto = new Button();
            btnContasPagar = new Button();
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
            // btnMovimento
            // 
            btnMovimento.Cursor = Cursors.Hand;
            btnMovimento.Image = Properties.Resources.movimento;
            btnMovimento.ImageAlign = ContentAlignment.MiddleLeft;
            btnMovimento.Location = new Point(477, 8);
            btnMovimento.Name = "btnMovimento";
            btnMovimento.Size = new Size(166, 34);
            btnMovimento.TabIndex = 2;
            btnMovimento.Text = "Movimento Analítico";
            btnMovimento.UseVisualStyleBackColor = true;
            btnMovimento.Click += btnMovimento_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(43, 76, 126);
            panel1.Controls.Add(btnEntrada);
            panel1.Controls.Add(btnFaturaEmAberto);
            panel1.Controls.Add(btnContasPagar);
            panel1.Controls.Add(btnCategoria);
            panel1.Controls.Add(btnMovimento);
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
            btnFaturaEmAberto.Location = new Point(821, 8);
            btnFaturaEmAberto.Name = "btnFaturaEmAberto";
            btnFaturaEmAberto.Size = new Size(166, 34);
            btnFaturaEmAberto.TabIndex = 4;
            btnFaturaEmAberto.Text = "Fatura Em Aberto";
            btnFaturaEmAberto.UseVisualStyleBackColor = true;
            btnFaturaEmAberto.Click += btnFaturaEmAberto_Click;
            // 
            // btnContasPagar
            // 
            btnContasPagar.Cursor = Cursors.Hand;
            btnContasPagar.Image = (Image)resources.GetObject("btnContasPagar.Image");
            btnContasPagar.ImageAlign = ContentAlignment.MiddleLeft;
            btnContasPagar.Location = new Point(649, 8);
            btnContasPagar.Name = "btnContasPagar";
            btnContasPagar.Size = new Size(166, 34);
            btnContasPagar.TabIndex = 3;
            btnContasPagar.Text = "Contas à Pagar";
            btnContasPagar.UseVisualStyleBackColor = true;
            btnContasPagar.Click += btnContasPagar_Click;
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
        private Button btnMovimento;
        private Panel panel1;
        private Button btnContasPagar;
        private Button btnFaturaEmAberto;
        private Button btnEntrada;
    }
}