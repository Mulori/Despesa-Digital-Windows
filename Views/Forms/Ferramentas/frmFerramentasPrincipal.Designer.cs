
namespace DespesaDigital.Views.Forms.Ferramentas
{
    partial class frmFerramentasPrincipal
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
            this.despesasPorCodigoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelFerramentas = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.despesasToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(800, 30);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // despesasToolStripMenuItem
            // 
            this.despesasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.despesasPorCodigoToolStripMenuItem});
            this.despesasToolStripMenuItem.Name = "despesasToolStripMenuItem";
            this.despesasToolStripMenuItem.Size = new System.Drawing.Size(164, 24);
            this.despesasToolStripMenuItem.Text = "Histórico de Eventos";
            // 
            // despesasPorCodigoToolStripMenuItem
            // 
            this.despesasPorCodigoToolStripMenuItem.Name = "despesasPorCodigoToolStripMenuItem";
            this.despesasPorCodigoToolStripMenuItem.Size = new System.Drawing.Size(204, 24);
            this.despesasPorCodigoToolStripMenuItem.Text = "Visualizar Eventos";
            this.despesasPorCodigoToolStripMenuItem.Click += new System.EventHandler(this.despesasPorCodigoToolStripMenuItem_Click);
            // 
            // panelFerramentas
            // 
            this.panelFerramentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFerramentas.Location = new System.Drawing.Point(0, 30);
            this.panelFerramentas.Name = "panelFerramentas";
            this.panelFerramentas.Size = new System.Drawing.Size(800, 420);
            this.panelFerramentas.TabIndex = 3;
            // 
            // frmFerramentasPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelFerramentas);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmFerramentasPrincipal";
            this.Text = "frmFerramentasPrincipal";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem despesasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem despesasPorCodigoToolStripMenuItem;
        private System.Windows.Forms.Panel panelFerramentas;
    }
}