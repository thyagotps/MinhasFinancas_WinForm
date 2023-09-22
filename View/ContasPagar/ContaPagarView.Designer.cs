namespace View.ContasPagar
{
    partial class ContaPagarView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContaPagarView));
            panel2 = new Panel();
            label1 = new Label();
            lblTotal = new Label();
            label4 = new Label();
            btnBuscar = new Button();
            dtpPeriodoFiltro = new DateTimePicker();
            dgvContaPagar = new DataGridView();
            panel1 = new Panel();
            btnCriarContasPagarAuto = new Button();
            btnNovo = new Button();
            btnEditar = new Button();
            btnExcluir = new Button();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvContaPagar).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(96, 109, 128);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(lblTotal);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(btnBuscar);
            panel2.Controls.Add(dtpPeriodoFiltro);
            panel2.Controls.Add(dgvContaPagar);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 40);
            panel2.Name = "panel2";
            panel2.Size = new Size(801, 494);
            panel2.TabIndex = 13;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(6, 10);
            label1.Name = "label1";
            label1.Size = new Size(40, 19);
            label1.TabIndex = 8;
            label1.Text = "Mês:";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lblTotal.ForeColor = Color.White;
            lblTotal.Location = new Point(333, 10);
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
            label4.Location = new Point(267, 10);
            label4.Name = "label4";
            label4.Size = new Size(46, 19);
            label4.TabIndex = 12;
            label4.Text = "Total:";
            // 
            // btnBuscar
            // 
            btnBuscar.Cursor = Cursors.Hand;
            btnBuscar.Image = (Image)resources.GetObject("btnBuscar.Image");
            btnBuscar.ImageAlign = ContentAlignment.MiddleLeft;
            btnBuscar.Location = new Point(188, 5);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(73, 29);
            btnBuscar.TabIndex = 11;
            btnBuscar.Text = "Buscar";
            btnBuscar.TextAlign = ContentAlignment.MiddleRight;
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // dtpPeriodoFiltro
            // 
            dtpPeriodoFiltro.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dtpPeriodoFiltro.Format = DateTimePickerFormat.Short;
            dtpPeriodoFiltro.Location = new Point(57, 7);
            dtpPeriodoFiltro.Name = "dtpPeriodoFiltro";
            dtpPeriodoFiltro.Size = new Size(125, 25);
            dtpPeriodoFiltro.TabIndex = 9;
            // 
            // dgvContaPagar
            // 
            dgvContaPagar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvContaPagar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvContaPagar.Location = new Point(12, 42);
            dgvContaPagar.Name = "dgvContaPagar";
            dgvContaPagar.RowTemplate.Height = 25;
            dgvContaPagar.Size = new Size(776, 440);
            dgvContaPagar.TabIndex = 7;
            dgvContaPagar.CellClick += dgvContaPagar_CellClick;
            dgvContaPagar.CellFormatting += dgvContaPagar_CellFormatting;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(43, 76, 126);
            panel1.Controls.Add(btnCriarContasPagarAuto);
            panel1.Controls.Add(btnNovo);
            panel1.Controls.Add(btnEditar);
            panel1.Controls.Add(btnExcluir);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(801, 40);
            panel1.TabIndex = 12;
            // 
            // btnCriarContasPagarAuto
            // 
            btnCriarContasPagarAuto.Cursor = Cursors.Hand;
            btnCriarContasPagarAuto.Image = (Image)resources.GetObject("btnCriarContasPagarAuto.Image");
            btnCriarContasPagarAuto.ImageAlign = ContentAlignment.MiddleLeft;
            btnCriarContasPagarAuto.Location = new Point(219, 3);
            btnCriarContasPagarAuto.Name = "btnCriarContasPagarAuto";
            btnCriarContasPagarAuto.Size = new Size(62, 30);
            btnCriarContasPagarAuto.TabIndex = 7;
            btnCriarContasPagarAuto.Text = "Auto";
            btnCriarContasPagarAuto.TextAlign = ContentAlignment.MiddleRight;
            btnCriarContasPagarAuto.UseVisualStyleBackColor = true;
            btnCriarContasPagarAuto.Click += btnCriarContasPagarAuto_Click;
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
            // btnEditar
            // 
            btnEditar.Cursor = Cursors.Hand;
            btnEditar.Image = Properties.Resources.editar;
            btnEditar.ImageAlign = ContentAlignment.MiddleLeft;
            btnEditar.Location = new Point(77, 4);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(65, 30);
            btnEditar.TabIndex = 5;
            btnEditar.Text = "Editar";
            btnEditar.TextAlign = ContentAlignment.MiddleRight;
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnExcluir
            // 
            btnExcluir.Cursor = Cursors.Hand;
            btnExcluir.Image = Properties.Resources.excluir;
            btnExcluir.ImageAlign = ContentAlignment.MiddleLeft;
            btnExcluir.Location = new Point(148, 4);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(65, 30);
            btnExcluir.TabIndex = 6;
            btnExcluir.Text = "Excluir";
            btnExcluir.TextAlign = ContentAlignment.MiddleRight;
            btnExcluir.UseVisualStyleBackColor = true;
            btnExcluir.Click += btnExcluir_Click;
            // 
            // ContaPagarView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(801, 534);
            Controls.Add(panel2);
            Controls.Add(panel1);
            MaximizeBox = false;
            Name = "ContaPagarView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Contas à Pagar";
            Load += ContaPagarView_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvContaPagar).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private DataGridView dgvContaPagar;
        private Panel panel1;
        private Button btnNovo;
        private Button btnEditar;
        private Button btnExcluir;
        private DateTimePicker dtpPeriodoFiltro;
        private Label label1;
        private Label lblTotal;
        private Label label4;
        private Button btnBuscar;
        private Button btnCriarContasPagarAuto;
    }
}