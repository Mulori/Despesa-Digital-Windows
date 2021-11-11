using DespesaDigital.Core;
using DespesaDigital.Report.rptDespesa;
using System;
using System.Windows.Forms;

namespace DespesaDigital.Views.Forms.Relatorio.Despesa
{
    public partial class frmFiltroRelDespesaPorDepartamento : Form
    {
        public frmFiltroRelDespesaPorDepartamento()
        {
            InitializeComponent();

            mskInicial.Text = DateTime.Today.ToString("dd/MM/yyyy");
            mskFinal.Text = DateTime.Today.ToString("dd/MM/yyyy");
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            DateTime inicial;
            DateTime final;

            try
            {
                inicial = Convert.ToDateTime(mskInicial.Text);
            }
            catch
            {
                corePopUp.exibirMensagem("A data inicial não é valida.", "Atenção");
                mskInicial.Mask = "";
                mskInicial.Text = "";
                mskInicial.Mask = "##/##/####";

                mskInicial.Focus();
                return;
            }

            try
            {
                final = Convert.ToDateTime(mskFinal.Text);
            }
            catch
            {
                corePopUp.exibirMensagem("A data final não é valida.", "Atenção");
                mskFinal.Mask = "";
                mskFinal.Text = "";
                mskFinal.Mask = "##/##/####";

                mskFinal.Focus();
                return;
            }

            if (inicial > final)
            {
                corePopUp.exibirMensagem("A data inicial não pode ser menor que a data final.", "Atenção");
                return;
            }

            using (var rel = new frmRelDespesaPorDepartamento(inicial, final))
            {
                rel.ShowDialog();
            }
        }

        private void mskInicial_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void mskFinal_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
