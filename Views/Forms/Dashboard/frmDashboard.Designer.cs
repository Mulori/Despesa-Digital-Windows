
namespace DespesaDigital.Views.Forms.Dashboard
{
    partial class frmDashboard
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.chartValorDespesaPorSetor = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.charSetorPorAno = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.charDespesaNosUltimo6Meses = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartValorDespesaPorSetor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.charSetorPorAno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.charDespesaNosUltimo6Meses)).BeginInit();
            this.SuspendLayout();
            // 
            // chartValorDespesaPorSetor
            // 
            this.chartValorDespesaPorSetor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chartValorDespesaPorSetor.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.chartValorDespesaPorSetor.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartValorDespesaPorSetor.Legends.Add(legend1);
            this.chartValorDespesaPorSetor.Location = new System.Drawing.Point(27, 287);
            this.chartValorDespesaPorSetor.Name = "chartValorDespesaPorSetor";
            this.chartValorDespesaPorSetor.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.EarthTones;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.Legend = "Legend1";
            series1.Name = "despesa";
            this.chartValorDespesaPorSetor.Series.Add(series1);
            this.chartValorDespesaPorSetor.Size = new System.Drawing.Size(347, 204);
            this.chartValorDespesaPorSetor.TabIndex = 0;
            this.chartValorDespesaPorSetor.Text = "Valor de despesa por setor";
            title1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "Total de despesas por centro de custo (R$)";
            this.chartValorDespesaPorSetor.Titles.Add(title1);
            // 
            // charSetorPorAno
            // 
            this.charSetorPorAno.Anchor = System.Windows.Forms.AnchorStyles.None;
            chartArea2.Name = "ChartArea1";
            this.charSetorPorAno.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.charSetorPorAno.Legends.Add(legend2);
            this.charSetorPorAno.Location = new System.Drawing.Point(610, 41);
            this.charSetorPorAno.Name = "charSetorPorAno";
            this.charSetorPorAno.Size = new System.Drawing.Size(679, 316);
            this.charSetorPorAno.TabIndex = 1;
            this.charSetorPorAno.Text = "chart1";
            this.charSetorPorAno.Visible = false;
            // 
            // charDespesaNosUltimo6Meses
            // 
            this.charDespesaNosUltimo6Meses.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.charDespesaNosUltimo6Meses.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea3.Name = "ChartArea1";
            this.charDespesaNosUltimo6Meses.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.charDespesaNosUltimo6Meses.Legends.Add(legend3);
            this.charDespesaNosUltimo6Meses.Location = new System.Drawing.Point(645, 287);
            this.charDespesaNosUltimo6Meses.Name = "charDespesaNosUltimo6Meses";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series2.Legend = "Legend1";
            series2.Name = "despesa";
            this.charDespesaNosUltimo6Meses.Series.Add(series2);
            this.charDespesaNosUltimo6Meses.Size = new System.Drawing.Size(347, 191);
            this.charDespesaNosUltimo6Meses.TabIndex = 2;
            this.charDespesaNosUltimo6Meses.Text = "Valor de despesa por setor";
            title2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title2.Name = "Total de despesas por centro de custo (R$)";
            this.charDespesaNosUltimo6Meses.Titles.Add(title2);
            // 
            // frmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1383, 568);
            this.Controls.Add(this.chartValorDespesaPorSetor);
            this.Controls.Add(this.charDespesaNosUltimo6Meses);
            this.Controls.Add(this.charSetorPorAno);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDashboard";
            ((System.ComponentModel.ISupportInitialize)(this.chartValorDespesaPorSetor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.charSetorPorAno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.charDespesaNosUltimo6Meses)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartValorDespesaPorSetor;
        private System.Windows.Forms.DataVisualization.Charting.Chart charSetorPorAno;
        private System.Windows.Forms.DataVisualization.Charting.Chart charDespesaNosUltimo6Meses;
    }
}