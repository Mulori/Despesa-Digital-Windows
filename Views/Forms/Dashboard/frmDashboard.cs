using DespesaDigital.Code.BLL;
using DespesaDigital.Code.BLL.bllDespesa;
using DespesaDigital.Core;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DespesaDigital.Views.Forms.Dashboard
{
    public partial class frmDashboard : Form
    {
        private bool mouseDown;
        private Point lastLocation;

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

        private void pnTotalDespesa_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void pnTotalDespesa_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                pnTotalDespesa.Location = new Point(
                    (pnTotalDespesa.Location.X - lastLocation.X) + e.X, (pnTotalDespesa.Location.Y - lastLocation.Y) + e.Y);

                pnTotalDespesa.Update();
            }
        }

        private void pnTotalDespesa_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void pnColaboradores_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void pnColaboradores_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                pnColaboradores.Location = new Point(
                    (pnColaboradores.Location.X - lastLocation.X) + e.X, (pnColaboradores.Location.Y - lastLocation.Y) + e.Y);

                pnColaboradores.Update();
            }
        }

        private void pnColaboradores_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void pnUltimaDespesa_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void pnUltimaDespesa_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                pnUltimaDespesa.Location = new Point(
                    (pnUltimaDespesa.Location.X - lastLocation.X) + e.X, (pnUltimaDespesa.Location.Y - lastLocation.Y) + e.Y);

                pnUltimaDespesa.Update();
            }
        }

        private void pnUltimaDespesa_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void pnTotalGrafico_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void pnTotalGrafico_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                pnTotalGrafico.Location = new Point(
                    (pnTotalGrafico.Location.X - lastLocation.X) + e.X, (pnTotalGrafico.Location.Y - lastLocation.Y) + e.Y);

                pnTotalGrafico.Update();
            }
        }

        private void pnTotalGrafico_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void chartValorDespesaPorSetor_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void chartValorDespesaPorSetor_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                pnTotalGrafico.Location = new Point(
                    (pnTotalGrafico.Location.X - lastLocation.X) + e.X, (pnTotalGrafico.Location.Y - lastLocation.Y) + e.Y);

                pnTotalGrafico.Update();
            }
        }

        private void chartValorDespesaPorSetor_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void pnQuantidadeDespesa_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void pnQuantidadeDespesa_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                pnQuantidadeDespesa.Location = new Point(
                    (pnQuantidadeDespesa.Location.X - lastLocation.X) + e.X, (pnQuantidadeDespesa.Location.Y - lastLocation.Y) + e.Y);

                pnQuantidadeDespesa.Update();
            }
        }

        private void pnQuantidadeDespesa_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void charDespesaNosUltimo6Meses_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void charDespesaNosUltimo6Meses_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                pnQuantidadeDespesa.Location = new Point(
                    (pnQuantidadeDespesa.Location.X - lastLocation.X) + e.X, (pnQuantidadeDespesa.Location.Y - lastLocation.Y) + e.Y);

                pnQuantidadeDespesa.Update();
            }
        }

        private void charDespesaNosUltimo6Meses_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }
}
