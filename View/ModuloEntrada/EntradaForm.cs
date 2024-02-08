using Controller;
using Controller.ModuloCartao;
using Controller.ModuloCategoria;
using Controller.ModuloEntrada;
using Controller.ModuloSalario;
using System.Data;

namespace View.ModuloEntrada
{
    public partial class EntradaForm : BaseView
    {
        private readonly IEntradaController _entradaController;
        private readonly ICategoriaController _categoriaController;
        private readonly ICartaoController _cartaoController;

        public EntradaForm(
            IEntradaController entradaController,
            ICategoriaController categoriaController,
            ICartaoController cartaoController)
        {
            InitializeComponent();
            _entradaController = entradaController;
            _categoriaController = categoriaController;
            _cartaoController = cartaoController;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

        }

        private void EntradaForm_Load(object sender, EventArgs e)
        {
            AplicarEventos(txtValor);
            setDataEntrada();
            popularListaCategoria();
            popularListaCartao();
            setLabelsMessageErrorsVisible();

            if (Id != -1)
            {
                var entradaDto = _entradaController.GetById(Id);
                popularComponentesFormulario(entradaDto);
            }

            
        }

        private void AplicarEventos(TextBox txtValor)
        {
            txtValor.KeyPress += ValidaValores;
        }

        private void setDataEntrada()
        {
            dtpDataEntrada.Value = DateTime.Now;
            dtpDataEntrada.Format = DateTimePickerFormat.Custom;
            dtpDataEntrada.CustomFormat = "dd/MM/yyyy";
        }

        private void popularListaCategoria()
        {
            var source = _categoriaController.GetAll().Where(x => x.Tipo == "Entrada").OrderBy(x => x.Descricao);
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


        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (Id == -1)
                novo();
            else
                editar();
        }

        private void novo()
        {
            var entradaDto = popularEntradaDto();
            if (mensagensErro(entradaDto)) return;
            var result = _entradaController.Insert(entradaDto);
            base.Message(result);
            this.Close();
        }

        private void editar()
        {
            var entradaDto = popularEntradaDto();
            if (mensagensErro(entradaDto)) return;
            var result = _entradaController.Update(entradaDto);
            base.Message(result);
            this.Close();
        }

        private EntradaDto popularEntradaDto()
        {
            EntradaDto entradaDto = new EntradaDto();
            entradaDto.Id = Id;
            entradaDto.Descricao = txtDescricao.Text;
            entradaDto.DataEntrada = dtpDataEntrada.Value;
            entradaDto.Valor = string.IsNullOrEmpty(txtValor.Text) ? null : Convert.ToDecimal(txtValor.Text);
            entradaDto.IdCategoria = Convert.ToInt16(cboCategoria.SelectedValue?.ToString());
            entradaDto.IdCartao = Convert.ToInt16(cboCartao.SelectedValue?.ToString());

            return entradaDto;
        }

        private void popularComponentesFormulario(EntradaDto entradaDto)
        {
            txtId.Text = entradaDto.Id.ToString();
            txtDescricao.Text = entradaDto.Descricao;
            dtpDataEntrada.Value = entradaDto.DataEntrada;
            txtValor.Text = entradaDto.Valor.ToString();

            var categoria = _categoriaController.GetById(entradaDto.IdCategoria);
            cboCategoria.SelectedIndex = cboCategoria.FindString(categoria.Descricao);

            var cartao = _categoriaController.GetById(entradaDto.IdCartao);
            if (cartao != null)
                cboCartao.SelectedIndex = cboCartao.FindString(cartao.Descricao);
        }

        private bool mensagensErro(EntradaDto entradaDto)
        {
            setLabelsMessageErrorsVisible();

            var errors = ValidarObjeto(entradaDto);
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

                    if (memberName == "DataEntrada")
                    {
                        lblErrorData.Visible = true;
                        lblErrorData.Text = $"* {item.ErrorMessage}";
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
            lblErrorDescricao.Visible = false;
            lblErrorData.Visible = false;
            lblErrorValor.Visible = false;
            lblErrorCategoria.Visible = false;
            lblErrorCartao.Visible = false;
        }

        
    }
}
