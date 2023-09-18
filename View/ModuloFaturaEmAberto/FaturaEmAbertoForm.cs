using Controller.ContasPagar;
using Controller.ModuloFaturaEmAberto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View.ModuloFaturaEmAberto
{
    public partial class FaturaEmAbertoForm : BaseView
    {
        public int Id { get; set; }
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
        }

        //TODO: Refatorar
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
            var result = _controller.Insert(faturaEmAbertoDto);
            base.Message(result);
            this.Close();
        }

        private FaturaEmAbertoDto popularFaturaEmAbertoDto()
        {
            FaturaEmAbertoDto obj = new FaturaEmAbertoDto();
            obj.Id = Id;
            obj.Descricao = txtDescricao.Text;
            obj.Valor = Convert.ToDecimal(txtValor.Text);
            obj.DataCompra = dtpDataCompra.Value;
            return obj;
        }

        private void editar()
        {
            var faturaEmAbertoDto = popularFaturaEmAbertoDto();
            var result = _controller.Update(faturaEmAbertoDto);
            base.Message(result);
            this.Close();
        }
    }
}
