using Controller.ModuloRelatorios;
using Model.ModuloEntrada;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View.ModuloRelatorios
{

    public partial class RelatoriosView : Form
    {

        private readonly IRelatorioController _relatorioController;

        public RelatoriosView(IRelatorioController relatorioController)
        {
            InitializeComponent();
            _relatorioController = relatorioController;
        }

        private void RelatoriosView_Load(object sender, EventArgs e)
        {
            var relatorios = _relatorioController.GetAll().ToList();
            cboRelatorios.DataSource = relatorios;
            cboRelatorios.DisplayMember = "Nome";
            cboRelatorios.ValueMember = "Id";
            cboRelatorios.SelectedIndex = -1;

            setPeriodoFiltro();
        }

        private void btnGerarRelatorio_Click(object sender, EventArgs e)
        {
            var relatorioDto = (RelatorioDto)cboRelatorios.SelectedItem;
            object source = null;

            if (relatorioDto.Id == 1)
            {
                source = _relatorioController.GetEntradasMensais(dtpPeriodoFiltro.Value);
                setGridViewRelatorioEntradaMensal(source);
            }

            if (relatorioDto.Id == 2)
            {
                source = _relatorioController.GetEntradasAnuais(dtpPeriodoFiltro.Value);
                setGridViewRelatorioEntradaAnuais(source);
            }

        }



        private void dgvRelatorio_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRow r = dgvRelatorio.Rows[e.RowIndex];
            if (r.Cells.Count > 1 && r.Cells[0].Value.ToString() == "TOTAL")
                r.DefaultCellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);

            if (r.Cells.Count > 3 && r.Cells[2].Value.ToString() == "TOTAL")
                r.DefaultCellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);



        }

        private void setPeriodoFiltro()
        {
            dtpPeriodoFiltro.Value = DateTime.Now;
            dtpPeriodoFiltro.Format = DateTimePickerFormat.Custom;
            dtpPeriodoFiltro.CustomFormat = "MM/yyyy";
        }


        private void setGridViewRelatorioEntradaMensal(object dataSource)
        {
            dgvRelatorio.DataSource = dataSource;
            dgvRelatorio.ReadOnly = true;

            dgvRelatorio.Columns["CategoriaDescricao"].HeaderText = "Categoria";
            dgvRelatorio.Columns["CategoriaDescricao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvRelatorio.Columns["Valor"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvRelatorio.Columns["Valor"].DefaultCellStyle.Format = "c2";
            dgvRelatorio.Columns["Valor"].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("pt-BR");

            dgvRelatorio.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dgvRelatorio.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            dgvRelatorio.RowsDefaultCellStyle.SelectionBackColor = Color.NavajoWhite;
            dgvRelatorio.RowsDefaultCellStyle.SelectionForeColor = Color.Black;

        }

        private void setGridViewRelatorioEntradaAnuais(object dataSource)
        {
            dgvRelatorio.DataSource = dataSource;
            dgvRelatorio.ReadOnly = true;

            dgvRelatorio.Columns["Ordem"].Visible = false;
            dgvRelatorio.Columns["IdCategoria"].Visible = false;

            dgvRelatorio.Columns["DescricaoCategoria"].HeaderText = "Categoria";
            dgvRelatorio.Columns["DescricaoCategoria"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            dgvRelatorio.Columns["ValorJaneiro"].HeaderText = "Janeiro";
            dgvRelatorio.Columns["ValorJaneiro"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvRelatorio.Columns["ValorJaneiro"].DefaultCellStyle.Format = "C2";
            dgvRelatorio.Columns["ValorJaneiro"].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("pt-BR");

            dgvRelatorio.Columns["ValorFevereiro"].HeaderText = "Fevereiro";
            dgvRelatorio.Columns["ValorFevereiro"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvRelatorio.Columns["ValorFevereiro"].DefaultCellStyle.Format = "C2";
            dgvRelatorio.Columns["ValorFevereiro"].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("pt-BR");

            dgvRelatorio.Columns["ValorMarco"].HeaderText = "Março";
            dgvRelatorio.Columns["ValorMarco"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvRelatorio.Columns["ValorMarco"].DefaultCellStyle.Format = "C2";
            dgvRelatorio.Columns["ValorMarco"].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("pt-BR");

            dgvRelatorio.Columns["ValorAbril"].HeaderText = "Abril";
            dgvRelatorio.Columns["ValorAbril"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvRelatorio.Columns["ValorAbril"].DefaultCellStyle.Format = "C2";
            dgvRelatorio.Columns["ValorAbril"].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("pt-BR");

            dgvRelatorio.Columns["ValorMaio"].HeaderText = "Maio";
            dgvRelatorio.Columns["ValorMaio"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvRelatorio.Columns["ValorMaio"].DefaultCellStyle.Format = "C2";
            dgvRelatorio.Columns["ValorMaio"].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("pt-BR");

            dgvRelatorio.Columns["ValorJunho"].HeaderText = "Junho";
            dgvRelatorio.Columns["ValorJunho"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvRelatorio.Columns["ValorJunho"].DefaultCellStyle.Format = "C2";
            dgvRelatorio.Columns["ValorJunho"].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("pt-BR");

            dgvRelatorio.Columns["ValorJulho"].HeaderText = "Julho";
            dgvRelatorio.Columns["ValorJulho"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvRelatorio.Columns["ValorJulho"].DefaultCellStyle.Format = "C2";
            dgvRelatorio.Columns["ValorJulho"].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("pt-BR");

            dgvRelatorio.Columns["ValorAgosto"].HeaderText = "Agosto";
            dgvRelatorio.Columns["ValorAgosto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvRelatorio.Columns["ValorAgosto"].DefaultCellStyle.Format = "C2";
            dgvRelatorio.Columns["ValorAgosto"].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("pt-BR");

            dgvRelatorio.Columns["ValorSetembro"].HeaderText = "Setembro";
            dgvRelatorio.Columns["ValorSetembro"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvRelatorio.Columns["ValorSetembro"].DefaultCellStyle.Format = "C2";
            dgvRelatorio.Columns["ValorSetembro"].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("pt-BR");

            dgvRelatorio.Columns["ValorOutubro"].HeaderText = "Outubro";
            dgvRelatorio.Columns["ValorOutubro"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvRelatorio.Columns["ValorOutubro"].DefaultCellStyle.Format = "C2";
            dgvRelatorio.Columns["ValorOutubro"].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("pt-BR");

            dgvRelatorio.Columns["ValorNovembro"].HeaderText = "Novembro";
            dgvRelatorio.Columns["ValorNovembro"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvRelatorio.Columns["ValorNovembro"].DefaultCellStyle.Format = "C2";
            dgvRelatorio.Columns["ValorNovembro"].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("pt-BR");

            dgvRelatorio.Columns["ValorDezembro"].HeaderText = "Dezembro";
            dgvRelatorio.Columns["ValorDezembro"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvRelatorio.Columns["ValorDezembro"].DefaultCellStyle.Format = "C2";
            dgvRelatorio.Columns["ValorDezembro"].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("pt-BR");

            dgvRelatorio.Columns["ValorTotalCategoria"].HeaderText = "Total";
            dgvRelatorio.Columns["ValorTotalCategoria"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvRelatorio.Columns["ValorTotalCategoria"].DefaultCellStyle.Format = "C2";
            dgvRelatorio.Columns["ValorTotalCategoria"].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("pt-BR");

            dgvRelatorio.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dgvRelatorio.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            dgvRelatorio.RowsDefaultCellStyle.SelectionBackColor = Color.NavajoWhite;
            dgvRelatorio.RowsDefaultCellStyle.SelectionForeColor = Color.Black;
        }


    }
}
