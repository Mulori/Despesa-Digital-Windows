using DespesaDigital.Code.BLL;
using DespesaDigital.Code.BLL.bllDespesa;
using DespesaDigital.Code.BLL.bllSetor;
using DespesaDigital.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DespesaDigital.Views.Forms.Dashboard
{
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
            inicializar();
        }

        private void inicializar()
        {
            try
            {
                var total = bllDespesa.DashboardTotalDespesa();

                if (string.IsNullOrEmpty(total.ToString()))
                {
                    return;
                }

                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("pt-BR");
                lbTotalDespesa.Text = string.Format("{0:C}", Convert.ToDouble(total));
            }
            catch
            {
                corePopUp.exibirMensagem("Ocorreu um erro ao converter o valor para moeda, verifique o campo valor!", "Erro de conversão");
                lbTotalDespesa.Text = "R$ 0,00";
            }

            lbTotalUsuario.Text = bllUsuario.DashboardTotalUsuario().ToString();

            try
            {
                var total = bllDespesa.DashboardValorUltimaDespesa();

                if (string.IsNullOrEmpty(total.ToString()))
                {
                    return;
                }

                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("pt-BR");
                lblValorUltimaDespesa.Text = string.Format("{0:C}", Convert.ToDouble(total));
            }
            catch
            {
                corePopUp.exibirMensagem("Ocorreu um erro ao converter o valor para moeda, verifique o campo valor!", "Erro de conversão");
                lblValorUltimaDespesa.Text = "R$ 0,00";
            }

            //Grafico 1
            chartValorDespesaPorSetor.DataSource = bllDespesa.DashboardTodoPeriodo();
            chartValorDespesaPorSetor.Series["despesa"].Label = "#PERCENT";
            chartValorDespesaPorSetor.Series["despesa"].LegendText = "#AXISLABEL";
            chartValorDespesaPorSetor.Series["despesa"].XValueMember = "CentrodeCusto";
            chartValorDespesaPorSetor.Series["despesa"].YValueMembers = "ValorDespesa";

            //Grafico 2
            charDespesaNosUltimo6Meses.DataSource = bllDespesa.DashboardQuantidadeDespesa();
            charDespesaNosUltimo6Meses.Series["despesa"].Label = "#PERCENT";
            charDespesaNosUltimo6Meses.Series["despesa"].LegendText = "#AXISLABEL";
            charDespesaNosUltimo6Meses.Series["despesa"].XValueMember = "nome";
            charDespesaNosUltimo6Meses.Series["despesa"].YValueMembers = "quantidade";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                var total = bllDespesa.DashboardValorUltimaDespesa();

                if (string.IsNullOrEmpty(total.ToString()))
                {
                    return;
                }

                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("pt-BR");
                lblValorUltimaDespesa.Text = string.Format("{0:C}", Convert.ToDouble(total));
            }
            catch
            {
                corePopUp.exibirMensagem("Ocorreu um erro ao converter o valor para moeda, verifique o campo valor!", "Erro de conversão");
                lblValorUltimaDespesa.Text = "R$ 0,00";
            }
        }
    }
}
