using Controller.ContasPagar;
using Controller.FormaPagamentos;
using Controller.ModuloSalario;
using Controller.MovimentosAnaliticos;
using Model.ContasPagar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View.ModuloSalario
{
    public partial class SalarioForm : BaseView
    {
        public int Id { get; set; }
        private readonly ISalarioController _salarioController;
        private readonly IFormaPagamentoController _formaPagamentoController;

        public SalarioForm(
            ISalarioController salarioController,
            IFormaPagamentoController formaPagamentoController)
        {
            InitializeComponent();
            _formaPagamentoController = formaPagamentoController;
            _salarioController = salarioController;
            AplicarEventos(txtValor);
        }

        private void AplicarEventos(TextBox txt)
        {
            txtValor.KeyPress += ValidaValores;
        }

        private void SalarioForm_Load(object sender, EventArgs e)
        {
            setDataVencimento();
            popularListaFormaPagamento();

            if (Id != -1)
            {
                var salario = _salarioController.GetById(Id);
                popularComponentesFormulario(salario);
            }
        }



        private void setDataVencimento()
        {
            dtpDataSalario.Value = DateTime.Now;
            dtpDataSalario.Format = DateTimePickerFormat.Custom;
            dtpDataSalario.CustomFormat = "dd/MM/yyyy";
        }

        private void popularListaFormaPagamento()
        {
            var source = _formaPagamentoController.GetAll().OrderBy(x => x.Descricao);
            cboFormaPagamento.DataSource = source.ToList();
            cboFormaPagamento.DisplayMember = "Descricao";
            cboFormaPagamento.ValueMember = "Id";
            cboFormaPagamento.SelectedIndex = -1;
        }

        private void popularComponentesFormulario(SalarioDto salario)
        {
            txtId.Text = salario.Id.ToString();
            txtDescricao.Text = salario.Descricao;
            dtpDataSalario.Value = salario.DataSalario;
            txtValor.Text = salario.Valor.ToString();
            var formaPagamento = _formaPagamentoController.GetById(salario.IdFormaPagamento);
            cboFormaPagamento.SelectedIndex = cboFormaPagamento.FindString(formaPagamento.Descricao);
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
            var salarioDto = popularSalarioDto();
            var result = _salarioController.Insert(salarioDto);
            base.Message(result);
            this.Close();
        }

        private void editar()
        {
            var salarioDto = popularSalarioDto();
            var result = _salarioController.Update(salarioDto);
            base.Message(result);
            this.Close();
        }

        private SalarioDto popularSalarioDto()
        {
            SalarioDto obj = new SalarioDto();
            obj.Id = Id;
            obj.Descricao = txtDescricao.Text;
            obj.DataSalario = dtpDataSalario.Value;
            obj.Valor = Convert.ToDecimal(txtValor.Text);
            obj.IdFormaPagamento = Convert.ToInt16(cboFormaPagamento.SelectedValue?.ToString());

            return obj;
        }
    }
}
