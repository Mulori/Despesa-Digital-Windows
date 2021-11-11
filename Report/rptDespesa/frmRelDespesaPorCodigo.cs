using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DespesaDigital.Report.rptDespesa
{
    public partial class frmRelDespesaPorCodigo : Form
    {
        public static int codigo_despesa { get; set; }
        public frmRelDespesaPorCodigo(int _codigo_despesa)
        {
            InitializeComponent();
            codigo_despesa = _codigo_despesa;
        }

        private void frmRelDespesaPorCodigo_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
