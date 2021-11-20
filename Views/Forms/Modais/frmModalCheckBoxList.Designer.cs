
namespace DespesaDigital.Views.Forms.Modais
{
    partial class frmModalCheckBoxList
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
            this.checkList = new System.Windows.Forms.CheckedListBox();
            this.btnSair = new System.Windows.Forms.Button();
            this.txtPesquisa = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPronto = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkList
            // 
            this.checkList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(56)))), ((int)(((byte)(64)))));
            this.checkList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkList.ForeColor = System.Drawing.Color.White;
            this.checkList.FormattingEnabled = true;
            this.checkList.Location = new System.Drawing.Point(13, 107);
            this.checkList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkList.Name = "checkList";
            this.checkList.Size = new System.Drawing.Size(741, 242);
            this.checkList.TabIndex = 54;
            // 
            // btnSair
            // 
            this.btnSair.BackgroundImage = global::DespesaDigital.Properties.Resources.exit;
            this.btnSair.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSair.FlatAppearance.BorderSize = 0;
            this.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSair.Location = new System.Drawing.Point(726, 12);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(29, 24);
            this.btnSair.TabIndex = 55;
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // txtPesquisa
            // 
            this.txtPesquisa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.txtPesquisa.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPesquisa.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesquisa.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtPesquisa.Location = new System.Drawing.Point(13, 64);
            this.txtPesquisa.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.txtPesquisa.Name = "txtPesquisa";
            this.txtPesquisa.Size = new System.Drawing.Size(741, 26);
            this.txtPesquisa.TabIndex = 56;
            this.txtPesquisa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPesquisa_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(9, 36);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 20);
            this.label2.TabIndex = 57;
            this.label2.Text = "Pesquisar: *";
            // 
            // btnPronto
            // 
            this.btnPronto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.btnPronto.FlatAppearance.BorderSize = 0;
            this.btnPronto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPronto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(56)))), ((int)(((byte)(64)))));
            this.btnPronto.Location = new System.Drawing.Point(610, 364);
            this.btnPronto.Name = "btnPronto";
            this.btnPronto.Size = new System.Drawing.Size(144, 28);
            this.btnPronto.TabIndex = 58;
            this.btnPronto.Text = "Pronto";
            this.btnPronto.UseVisualStyleBackColor = false;
            this.btnPronto.Click += new System.EventHandler(this.btnPronto_Click);
            // 
            // frmModalCheckBoxList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(56)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(767, 409);
            this.Controls.Add(this.btnPronto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPesquisa);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.checkList);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmModalCheckBoxList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmModalCheckBoxList";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmModalCheckBoxList_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmModalCheckBoxList_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.frmModalCheckBoxList_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckedListBox checkList;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.TextBox txtPesquisa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPronto;
    }
}