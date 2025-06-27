namespace View.ModuloContaPadrao
{
    partial class ContaPadraoView
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
            dgvContaPadrao = new DataGridView();
            panel1 = new Panel();
            btnNovo = new Button();
            btnExcluir = new Button();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvContaPadrao).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(96, 109, 128);
            panel2.Controls.Add(dgvContaPadrao);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 40);
            panel2.Name = "panel2";
            panel2.Size = new Size(800, 410);
            panel2.TabIndex = 13;
            // 
            // dgvContaPadrao
            // 
            dgvContaPadrao.AllowUserToAddRows = false;
            dgvContaPadrao.AllowUserToDeleteRows = false;
            dgvContaPadrao.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvContaPadrao.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvContaPadrao.Location = new Point(12, 6);
            dgvContaPadrao.Name = "dgvContaPadrao";
            dgvContaPadrao.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvContaPadrao.Size = new Size(776, 392);
            dgvContaPadrao.TabIndex = 0;
            dgvContaPadrao.CellClick += dgvContaPadrao_CellClick;
            dgvContaPadrao.CellMouseDoubleClick += dgvContaPadrao_CellMouseDoubleClick;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(43, 76, 126);
            panel1.Controls.Add(btnNovo);
            panel1.Controls.Add(btnExcluir);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 40);
            panel1.TabIndex = 12;
            // 
            // btnNovo
            // 
            btnNovo.Cursor = Cursors.Hand;
            btnNovo.Image = Properties.Resources.novo;
            btnNovo.ImageAlign = ContentAlignment.MiddleLeft;
            btnNovo.Location = new Point(3, 5);
            btnNovo.Name = "btnNovo";
            btnNovo.Size = new Size(67, 28);
            btnNovo.TabIndex = 5;
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
            btnExcluir.Location = new Point(76, 4);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(67, 29);
            btnExcluir.TabIndex = 7;
            btnExcluir.Text = "Excluir";
            btnExcluir.TextAlign = ContentAlignment.MiddleRight;
            btnExcluir.UseVisualStyleBackColor = true;
            btnExcluir.Click += btnExcluir_Click;
            // 
            // ContaPadraoView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel2);
            Controls.Add(panel1);
            MaximizeBox = false;
            Name = "ContaPadraoView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Contas Padrão";
            Load += ContaPadraoView_Load;
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvContaPadrao).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private DataGridView dgvContaPadrao;
        private Panel panel1;
        private Button btnNovo;
        private Button btnExcluir;
    }
}