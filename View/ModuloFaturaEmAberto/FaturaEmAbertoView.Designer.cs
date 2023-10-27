namespace View.ModuloFaturaEmAberto
{
    partial class FaturaEmAbertoView
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
            lblTotal = new Label();
            label4 = new Label();
            dgvFaturaEmAberto = new DataGridView();
            panel1 = new Panel();
            btnNovo = new Button();
            btnExcluir = new Button();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFaturaEmAberto).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(96, 109, 128);
            panel2.Controls.Add(lblTotal);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(dgvFaturaEmAberto);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 40);
            panel2.Name = "panel2";
            panel2.Size = new Size(614, 410);
            panel2.TabIndex = 15;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblTotal.ForeColor = Color.White;
            lblTotal.Location = new Point(53, 6);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(26, 19);
            lblTotal.TabIndex = 13;
            lblTotal.Text = "R$";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.White;
            label4.Location = new Point(12, 6);
            label4.Name = "label4";
            label4.Size = new Size(46, 19);
            label4.TabIndex = 12;
            label4.Text = "Total:";
            // 
            // dgvFaturaEmAberto
            // 
            dgvFaturaEmAberto.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFaturaEmAberto.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFaturaEmAberto.Location = new Point(6, 31);
            dgvFaturaEmAberto.Name = "dgvFaturaEmAberto";
            dgvFaturaEmAberto.RowTemplate.Height = 25;
            dgvFaturaEmAberto.Size = new Size(595, 367);
            dgvFaturaEmAberto.TabIndex = 7;
            dgvFaturaEmAberto.CellMouseClick += dgvFaturaEmAberto_CellMouseClick_1;
            dgvFaturaEmAberto.CellMouseDoubleClick += dgvFaturaEmAberto_CellMouseDoubleClick;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(43, 76, 126);
            panel1.Controls.Add(btnNovo);
            panel1.Controls.Add(btnExcluir);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(614, 40);
            panel1.TabIndex = 14;
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
            // FaturaEmAbertoView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(614, 450);
            Controls.Add(panel2);
            Controls.Add(panel1);
            MaximizeBox = false;
            Name = "FaturaEmAbertoView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Fatura Em Aberto";
            Load += FaturaEmAbertoView_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFaturaEmAberto).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private Label lblTotal;
        private Label label4;
        private DataGridView dgvFaturaEmAberto;
        private Panel panel1;
        private Button btnNovo;
        private Button btnExcluir;
    }
}