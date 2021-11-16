using DespesaDigital.Code.BLL.bllDepartamento;
using DespesaDigital.Code.BLL.bllSolicitacaoCompra;
using DespesaDigital.Core;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DespesaDigital.Report.rptSolicitacoesCompra
{
    public partial class frmRelSolicitacoesCompras : Form
    {
        public static DateTime inicio { get; set; }
        public static DateTime fim { get; set; }
        public static int codigo_setor { get; set; }
        public static int codigo_usuario { get; set; }
        public frmRelSolicitacoesCompras(DateTime _inicio, DateTime _fim, int _codigo_setor, int _codigo_usuario)
        {
            InitializeComponent();
            inicio = _inicio;
            fim = _fim;
            codigo_setor = _codigo_setor;
            codigo_usuario = _codigo_usuario;
        }

        private void frmRelSolicitacoesCompras_Load(object sender, EventArgs e)
        {
            var departamento = bllDepartamento.DepartamentoPorCodigo(VariaveisGlobais.codigo_departamento);
            var list = bllSolicitacaoCompra.RelSolicitacao(inicio, fim, codigo_setor, codigo_usuario);
            DataTable customerTable = list.Tables[0];
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("departamento", departamento.nome));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("periodo", inicio.ToString("dd/MM/yyyy") + " Até " + fim.ToString("dd/MM/yyyy")));
            this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsSolicitacao", customerTable));

            this.reportViewer1.RefreshReport();
        }
    }
}
