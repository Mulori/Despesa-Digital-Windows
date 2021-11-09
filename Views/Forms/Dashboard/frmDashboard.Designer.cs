
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDashboard));
            this.chartValorDespesaPorSetor = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.charDespesaNosUltimo6Meses = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnTotalDespesa = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbTotalDespesa = new System.Windows.Forms.Label();
            this.pnColaboradores = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbTotalUsuario = new System.Windows.Forms.Label();
            this.pnTotalGrafico = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.pnQuantidadeDespesa = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.pnUltimaDespesa = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblValorUltimaDespesa = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.chartValorDespesaPorSetor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.charDespesaNosUltimo6Meses)).BeginInit();
            this.pnTotalDespesa.SuspendLayout();
            this.pnColaboradores.SuspendLayout();
            this.pnTotalGrafico.SuspendLayout();
            this.pnQuantidadeDespesa.SuspendLayout();
            this.pnUltimaDespesa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
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
            this.chartValorDespesaPorSetor.Location = new System.Drawing.Point(7, 80);
            this.chartValorDespesaPorSetor.Name = "chartValorDespesaPorSetor";
            this.chartValorDespesaPorSetor.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.EarthTones;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.Legend = "Legend1";
            series1.Name = "despesa";
            this.chartValorDespesaPorSetor.Series.Add(series1);
            this.chartValorDespesaPorSetor.Size = new System.Drawing.Size(294, 227);
            this.chartValorDespesaPorSetor.TabIndex = 0;
            this.chartValorDespesaPorSetor.Text = "Valor de despesa por setor";
            title1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "Total de despesas por centro de custo (R$)";
            this.chartValorDespesaPorSetor.Titles.Add(title1);
            this.chartValorDespesaPorSetor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chartValorDespesaPorSetor_MouseDown);
            this.chartValorDespesaPorSetor.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chartValorDespesaPorSetor_MouseMove);
            this.chartValorDespesaPorSetor.MouseUp += new System.Windows.Forms.MouseEventHandler(this.chartValorDespesaPorSetor_MouseUp);
            // 
            // charDespesaNosUltimo6Meses
            // 
            this.charDespesaNosUltimo6Meses.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.charDespesaNosUltimo6Meses.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea2.Name = "ChartArea1";
            this.charDespesaNosUltimo6Meses.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.charDespesaNosUltimo6Meses.Legends.Add(legend2);
            this.charDespesaNosUltimo6Meses.Location = new System.Drawing.Point(7, 80);
            this.charDespesaNosUltimo6Meses.Name = "charDespesaNosUltimo6Meses";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series2.Legend = "Legend1";
            series2.Name = "despesa";
            this.charDespesaNosUltimo6Meses.Series.Add(series2);
            this.charDespesaNosUltimo6Meses.Size = new System.Drawing.Size(296, 227);
            this.charDespesaNosUltimo6Meses.TabIndex = 2;
            this.charDespesaNosUltimo6Meses.Text = "Valor de despesa por setor";
            title2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title2.Name = "Total de despesas por centro de custo (R$)";
            this.charDespesaNosUltimo6Meses.Titles.Add(title2);
            this.charDespesaNosUltimo6Meses.MouseDown += new System.Windows.Forms.MouseEventHandler(this.charDespesaNosUltimo6Meses_MouseDown);
            this.charDespesaNosUltimo6Meses.MouseMove += new System.Windows.Forms.MouseEventHandler(this.charDespesaNosUltimo6Meses_MouseMove);
            this.charDespesaNosUltimo6Meses.MouseUp += new System.Windows.Forms.MouseEventHandler(this.charDespesaNosUltimo6Meses_MouseUp);
            // 
            // pnTotalDespesa
            // 
            this.pnTotalDespesa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.pnTotalDespesa.Controls.Add(this.label3);
            this.pnTotalDespesa.Controls.Add(this.label2);
            this.pnTotalDespesa.Controls.Add(this.lbTotalDespesa);
            this.pnTotalDespesa.Controls.Add(this.pictureBox1);
            this.pnTotalDespesa.Location = new System.Drawing.Point(12, 12);
            this.pnTotalDespesa.Name = "pnTotalDespesa";
            this.pnTotalDespesa.Size = new System.Drawing.Size(309, 117);
            this.pnTotalDespesa.TabIndex = 3;
            this.pnTotalDespesa.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnTotalDespesa_MouseDown);
            this.pnTotalDespesa.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnTotalDespesa_MouseMove);
            this.pnTotalDespesa.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnTotalDespesa_MouseUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 21);
            this.label3.TabIndex = 6;
            this.label3.Text = "Ultimas 24h";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Total de Despesas";
            // 
            // lbTotalDespesa
            // 
            this.lbTotalDespesa.AutoSize = true;
            this.lbTotalDespesa.Font = new System.Drawing.Font("Segoe UI Semibold", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalDespesa.ForeColor = System.Drawing.Color.White;
            this.lbTotalDespesa.Location = new System.Drawing.Point(-2, 40);
            this.lbTotalDespesa.Name = "lbTotalDespesa";
            this.lbTotalDespesa.Size = new System.Drawing.Size(114, 40);
            this.lbTotalDespesa.TabIndex = 4;
            this.lbTotalDespesa.Text = "R$ 0,00";
            // 
            // pnColaboradores
            // 
            this.pnColaboradores.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(146)))), ((int)(((byte)(222)))));
            this.pnColaboradores.Controls.Add(this.label1);
            this.pnColaboradores.Controls.Add(this.label4);
            this.pnColaboradores.Controls.Add(this.lbTotalUsuario);
            this.pnColaboradores.Controls.Add(this.pictureBox2);
            this.pnColaboradores.Location = new System.Drawing.Point(361, 12);
            this.pnColaboradores.Name = "pnColaboradores";
            this.pnColaboradores.Size = new System.Drawing.Size(309, 117);
            this.pnColaboradores.TabIndex = 7;
            this.pnColaboradores.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnColaboradores_MouseDown);
            this.pnColaboradores.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnColaboradores_MouseMove);
            this.pnColaboradores.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnColaboradores_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 21);
            this.label1.TabIndex = 6;
            this.label1.Text = "Deste Departamento";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "Colaboradores";
            // 
            // lbTotalUsuario
            // 
            this.lbTotalUsuario.AutoSize = true;
            this.lbTotalUsuario.Font = new System.Drawing.Font("Segoe UI Semibold", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalUsuario.ForeColor = System.Drawing.Color.White;
            this.lbTotalUsuario.Location = new System.Drawing.Point(16, 40);
            this.lbTotalUsuario.Name = "lbTotalUsuario";
            this.lbTotalUsuario.Size = new System.Drawing.Size(33, 40);
            this.lbTotalUsuario.TabIndex = 4;
            this.lbTotalUsuario.Text = "0";
            // 
            // pnTotalGrafico
            // 
            this.pnTotalGrafico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pnTotalGrafico.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnTotalGrafico.Controls.Add(this.chartValorDespesaPorSetor);
            this.pnTotalGrafico.Controls.Add(this.pictureBox3);
            this.pnTotalGrafico.Controls.Add(this.label6);
            this.pnTotalGrafico.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnTotalGrafico.Location = new System.Drawing.Point(12, 207);
            this.pnTotalGrafico.Name = "pnTotalGrafico";
            this.pnTotalGrafico.Size = new System.Drawing.Size(309, 314);
            this.pnTotalGrafico.TabIndex = 8;
            this.pnTotalGrafico.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnTotalGrafico_MouseDown);
            this.pnTotalGrafico.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnTotalGrafico_MouseMove);
            this.pnTotalGrafico.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnTotalGrafico_MouseUp);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(74, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(217, 45);
            this.label5.TabIndex = 0;
            this.label5.Text = "O grafico abaixo mostra a porcentagem\r\nda quantidade de despesas de todos os \r\nce" +
    "ntros de custos em todo o período.";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnQuantidadeDespesa
            // 
            this.pnQuantidadeDespesa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pnQuantidadeDespesa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnQuantidadeDespesa.Controls.Add(this.pictureBox4);
            this.pnQuantidadeDespesa.Controls.Add(this.charDespesaNosUltimo6Meses);
            this.pnQuantidadeDespesa.Controls.Add(this.label5);
            this.pnQuantidadeDespesa.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnQuantidadeDespesa.Location = new System.Drawing.Point(361, 207);
            this.pnQuantidadeDespesa.Name = "pnQuantidadeDespesa";
            this.pnQuantidadeDespesa.Size = new System.Drawing.Size(309, 314);
            this.pnQuantidadeDespesa.TabIndex = 9;
            this.pnQuantidadeDespesa.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnQuantidadeDespesa_MouseDown);
            this.pnQuantidadeDespesa.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnQuantidadeDespesa_MouseMove);
            this.pnQuantidadeDespesa.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnQuantidadeDespesa_MouseUp);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(65, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(228, 45);
            this.label6.TabIndex = 0;
            this.label6.Text = "O grafico abaixo mostra em porcentagem\r\num total de despesas de todos centros de " +
    "\r\ncustos em todo o período.";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnUltimaDespesa
            // 
            this.pnUltimaDespesa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(184)))), ((int)(((byte)(111)))));
            this.pnUltimaDespesa.Controls.Add(this.label7);
            this.pnUltimaDespesa.Controls.Add(this.label8);
            this.pnUltimaDespesa.Controls.Add(this.lblValorUltimaDespesa);
            this.pnUltimaDespesa.Controls.Add(this.pictureBox5);
            this.pnUltimaDespesa.Location = new System.Drawing.Point(709, 12);
            this.pnUltimaDespesa.Name = "pnUltimaDespesa";
            this.pnUltimaDespesa.Size = new System.Drawing.Size(309, 117);
            this.pnUltimaDespesa.TabIndex = 7;
            this.pnUltimaDespesa.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnUltimaDespesa_MouseDown);
            this.pnUltimaDespesa.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnUltimaDespesa_MouseMove);
            this.pnUltimaDespesa.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnUltimaDespesa_MouseUp);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(3, 83);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(146, 21);
            this.label7.TabIndex = 6;
            this.label7.Text = "Ultimo Lançamento";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(0, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(142, 25);
            this.label8.TabIndex = 5;
            this.label8.Text = "Ultima Despesa";
            // 
            // lblValorUltimaDespesa
            // 
            this.lblValorUltimaDespesa.AutoSize = true;
            this.lblValorUltimaDespesa.Font = new System.Drawing.Font("Segoe UI Semibold", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorUltimaDespesa.ForeColor = System.Drawing.Color.White;
            this.lblValorUltimaDespesa.Location = new System.Drawing.Point(-2, 40);
            this.lblValorUltimaDespesa.Name = "lblValorUltimaDespesa";
            this.lblValorUltimaDespesa.Size = new System.Drawing.Size(114, 40);
            this.lblValorUltimaDespesa.TabIndex = 4;
            this.lblValorUltimaDespesa.Text = "R$ 0,00";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::DespesaDigital.Properties.Resources.relogio_ico;
            this.pictureBox5.Location = new System.Drawing.Point(187, 8);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(115, 102);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 0;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DespesaDigital.Properties.Resources.user_ico;
            this.pictureBox2.Location = new System.Drawing.Point(187, 8);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(115, 102);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DespesaDigital.Properties.Resources.icon_grafico;
            this.pictureBox1.Location = new System.Drawing.Point(187, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(115, 102);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(19, 17);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(40, 42);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 7;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(19, 18);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(40, 42);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 8;
            this.pictureBox4.TabStop = false;
            // 
            // frmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1383, 568);
            this.Controls.Add(this.pnUltimaDespesa);
            this.Controls.Add(this.pnColaboradores);
            this.Controls.Add(this.pnTotalDespesa);
            this.Controls.Add(this.pnTotalGrafico);
            this.Controls.Add(this.pnQuantidadeDespesa);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDashboard";
            ((System.ComponentModel.ISupportInitialize)(this.chartValorDespesaPorSetor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.charDespesaNosUltimo6Meses)).EndInit();
            this.pnTotalDespesa.ResumeLayout(false);
            this.pnTotalDespesa.PerformLayout();
            this.pnColaboradores.ResumeLayout(false);
            this.pnColaboradores.PerformLayout();
            this.pnTotalGrafico.ResumeLayout(false);
            this.pnTotalGrafico.PerformLayout();
            this.pnQuantidadeDespesa.ResumeLayout(false);
            this.pnQuantidadeDespesa.PerformLayout();
            this.pnUltimaDespesa.ResumeLayout(false);
            this.pnUltimaDespesa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartValorDespesaPorSetor;
        private System.Windows.Forms.DataVisualization.Charting.Chart charDespesaNosUltimo6Meses;
        private System.Windows.Forms.Panel pnTotalDespesa;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbTotalDespesa;
        private System.Windows.Forms.Panel pnColaboradores;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbTotalUsuario;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel pnTotalGrafico;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnQuantidadeDespesa;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel pnUltimaDespesa;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblValorUltimaDespesa;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Timer timer1;
    }
}