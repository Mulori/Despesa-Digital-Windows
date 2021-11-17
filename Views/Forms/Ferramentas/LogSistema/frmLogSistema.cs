using DespesaDigital.Code.BLL.bllLogSistema;
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

namespace DespesaDigital.Views.Forms.Ferramentas.LogSistema
{
    public partial class frmLogSistema : Form
    {
        public frmLogSistema()
        {
            InitializeComponent();
            mskInicial.Text = DateTime.Today.ToString("dd/MM/yyyy");
            mskFinal.Text = DateTime.Today.ToString("dd/MM/yyyy");

            var dados = bllLogSistema.SelecionarLogs(Convert.ToDateTime(DateTime.Today.ToString("yyyy-MM-dd")), Convert.ToDateTime(DateTime.Today.ToString("yyyy-MM-dd")), txtEmail.Text.Trim());
            dataGrid.DataSource = dados;
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
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

            var dados = bllLogSistema.SelecionarLogs(inicial, final, txtEmail.Text.Trim());
            dataGrid.DataSource = dados;
        }

        private void dataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var descricao = dataGrid.CurrentRow.Cells[3].Value.ToString();

            MessageBox.Show($"DESCRIÇÃO: {descricao}", "Visualizar Descrição", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
