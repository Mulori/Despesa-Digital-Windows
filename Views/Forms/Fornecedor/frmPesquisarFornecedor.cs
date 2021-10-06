using DespesaDigital.Code.BLL.bllFornecedor;
using DespesaDigital.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DespesaDigital.Views.Forms.Fornecedor
{
    public partial class frmPesquisarFornecedor : Form
    {
        public frmPesquisarFornecedor()
        {
            InitializeComponent();
            Inicializar();
        }

        void Inicializar()
        {
            dataGrid.DataSource = bllFornecedor.ListarTodosFornecedores();
        }

        private void mskCNPJ_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (mskCNPJ.Text.Length == 18)
                {
                    dataGrid.DataSource = bllFornecedor.ListarTodosFornecedoresPorCNPJ(coreFormat.SemFormatacao(mskCNPJ.Text));
                }                
            }
        }

        private void txtRazaoSocial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                dataGrid.DataSource = bllFornecedor.ListarTodosFornecedoresPorRazaoSocial(txtRazaoSocial.Text);
            }
        }
    }
}
