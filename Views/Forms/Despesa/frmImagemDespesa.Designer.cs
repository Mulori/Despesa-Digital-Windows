
namespace DespesaDigital.Views.Forms.Despesa
{
    partial class frmImagemDespesa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImagemDespesa));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnGirar = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.linkSalvarComputador = new System.Windows.Forms.LinkLabel();
            this.btnRetrocede = new System.Windows.Forms.Button();
            this.btnAvanca = new System.Windows.Forms.Button();
            this.picImagem = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImagem)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.panel1.Controls.Add(this.btnGirar);
            this.panel1.Controls.Add(this.btnSair);
            this.panel1.Controls.Add(this.btnSalvar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1071, 75);
            this.panel1.TabIndex = 19;
            // 
            // btnGirar
            // 
            this.btnGirar.BackColor = System.Drawing.SystemColors.Control;
            this.btnGirar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnGirar.FlatAppearance.BorderSize = 0;
            this.btnGirar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGirar.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGirar.Location = new System.Drawing.Point(11, 11);
            this.btnGirar.Margin = new System.Windows.Forms.Padding(2);
            this.btnGirar.Name = "btnGirar";
            this.btnGirar.Size = new System.Drawing.Size(94, 54);
            this.btnGirar.TabIndex = 0;
            this.btnGirar.Text = "Girar Imagem";
            this.btnGirar.UseVisualStyleBackColor = false;
            this.btnGirar.Click += new System.EventHandler(this.btnGirar_Click_1);
            // 
            // btnSair
            // 
            this.btnSair.BackColor = System.Drawing.SystemColors.Control;
            this.btnSair.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSair.FlatAppearance.BorderSize = 0;
            this.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSair.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.Location = new System.Drawing.Point(207, 11);
            this.btnSair.Margin = new System.Windows.Forms.Padding(2);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(95, 54);
            this.btnSair.TabIndex = 2;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = false;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.SystemColors.Control;
            this.btnSalvar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSalvar.FlatAppearance.BorderSize = 0;
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.Location = new System.Drawing.Point(109, 11);
            this.btnSalvar.Margin = new System.Windows.Forms.Padding(2);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(94, 54);
            this.btnSalvar.TabIndex = 1;
            this.btnSalvar.Text = "Exportar";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // linkSalvarComputador
            // 
            this.linkSalvarComputador.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.linkSalvarComputador.AutoSize = true;
            this.linkSalvarComputador.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkSalvarComputador.Location = new System.Drawing.Point(230, 344);
            this.linkSalvarComputador.Name = "linkSalvarComputador";
            this.linkSalvarComputador.Size = new System.Drawing.Size(557, 17);
            this.linkSalvarComputador.TabIndex = 21;
            this.linkSalvarComputador.TabStop = true;
            this.linkSalvarComputador.Text = "Este arquivo não da suporte a visualização. Clique aqui para salvar o arquivo no " +
    "computador.";
            this.linkSalvarComputador.Visible = false;
            this.linkSalvarComputador.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkSalvarComputador_LinkClicked);
            // 
            // btnRetrocede
            // 
            this.btnRetrocede.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnRetrocede.BackColor = System.Drawing.Color.White;
            this.btnRetrocede.FlatAppearance.BorderSize = 0;
            this.btnRetrocede.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRetrocede.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetrocede.Image = global::DespesaDigital.Properties.Resources.left_arrow;
            this.btnRetrocede.Location = new System.Drawing.Point(11, 333);
            this.btnRetrocede.Name = "btnRetrocede";
            this.btnRetrocede.Size = new System.Drawing.Size(39, 38);
            this.btnRetrocede.TabIndex = 23;
            this.btnRetrocede.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRetrocede.UseVisualStyleBackColor = false;
            this.btnRetrocede.Click += new System.EventHandler(this.btnRetrocede_Click);
            // 
            // btnAvanca
            // 
            this.btnAvanca.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnAvanca.BackColor = System.Drawing.Color.White;
            this.btnAvanca.FlatAppearance.BorderSize = 0;
            this.btnAvanca.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAvanca.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAvanca.Image = global::DespesaDigital.Properties.Resources.right_arrow;
            this.btnAvanca.Location = new System.Drawing.Point(1020, 333);
            this.btnAvanca.Name = "btnAvanca";
            this.btnAvanca.Size = new System.Drawing.Size(39, 38);
            this.btnAvanca.TabIndex = 22;
            this.btnAvanca.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAvanca.UseVisualStyleBackColor = false;
            this.btnAvanca.Click += new System.EventHandler(this.btnAvanca_Click);
            // 
            // picImagem
            // 
            this.picImagem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picImagem.Location = new System.Drawing.Point(0, 75);
            this.picImagem.Name = "picImagem";
            this.picImagem.Size = new System.Drawing.Size(1071, 556);
            this.picImagem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picImagem.TabIndex = 20;
            this.picImagem.TabStop = false;
            // 
            // frmImagemDespesa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 631);
            this.Controls.Add(this.btnRetrocede);
            this.Controls.Add(this.btnAvanca);
            this.Controls.Add(this.linkSalvarComputador);
            this.Controls.Add(this.picImagem);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmImagemDespesa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Imagem da Despesa";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picImagem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.PictureBox picImagem;
        private System.Windows.Forms.Button btnGirar;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
        private System.Windows.Forms.LinkLabel linkSalvarComputador;
        private System.Windows.Forms.Button btnAvanca;
        private System.Windows.Forms.Button btnRetrocede;
    }
}