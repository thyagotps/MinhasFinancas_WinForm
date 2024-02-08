namespace View.ModuloEntrada
{
    partial class EntradaView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EntradaView));
            panel2 = new Panel();
            panel3 = new Panel();
            lblTotal = new Label();
            label4 = new Label();
            btnBuscar = new Button();
            dtpDataFiltro = new DateTimePicker();
            label1 = new Label();
            dgvEntrada = new DataGridView();
            panel1 = new Panel();
            btnNovo = new Button();
            btnExcluir = new Button();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEntrada).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(96, 109, 128);
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(dgvEntrada);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 40);
            panel2.Name = "panel2";
            panel2.Size = new Size(854, 410);
            panel2.TabIndex = 16;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(96, 109, 128);
            panel3.Controls.Add(lblTotal);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(btnBuscar);
            panel3.Controls.Add(dtpDataFiltro);
            panel3.Controls.Add(label1);
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(854, 50);
            panel3.TabIndex = 15;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblTotal.ForeColor = Color.White;
            lblTotal.Location = new Point(403, 11);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(29, 21);
            lblTotal.TabIndex = 10;
            lblTotal.Text = "R$";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.White;
            label4.Location = new Point(354, 11);
            label4.Name = "label4";
            label4.Size = new Size(52, 21);
            label4.TabIndex = 9;
            label4.Text = "Total:";
            // 
            // btnBuscar
            // 
            btnBuscar.Cursor = Cursors.Hand;
            btnBuscar.Image = (Image)resources.GetObject("btnBuscar.Image");
            btnBuscar.ImageAlign = ContentAlignment.MiddleLeft;
            btnBuscar.Location = new Point(257, 4);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(91, 39);
            btnBuscar.TabIndex = 7;
            btnBuscar.Text = "Buscar";
            btnBuscar.TextAlign = ContentAlignment.MiddleRight;
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // dtpDataFiltro
            // 
            dtpDataFiltro.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dtpDataFiltro.Format = DateTimePickerFormat.Short;
            dtpDataFiltro.Location = new Point(53, 10);
            dtpDataFiltro.Name = "dtpDataFiltro";
            dtpDataFiltro.Size = new Size(176, 25);
            dtpDataFiltro.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 14);
            label1.Name = "label1";
            label1.Size = new Size(44, 19);
            label1.TabIndex = 1;
            label1.Text = "Data:";
            // 
            // dgvEntrada
            // 
            dgvEntrada.AllowUserToAddRows = false;
            dgvEntrada.AllowUserToDeleteRows = false;
            dgvEntrada.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEntrada.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEntrada.Location = new Point(3, 56);
            dgvEntrada.Name = "dgvEntrada";
            dgvEntrada.ReadOnly = true;
            dgvEntrada.RowTemplate.Height = 25;
            dgvEntrada.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEntrada.Size = new Size(848, 351);
            dgvEntrada.TabIndex = 0;
            dgvEntrada.CellClick += dgvEntrada_CellClick;
            dgvEntrada.CellMouseDoubleClick += dgvEntrada_CellMouseDoubleClick;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(43, 76, 126);
            panel1.Controls.Add(btnNovo);
            panel1.Controls.Add(btnExcluir);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(854, 40);
            panel1.TabIndex = 15;
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
            // EntradaView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(854, 450);
            Controls.Add(panel2);
            Controls.Add(panel1);
            MaximizeBox = false;
            Name = "EntradaView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Entradas";
            Load += EntradaView_Load;
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEntrada).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private DataGridView dgvEntrada;
        private Panel panel1;
        private Button btnNovo;
        private Button btnExcluir;
        private Panel panel3;
        private Label lblTotal;
        private Label label4;
        private Button btnBuscar;
        private DateTimePicker dtpDataFiltro;
        private Label label1;
    }
}