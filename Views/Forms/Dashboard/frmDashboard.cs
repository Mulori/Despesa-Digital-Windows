﻿using DespesaDigital.Code.BLL.bllDespesa;
using DespesaDigital.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DespesaDigital.Views.Forms.Dashboard
{
    public partial class frmDashboard : Form
    {
        List<int> codigo_setor;

        public frmDashboard()
        {
            InitializeComponent();
            inicializar();
        }

        private void inicializar()
        {
            charSetorPorAno.Size = new Size(1188, 480);
            charSetorPorAno.Location = new Point(95, 41);

            //Grafico de Pizza
            chartValorDespesaPorSetor.DataSource = bllDespesa.DashboardTodoPeriodo();
            chartValorDespesaPorSetor.Series["despesa"].Label = "#PERCENT";
            chartValorDespesaPorSetor.Series["despesa"].LegendText = "#AXISLABEL";
            chartValorDespesaPorSetor.Series["despesa"].XValueMember = "CentrodeCusto";
            chartValorDespesaPorSetor.Series["despesa"].YValueMembers = "ValorDespesa";
            chartValorDespesaPorSetor.Titles.Add("Total de despesas por centro de custo");

            codigo_setor = new List<int>();

            var list_ano = bllDespesa.DashboardPeriodoUmAno();

            charSetorPorAno.ChartAreas["ChartArea1"].AxisX.Maximum = 0;

            foreach (var mes in list_ano)
            {
                if (!existeRegistroLista(mes.i_setor))
                {
                    charSetorPorAno.Series.Add(mes.s_setor);
                    charSetorPorAno.Series[mes.s_setor].ChartType = SeriesChartType.Column;
                    
                    codigo_setor.Add(mes.i_setor);
                }

                if (charSetorPorAno.ChartAreas["ChartArea1"].AxisX.Maximum < Convert.ToDouble(mes.valor))
                {
                    charSetorPorAno.ChartAreas["ChartArea1"].AxisX.Maximum = Convert.ToDouble(mes.valor);
                }

                //charSetorPorAno.ChartAreas["ChartArea1"].AxisX.Maximum;
                charSetorPorAno.Series[mes.s_setor].Points.AddXY(coreNumericToString.MesNumericoParaMesCaracter(mes.i_mes), mes.valor);
            }
            charSetorPorAno.Titles.Add("Levantamento de despesa no periodo de 1 ano");
        }

        public bool existeRegistroLista(int codigo)
        {
            if(codigo_setor.Count == 0)
            {
                return false;
            }

            foreach (var setor in codigo_setor)
            {
                if (setor == codigo)
                {
                    return true;   
                }
            }

            return false;
        }
    }
}
