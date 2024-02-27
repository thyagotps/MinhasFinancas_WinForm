using Controller.ModuloCartao;
using Controller.ModuloCategoria;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View.ModuloCartao
{
    public partial class CartaoForm : BaseView
    {

        private readonly ICartaoController _cartaoController;


        public CartaoForm(ICartaoController cartaoController)
        {
            InitializeComponent();
            _cartaoController = cartaoController;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            popularListaTipo();
        }

        private void CartaoForm_Load(object sender, EventArgs e)
        {
            if (Id != -1)
            {
                var objectDto = _cartaoController.GetById(Id);
                popularComponentesFormulario(objectDto);
            }
            setLabelsMessageErrorsVisible();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (Id == -1)
                novo();
            else
                editar();
        }

        private void novo()
        {
            var objectDto = popularCartaoDto();
            if (mensagensErro(objectDto)) return;
            var result = _cartaoController.Insert(objectDto);
            base.Message(result);
            this.Close();
        }

        private void editar()
        {
            var objectDto = popularCartaoDto();
            if (mensagensErro(objectDto)) return;
            var result = _cartaoController.Update(objectDto);
            base.Message(result);
            this.Close();
        }

        private CartaoDto popularCartaoDto()
        {
            CartaoDto cartaoDto = new CartaoDto();
            cartaoDto.Id = Id;
            cartaoDto.Descricao = txtDescricao.Text;
            cartaoDto.Tipo = cboTipo.Text;
            return cartaoDto;
        }

        private void popularComponentesFormulario(CartaoDto cartaoDto)
        {
            txtId.Text = cartaoDto.Id.ToString();
            txtDescricao.Text = cartaoDto.Descricao;
            cboTipo.SelectedIndex = string.IsNullOrEmpty(cartaoDto.Tipo) ? -1 : cboTipo.FindString(cartaoDto.Tipo);
        }

        private void popularListaTipo()
        {
            cboTipo.Items.Add("Conta Corrente");
            cboTipo.Items.Add("Crédito");
            cboTipo.Items.Add("Poupança");
            cboTipo.Items.Add("Vale Refeição");
            cboTipo.SelectedIndex = -1;
        }

        private bool mensagensErro(CartaoDto cartaoDto)
        {
            setLabelsMessageErrorsVisible();

            var errors = ValidarObjeto(cartaoDto);
            if (errors.Count() > 0)
            {
                foreach (var item in errors)
                {
                    var memberName = item.MemberNames.FirstOrDefault();

                    if (memberName == "Descricao")
                    {
                        lblErrorDescricao.Visible = true;
                        lblErrorDescricao.Text = $"* {item.ErrorMessage}";
                    }

                    if (memberName == "Tipo")
                    {
                        lblErrorTipo.Visible = true;
                        lblErrorTipo.Text = $"* {item.ErrorMessage}";
                    }

                }
            }

            return errors.Count() > 0 ? true : false;
        }

        private void setLabelsMessageErrorsVisible()
        {
            lblErrorDescricao.Visible = false;
            lblErrorTipo.Visible = false;
        }
    }
}
