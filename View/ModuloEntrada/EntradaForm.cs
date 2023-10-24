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

        public EntradaForm(
            IEntradaController entradaController,
            ICategoriaController categoriaController)
        {
            InitializeComponent();
            _entradaController = entradaController;
            _categoriaController = categoriaController;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

        }

        private void EntradaForm_Load(object sender, EventArgs e)
        {
            AplicarEventos(txtValor);
            setDataEntrada();
            popularListaCategoria();

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
            var result = _entradaController.Insert(entradaDto);
            base.Message(result);
            this.Close();
        }

        private void editar()
        {
            var entradaDto = popularEntradaDto();
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
            entradaDto.Valor = Convert.ToDecimal(txtValor.Text);
            entradaDto.IdCategoria = Convert.ToInt16(cboCategoria.SelectedValue?.ToString());

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
        }




    }
}
