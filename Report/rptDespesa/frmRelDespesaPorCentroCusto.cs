using DespesaDigital.Code.BLL.bllDepartamento;
using DespesaDigital.Code.BLL.bllDespesa;
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

namespace DespesaDigital.Report.rptDespesa
{
    public partial class frmRelDespesaPorCentroCusto : Form
    {

        public static DateTime inicio { get; set; }
        public static DateTime fim { get; set; }
        public static int codigo_forma_pagamento { get; set; }
        public static int codigo_tipo_despesa { get; set; }
        public static string centro_custo { get; set; }
        public static int codigo_setor { get; set; }

        public frmRelDespesaPorCentroCusto(DateTime _inicio, DateTime _fim, int _codigo_setor, int _codigo_forma_pagamento, int _codigo_tipo_despesa, string _centro_custo)
        {
            InitializeComponent();
            inicio = _inicio;
            fim = _fim;
            codigo_forma_pagamento = _codigo_forma_pagamento;
            codigo_tipo_despesa = _codigo_tipo_despesa;
            centro_custo = _centro_custo;
            codigo_setor = _codigo_setor;
        }

        private void frmRelDespesaPorCentroCusto_Load(object sender, EventArgs e)
        {
            var departamento = bllDepartamento.DepartamentoPorCodigo(VariaveisGlobais.codigo_departamento);

            var list = bllDespesa.RelDespesaPorCentroCusto(inicio, fim, codigo_setor, codigo_forma_pagamento, codigo_tipo_despesa);
            DataTable customerTable = list.Tables[0];
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("nomeSetor", centro_custo));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("nomeDepartamento", departamento.nome));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("periodo", inicio.ToString("dd/MM/yyyy") + " Até " + fim.ToString("dd/MM/yyyy")));
            this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsCentroCusto", customerTable));


            this.reportViewer1.RefreshReport();
        }
    }
}
