namespace View.ModuloSalario
{
    partial class SalarioView
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
            dgvSalario = new DataGridView();
            panel2 = new Panel();
            panel1 = new Panel();
            btnNovo = new Button();
            btnExcluir = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvSalario).BeginInit();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvSalario
            // 
            dgvSalario.AllowUserToAddRows = false;
            dgvSalario.AllowUserToDeleteRows = false;
            dgvSalario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSalario.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSalario.Location = new Point(12, 12);
            dgvSalario.Name = "dgvSalario";
            dgvSalario.ReadOnly = true;
            dgvSalario.RowTemplate.Height = 25;
            dgvSalario.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSalario.Size = new Size(382, 386);
            dgvSalario.TabIndex = 0;
            dgvSalario.CellContentDoubleClick += dgvSalario_CellContentDoubleClick;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(96, 109, 128);
            panel2.Controls.Add(dgvSalario);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 40);
            panel2.Name = "panel2";
            panel2.Size = new Size(404, 410);
            panel2.TabIndex = 14;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(43, 76, 126);
            panel1.Controls.Add(btnNovo);
            panel1.Controls.Add(btnExcluir);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(404, 40);
            panel1.TabIndex = 13;
            // 
            // btnNovo
            // 
            btnNovo.Cursor = Cursors.Hand;
            btnNovo.Image = Properties.Resources.novo;
            btnNovo.ImageAlign = ContentAlignment.MiddleLeft;
            btnNovo.Location = new Point(12, 6);
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
            btnExcluir.Location = new Point(85, 6);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(67, 29);
            btnExcluir.TabIndex = 7;
            btnExcluir.Text = "Excluir";
            btnExcluir.TextAlign = ContentAlignment.MiddleRight;
            btnExcluir.UseVisualStyleBackColor = true;
            btnExcluir.Click += btnExcluir_Click;
            // 
            // SalarioView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(404, 450);
            Controls.Add(panel2);
            Controls.Add(panel1);
            MaximizeBox = false;
            Name = "SalarioView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Salário";
            Load += SalarioView_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSalario).EndInit();
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvSalario;
        private Panel panel2;
        private Panel panel1;
        private Button btnNovo;
        private Button btnExcluir;
    }
}