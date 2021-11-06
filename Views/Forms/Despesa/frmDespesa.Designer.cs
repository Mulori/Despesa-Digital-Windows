
namespace DespesaDigital.Views.Forms.Despesa
{
    partial class frmDespesa
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
            this.btnVisualizarDespesas = new System.Windows.Forms.Button();
            this.btnNovaDespesa = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnVisualizarDespesas
            // 
            this.btnVisualizarDespesas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.btnVisualizarDespesas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnVisualizarDespesas.FlatAppearance.BorderSize = 0;
            this.btnVisualizarDespesas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVisualizarDespesas.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVisualizarDespesas.ForeColor = System.Drawing.Color.White;
            this.btnVisualizarDespesas.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnVisualizarDespesas.Location = new System.Drawing.Point(255, 43);
            this.btnVisualizarDespesas.Name = "btnVisualizarDespesas";
            this.btnVisualizarDespesas.Size = new System.Drawing.Size(165, 144);
            this.btnVisualizarDespesas.TabIndex = 2;
            this.btnVisualizarDespesas.Text = "Visualizar Despesas";
            this.btnVisualizarDespesas.UseVisualStyleBackColor = false;
            this.btnVisualizarDespesas.Click += new System.EventHandler(this.btnVisualizarDespesas_Click);
            // 
            // btnNovaDespesa
            // 
            this.btnNovaDespesa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.btnNovaDespesa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnNovaDespesa.FlatAppearance.BorderSize = 0;
            this.btnNovaDespesa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovaDespesa.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovaDespesa.ForeColor = System.Drawing.Color.White;
            this.btnNovaDespesa.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNovaDespesa.Location = new System.Drawing.Point(46, 43);
            this.btnNovaDespesa.Name = "btnNovaDespesa";
            this.btnNovaDespesa.Size = new System.Drawing.Size(165, 144);
            this.btnNovaDespesa.TabIndex = 3;
            this.btnNovaDespesa.Text = "Nova Despesa";
            this.btnNovaDespesa.UseVisualStyleBackColor = false;
            this.btnNovaDespesa.Click += new System.EventHandler(this.btnNovaDespesa_Click);
            // 
            // frmDespesa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1266, 601);
            this.Controls.Add(this.btnNovaDespesa);
            this.Controls.Add(this.btnVisualizarDespesas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDespesa";
            this.Text = "frmDespesa";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnVisualizarDespesas;
        private System.Windows.Forms.Button btnNovaDespesa;
    }
}