﻿
namespace DespesaDigital
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRelatorios = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.lbVersao = new System.Windows.Forms.Label();
            this.btnCadastro = new System.Windows.Forms.Button();
            this.btnMinhaConta = new System.Windows.Forms.Button();
            this.btnCentroCusto = new System.Windows.Forms.Button();
            this.btnDespesa = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbNome = new System.Windows.Forms.Label();
            this.panelPrincipal = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbRodape = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnFerramentas = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelPrincipal.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(56)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.btnFerramentas);
            this.panel1.Controls.Add(this.btnRelatorios);
            this.panel1.Controls.Add(this.btnDashboard);
            this.panel1.Controls.Add(this.lbVersao);
            this.panel1.Controls.Add(this.btnCadastro);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btnMinhaConta);
            this.panel1.Controls.Add(this.btnCentroCusto);
            this.panel1.Controls.Add(this.btnDespesa);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(179, 620);
            this.panel1.TabIndex = 0;
            // 
            // btnRelatorios
            // 
            this.btnRelatorios.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRelatorios.Enabled = false;
            this.btnRelatorios.FlatAppearance.BorderSize = 0;
            this.btnRelatorios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRelatorios.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRelatorios.ForeColor = System.Drawing.Color.White;
            this.btnRelatorios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRelatorios.Location = new System.Drawing.Point(0, 252);
            this.btnRelatorios.Name = "btnRelatorios";
            this.btnRelatorios.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnRelatorios.Size = new System.Drawing.Size(182, 52);
            this.btnRelatorios.TabIndex = 5;
            this.btnRelatorios.Text = "Relatórios";
            this.btnRelatorios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRelatorios.UseVisualStyleBackColor = true;
            this.btnRelatorios.Click += new System.EventHandler(this.btnRelatorios_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(56)))), ((int)(((byte)(64)))));
            this.btnDashboard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDashboard.Enabled = false;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.Location = new System.Drawing.Point(0, 136);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnDashboard.Size = new System.Drawing.Size(182, 52);
            this.btnDashboard.TabIndex = 4;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbVersao
            // 
            this.lbVersao.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbVersao.AutoSize = true;
            this.lbVersao.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbVersao.ForeColor = System.Drawing.Color.White;
            this.lbVersao.Location = new System.Drawing.Point(66, 594);
            this.lbVersao.Name = "lbVersao";
            this.lbVersao.Size = new System.Drawing.Size(47, 17);
            this.lbVersao.TabIndex = 0;
            this.lbVersao.Text = "versão";
            this.lbVersao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCadastro
            // 
            this.btnCadastro.Enabled = false;
            this.btnCadastro.FlatAppearance.BorderSize = 0;
            this.btnCadastro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCadastro.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadastro.ForeColor = System.Drawing.Color.White;
            this.btnCadastro.Location = new System.Drawing.Point(0, 365);
            this.btnCadastro.Name = "btnCadastro";
            this.btnCadastro.Size = new System.Drawing.Size(182, 52);
            this.btnCadastro.TabIndex = 3;
            this.btnCadastro.Text = "Cadastros";
            this.btnCadastro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCadastro.UseVisualStyleBackColor = true;
            this.btnCadastro.Click += new System.EventHandler(this.btnCadastro_Click);
            // 
            // btnMinhaConta
            // 
            this.btnMinhaConta.Enabled = false;
            this.btnMinhaConta.FlatAppearance.BorderSize = 0;
            this.btnMinhaConta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinhaConta.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinhaConta.ForeColor = System.Drawing.Color.White;
            this.btnMinhaConta.Location = new System.Drawing.Point(0, 423);
            this.btnMinhaConta.Name = "btnMinhaConta";
            this.btnMinhaConta.Size = new System.Drawing.Size(182, 52);
            this.btnMinhaConta.TabIndex = 2;
            this.btnMinhaConta.Text = "Minha Conta";
            this.btnMinhaConta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMinhaConta.UseVisualStyleBackColor = true;
            this.btnMinhaConta.Click += new System.EventHandler(this.btnMinhaConta_Click);
            // 
            // btnCentroCusto
            // 
            this.btnCentroCusto.Enabled = false;
            this.btnCentroCusto.FlatAppearance.BorderSize = 0;
            this.btnCentroCusto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCentroCusto.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCentroCusto.ForeColor = System.Drawing.Color.White;
            this.btnCentroCusto.Location = new System.Drawing.Point(0, 307);
            this.btnCentroCusto.Name = "btnCentroCusto";
            this.btnCentroCusto.Size = new System.Drawing.Size(182, 52);
            this.btnCentroCusto.TabIndex = 1;
            this.btnCentroCusto.Text = "Solicitações de Compras";
            this.btnCentroCusto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCentroCusto.UseVisualStyleBackColor = true;
            this.btnCentroCusto.Click += new System.EventHandler(this.btnCentroCusto_Click);
            // 
            // btnDespesa
            // 
            this.btnDespesa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDespesa.Enabled = false;
            this.btnDespesa.FlatAppearance.BorderSize = 0;
            this.btnDespesa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDespesa.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDespesa.ForeColor = System.Drawing.Color.White;
            this.btnDespesa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDespesa.Location = new System.Drawing.Point(0, 194);
            this.btnDespesa.Name = "btnDespesa";
            this.btnDespesa.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnDespesa.Size = new System.Drawing.Size(182, 52);
            this.btnDespesa.TabIndex = 0;
            this.btnDespesa.Text = "Despesas";
            this.btnDespesa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDespesa.UseVisualStyleBackColor = true;
            this.btnDespesa.Click += new System.EventHandler(this.btnDespesa_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.btnLogout);
            this.panel2.Controls.Add(this.lbNome);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(179, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(892, 64);
            this.panel2.TabIndex = 1;
            // 
            // lbNome
            // 
            this.lbNome.AutoSize = true;
            this.lbNome.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNome.Location = new System.Drawing.Point(15, 21);
            this.lbNome.Name = "lbNome";
            this.lbNome.Size = new System.Drawing.Size(86, 21);
            this.lbNome.TabIndex = 0;
            this.lbNome.Text = "Seu nome";
            // 
            // panelPrincipal
            // 
            this.panelPrincipal.BackColor = System.Drawing.SystemColors.Control;
            this.panelPrincipal.Controls.Add(this.panel3);
            this.panelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPrincipal.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelPrincipal.Location = new System.Drawing.Point(179, 64);
            this.panelPrincipal.Name = "panelPrincipal";
            this.panelPrincipal.Size = new System.Drawing.Size(892, 556);
            this.panelPrincipal.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Silver;
            this.panel3.Controls.Add(this.lbRodape);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 522);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(892, 34);
            this.panel3.TabIndex = 0;
            // 
            // lbRodape
            // 
            this.lbRodape.AutoSize = true;
            this.lbRodape.Location = new System.Drawing.Point(5, 7);
            this.lbRodape.Name = "lbRodape";
            this.lbRodape.Size = new System.Drawing.Size(150, 20);
            this.lbRodape.TabIndex = 0;
            this.lbRodape.Text = "Informações de login";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnFerramentas
            // 
            this.btnFerramentas.Enabled = false;
            this.btnFerramentas.FlatAppearance.BorderSize = 0;
            this.btnFerramentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFerramentas.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFerramentas.ForeColor = System.Drawing.Color.White;
            this.btnFerramentas.Location = new System.Drawing.Point(0, 481);
            this.btnFerramentas.Name = "btnFerramentas";
            this.btnFerramentas.Size = new System.Drawing.Size(182, 52);
            this.btnFerramentas.TabIndex = 6;
            this.btnFerramentas.Text = "Ferramentas";
            this.btnFerramentas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFerramentas.UseVisualStyleBackColor = true;
            this.btnFerramentas.Click += new System.EventHandler(this.btnFerramentas_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.BackgroundImage = global::DespesaDigital.Properties.Resources.logout;
            this.btnLogout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Location = new System.Drawing.Point(851, 21);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(29, 24);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Visible = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DespesaDigital.Properties.Resources.logodespesadigital;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(173, 97);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 620);
            this.Controls.Add(this.panelPrincipal);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Despesa Digital Coopercitrus";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelPrincipal.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelPrincipal;
        private System.Windows.Forms.Button btnMinhaConta;
        private System.Windows.Forms.Button btnCentroCusto;
        private System.Windows.Forms.Button btnDespesa;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbNome;
        private System.Windows.Forms.Button btnCadastro;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lbVersao;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbRodape;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnRelatorios;
        private System.Windows.Forms.Button btnFerramentas;
    }
}

