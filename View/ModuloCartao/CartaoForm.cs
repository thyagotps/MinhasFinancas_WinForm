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
        }

        private void CartaoForm_Load(object sender, EventArgs e)
        {
            if (Id != -1)
            {
                var objectDto = _cartaoController.GetById(Id);
                popularComponentesFormulario(objectDto);
            }
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
            var result = _cartaoController.Insert(objectDto);
            base.Message(result);
            this.Close();
        }

        private void editar()
        {
            var objectDto = popularCartaoDto();
            var result = _cartaoController.Update(objectDto);
            base.Message(result);
            this.Close();
        }

        private CartaoDto popularCartaoDto()
        {
            CartaoDto cartaoDto = new CartaoDto();
            cartaoDto.Id = Id;
            cartaoDto.Descricao = txtDescricao.Text;
            return cartaoDto;
        }

        private void popularComponentesFormulario(CartaoDto cartaoDto)
        {
            txtId.Text = cartaoDto.Id.ToString();
            txtDescricao.Text = cartaoDto.Descricao;
        }
    }
}
