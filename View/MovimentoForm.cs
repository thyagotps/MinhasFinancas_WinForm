using Controller;
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
    public partial class MovimentoForm : Form
    {
        public int Codigo { get; set; }
        private readonly IMovimentoController _movimentoController;
        private readonly ICategoriaController _categoriaController;
        private readonly IFormaPagamentoController _pagamentoController;
        
        public MovimentoForm(IMovimentoController movimentoController,
            ICategoriaController categoriaController,
            IFormaPagamentoController pagamentoController)
        {
            InitializeComponent();
            _movimentoController = movimentoController;
            _categoriaController = categoriaController;
            _pagamentoController = pagamentoController;
            PopularListaCategoria();
            PopularListaPagamento();
        }

        private void PopularListaPagamento()
        {
            var source = _pagamentoController.GetAll();
            cboFormaPagamento.DataSource = source.ToList();
            cboFormaPagamento.DisplayMember = "Descricao";
            cboFormaPagamento.ValueMember = "Id";
        }

        private void PopularListaCategoria()
        {
            var source = _categoriaController.GetAll();
            cboCategoria.DataSource = source.ToList();
            cboCategoria.DisplayMember = "Descricao";
            cboCategoria.ValueMember = "Id";
        }

        private void MovimentoForm_Load(object sender, EventArgs e)
        {
            if (Codigo != -1)
            {
                var movimentoDto = GetMovimentoById(Codigo);
                PopularComponentesFormulario(movimentoDto);
            }
        }



        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (Codigo == -1)
                Novo();
            else
                Editar();
        }

      

        private void Novo()
        {
            var movimentoDto = PopularMovimentoDto();
            var result = _movimentoController.Insert(movimentoDto);
            Message(result);
        }

        private void Editar()
        {
            var movimentoDto = PopularMovimentoDto();
            var result = _movimentoController.Update(movimentoDto);
            Message(result);
        }

        private MovimentoDto PopularMovimentoDto()
        {
            MovimentoDto movimentoDto = new MovimentoDto();
            movimentoDto.Id = Codigo;
            movimentoDto.DataCompra = dtpDataCompra.Value;
            movimentoDto.Descricao = txtDescricao.Text;
            movimentoDto.Parcelas = txtParcelas.Text;
            movimentoDto.Valor = Convert.ToDecimal(txtValor.Text);
            movimentoDto.DataVencimento = dtpDataVencimento.Value;
            movimentoDto.Situacao = rdbNaoPago.Checked ? 0 : 1;
            movimentoDto.CategoriaId = cboCategoria.SelectedValue.ToString();
            movimentoDto.PagamentoId = cboFormaPagamento.SelectedValue.ToString();
            return movimentoDto;
        }

        private MovimentoDto GetMovimentoById(int id)
        {
            return _movimentoController.GetById(id);
        }

        private void PopularComponentesFormulario(MovimentoDto movimentoDto)
        {
            txtCodigo.Text = movimentoDto.Id.ToString();
            dtpDataCompra.Value = movimentoDto.DataCompra;
            
            

            if (movimentoDto.DataVencimento.HasValue)
            {
                dtpDataVencimento.Value = movimentoDto.DataVencimento.Value;
            }
            else
            {
                dtpDataVencimento.CustomFormat = " ";
                dtpDataVencimento.Format = DateTimePickerFormat.Custom;

            }

            txtDescricao.Text = movimentoDto.Descricao;
            txtParcelas.Text = movimentoDto.Parcelas;
            txtValor.Text = movimentoDto.Valor.ToString();
            if (movimentoDto.Situacao == 0)
            {
                rdbNaoPago.Checked = false;
                rdbPago.Checked = true;
            }

            else
            {
                rdbNaoPago.Checked = true;
                rdbPago.Checked = false;
            }
            cboCategoria.SelectedIndex = cboCategoria.FindString(movimentoDto.CategoriaDescricao);
            cboFormaPagamento.SelectedIndex = cboFormaPagamento.FindString(movimentoDto.PagamentoDescricao);


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

        
    }
}
