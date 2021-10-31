﻿using DespesaDigital.Code.BLL.bllProduto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DespesaDigital.Views.Forms.Despesa
{
    public partial class frmPesquisaProdutoDespesa : Form
    {
        public frmPesquisaProdutoDespesa()
        {
            InitializeComponent();
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            dataGrid.DataSource = bllProduto.ListarTodosProdutosPorStatusDescricao("A", txtPesquisa.Text);
        }
    }
}
