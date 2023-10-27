using Controller.ModuloCartao;
using Controller.ModuloCategoria;
using Controller.ModuloFaturaEmAberto;
using Controller.ModuloSaida;
using System.Data;

namespace View.ModuloSaida
{
    public partial class SaidaForm : BaseView
    {

        private readonly ISaidaController _saidaController;
        private readonly ICategoriaController _categoriaController;
        private readonly ICartaoController _cartaoController;
        private readonly IFaturaEmAbertoController _faturaEmAbertoController;

        public SaidaForm(
            ISaidaController saidaController,
            ICategoriaController categoriaController,
            ICartaoController cartaoController,
            IFaturaEmAbertoController faturaEmAbertoController)
        {
            InitializeComponent();

            _saidaController = saidaController;
            _categoriaController = categoriaController;
            _cartaoController = cartaoController;
            _faturaEmAbertoController = faturaEmAbertoController;

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        private void SaidaForm_Load(object sender, EventArgs e)
        {
            setDataSaida();
            popularListaCategoria();
            popularListaCartao();
            AplicarEventos(txtValor);

            if (Id != -1)
            {
                var saidaDto = _saidaController.GetById(Id);
                popularComponentesFormulario(saidaDto);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (Id == -1)
                novo();
            else
                editar();
        }

        private void setDataSaida()
        {
            dtpDataSaida.Value = DateTime.Now;
            dtpDataSaida.Format = DateTimePickerFormat.Custom;
            dtpDataSaida.CustomFormat = "dd/MM/yyyy";
        }

        private void popularListaCategoria()
        {
            var source = _categoriaController.GetAll().Where(x => x.Tipo == "Saída").OrderBy(x => x.Descricao);

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

        private void popularComponentesFormulario(SaidaDto saidaDto)
        {
            txtId.Text = saidaDto.Id.ToString();
            txtDescricao.Text = saidaDto.Descricao;
            txtValor.Text = saidaDto.Valor.ToString();
            cboCategoria.SelectedIndex = cboCategoria.FindString(saidaDto.CategoriaDescricao);
            cboCartao.SelectedIndex = cboCartao.FindString(saidaDto.CartaoDescricao);
        }

        private void novo()
        {
            var saidaDto = PopularSaidaDto();
            var result = _saidaController.Insert(saidaDto);
            base.Message(result);
            inserirSaidaEmFaturaAberta(saidaDto);
            this.Close();
        }

        private void editar()
        {
            var saidaDto = PopularSaidaDto();
            var result = _saidaController.Update(saidaDto);
            base.Message(result);
            this.Close();
        }

        private SaidaDto PopularSaidaDto()
        {
            SaidaDto saida = new SaidaDto();
            saida.Id = Id;
            saida.DataSaida = dtpDataSaida.Value;
            saida.Valor = Convert.ToDecimal(txtValor.Text);
            saida.Descricao = txtDescricao.Text;
            saida.IdCategoria = Convert.ToInt32(cboCategoria.SelectedValue.ToString());
            saida.IdCartao = Convert.ToInt32(cboCartao.SelectedValue.ToString());
            return saida;
        }

        private void inserirSaidaEmFaturaAberta(SaidaDto saidaDto)
        {
            var cartao = _cartaoController.GetById(Convert.ToInt16(saidaDto.IdCartao));

            if (cartao.Descricao == "Porto Seguro")
            {
                var resp = MessageBox.Show("Deseja lançar movimento em Fatura Em Aberto", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resp == DialogResult.Yes)
                {
                    FaturaEmAbertoDto faturaEmAbertoDto = new FaturaEmAbertoDto();
                    faturaEmAbertoDto.Descricao = saidaDto.Descricao;
                    faturaEmAbertoDto.DataCompra = saidaDto.DataSaida;
                    faturaEmAbertoDto.Valor = saidaDto.Valor;
                    _faturaEmAbertoController.Insert(faturaEmAbertoDto);
                }
            }
        }


    }
}
