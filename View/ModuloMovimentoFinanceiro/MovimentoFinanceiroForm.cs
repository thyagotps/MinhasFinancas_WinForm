using Controller.ModuloCartao;
using Controller.ModuloCategoria;
using Controller.ModuloEntrada;
using Controller.ModuloFaturaEmAberto;
using Controller.ModuloMovimentoFinanceiro;
using Controller.ModuloSaida;
using Model.ModuloMovimentoFinanceiro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View.ModuloMovimentoFinanceiro
{
    public partial class MovimentoFinanceiroForm : BaseView
    {
        private readonly IMovimentoFinanceiroController _movimentoFinanceiroController;
        private readonly ICategoriaController _categoriaController;
        private readonly ICartaoController _cartaoController;
        private readonly IFaturaEmAbertoController _faturaEmAbertoController;

        public MovimentoFinanceiroForm(
            IMovimentoFinanceiroController movimentoFinanceiroController,
            ICategoriaController categoriaController,
            ICartaoController cartaoController,
            IFaturaEmAbertoController faturaEmAbertoController)
        {
            InitializeComponent();

            _movimentoFinanceiroController = movimentoFinanceiroController;
            _categoriaController = categoriaController;
            _cartaoController = cartaoController;
            _faturaEmAbertoController = faturaEmAbertoController;
        }

        private void MovimentoFinanceiroForm_Load(object sender, EventArgs e)
        {
            setDataMovimento();
            popularListaTipoMovimento();
            //popularListaCategoria();
            popularListaCartao();
            AplicarEventos(txtValor);
            setLabelsMessageErrorsVisible();

            if (Id != -1)
            {
                var objDto = _movimentoFinanceiroController.GetById(Id);
                popularComponentesFormulario(objDto);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (Id == -1)
                novo();
            else
                editar();
        }

        private void cboTipoMovimento_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tipoMov = cboTipoMovimento.SelectedValue?.ToString();
            popularListaCategoria(tipoMov);
        }






        private void setDataMovimento()
        {
            dtpDataMovimento.Value = DateTime.Now;
            dtpDataMovimento.Format = DateTimePickerFormat.Custom;
            dtpDataMovimento.CustomFormat = "dd/MM/yyyy";
        }

        private void popularListaTipoMovimento()
        {
            List<string> lista = new List<string>() { "Renda", "Despesa" };
            cboTipoMovimento.DataSource = lista;
        }

        private void popularListaCategoria(string tipoMov)
        {
            var source = _categoriaController.GetAll().Where(x => x.Tipo == tipoMov).OrderBy(x => x.Descricao);

            cboCategoria.DataSource = source.ToList();
            cboCategoria.DisplayMember = "Descricao";
            cboCategoria.ValueMember = "Id";
            cboCategoria.SelectedIndex = -1;
        }

        private void popularListaCartao()
        {
            var source = _cartaoController.GetAll().OrderBy(x => x.Descricao);
            cboCartao.DataSource = source.ToList();
            cboCartao.DisplayMember = "Descricao";
            cboCartao.ValueMember = "Id";
            cboCartao.SelectedIndex = -1;
        }

        private void AplicarEventos(System.Windows.Forms.TextBox txt)
        {
            txtValor.KeyPress += ValidaValores;
        }

        private void popularComponentesFormulario(MovimentoFinanceiroDto objDto)
        {
            txtId.Text = objDto.Id.ToString();
            cboTipoMovimento.SelectedIndex = cboTipoMovimento.FindString(objDto.TipoMovimento);
            dtpDataMovimento.Value = objDto.DataMovimento;
            txtDescricao.Text = objDto.Descricao;
            txtValor.Text = objDto.Valor.ToString();
            cboCategoria.SelectedIndex = cboCategoria.FindString(objDto.CategoriaDescricao);
            cboCartao.SelectedIndex = cboCartao.FindString(objDto.CartaoDescricao);
        }

        private void novo()
        {
            var objDto = PopularMovimentoFinanceiroDto();
            if (mensagensErro(objDto)) return;
            var result = _movimentoFinanceiroController.Insert(objDto);
            base.Message(result);
            inserirEmFaturaAberta(objDto);
            this.Close();
        }

        private void editar()
        {
            var objDto = PopularMovimentoFinanceiroDto();
            if (mensagensErro(objDto)) return;
            var result = _movimentoFinanceiroController.Update(objDto);
            base.Message(result);
            this.Close();
        }

        private MovimentoFinanceiroDto PopularMovimentoFinanceiroDto()
        {
            MovimentoFinanceiroDto mov = new MovimentoFinanceiroDto();
            mov.Id = Id;
            mov.TipoMovimento = cboTipoMovimento.SelectedValue?.ToString();
            mov.DataMovimento = dtpDataMovimento.Value;
            mov.Valor = string.IsNullOrEmpty(txtValor.Text) ? null : Convert.ToDecimal(txtValor.Text);
            mov.Descricao = txtDescricao.Text;
            mov.IdCategoria = Convert.ToInt32(cboCategoria.SelectedValue?.ToString());
            mov.IdCartao = Convert.ToInt32(cboCartao.SelectedValue?.ToString());
            return mov;
        }

        private void inserirEmFaturaAberta(MovimentoFinanceiroDto mov)
        {
            var cartao = _cartaoController.GetById(Convert.ToInt16(mov.IdCartao));

            if (cartao.Descricao == "Porto Seguro")
            {
                var resp = MessageBox.Show("Deseja lançar movimento em Fatura Em Aberto", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resp == DialogResult.Yes)
                {
                    FaturaEmAbertoDto faturaEmAbertoDto = new FaturaEmAbertoDto();
                    faturaEmAbertoDto.Descricao = mov.Descricao;
                    faturaEmAbertoDto.DataCompra = mov.DataMovimento;
                    faturaEmAbertoDto.Valor = mov.Valor.Value;
                    _faturaEmAbertoController.Insert(faturaEmAbertoDto);
                }
            }
        }

        private bool mensagensErro(MovimentoFinanceiroDto entradaDto)
        {
            setLabelsMessageErrorsVisible();

            var errors = ValidarObjeto(entradaDto);
            if (errors.Count() > 0)
            {
                foreach (var item in errors)
                {
                    var memberName = item.MemberNames.FirstOrDefault();

                    if (memberName == "TipoMovimento")
                    {
                        lblErrorTipoMovimento.Visible = true;
                        lblErrorTipoMovimento.Text = $"* {item.ErrorMessage}";
                    }

                    if (memberName == "DataMovimento")
                    {
                        lblErrorDataMovimento.Visible = true;
                        lblErrorDataMovimento.Text = $"* {item.ErrorMessage}";
                    }

                    if (memberName == "Descricao")
                    {
                        lblErrorDescricao.Visible = true;
                        lblErrorDescricao.Text = $"* {item.ErrorMessage}";
                    }

                    if (memberName == "Valor")
                    {
                        lblErrorValor.Visible = true;
                        lblErrorValor.Text = $"* {item.ErrorMessage}";
                    }

                    if (memberName == "IdCategoria")
                    {
                        lblErrorCategoria.Visible = true;
                        lblErrorCategoria.Text = $"* {item.ErrorMessage}";
                    }

                    if (memberName == "IdCartao")
                    {
                        lblErrorCartao.Visible = true;
                        lblErrorCartao.Text = $"* {item.ErrorMessage}";
                    }

                }
            }

            return errors.Count() > 0 ? true : false;
        }

        private void setLabelsMessageErrorsVisible()
        {
            lblErrorTipoMovimento.Visible = false;
            lblErrorDataMovimento.Visible = false;
            lblErrorDescricao.Visible = false;
            lblErrorValor.Visible = false;
            lblErrorCategoria.Visible = false;
            lblErrorCartao.Visible = false;
        }


    }
}
