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
    public partial class frmFiltroRelDespesaPorDepartamento : Form
    {
        public frmFiltroRelDespesaPorDepartamento()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var rel = new frmRelDespesaPorDepartamento())
            {
                rel.Show();
            }
        }
    }
}
