
namespace DespesaDigital.Views.Forms.SolicitacaoCompra
{
    partial class frmDetalheSolicitacaoCompra
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
            this.txtInformacoes = new System.Windows.Forms.TextBox();
            this.btnRejeitar = new System.Windows.Forms.Button();
            this.btnAprovar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtInformacoes
            // 
            this.txtInformacoes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInformacoes.Enabled = false;
            this.txtInformacoes.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInformacoes.Location = new System.Drawing.Point(12, 12);
            this.txtInformacoes.Multiline = true;
            this.txtInformacoes.Name = "txtInformacoes";
            this.txtInformacoes.Size = new System.Drawing.Size(670, 458);
            this.txtInformacoes.TabIndex = 0;
            // 
            // btnRejeitar
            // 
            this.btnRejeitar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRejeitar.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnRejeitar.FlatAppearance.BorderSize = 0;
            this.btnRejeitar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRejeitar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRejeitar.Location = new System.Drawing.Point(563, 487);
            this.btnRejeitar.Name = "btnRejeitar";
            this.btnRejeitar.Size = new System.Drawing.Size(119, 43);
            this.btnRejeitar.TabIndex = 1;
            this.btnRejeitar.Text = "Rejeitar";
            this.btnRejeitar.UseVisualStyleBackColor = false;
            this.btnRejeitar.Click += new System.EventHandler(this.btnRejeitar_Click);
            // 
            // btnAprovar
            // 
            this.btnAprovar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAprovar.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnAprovar.FlatAppearance.BorderSize = 0;
            this.btnAprovar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAprovar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAprovar.Location = new System.Drawing.Point(438, 487);
            this.btnAprovar.Name = "btnAprovar";
            this.btnAprovar.Size = new System.Drawing.Size(119, 43);
            this.btnAprovar.TabIndex = 2;
            this.btnAprovar.Text = "Aprovar";
            this.btnAprovar.UseVisualStyleBackColor = false;
            this.btnAprovar.Click += new System.EventHandler(this.btnAprovar_Click);
            // 
            // frmDetalheSolicitacaoCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 542);
            this.Controls.Add(this.btnAprovar);
            this.Controls.Add(this.btnRejeitar);
            this.Controls.Add(this.txtInformacoes);
            this.Name = "frmDetalheSolicitacaoCompra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalhe Solicitação de Compra";
            this.Load += new System.EventHandler(this.frmDetalheSolicitacaoCompra_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInformacoes;
        private System.Windows.Forms.Button btnRejeitar;
        private System.Windows.Forms.Button btnAprovar;
    }
}