using DespesaDigital.Code.BLL;
using DespesaDigital.Code.BLL.bllDespesa;
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

namespace DespesaDigital.Report.rptDespesa
{
    public partial class frmRelDespesaPorColaborador : Form
    {
        public static DateTime inicio { get; set; }
        public static DateTime fim { get; set; }
        public static int codigo_usuario { get; set; }

        public frmRelDespesaPorColaborador(DateTime _inicio, DateTime _fim, int _codigo_usuario)
        {
            InitializeComponent();
            inicio = _inicio;
            fim = _fim;
            codigo_usuario = _codigo_usuario;
        }

        private void frmRelDespesaPorColaborador_Load(object sender, EventArgs e)
        {
            var usuario = bllUsuario.UsuarioPorCodigo(codigo_usuario);            

            var list = bllDespesa.RelDespesaPorColaborador(inicio, fim, codigo_usuario, usuario.codigo_setor);
            DataTable customerTable = list.Tables[0];
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("txtColaborador", "Murilo"));

            this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dtSet", customerTable));

            this.reportViewer1.RefreshReport();
        }
    }
}
