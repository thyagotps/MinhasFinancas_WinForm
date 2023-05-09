namespace View
{
    partial class MovimentoView
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
            this.dgvMovimento = new System.Windows.Forms.DataGridView();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDataCompraFiltro = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cboFormaPagamentoFiltro = new System.Windows.Forms.ComboBox();
            this.cboCategoriaFiltro = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimento)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMovimento
            // 
            this.dgvMovimento.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMovimento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMovimento.Location = new System.Drawing.Point(12, 126);
            this.dgvMovimento.Name = "dgvMovimento";
            this.dgvMovimento.RowTemplate.Height = 25;
            this.dgvMovimento.Size = new System.Drawing.Size(994, 312);
            this.dgvMovimento.TabIndex = 11;
            this.dgvMovimento.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvMovimento_CellMouseClick);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Image = global::View.Properties.Resources.excluir;
            this.btnExcluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcluir.Location = new System.Drawing.Point(154, 11);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(65, 30);
            this.btnExcluir.TabIndex = 10;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Image = global::View.Properties.Resources.editar;
            this.btnEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditar.Location = new System.Drawing.Point(83, 11);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(65, 30);
            this.btnEditar.TabIndex = 9;
            this.btnEditar.Text = "Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.Image = global::View.Properties.Resources.novo;
            this.btnNovo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNovo.Location = new System.Drawing.Point(12, 11);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(65, 30);
            this.btnNovo.TabIndex = 8;
            this.btnNovo.Text = "Novo";
            this.btnNovo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(318, 47);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(65, 30);
            this.btnBuscar.TabIndex = 12;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 15);
            this.label1.TabIndex = 13;
            this.label1.Text = "Data Compra:";
            // 
            // dtpDataCompraFiltro
            // 
            this.dtpDataCompraFiltro.Location = new System.Drawing.Point(98, 49);
            this.dtpDataCompraFiltro.Name = "dtpDataCompraFiltro";
            this.dtpDataCompraFiltro.Size = new System.Drawing.Size(200, 23);
            this.dtpDataCompraFiltro.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(154, 72);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 15);
            this.label8.TabIndex = 21;
            this.label8.Text = "Pagamento";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 15);
            this.label7.TabIndex = 20;
            this.label7.Text = "Categoria";
            // 
            // cboFormaPagamentoFiltro
            // 
            this.cboFormaPagamentoFiltro.FormattingEnabled = true;
            this.cboFormaPagamentoFiltro.Location = new System.Drawing.Point(154, 90);
            this.cboFormaPagamentoFiltro.Name = "cboFormaPagamentoFiltro";
            this.cboFormaPagamentoFiltro.Size = new System.Drawing.Size(121, 23);
            this.cboFormaPagamentoFiltro.TabIndex = 19;
            // 
            // cboCategoriaFiltro
            // 
            this.cboCategoriaFiltro.FormattingEnabled = true;
            this.cboCategoriaFiltro.Location = new System.Drawing.Point(19, 90);
            this.cboCategoriaFiltro.Name = "cboCategoriaFiltro";
            this.cboCategoriaFiltro.Size = new System.Drawing.Size(121, 23);
            this.cboCategoriaFiltro.TabIndex = 18;
            // 
            // MovimentoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 450);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboFormaPagamentoFiltro);
            this.Controls.Add(this.cboCategoriaFiltro);
            this.Controls.Add(this.dtpDataCompraFiltro);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.dgvMovimento);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnNovo);
            this.Name = "MovimentoView";
            this.Text = "MovimentoView";
            this.Load += new System.EventHandler(this.MovimentoView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimento)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dgvMovimento;
        private Button btnExcluir;
        private Button btnEditar;
        private Button btnNovo;
        private Button btnBuscar;
        private Label label1;
        private DateTimePicker dtpDataCompraFiltro;
        private Label label2;
        private DateTimePicker dtpDataVencimentoFiltro;
        private Label label8;
        private Label label7;
        private ComboBox cboFormaPagamentoFiltro;
        private ComboBox cboCategoriaFiltro;
    }
}