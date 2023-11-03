﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ModuloRelatorios
{
    public class EntradaMensal
    {
        public DateTime DataEntrada { get; set; }
        public string CategoriaDescricao { get; set; }
        public string EntradaDescricao { get; set; }
        public decimal Valor { get; set; }
    }
}
