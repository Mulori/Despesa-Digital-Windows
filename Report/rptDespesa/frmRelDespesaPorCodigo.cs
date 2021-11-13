using DespesaDigital.Code.BLL.bllDespesa;
using DespesaDigital.Code.BLL.bllImagem;
using Microsoft.Reporting.WinForms;
using System;
using System.Windows.Forms;

namespace DespesaDigital.Report.rptDespesa
{
    public partial class frmRelDespesaPorCodigo : Form
    {
        public static long codigo_despesa { get; set; }
        public frmRelDespesaPorCodigo(long _codigo_despesa)
        {
            InitializeComponent();
            codigo_despesa = _codigo_despesa;
        }

        private void frmRelDespesaPorCodigo_Load(object sender, EventArgs e)
        {
            string itens = "";
            var dto = bllDespesa.RelDespesaPorCodigo(codigo_despesa);
            var list_itens = bllDespesaItens.ListarTodoProdutoDespesaPorCodigo(codigo_despesa);
            var image = bllImagem.ObterByteImagemDespesaPorCodigo(codigo_despesa);

            if(list_itens.Count > 0)
            {
                foreach (var i in list_itens)
                {
                    if (itens.Length == 0)
                    {
                        itens = i.descricao;
                    }
                    else
                    {
                        itens += ", " + i.descricao;
                    }
                }                
            }

            if(itens == null)
            {
                itens = "Nenhum item encontrado.";
            }

            if(image == null)
            {
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("comprovante", "NÃO"));
            }
            else
            {
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("comprovante", "SIM"));
            }

            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("codigo", dto.codigo.ToString()));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("data_hora", dto.data_hora_emissao.ToString()));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("valor", dto.valor.ToString()));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("usuario", dto.usuario));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("centro_custo", dto.setor));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("departamento", dto.departamento));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("forma_pagamento", dto.forma_paramento));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("tipo_despesa", dto.tipo));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("descricao", dto.descricao));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("itens", itens));

            this.reportViewer1.RefreshReport();
        }
    }
}
