using Controller.Categorias;
using Controller.FormaPagamentos;
using Controller.MovimentosAnaliticos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View.MovimentosAnaliticos
{
    public partial class MovimentoAnaliticoForm : BaseView
    {

        public int Id { get; set; }
        private readonly IMovimentoAnaliticoController _movimentoAnaliticoController;
        private readonly ICategoriaController _categoriaController;
        private readonly IFormaPagamentoController _formaPagamentoController;

        public MovimentoAnaliticoForm(IMovimentoAnaliticoController movimentoAnaliticoController,
                                      ICategoriaController categoriaController,
                                      IFormaPagamentoController formaPagamentoController)
        {
            InitializeComponent();
            _movimentoAnaliticoController = movimentoAnaliticoController;
            _categoriaController = categoriaController;
            _formaPagamentoController = formaPagamentoController;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        private void MovimentoAnaliticoForm_Load(object sender, EventArgs e)
        {
            setDataCompra();
            popularListaCategoria();
            popularListaFormaPagamento();

            if (Id != -1)
            {
                var movDto = _movimentoAnaliticoController.GetById(Id); 
                popularComponentesFormulario(movDto);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (Id == -1)
                Novo();
            else
                Editar();
        }

        private void Novo()
        {
            var movimentoAnaliticoDto = PopularMovimentoAnaliticoDto();
            var result = _movimentoAnaliticoController.Insert(movimentoAnaliticoDto);
            base.Message(result);
            this.Close();
        }

        private void Editar()
        {
            var categoriaDto = PopularMovimentoAnaliticoDto();
            var result = _movimentoAnaliticoController.Update(categoriaDto);
            base.Message(result);
            this.Close();
        }

        private MovimentoAnaliticoDto PopularMovimentoAnaliticoDto()
        {
            MovimentoAnaliticoDto mov = new MovimentoAnaliticoDto();
            mov.Id = Id;
            mov.DataCompra = dtpDataCompra.Value;
            mov.Valor = Convert.ToDecimal(txtValor.Text);
            mov.Descricao = txtDescricao.Text;
            mov.CategoriaId = cboCategoria.SelectedValue?.ToString();
            mov.FormaPagamentoId = cboFormaPagamento.SelectedValue?.ToString();
            return mov;
        }

        private void setDataCompra()
        {
            dtpDataCompra.Value = DateTime.Now;
            dtpDataCompra.Format = DateTimePickerFormat.Custom;
            dtpDataCompra.CustomFormat = "dd/MM/yyyy";
        }

        private void popularListaCategoria()
        {
            var source = _categoriaController.GetAll();

            cboCategoria.DataSource = source.ToList();
            cboCategoria.DisplayMember = "Descricao";
            cboCategoria.ValueMember = "Id";
            cboCategoria.SelectedIndex = -1;
        }

        private void popularListaFormaPagamento()
        {
            var source = _formaPagamentoController.GetAll();
            cboFormaPagamento.DataSource = source.ToList();
            cboFormaPagamento.DisplayMember = "Descricao";
            cboFormaPagamento.ValueMember = "Id";
            cboFormaPagamento.SelectedIndex = -1;
        }

        private void popularComponentesFormulario(MovimentoAnaliticoDto movimentoAnaliticoDto)
        {
            txtId.Text = movimentoAnaliticoDto.Id.ToString();
            txtDescricao.Text = movimentoAnaliticoDto.Descricao;
            txtValor.Text = movimentoAnaliticoDto.Valor.ToString();
            cboCategoria.SelectedIndex = cboCategoria.FindString(movimentoAnaliticoDto.CategoriaDescricao);
            cboFormaPagamento.SelectedIndex = cboFormaPagamento.FindString(movimentoAnaliticoDto.FormaPagamentoDescricao);
        }


    }
}
