using Base.Ninject;
using Controller.Categorias;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View.Categorias
{
    public partial class CategoriaView : BaseView
    {
        private int _id { get; set; }
        private readonly ICategoriaController _categoriaController;

        public CategoriaView(ICategoriaController categoriaController)
        {
            InitializeComponent();
            _categoriaController = categoriaController;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        private void CategoriaView_Load(object sender, EventArgs e)
        {
            Buscar();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            Novo();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Editar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Excluir();
        }

        private void dgvCategoria_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Retorna o indice da linha no qual a célula foi clicada
            var _linhaIndice = e.RowIndex;

            //Se _linhaIndice é menor que -1 então retorna
            if (_linhaIndice == -1)
                return;

            //Cria um objeto DataGridViewRow de um indice particular
            DataGridViewRow rowData = dgvCategoria.Rows[_linhaIndice];

            //obtém valor
            _id = Convert.ToInt32(rowData.Cells[0].Value.ToString());
        }

        private void Buscar()
        {
            var source = _categoriaController.GetAll();
            dgvCategoria.ReadOnly = true;
            dgvCategoria.DataSource = source;
            dgvCategoria.Columns["Id"].Width = 50;
            dgvCategoria.Columns["Descricao"].HeaderText = "Descrição";
            dgvCategoria.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvCategoria.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dgvCategoria.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

            dgvCategoria.RowsDefaultCellStyle.SelectionBackColor = Color.NavajoWhite;
            dgvCategoria.RowsDefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void Novo()
        {
            //CategoriaForm form = new CategoriaForm(_categoriaController);
            var form = NinjectKernel.Resolve<CategoriaForm>();
            form.Id = -1;
            form.ShowDialog();
            Buscar();
        }

        private void Editar()
        {
            //CategoriaForm form = new CategoriaForm(_categoriaController);
            var form = NinjectKernel.Resolve<CategoriaForm>();
            form.Id = _id;
            form.ShowDialog();
            Buscar();
        }

        private void Excluir()
        {
            var result = base.MessageDelete(_id);
            if (result == DialogResult.Yes)
                _categoriaController.Delete(_id);
            Buscar();
        }
    }
}
