using Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    public partial class CategoriaForm : Form
    {

        public int Codigo { get; set; }
        private readonly ICategoriaController _categoriaController;

        public CategoriaForm(ICategoriaController categoriaController)
        {
            InitializeComponent();
            _categoriaController = categoriaController;

           
        }

        /// <summary>
        /// Botão salvar categoria
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (Codigo == -1)
                Novo();
            else
            {
                
                Editar();
            }
        }

        private void Novo()
        {
            var categoriaDto = PopularCategoriaDto();
            var result = _categoriaController.Insert(categoriaDto);
            Message(result);
        }

        private void Editar()
        {

            var categoriaDto = PopularCategoriaDto();
            var result = _categoriaController.Update(categoriaDto);
            Message(result);
        }

        private CategoriaDto PopularCategoriaDto()
        {
            CategoriaDto categoriaDto = new CategoriaDto();
            categoriaDto.Codigo = Codigo;
            categoriaDto.Descricao = txtDescricao.Text;
            categoriaDto.Sinal = cboSinal.Text;
            return categoriaDto;
        }

        private void PopularComponentesFormulario(CategoriaDto categoriaDto)
        {
            txtCodigo.Text = categoriaDto.Codigo.ToString();
            txtDescricao.Text = categoriaDto.Descricao;
            cboSinal.Text = categoriaDto.Sinal;
        }

        private CategoriaDto GetCategoriaById(int id)
        {
            return _categoriaController.GetCategoriaById(id);
        }

        private void Message(bool result)
        {
            if (result)
            {
                MessageBox.Show("Sucesso", "Info", MessageBoxButtons.OK);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
                MessageBox.Show("Erro", "Info", MessageBoxButtons.OK);
        }

        private void CategoriaForm_Load(object sender, EventArgs e)
        {
            if (Codigo != -1)
            {
                var categoriaDto = GetCategoriaById(Codigo);
                PopularComponentesFormulario(categoriaDto);
            }
        }
    }
}
