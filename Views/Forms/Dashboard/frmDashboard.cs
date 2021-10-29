using DespesaDigital.Code.BLL.bllDespesa;
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
        public frmDashboard()
        {
            InitializeComponent();
            inicializar();
        }

        private void inicializar()
        {
            chartValorDespesaPorSetor.DataSource = bllDespesa.DashboardTodoPeriodo();
            chartValorDespesaPorSetor.Series["despesa"].XValueMember = "CentrodeCusto";
            chartValorDespesaPorSetor.Series["despesa"].YValueMembers = "ValorDespesa";            
            chartValorDespesaPorSetor.Titles.Add("Total de despesas por centro de custo");

            //chartValorDespesaPorSetor.Series.Clear();
            //chartValorDespesaPorSetor.Series.Add("despesa");
            //chartValorDespesaPorSetor.Series.FindByName("despesa").ChartType = SeriesChartType.Pie;

            //var list = bllDespesa.DashboardTodoPeriodo();
            //foreach (var i in list)
            //{
            //    chartValorDespesaPorSetor.Series["despesa"].Points.AddXY(i.centro_custo, i.valor);
            //}

            //chartValorDespesaPorSetor.Titles.Add("Total de despesas por centro de custo");
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            chartValorDespesaPorSetor.DataSource = bllDespesa.DashboardTodoPeriodo();
            chartValorDespesaPorSetor.Series["despesa"].XValueMember = "CentrodeCusto";
            chartValorDespesaPorSetor.Series["despesa"].YValueMembers = "ValorDespesa";
            chartValorDespesaPorSetor.Titles.Add("Total de despesas por centro de custo");
        }

        public class Record
        {
            int id, age;
            string name;
            public Record(int id, string name, int age)
            {
                this.id = id;
                this.name = name;
                this.age = age;
            }
            public int ID
            {
                get { return id; }
                set { id = value; }
            }
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            public int Age
            {
                get { return age; }
                set { age = value; }
            }
        }
    }
}
