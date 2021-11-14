using DespesaDigital.Code.BLL.bllDespesa;
using DespesaDigital.Core;
using DespesaDigital.Report.rptDespesa;
using DespesaDigital.Views.Forms.Despesa;
using System;
using System.Windows.Forms;

namespace DespesaDigital.Views.Forms.Relatorio.Despesa
{
    public partial class frmFiltroRelDespesaPorCodigo : Form
    {
        public frmFiltroRelDespesaPorCodigo()
        {
            InitializeComponent();
            txtCodigo.Focus();
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            if(txtCodigo.Text.Length == 0)
            {
                corePopUp.exibirMensagem("Informe o código de lançamento da despesa.", "Atenção");
                return;
            }

            if (bllDespesa.DespesaPorCodigo(Convert.ToInt32(txtCodigo.Text)).codigo == 0)
            {
                corePopUp.exibirMensagem("Nenhuma despesa encontrada com o código informado.", "Atenção");
                return;
            }

            using (var rel = new frmRelDespesaPorCodigo(Convert.ToInt32(txtCodigo.Text)))
            {
                rel.ShowDialog();
            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar == ','))
            {
                e.Handled = true;
                corePopUp.exibirMensagem("Este campo aceita somente números", "Atenção");
            }
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F10)
            {
                using (var form = new frmPesquisarDespesa())
                {
                    form.ShowDialog();
                    txtCodigo.Text = "";
                    txtCodigo.Text = VariaveisGlobais.codigo_despesa_pesquisa.ToString();
                }
            }
        }
    }
}
