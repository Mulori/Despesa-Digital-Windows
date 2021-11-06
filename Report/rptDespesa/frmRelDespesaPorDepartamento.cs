using DespesaDigital.Code.BLL.bllDespesa;
using System;
using System.Data;
using System.Windows.Forms;

namespace DespesaDigital.Report.rptDespesa
{
    public partial class frmRelDespesaPorDepartamento : Form
    {
        public frmRelDespesaPorDepartamento()
        {
            InitializeComponent();
        }

        private void frmRelDespesaPorDepartamento_Load(object sender, EventArgs e)
        {
            var list = bllDespesa.TodasDespesa();
            DataTable customerTable = list.Tables[0];

            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("dsDespesas1", customerTable));

            reportViewer1.RefreshReport();

            this.reportViewer1.RefreshReport();
        }
    }
}
