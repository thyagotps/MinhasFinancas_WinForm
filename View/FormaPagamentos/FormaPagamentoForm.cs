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

namespace View.FormaPagamentos
{
    public partial class FormaPagamentoForm : BaseView
    {
        public int Id { get; set; }
        private readonly IFormaPagamentoController _formaPagamentoController;

        public FormaPagamentoForm(IFormaPagamentoController formaPagamentoController)
        {
            InitializeComponent();
            _formaPagamentoController = formaPagamentoController;
        }

        #region Eventos da view
        
        private void PagamentoForm_Load(object sender, EventArgs e)
        {
            if (Id != -1)
            {
                var formaPagamentoDto = GetFormaPagamentoById(Id);
                PopularComponentesFormulario(formaPagamentoDto);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (Id == -1)
                Novo();
            else
                Editar();
        }
        #endregion

        #region Métodos
        private void Novo()
        {
            var formaPagamentoDto = PopularFormaPagamentoDto();
            var result = _formaPagamentoController.Insert(formaPagamentoDto);
            base.Message(result);
            this.Close();
        }

        private void Editar()
        {
            var formaPagamentoDto = PopularFormaPagamentoDto();
            var result = _formaPagamentoController.Update(formaPagamentoDto);
            base.Message(result);
            this.Close();
        }

        private FormaPagamentoDto PopularFormaPagamentoDto()
        {
            FormaPagamentoDto formaPagamentoDto = new FormaPagamentoDto();
            formaPagamentoDto.Id = Id;
            formaPagamentoDto.Descricao = txtDescricao.Text;
            return formaPagamentoDto;
        }

        private void PopularComponentesFormulario(FormaPagamentoDto formaPagamentoDto)
        {
            txtId.Text = formaPagamentoDto.Id.ToString();
            txtDescricao.Text = formaPagamentoDto.Descricao;
        }

        private FormaPagamentoDto GetFormaPagamentoById(int id)
        {
            return _formaPagamentoController.GetById(id);
        }

        #endregion
    }
}
