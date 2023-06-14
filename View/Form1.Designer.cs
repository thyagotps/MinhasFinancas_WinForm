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
            btnCategoria = new Button();
            btnPagamento = new Button();
            btnMovimento = new Button();
            SuspendLayout();
            // 
            // btnCategoria
            // 
            btnCategoria.Location = new Point(12, 12);
            btnCategoria.Name = "btnCategoria";
            btnCategoria.Size = new Size(75, 23);
            btnCategoria.TabIndex = 0;
            btnCategoria.Text = "Categoria";
            btnCategoria.UseVisualStyleBackColor = true;
            btnCategoria.Click += btnCategoria_Click_1;
            // 
            // btnPagamento
            // 
            btnPagamento.Location = new Point(93, 12);
            btnPagamento.Name = "btnPagamento";
            btnPagamento.Size = new Size(109, 23);
            btnPagamento.TabIndex = 1;
            btnPagamento.Text = "Pagamentos";
            btnPagamento.UseVisualStyleBackColor = true;
            btnPagamento.Click += btnPagamento_Click;
            // 
            // btnMovimento
            // 
            btnMovimento.Location = new Point(208, 12);
            btnMovimento.Name = "btnMovimento";
            btnMovimento.Size = new Size(168, 23);
            btnMovimento.TabIndex = 2;
            btnMovimento.Text = "Movimento Analítico";
            btnMovimento.UseVisualStyleBackColor = true;
            btnMovimento.Click += btnMovimento_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnMovimento);
            Controls.Add(btnPagamento);
            Controls.Add(btnCategoria);
            Name = "Form1";
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            ResumeLayout(false);
        }



        #endregion

        private Button btnCategoria;
        private Button btnPagamento;
        private Button btnMovimento;
    }
}