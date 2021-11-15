using DespesaDigital.Code.BLL.bllDepartamento;
using DespesaDigital.Code.BLL.bllDespesa;
using DespesaDigital.Core;
using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Windows.Forms;

namespace DespesaDigital.Report.rptItem
{
    public partial class frmRelItensMaisAdquiridos : Form
    {
        public static int codigo_categoria { get; set; }
        public frmRelItensMaisAdquiridos(int _codigo_categoria)
        {
            InitializeComponent();
            codigo_categoria = _codigo_categoria;
        }

        private void frmRelItensMaisAdquiridos_Load(object sender, EventArgs e)
        {
            var departamento = bllDepartamento.DepartamentoPorCodigo(VariaveisGlobais.codigo_departamento);
            var list = bllDespesaItens.RelProdutosMaisAdquiridos(codigo_categoria);
            DataTable customerTable = list.Tables[0];
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("departamento", departamento.nome));
            this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsItens", customerTable));
            this.reportViewer1.RefreshReport();
        }
    }
}
