namespace View.ModuloCategoria
{
    partial class CategoriaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CategoriaForm));
            panel2 = new Panel();
            cbo_Tipo = new ComboBox();
            label3 = new Label();
            label1 = new Label();
            txtId = new TextBox();
            label2 = new Label();
            txtDescricao = new TextBox();
            panel1 = new Panel();
            btnSalvar = new Button();
            lblErrorDescricao = new Label();
            lblErrorTipo = new Label();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(lblErrorTipo);
            panel2.Controls.Add(lblErrorDescricao);
            panel2.Controls.Add(cbo_Tipo);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(txtId);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(txtDescricao);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 40);
            panel2.Name = "panel2";
            panel2.Size = new Size(231, 165);
            panel2.TabIndex = 9;
            // 
            // cbo_Tipo
            // 
            cbo_Tipo.FormattingEnabled = true;
            cbo_Tipo.Items.AddRange(new object[] { "Despesa", "Renda" });
            cbo_Tipo.Location = new Point(6, 122);
            cbo_Tipo.Name = "cbo_Tipo";
            cbo_Tipo.Size = new Size(216, 23);
            cbo_Tipo.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 104);
            label3.Name = "label3";
            label3.Size = new Size(33, 15);
            label3.TabIndex = 6;
            label3.Text = "Tipo:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 6);
            label1.Name = "label1";
            label1.Size = new Size(49, 15);
            label1.TabIndex = 0;
            label1.Text = "Código:";
            // 
            // txtId
            // 
            txtId.Enabled = false;
            txtId.Location = new Point(6, 24);
            txtId.Name = "txtId";
            txtId.Size = new Size(216, 23);
            txtId.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 55);
            label2.Name = "label2";
            label2.Size = new Size(61, 15);
            label2.TabIndex = 1;
            label2.Text = "Descrição:";
            // 
            // txtDescricao
            // 
            txtDescricao.Location = new Point(6, 73);
            txtDescricao.Name = "txtDescricao";
            txtDescricao.Size = new Size(216, 23);
            txtDescricao.TabIndex = 5;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(43, 76, 126);
            panel1.Controls.Add(btnSalvar);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(231, 40);
            panel1.TabIndex = 8;
            // 
            // btnSalvar
            // 
            btnSalvar.Cursor = Cursors.Hand;
            btnSalvar.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnSalvar.Image = (Image)resources.GetObject("btnSalvar.Image");
            btnSalvar.ImageAlign = ContentAlignment.MiddleLeft;
            btnSalvar.Location = new Point(6, 7);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(64, 27);
            btnSalvar.TabIndex = 2;
            btnSalvar.Text = "Salvar";
            btnSalvar.TextAlign = ContentAlignment.MiddleRight;
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // lblErrorDescricao
            // 
            lblErrorDescricao.AutoSize = true;
            lblErrorDescricao.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblErrorDescricao.ForeColor = Color.Red;
            lblErrorDescricao.Location = new Point(73, 55);
            lblErrorDescricao.Name = "lblErrorDescricao";
            lblErrorDescricao.Size = new Size(36, 15);
            lblErrorDescricao.TabIndex = 20;
            lblErrorDescricao.Text = "error";
            // 
            // lblErrorTipo
            // 
            lblErrorTipo.AutoSize = true;
            lblErrorTipo.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblErrorTipo.ForeColor = Color.Red;
            lblErrorTipo.Location = new Point(45, 104);
            lblErrorTipo.Name = "lblErrorTipo";
            lblErrorTipo.Size = new Size(36, 15);
            lblErrorTipo.TabIndex = 21;
            lblErrorTipo.Text = "error";
            // 
            // CategoriaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(231, 205);
            Controls.Add(panel2);
            Controls.Add(panel1);
            MaximizeBox = false;
            Name = "CategoriaForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Formulário";
            Load += CategoriaForm_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private Label label1;
        private TextBox txtId;
        private Label label2;
        private TextBox txtDescricao;
        private Panel panel1;
        private Button btnSalvar;
        private ComboBox cbo_Tipo;
        private Label label3;
        private Label lblErrorTipo;
        private Label lblErrorDescricao;
    }
}