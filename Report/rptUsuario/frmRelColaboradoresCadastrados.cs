using DespesaDigital.Code.BLL;
using DespesaDigital.Code.BLL.bllDepartamento;
using DespesaDigital.Core;
using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Windows.Forms;

namespace DespesaDigital.Report.rptUsuario
{
    public partial class frmRelColaboradoresCadastrados : Form
    {
        public static int codigo_setor { get; set; }
        public static string status { get; set; }
        public static int nivel_acesso { get; set; }
        public frmRelColaboradoresCadastrados(int _codigo_setor, string _status, int _nivel_acesso)
        {
            InitializeComponent();
            codigo_setor = _codigo_setor;
            status = _status;
            nivel_acesso = _nivel_acesso;
        }

        private void frmRelColaboradoresCadastrados_Load(object sender, EventArgs e)
        {
            var departamento = bllDepartamento.DepartamentoPorCodigo(VariaveisGlobais.codigo_departamento);
            var list = bllUsuario.RelColaboradoresCadastrados(nivel_acesso, status, codigo_setor);
            DataTable customerTable = list.Tables[0];
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("departamento", departamento.nome));
            this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsUsuario", customerTable));

            this.reportViewer1.RefreshReport();
        }
    }
}
