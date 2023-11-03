﻿using Controller.ModuloRelatorios;
using Model.ModuloEntrada;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            }

            setDataGridView(source);


        }

        private void setPeriodoFiltro()
        {
            dtpPeriodoFiltro.Value = DateTime.Now;
            dtpPeriodoFiltro.Format = DateTimePickerFormat.Custom;
            dtpPeriodoFiltro.CustomFormat = "MM/yyyy";
        }

        private void setDataGridView(object source)
        {
            dgvRelatorio.DataSource = source;
            dgvRelatorio.ReadOnly = true;

        }
    }
}
