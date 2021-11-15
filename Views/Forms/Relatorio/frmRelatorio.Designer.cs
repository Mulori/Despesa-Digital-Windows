
namespace DespesaDigital.Views.Forms.Relatorio
{
    partial class frmRelatorio
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.despesasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.despesasPorDepartamentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.despesasPorColaboradorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.despesasPorCentroDeCustoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.despesasPorCodigoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.solicitaçõesDeComprasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colaboradoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itensToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.relatórioDeItensMaisAdquiridosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelRelatorio = new System.Windows.Forms.Panel();
            this.relatórioDeColaboradoresCadastradosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.despesasToolStripMenuItem,
            this.solicitaçõesDeComprasToolStripMenuItem,
            this.colaboradoresToolStripMenuItem,
            this.itensToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1223, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // despesasToolStripMenuItem
            // 
            this.despesasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.despesasPorDepartamentoToolStripMenuItem,
            this.despesasPorColaboradorToolStripMenuItem,
            this.despesasPorCentroDeCustoToolStripMenuItem,
            this.despesasPorCodigoToolStripMenuItem});
            this.despesasToolStripMenuItem.Name = "despesasToolStripMenuItem";
            this.despesasToolStripMenuItem.Size = new System.Drawing.Size(86, 24);
            this.despesasToolStripMenuItem.Text = "Despesas";
            // 
            // despesasPorDepartamentoToolStripMenuItem
            // 
            this.despesasPorDepartamentoToolStripMenuItem.Name = "despesasPorDepartamentoToolStripMenuItem";
            this.despesasPorDepartamentoToolStripMenuItem.Size = new System.Drawing.Size(287, 24);
            this.despesasPorDepartamentoToolStripMenuItem.Text = "Despesas por Departamento";
            this.despesasPorDepartamentoToolStripMenuItem.Click += new System.EventHandler(this.despesasPorDepartamentoToolStripMenuItem_Click);
            // 
            // despesasPorColaboradorToolStripMenuItem
            // 
            this.despesasPorColaboradorToolStripMenuItem.Name = "despesasPorColaboradorToolStripMenuItem";
            this.despesasPorColaboradorToolStripMenuItem.Size = new System.Drawing.Size(287, 24);
            this.despesasPorColaboradorToolStripMenuItem.Text = "Despesas por Colaborador";
            this.despesasPorColaboradorToolStripMenuItem.Click += new System.EventHandler(this.despesasPorColaboradorToolStripMenuItem_Click);
            // 
            // despesasPorCentroDeCustoToolStripMenuItem
            // 
            this.despesasPorCentroDeCustoToolStripMenuItem.Name = "despesasPorCentroDeCustoToolStripMenuItem";
            this.despesasPorCentroDeCustoToolStripMenuItem.Size = new System.Drawing.Size(287, 24);
            this.despesasPorCentroDeCustoToolStripMenuItem.Text = "Despesas por Centro de Custo";
            this.despesasPorCentroDeCustoToolStripMenuItem.Click += new System.EventHandler(this.despesasPorCentroDeCustoToolStripMenuItem_Click);
            // 
            // despesasPorCodigoToolStripMenuItem
            // 
            this.despesasPorCodigoToolStripMenuItem.Name = "despesasPorCodigoToolStripMenuItem";
            this.despesasPorCodigoToolStripMenuItem.Size = new System.Drawing.Size(287, 24);
            this.despesasPorCodigoToolStripMenuItem.Text = "Despesas por Código";
            this.despesasPorCodigoToolStripMenuItem.Click += new System.EventHandler(this.despesasPorCodigoToolStripMenuItem_Click);
            // 
            // solicitaçõesDeComprasToolStripMenuItem
            // 
            this.solicitaçõesDeComprasToolStripMenuItem.Name = "solicitaçõesDeComprasToolStripMenuItem";
            this.solicitaçõesDeComprasToolStripMenuItem.Size = new System.Drawing.Size(189, 24);
            this.solicitaçõesDeComprasToolStripMenuItem.Text = "Solicitações de Compras";
            // 
            // colaboradoresToolStripMenuItem
            // 
            this.colaboradoresToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.relatórioDeColaboradoresCadastradosToolStripMenuItem});
            this.colaboradoresToolStripMenuItem.Name = "colaboradoresToolStripMenuItem";
            this.colaboradoresToolStripMenuItem.Size = new System.Drawing.Size(122, 24);
            this.colaboradoresToolStripMenuItem.Text = "Colaboradores";
            // 
            // itensToolStripMenuItem
            // 
            this.itensToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.relatórioDeItensMaisAdquiridosToolStripMenuItem});
            this.itensToolStripMenuItem.Name = "itensToolStripMenuItem";
            this.itensToolStripMenuItem.Size = new System.Drawing.Size(56, 24);
            this.itensToolStripMenuItem.Text = "Itens";
            // 
            // relatórioDeItensMaisAdquiridosToolStripMenuItem
            // 
            this.relatórioDeItensMaisAdquiridosToolStripMenuItem.Name = "relatórioDeItensMaisAdquiridosToolStripMenuItem";
            this.relatórioDeItensMaisAdquiridosToolStripMenuItem.Size = new System.Drawing.Size(320, 24);
            this.relatórioDeItensMaisAdquiridosToolStripMenuItem.Text = "Relatório de Itens mais Adquiridos";
            this.relatórioDeItensMaisAdquiridosToolStripMenuItem.Click += new System.EventHandler(this.relatórioDeItensMaisAdquiridosToolStripMenuItem_Click);
            // 
            // panelRelatorio
            // 
            this.panelRelatorio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRelatorio.Location = new System.Drawing.Point(0, 30);
            this.panelRelatorio.Name = "panelRelatorio";
            this.panelRelatorio.Size = new System.Drawing.Size(1223, 549);
            this.panelRelatorio.TabIndex = 1;
            // 
            // relatórioDeColaboradoresCadastradosToolStripMenuItem
            // 
            this.relatórioDeColaboradoresCadastradosToolStripMenuItem.Name = "relatórioDeColaboradoresCadastradosToolStripMenuItem";
            this.relatórioDeColaboradoresCadastradosToolStripMenuItem.Size = new System.Drawing.Size(358, 24);
            this.relatórioDeColaboradoresCadastradosToolStripMenuItem.Text = "Relatório de Colaboradores Cadastrados";
            this.relatórioDeColaboradoresCadastradosToolStripMenuItem.Click += new System.EventHandler(this.relatórioDeColaboradoresCadastradosToolStripMenuItem_Click);
            // 
            // frmRelatorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1223, 579);
            this.Controls.Add(this.panelRelatorio);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmRelatorio";
            this.Text = "frmRelatorio";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem despesasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem solicitaçõesDeComprasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colaboradoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem despesasPorDepartamentoToolStripMenuItem;
        private System.Windows.Forms.Panel panelRelatorio;
        private System.Windows.Forms.ToolStripMenuItem despesasPorColaboradorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem despesasPorCentroDeCustoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem despesasPorCodigoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itensToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem relatórioDeItensMaisAdquiridosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem relatórioDeColaboradoresCadastradosToolStripMenuItem;
    }
}