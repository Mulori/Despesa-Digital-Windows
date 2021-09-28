
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnMinhaConta = new System.Windows.Forms.Button();
            this.btnCentroCusto = new System.Windows.Forms.Button();
            this.btnDespesa = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbNome = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnCadastro = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(56)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.btnCadastro);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btnMinhaConta);
            this.panel1.Controls.Add(this.btnCentroCusto);
            this.panel1.Controls.Add(this.btnDespesa);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(179, 491);
            this.panel1.TabIndex = 0;
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
            // btnMinhaConta
            // 
            this.btnMinhaConta.Enabled = false;
            this.btnMinhaConta.FlatAppearance.BorderSize = 0;
            this.btnMinhaConta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinhaConta.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinhaConta.ForeColor = System.Drawing.Color.White;
            this.btnMinhaConta.Location = new System.Drawing.Point(0, 297);
            this.btnMinhaConta.Name = "btnMinhaConta";
            this.btnMinhaConta.Size = new System.Drawing.Size(182, 52);
            this.btnMinhaConta.TabIndex = 2;
            this.btnMinhaConta.Text = "Minha Conta";
            this.btnMinhaConta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMinhaConta.UseVisualStyleBackColor = true;
            // 
            // btnCentroCusto
            // 
            this.btnCentroCusto.Enabled = false;
            this.btnCentroCusto.FlatAppearance.BorderSize = 0;
            this.btnCentroCusto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCentroCusto.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCentroCusto.ForeColor = System.Drawing.Color.White;
            this.btnCentroCusto.Location = new System.Drawing.Point(0, 181);
            this.btnCentroCusto.Name = "btnCentroCusto";
            this.btnCentroCusto.Size = new System.Drawing.Size(182, 52);
            this.btnCentroCusto.TabIndex = 1;
            this.btnCentroCusto.Text = "Centro de Custo";
            this.btnCentroCusto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCentroCusto.UseVisualStyleBackColor = true;
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
            this.btnDespesa.Location = new System.Drawing.Point(0, 123);
            this.btnDespesa.Name = "btnDespesa";
            this.btnDespesa.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnDespesa.Size = new System.Drawing.Size(182, 52);
            this.btnDespesa.TabIndex = 0;
            this.btnDespesa.Text = "Despesas";
            this.btnDespesa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDespesa.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.lbNome);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(179, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(757, 64);
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
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(231)))), ((int)(((byte)(213)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(179, 64);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(757, 427);
            this.panel3.TabIndex = 2;
            // 
            // btnCadastro
            // 
            this.btnCadastro.Enabled = false;
            this.btnCadastro.FlatAppearance.BorderSize = 0;
            this.btnCadastro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCadastro.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadastro.ForeColor = System.Drawing.Color.White;
            this.btnCadastro.Location = new System.Drawing.Point(0, 239);
            this.btnCadastro.Name = "btnCadastro";
            this.btnCadastro.Size = new System.Drawing.Size(182, 52);
            this.btnCadastro.TabIndex = 3;
            this.btnCadastro.Text = "Cadastros";
            this.btnCadastro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCadastro.UseVisualStyleBackColor = true;
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 491);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Despesa Digital";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnMinhaConta;
        private System.Windows.Forms.Button btnCentroCusto;
        private System.Windows.Forms.Button btnDespesa;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbNome;
        private System.Windows.Forms.Button btnCadastro;
    }
}

