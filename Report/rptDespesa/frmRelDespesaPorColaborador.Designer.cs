﻿
namespace DespesaDigital.Report.rptDespesa
{
    partial class frmRelDespesaPorColaborador
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRelDespesaPorColaborador));
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dtoRelDespesaPorDepartamentoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dtoDespesaItensBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dtoRelDespesaPorDepartamentoBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtoRelDespesaPorDepartamentoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtoDespesaItensBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtoRelDespesaPorDepartamentoBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "dsDespesaPorColaborador";
            reportDataSource1.Value = this.dtoRelDespesaPorDepartamentoBindingSource1;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "DespesaDigital.Report.rptDespesa.relDespesaPorColaborador.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1015, 618);
            this.reportViewer1.TabIndex = 0;
            // 
            // dtoRelDespesaPorDepartamentoBindingSource
            // 
            this.dtoRelDespesaPorDepartamentoBindingSource.DataSource = typeof(DespesaDigital.Code.DTO.dtoDespesa.dtoRelDespesaPorDepartamento);
            // 
            // dtoDespesaItensBindingSource
            // 
            this.dtoDespesaItensBindingSource.DataSource = typeof(DespesaDigital.Code.DTO.dtoDespesa.dtoDespesaItens);
            // 
            // dtoRelDespesaPorDepartamentoBindingSource1
            // 
            this.dtoRelDespesaPorDepartamentoBindingSource1.DataSource = typeof(DespesaDigital.Code.DTO.dtoDespesa.dtoRelDespesaPorDepartamento);
            // 
            // frmRelDespesaPorColaborador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 618);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRelDespesaPorColaborador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatório de Despesa por Colaborador";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRelDespesaPorColaborador_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtoRelDespesaPorDepartamentoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtoDespesaItensBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtoRelDespesaPorDepartamentoBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource dtoRelDespesaPorDepartamentoBindingSource;
        private System.Windows.Forms.BindingSource dtoRelDespesaPorDepartamentoBindingSource1;
        private System.Windows.Forms.BindingSource dtoDespesaItensBindingSource;
    }
}