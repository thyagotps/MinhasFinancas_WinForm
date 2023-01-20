using Ado;
using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design.Behavior;

namespace View
{
    public partial class CategoriaView : Form
    {
        private int _codigo { get; set; }
        private readonly ICategoriaController _categoriaController;

        public CategoriaView(ICategoriaController categoriaController)
        {
            InitializeComponent();
            _categoriaController = categoriaController;
        }

        #region Eventos da view

        /// <summary>
        /// Ação load do formulário
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CategoriaView_Load(object sender, EventArgs e)
        {
            Buscar();
        }

        /// <summary>
        /// Ação novo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNovo_Click(object sender, EventArgs e)
        {
            Novo();
        }

        /// <summary>
        /// Evento editar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditar_Click(object sender, EventArgs e)
        {
            Editar();
        }

        /// <summary>
        /// Evento excluir
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Excluir();
        }

        /// <summary>
        /// Evento cell click do datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            _codigo = Convert.ToInt32(rowData.Cells[0].Value.ToString());
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Busca todos os registros
        /// </summary>
        private void Buscar()
        {
            var source = _categoriaController.GetAll();
            dgvCategoria.ReadOnly = true;
            dgvCategoria.DataSource = source;
        }

        /// <summary>
        /// Exibe view para inserção de novo registro
        /// </summary>
        private void Novo()
        {
            CategoriaForm form = new CategoriaForm(_categoriaController);
            form.Codigo = -1;
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
                Buscar();
        }

        /// <summary>
        /// Exibe view para edição de registro
        /// </summary>
        private void Editar()
        {
            CategoriaForm form = new CategoriaForm(_categoriaController);
            form.Codigo = _codigo;
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
                Buscar();
        }

        /// <summary>
        /// Excluir registro
        /// </summary>
        private void Excluir()
        {
            var result = MessageBox.Show("Deseja realmente excluir o registro de código: " + _codigo.ToString() + "?","Atenção",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                _categoriaController.Delete(_codigo);
            Buscar();
        }

        #endregion

      
    }
}
