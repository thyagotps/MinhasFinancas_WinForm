namespace View.ModuloRelatorios
{
    partial class RelatoriosView
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
            cboRelatorios = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            dtpPeriodoFiltro = new DateTimePicker();
            btnGerarRelatorio = new Button();
            dgvRelatorio = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvRelatorio).BeginInit();
            SuspendLayout();
            // 
            // cboRelatorios
            // 
            cboRelatorios.FormattingEnabled = true;
            cboRelatorios.Location = new Point(12, 27);
            cboRelatorios.Name = "cboRelatorios";
            cboRelatorios.Size = new Size(191, 23);
            cboRelatorios.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 1;
            label1.Text = "Relatórios:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(225, 9);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 2;
            label2.Text = "Período:";
            // 
            // dtpPeriodoFiltro
            // 
            dtpPeriodoFiltro.Location = new Point(225, 27);
            dtpPeriodoFiltro.Name = "dtpPeriodoFiltro";
            dtpPeriodoFiltro.Size = new Size(200, 23);
            dtpPeriodoFiltro.TabIndex = 3;
            // 
            // btnGerarRelatorio
            // 
            btnGerarRelatorio.Location = new Point(471, 29);
            btnGerarRelatorio.Name = "btnGerarRelatorio";
            btnGerarRelatorio.Size = new Size(130, 23);
            btnGerarRelatorio.TabIndex = 4;
            btnGerarRelatorio.Text = "Gerar Relatório";
            btnGerarRelatorio.UseVisualStyleBackColor = true;
            btnGerarRelatorio.Click += btnGerarRelatorio_Click;
            // 
            // dgvRelatorio
            // 
            dgvRelatorio.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRelatorio.Location = new Point(12, 56);
            dgvRelatorio.Name = "dgvRelatorio";
            dgvRelatorio.RowTemplate.Height = 25;
            dgvRelatorio.Size = new Size(968, 382);
            dgvRelatorio.TabIndex = 5;
            dgvRelatorio.CellFormatting += dgvRelatorio_CellFormatting;
            // 
            // RelatoriosView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(992, 450);
            Controls.Add(dgvRelatorio);
            Controls.Add(btnGerarRelatorio);
            Controls.Add(dtpPeriodoFiltro);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cboRelatorios);
            Name = "RelatoriosView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Relatorios";
            Load += RelatoriosView_Load;
            ((System.ComponentModel.ISupportInitialize)dgvRelatorio).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cboRelatorios;
        private Label label1;
        private Label label2;
        private DateTimePicker dtpPeriodoFiltro;
        private Button btnGerarRelatorio;
        private DataGridView dgvRelatorio;
    }
}