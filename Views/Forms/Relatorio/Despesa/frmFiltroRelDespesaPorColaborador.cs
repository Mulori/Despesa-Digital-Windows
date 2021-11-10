using DespesaDigital.Core;
using DespesaDigital.Report.rptDespesa;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DespesaDigital.Views.Forms.Relatorio.Despesa
{
    public partial class frmFiltroRelDespesaPorColaborador : Form
    {
        public frmFiltroRelDespesaPorColaborador()
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
                mskInicial.Mask = "__/__/____";

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
                mskFinal.Mask = "__/__/____";

                mskFinal.Focus();
                return;
            }

            if (inicial > final)
            {
                corePopUp.exibirMensagem("A data inicial não pode ser menor que a data final.", "Atenção");
                return;
            }

            using (var rel = new frmRelDespesaPorColaborador(inicial, final, 130))
            {
                rel.ShowDialog();
            }
        }
    }
}
