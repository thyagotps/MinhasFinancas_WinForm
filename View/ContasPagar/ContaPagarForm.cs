using Controller.ContasPagar;

namespace View.ContasPagar
{
    public partial class ContaPagarForm : BaseView
    {
        public int Id { get; set; }
        private readonly IContaPagarController _contaPagarController;

        public ContaPagarForm(IContaPagarController contaPagarController)
        {
            InitializeComponent();
            _contaPagarController = contaPagarController;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            AplicarEventos(txtValor);
        }

        // Aplica no form movimento analitico
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
                var contaPagar = _contaPagarController.GetById(Id);
                popularComponentesFormulario(contaPagar);
            }
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

        private void popularComponentesFormulario(ContaPagarDto contaPagar)
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
            var result = _contaPagarController.Insert(contaPagarDto);
            base.Message(result);
            this.Close();
        }

        private void editar()
        {
            var contaPagarDto = popularContaPagarDto();
            var result = _contaPagarController.Update(contaPagarDto);
            base.Message(result);
            this.Close();
        }

        private ContaPagarDto popularContaPagarDto()
        {
            ContaPagarDto obj = new ContaPagarDto();
            obj.Id = Id;
            obj.NrIdentificador = Convert.ToInt32(txtNrIdentificador.Text);
            obj.Descricao = txtDescricao.Text;
            obj.Valor = Convert.ToDecimal(txtValor.Text);
            obj.DataVencimento = dtpDataVencimento.Value;

            var sit = cboSituacao.SelectedValue.ToString();
            if (sit == "Pago") obj.Situacao = "S";
            else if (sit == "Não Pago") obj.Situacao = "N";
            else obj.Situacao = "N";

            return obj;
        }
    }
}
