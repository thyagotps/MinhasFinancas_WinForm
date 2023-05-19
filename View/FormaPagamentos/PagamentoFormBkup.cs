using Controller.FormaPagamentos;
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
    public partial class PagamentoFormBkup : Form
    {
        public int Codigo { get; set; }
        private readonly IFormaPagamentoController _pagamentoController;

        public PagamentoFormBkup(IFormaPagamentoController pagamentoController)
        {
            InitializeComponent();
            _pagamentoController = pagamentoController;
        }

        #region Eventos da view
        /// <summary>
        /// Ação load da view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PagamentoForm_Load(object sender, EventArgs e)
        {
            if (Codigo != -1)
            {
                var pagamentoDto = GetPagamentoById(Codigo);
                PopularComponentesFormulario(pagamentoDto);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (Codigo == -1)
                Novo();
            else
                Editar();
        }
        #endregion

        #region Métodos
        private void Novo()
        {
            var pagamentoDto = PopularPagamentoDto();
            var result = _pagamentoController.Insert(pagamentoDto);
            Message(result);
        }

        private void Editar()
        {
            var pagamentoDto = PopularPagamentoDto();
            var result = _pagamentoController.Update(pagamentoDto);
            Message(result);
        }

        private FormaPagamentoDto PopularPagamentoDto()
        {
            FormaPagamentoDto pagamentoDto = new FormaPagamentoDto();
            pagamentoDto.Id = Codigo;
            pagamentoDto.Descricao = txtDescricao.Text;
            return pagamentoDto;
        }

        private void PopularComponentesFormulario(FormaPagamentoDto pagamentoDto)
        {
            txtCodigo.Text = pagamentoDto.Id.ToString();
            txtDescricao.Text = pagamentoDto.Descricao;
        }

        private FormaPagamentoDto GetPagamentoById(int id)
        {
            return _pagamentoController.GetById(id);
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
        #endregion

       
    }
}
