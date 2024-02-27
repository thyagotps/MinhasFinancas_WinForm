using Controller.ModuloCartao;
using Controller.ModuloCategoria;
using Controller.ModuloPagamento;

namespace View.ModuloPagamento
{
    public partial class PagamentoForm : BaseView
    {
        public int Id { get; set; }
        private readonly IPagamentoController _pagamentoController;

        public PagamentoForm(IPagamentoController contaPagarController)
        {
            InitializeComponent();
            _pagamentoController = contaPagarController;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            AplicarEventos(txtValor);
        }

        private void AplicarEventos(TextBox txt)
        {
            txtValor.KeyPress += ValidaValores;
        }

        private void ContaPagarForm_Load(object sender, EventArgs e)
        {
            setDataVencimento();
            popularListaSituacao();

            if (Id != -1)
            {
                var contaPagar = _pagamentoController.GetById(Id);
                popularComponentesFormulario(contaPagar);
            }

            setLabelsMessageErrorsVisible();
        }



        private void setDataVencimento()
        {
            dtpDataVencimento.Value = DateTime.Now;
            dtpDataVencimento.Format = DateTimePickerFormat.Custom;
            dtpDataVencimento.CustomFormat = "dd/MM/yyyy";
        }

        private void popularListaSituacao()
        {
            List<String> listaSituacoes = new List<string>();
            listaSituacoes.Add("Pago");
            listaSituacoes.Add("Não Pago");
            cboSituacao.DataSource = listaSituacoes;
            cboSituacao.SelectedIndex = -1;
        }

        private void popularComponentesFormulario(PagamentoDto contaPagar)
        {
            txtId.Text = contaPagar.Id.ToString();
            txtNrIdentificador.Text = contaPagar.NrIdentificador.ToString();
            dtpDataVencimento.Value = contaPagar.DataVencimento;
            txtDescricao.Text = contaPagar.Descricao;
            txtValor.Text = contaPagar.Valor.ToString();

            if (contaPagar.Situacao == "S")
                cboSituacao.SelectedIndex = cboSituacao.FindString("Pago");
            else if (contaPagar.Situacao == "N")
                cboSituacao.SelectedIndex = cboSituacao.FindString("Não Pago");
            else
                cboSituacao.SelectedIndex = -1;

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
            var contaPagarDto = popularContaPagarDto();
            if (mensagensErro(contaPagarDto)) return;
            var result = _pagamentoController.Insert(contaPagarDto);
            base.Message(result);
            this.Close();
        }

        private void editar()
        {
            var contaPagarDto = popularContaPagarDto();
            if (mensagensErro(contaPagarDto)) return;
            var result = _pagamentoController.Update(contaPagarDto);
            base.Message(result);
            this.Close();
        }

        private PagamentoDto popularContaPagarDto()
        {
            PagamentoDto obj = new PagamentoDto();
            obj.Id = Id;
            obj.NrIdentificador = string.IsNullOrEmpty(txtNrIdentificador.Text) ? null : Convert.ToInt32(txtNrIdentificador.Text);
            obj.Descricao = txtDescricao.Text;
            obj.Valor = string.IsNullOrEmpty(txtValor.Text) ? null : Convert.ToDecimal(txtValor.Text);
            obj.DataVencimento = dtpDataVencimento.Value;

            var sit = cboSituacao.SelectedValue?.ToString();
            if (sit == "Pago") obj.Situacao = "S";
            else if (sit == "Não Pago") obj.Situacao = "N";
            else obj.Situacao = null;

            return obj;
        }

        private bool mensagensErro(PagamentoDto pagamentoDto)
        {
            setLabelsMessageErrorsVisible();

            var errors = ValidarObjeto(pagamentoDto);
            if (errors.Count() > 0)
            {
                foreach (var item in errors)
                {
                    var memberName = item.MemberNames.FirstOrDefault();

                    if (memberName == "NrIdentificador")
                    {
                        lblErrorIdentificador.Visible = true;
                        lblErrorIdentificador.Text = $"* {item.ErrorMessage}";
                    }

                    if (memberName == "DataVencimento")
                    {
                        lblErrorDataVencimento.Visible = true;
                        lblErrorDataVencimento.Text = $"* {item.ErrorMessage}";
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

                    if (memberName == "Situacao")
                    {
                        lblErrorSituacao.Visible = true;
                        lblErrorSituacao.Text = $"* {item.ErrorMessage}";
                    }

                }
            }

            return errors.Count() > 0 ? true : false;
        }

        private void setLabelsMessageErrorsVisible()
        {
            lblErrorIdentificador.Visible = false;
            lblErrorDataVencimento.Visible = false;
            lblErrorDescricao.Visible = false;
            lblErrorValor.Visible = false;
            lblErrorSituacao.Visible = false;
        }
    }
}
