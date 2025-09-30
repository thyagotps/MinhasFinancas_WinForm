using Controller.ModuloBalancoMensal;
using Controller.ModuloCartao;
using System.Data;

namespace View.ModuloBalancoMensal
{
    public partial class BalancoMensalView : Form
    {

        private readonly IBalancoMensalController _balancoMensalController;
        private readonly ICartaoController _cartaController;

        public BalancoMensalView(
            IBalancoMensalController balancoMensalController,
            ICartaoController cartaController)
        {
            InitializeComponent();
            _balancoMensalController = balancoMensalController;
            _cartaController = cartaController;
            setDataMovimento();
            popularListaCartao();
        }


        private void setDataMovimento()
        {
            dtpPeriodo.Value = DateTime.Now;
            dtpPeriodo.Format = DateTimePickerFormat.Custom;
            dtpPeriodo.CustomFormat = "MM/yyyy";
        }

        private void popularListaCartao()
        {
            var source = _cartaController.GetAll().OrderBy(x => x.Descricao);
            cboCartao.DataSource = source.ToList();
            cboCartao.DisplayMember = "Descricao";
            cboCartao.ValueMember = "Id";
            cboCartao.SelectedIndex = -1;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var idCartao = Convert.ToInt32(cboCartao.SelectedValue?.ToString());
            var periodo = dtpPeriodo.Value;

            carregarBalancoMensal(idCartao, periodo);
            carregarBalancoMensalPorCategoriaRenda(idCartao, periodo);
            carregarBalancoMensalPorCategoriaDespesa(idCartao, periodo);
        }

        private void carregarBalancoMensal(int idCartao, DateTime periodo)
        {
            var balMensal = _balancoMensalController.GetBalancoMensal(idCartao, periodo);

            lbl_cartao.Text = "";
            txt_renda.Text = "";
            txt_despesa.Text = "";
            txt_saldo.Text = "";

            lbl_cartao.Text = balMensal.CartaoDescricao;
            txt_renda.Text = balMensal.ValorTotalReceita.Value.ToString("N2");
            txt_despesa.Text = balMensal.ValorTotalDespesa.Value.ToString("N2");
            txt_saldo.Text = balMensal.SaldoFinal.Value.ToString("N2");
        }

        private void carregarBalancoMensalPorCategoriaRenda(int idCartao, DateTime periodo)
        {
            var balMensalPorCategoriaRenda = _balancoMensalController.GetBalancoMensalPorCategoria(idCartao, periodo, "Renda");
            
            listView_categorias_renda.Columns.Clear();
            listView_categorias_renda.Items.Clear();
            listView_categorias_renda.FullRowSelect = true;

            listView_categorias_renda.Columns.Add(new ColumnHeader
            {
                Text = "Categoria",
                Width = 165,
                TextAlign = HorizontalAlignment.Left
            });

            listView_categorias_renda.Columns.Add(new ColumnHeader
            {
                Text = "Valor",
                Width = 100,
                TextAlign = HorizontalAlignment.Right
            });

            foreach (var item in balMensalPorCategoriaRenda.OrderByDescending(x => x.Valor))
            {
                ListViewItem listViewItem = new ListViewItem(item.Categoria);
                listViewItem.SubItems.Add(item.Valor.ToString());
                listView_categorias_renda.Items.Add(listViewItem);
            }
        }

        private void carregarBalancoMensalPorCategoriaDespesa(int idCartao, DateTime periodo)
        {
            var balMensalPorCategoriaDespesa = _balancoMensalController.GetBalancoMensalPorCategoria(idCartao, periodo, "Despesa");

            listView_categorias_despesa.Columns.Clear();
            listView_categorias_despesa.Items.Clear();
            listView_categorias_despesa.FullRowSelect = true;

            listView_categorias_despesa.Columns.Add(new ColumnHeader
            {
                Text = "Categoria",
                Width = 165,
                TextAlign = HorizontalAlignment.Left
            });

            listView_categorias_despesa.Columns.Add(new ColumnHeader
            {
                Text = "Valor",
                Width = 100,
                TextAlign = HorizontalAlignment.Right
            });

            foreach (var item in balMensalPorCategoriaDespesa.OrderByDescending(x => x.Valor))
            {
                ListViewItem listViewItem = new ListViewItem(item.Categoria);
                listViewItem.SubItems.Add(item.Valor.ToString());
                listView_categorias_despesa.Items.Add(listViewItem);
            }
        }


    }
}
