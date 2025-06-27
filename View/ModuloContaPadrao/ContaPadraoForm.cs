using Controller.ModuloCartao;
using Controller.ModuloCategoria;
using Controller.ModuloContaPadrao;
using Controller.ModuloMovimentoFinanceiro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View.ModuloContaPadrao
{
    public partial class ContaPadraoForm : BaseView
    {

        private readonly IContaPadraoController _contaPadraoController;
        private readonly ICartaoController _cartaoController;
        private readonly ICategoriaController _categoriaController;

        public ContaPadraoForm(IContaPadraoController contaPadraoController,
            ICartaoController cartaoController,
            ICategoriaController categoriaController)
        {
            InitializeComponent();
            _contaPadraoController = contaPadraoController;
            _cartaoController = cartaoController;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            _categoriaController = categoriaController;
        }

        private void ContaPadraoForm_Load(object sender, EventArgs e)
        {
            setDataMovimento();
            setDataVencimento();
            popularListaTipoMovimento();
            popularListaCartao();
            setLabelsMessageErrorsVisible();
            popularListaSituacao();

            if (Estado == Estado.Update)
            {
                var contaPadraDto = _contaPadraoController.GetById(Id);
                popularComponentesFormulario(contaPadraDto);
            }
            setLabelsMessageErrorsVisible();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (Estado == Estado.Insert)
                novo();
            else if (Estado == Estado.Update)
                editar();
            else
                return;
        }

        private void cboTipoMovimento_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tipoMov = cboTipoMovimento.SelectedValue?.ToString();
            popularListaCategoria(tipoMov);
            setDataVencimentoByTipoMovimento(tipoMov);
        }

        private void setDataVencimentoByTipoMovimento(string tipoMov)
        {
            if (tipoMov == "Renda")
            {
                dtpDataVencimento.Value = new DateTime(1900, 1, 1);
                dtpDataVencimento.Enabled = false;
                dtpDataVencimento.Format = DateTimePickerFormat.Custom;
                dtpDataVencimento.CustomFormat = " "; // Define um espaço em branco
            }
            else
            {
                dtpDataVencimento.Value = dtpDataMovimento.Value;
                dtpDataVencimento.Enabled = true;
                setDataVencimento();
            }
        }

        private void popularListaCategoria(string tipoMov)
        {
            var source = _categoriaController.GetAll().Where(x => x.Tipo == tipoMov).OrderBy(x => x.Descricao);

            cboCategoria.DataSource = source.ToList();
            cboCategoria.DisplayMember = "Descricao";
            cboCategoria.ValueMember = "Id";
            cboCategoria.SelectedIndex = -1;
        }

        private void novo()
        {
            var objDto = PopularContaPadraoDto();
            if (mensagensErro(objDto)) return;
            var result = _contaPadraoController.Insert(objDto);
            base.Message(result);
            this.Close();
        }

        private void editar()
        {
            var objDto = PopularContaPadraoDto();
            if (mensagensErro(objDto)) return;
            var result = _contaPadraoController.Update(objDto);
            base.Message(result);
            this.Close();
        }

        private ContaPadraoDto PopularContaPadraoDto()
        {
            ContaPadraoDto mov = new ContaPadraoDto();
            mov.Id = Id;
            mov.TipoMovimento = cboTipoMovimento.SelectedValue?.ToString();
            mov.DataMovimento = dtpDataMovimento.Value;
            mov.DataVencimento = dtpDataVencimento.Value;
            mov.Valor = string.IsNullOrEmpty(txtValor.Text) ? null : Convert.ToDecimal(txtValor.Text);
            mov.Descricao = txtDescricao.Text;
            mov.IdCategoria = Convert.ToInt32(cboCategoria.SelectedValue?.ToString());
            mov.IdCartao = Convert.ToInt32(cboCartao.SelectedValue?.ToString());

            var sit = cboSituacao.SelectedValue?.ToString();
            if (sit == "Pago") mov.Situacao = "S";
            else if (sit == "Não Pago") mov.Situacao = "N";
            else mov.Situacao = null;
            return mov;
        }

        private bool mensagensErro(ContaPadraoDto entradaDto)
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


                    if (memberName == "DataVencimento")
                    {
                        lblErrorDataVencimento.Visible = true;
                        lblErrorDataVencimento.Text = $"* {item.ErrorMessage}";
                    }

                    if (memberName == "Situacao")
                    {
                        lblErrorSituacao.Visible = true;
                        lblErrorSituacao.Text = $"* {item.ErrorMessage}";
                    }

                }
            }

            return errors.Count() > 0 ? true : false;
        }




        private void popularListaTipoMovimento()
        {
            List<string> lista = new List<string>() { "Renda", "Despesa" };
            cboTipoMovimento.DataSource = lista;
        }

        private void setDataMovimento()
        {
            dtpDataMovimento.Value = DateTime.Now;
            dtpDataMovimento.Format = DateTimePickerFormat.Custom;
            dtpDataMovimento.CustomFormat = "dd/MM/yyyy";
        }

        private void setDataVencimento()
        {
            dtpDataVencimento.Value = DateTime.Now;
            dtpDataVencimento.Format = DateTimePickerFormat.Custom;
            dtpDataVencimento.CustomFormat = "dd/MM/yyyy";
        }

        private void popularListaCartao()
        {
            var source = _cartaoController.GetAll().OrderBy(x => x.Descricao);
            cboCartao.DataSource = source.ToList();
            cboCartao.DisplayMember = "Descricao";
            cboCartao.ValueMember = "Id";
            cboCartao.SelectedIndex = -1;
        }

        private void setLabelsMessageErrorsVisible()
        {
            lblErrorTipoMovimento.Visible = false;
            lblErrorDataMovimento.Visible = false;
            lblErrorDescricao.Visible = false;
            lblErrorValor.Visible = false;
            lblErrorCategoria.Visible = false;
            lblErrorCartao.Visible = false;
            lblErrorDataVencimento.Visible = false;
            lblErrorSituacao.Visible = false;
        }

        private void popularListaSituacao()
        {
            List<String> listaSituacoes = new List<string>();
            listaSituacoes.Add("Pago");
            listaSituacoes.Add("Não Pago");
            cboSituacao.DataSource = listaSituacoes;
            cboSituacao.SelectedIndex = -1;
        }

        private void popularComponentesFormulario(ContaPadraoDto objDto)
        {
            txtId.Text = objDto.Id.ToString();
            cboTipoMovimento.SelectedIndex = cboTipoMovimento.FindString(objDto.TipoMovimento);
            dtpDataMovimento.Value = objDto.DataMovimento;
            dtpDataVencimento.Value = (DateTime)objDto.DataVencimento;
            txtDescricao.Text = objDto.Descricao;
            txtValor.Text = objDto.Valor.ToString();
            cboCategoria.SelectedIndex = cboCategoria.FindString(objDto.CategoriaDescricao);
            cboCartao.SelectedIndex = cboCartao.FindString(objDto.CartaoDescricao);

            if (objDto.Situacao == "S")
                cboSituacao.SelectedIndex = cboSituacao.FindString("Pago");
            else if (objDto.Situacao == "N")
                cboSituacao.SelectedIndex = cboSituacao.FindString("Não Pago");
            else
                cboSituacao.SelectedIndex = -1;
        }

        
    }
}
