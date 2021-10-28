
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
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnVisualizarDespesas = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(515, 321);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(67, 66);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(647, 305);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(328, 230);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
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
            this.btnVisualizarDespesas.Location = new System.Drawing.Point(47, 43);
            this.btnVisualizarDespesas.Name = "btnVisualizarDespesas";
            this.btnVisualizarDespesas.Size = new System.Drawing.Size(165, 144);
            this.btnVisualizarDespesas.TabIndex = 2;
            this.btnVisualizarDespesas.Text = "Visualizar Despesas";
            this.btnVisualizarDespesas.UseVisualStyleBackColor = false;
            this.btnVisualizarDespesas.Click += new System.EventHandler(this.btnVisualizarDespesas_Click);
            // 
            // frmDespesa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1266, 601);
            this.Controls.Add(this.btnVisualizarDespesas);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDespesa";
            this.Text = "frmDespesa";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnVisualizarDespesas;
    }
}