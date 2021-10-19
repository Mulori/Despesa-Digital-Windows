using System;
using System.Windows.Forms;

namespace DespesaDigital.Views.Forms.SolicitacaoCompra
{
    public partial class frmSolicitacaoCompra : Form
    {
        public frmSolicitacaoCompra()
        {
            InitializeComponent();
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            using (var form = new frmPesquisarSolicitacaoCompra())
            {
                form.ShowDialog();
            }
        }
    }
}
