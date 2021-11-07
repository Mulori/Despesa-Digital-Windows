using DespesaDigital.Code.BLL.bllDespesa;
using System;
using System.Data;
using System.Windows.Forms;

namespace DespesaDigital.Report.rptDespesa
{
    public partial class frmRelDespesaPorDepartamento : Form
    {
        public static DateTime inicio { get; set; }
        public static DateTime fim { get; set; }

        public frmRelDespesaPorDepartamento(DateTime _inicio, DateTime _fim)
        {
            InitializeComponent();
            inicio = _inicio;
            fim = _fim;
        }

        private void frmRelDespesaPorDepartamento_Load(object sender, EventArgs e)
        {
            var list = bllDespesa.relTodasDespesasPorDepartamentoData(inicio, fim);
            DataTable customerTable = list.Tables[0];
            this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("dsDespesasPorDepartamento", customerTable));
            this.reportViewer1.RefreshReport();
        }
    }
}
