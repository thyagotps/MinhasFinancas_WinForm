using Controller.ModuloCategoria;
using Controller.ModuloFaturaEmAberto;

namespace View.ModuloFaturaEmAberto
{
    public partial class FaturaEmAbertoForm : BaseView
    {
        private readonly IFaturaEmAbertoController _controller;

        public FaturaEmAbertoForm(IFaturaEmAbertoController controller)
        {
            InitializeComponent();
            _controller = controller;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            AplicarEventos(txtValor);
        }

        private void AplicarEventos(TextBox txt)
        {
            txtValor.KeyPress += ValidaValores;
        }

        private void FaturaEmAbertoForm_Load(object sender, EventArgs e)
        {
            setDataCompra();

            if (Id != -1)
            {
                var contaPagar = _controller.GetById(Id);
                popularComponentesFormulario(contaPagar);
            }

            setLabelsMessageErrorsVisible();
        }

        private void setDataCompra()
        {
            dtpDataCompra.Value = DateTime.Now;
            dtpDataCompra.Format = DateTimePickerFormat.Custom;
            dtpDataCompra.CustomFormat = "dd/MM/yyyy";
        }

        private void popularComponentesFormulario(FaturaEmAbertoDto objDto)
        {
            txtId.Text = objDto.Id.ToString();
            dtpDataCompra.Value = objDto.DataCompra;
            txtDescricao.Text = objDto.Descricao;
            txtValor.Text = objDto.Valor.ToString();
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
            var faturaEmAbertoDto = popularFaturaEmAbertoDto();
            if (mensagensErro(faturaEmAbertoDto)) return;
            var result = _controller.Insert(faturaEmAbertoDto);
            base.Message(result);
            this.Close();
        }

        private FaturaEmAbertoDto popularFaturaEmAbertoDto()
        {
            FaturaEmAbertoDto obj = new FaturaEmAbertoDto();
            obj.Id = Id;
            obj.Descricao = txtDescricao.Text;
            obj.Valor = string.IsNullOrEmpty(txtValor.Text) ? null : Convert.ToDecimal(txtValor.Text);
            obj.DataCompra = dtpDataCompra.Value;
            return obj;
        }

        private void editar()
        {
            var faturaEmAbertoDto = popularFaturaEmAbertoDto();
            if (mensagensErro(faturaEmAbertoDto)) return;
            var result = _controller.Update(faturaEmAbertoDto);
            base.Message(result);
            this.Close();
        }

        private bool mensagensErro(FaturaEmAbertoDto objectDto)
        {
            setLabelsMessageErrorsVisible();

            var errors = ValidarObjeto(objectDto);
            if (errors.Count() > 0)
            {
                foreach (var item in errors)
                {
                    var memberName = item.MemberNames.FirstOrDefault();
                    
                    if (memberName == "DataCompra")
                    {
                        lblErrorDataCompra.Visible = true;
                        lblErrorDataCompra.Text = $"* {item.ErrorMessage}";
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

                }
            }

            return errors.Count() > 0 ? true : false;
        }

        private void setLabelsMessageErrorsVisible()
        {
            lblErrorDataCompra.Visible = false;
            lblErrorDescricao.Visible = false;
            lblErrorValor.Visible = false;
        }
    }
}
