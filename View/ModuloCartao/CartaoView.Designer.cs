namespace View.ModuloCartao
{
    partial class CartaoView
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
            panel2 = new Panel();
            dgvCartao = new DataGridView();
            panel1 = new Panel();
            btnNovo = new Button();
            btnExcluir = new Button();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCartao).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(96, 109, 128);
            panel2.Controls.Add(dgvCartao);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 40);
            panel2.Name = "panel2";
            panel2.Size = new Size(379, 388);
            panel2.TabIndex = 13;
            // 
            // dgvCartao
            // 
            dgvCartao.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCartao.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCartao.Location = new Point(3, 6);
            dgvCartao.Name = "dgvCartao";
            dgvCartao.RowTemplate.Height = 25;
            dgvCartao.Size = new Size(373, 379);
            dgvCartao.TabIndex = 7;
            dgvCartao.CellClick += dgvCartao_CellClick;
            dgvCartao.CellMouseDoubleClick += dgvCartao_CellMouseDoubleClick;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(43, 76, 126);
            panel1.Controls.Add(btnNovo);
            panel1.Controls.Add(btnExcluir);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(379, 40);
            panel1.TabIndex = 12;
            // 
            // btnNovo
            // 
            btnNovo.Cursor = Cursors.Hand;
            btnNovo.Image = Properties.Resources.novo;
            btnNovo.ImageAlign = ContentAlignment.MiddleLeft;
            btnNovo.Location = new Point(6, 4);
            btnNovo.Name = "btnNovo";
            btnNovo.Size = new Size(65, 30);
            btnNovo.TabIndex = 4;
            btnNovo.Text = "Novo";
            btnNovo.TextAlign = ContentAlignment.MiddleRight;
            btnNovo.UseVisualStyleBackColor = true;
            btnNovo.Click += btnNovo_Click;
            // 
            // btnExcluir
            // 
            btnExcluir.Cursor = Cursors.Hand;
            btnExcluir.Image = Properties.Resources.excluir;
            btnExcluir.ImageAlign = ContentAlignment.MiddleLeft;
            btnExcluir.Location = new Point(77, 4);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(65, 30);
            btnExcluir.TabIndex = 6;
            btnExcluir.Text = "Excluir";
            btnExcluir.TextAlign = ContentAlignment.MiddleRight;
            btnExcluir.UseVisualStyleBackColor = true;
            btnExcluir.Click += btnExcluir_Click;
            // 
            // CartaoView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(379, 428);
            Controls.Add(panel2);
            Controls.Add(panel1);
            MaximizeBox = false;
            Name = "CartaoView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cartão";
            Load += CartaoView_Load;
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCartao).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private DataGridView dgvCartao;
        private Panel panel1;
        private Button btnNovo;
        private Button btnExcluir;
    }
}