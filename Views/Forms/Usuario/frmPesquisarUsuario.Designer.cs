
namespace DespesaDigital.Views.Forms.Usuario
{
    partial class frmPesquisarUsuario
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPesquisarUsuario));
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sobrenome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nivel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.setor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.senha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigo_setor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nivel_acesso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nome_departamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rdAtivos = new System.Windows.Forms.RadioButton();
            this.rdInativos = new System.Windows.Forms.RadioButton();
            this.rdPendentes = new System.Windows.Forms.RadioButton();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGrid
            // 
            this.dataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigo,
            this.nome,
            this.sobrenome,
            this.email,
            this.nivel,
            this.status,
            this.setor,
            this.senha,
            this.codigo_setor,
            this.nivel_acesso,
            this.nome_departamento});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGrid.Location = new System.Drawing.Point(-2, 95);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.RowHeadersVisible = false;
            this.dataGrid.Size = new System.Drawing.Size(917, 405);
            this.dataGrid.TabIndex = 0;
            this.dataGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellDoubleClick);
            // 
            // codigo
            // 
            this.codigo.DataPropertyName = "codigo";
            this.codigo.HeaderText = "Código:";
            this.codigo.Name = "codigo";
            this.codigo.ReadOnly = true;
            // 
            // nome
            // 
            this.nome.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nome.DataPropertyName = "nome";
            this.nome.HeaderText = "Nome:";
            this.nome.Name = "nome";
            // 
            // sobrenome
            // 
            this.sobrenome.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.sobrenome.DataPropertyName = "sobrenome";
            this.sobrenome.HeaderText = "Sobrenome:";
            this.sobrenome.Name = "sobrenome";
            // 
            // email
            // 
            this.email.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.email.DataPropertyName = "email";
            this.email.HeaderText = "E-mail:";
            this.email.Name = "email";
            this.email.ReadOnly = true;
            // 
            // nivel
            // 
            this.nivel.DataPropertyName = "s_nivel_acesso";
            this.nivel.HeaderText = "Acesso:";
            this.nivel.Name = "nivel";
            this.nivel.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // status
            // 
            this.status.DataPropertyName = "ativo";
            this.status.HeaderText = "Status:";
            this.status.Name = "status";
            this.status.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // setor
            // 
            this.setor.DataPropertyName = "nome_setor";
            this.setor.HeaderText = "Setor:";
            this.setor.Name = "setor";
            this.setor.ReadOnly = true;
            this.setor.Width = 207;
            // 
            // senha
            // 
            this.senha.DataPropertyName = "senha";
            this.senha.HeaderText = "senha";
            this.senha.Name = "senha";
            this.senha.ReadOnly = true;
            this.senha.Visible = false;
            // 
            // codigo_setor
            // 
            this.codigo_setor.DataPropertyName = "codigo_setor";
            this.codigo_setor.HeaderText = "codigo_Setor";
            this.codigo_setor.Name = "codigo_setor";
            this.codigo_setor.ReadOnly = true;
            this.codigo_setor.Visible = false;
            // 
            // nivel_acesso
            // 
            this.nivel_acesso.DataPropertyName = "nivel_acesso";
            this.nivel_acesso.HeaderText = "nivel_acesso";
            this.nivel_acesso.Name = "nivel_acesso";
            this.nivel_acesso.ReadOnly = true;
            this.nivel_acesso.Visible = false;
            // 
            // nome_departamento
            // 
            this.nome_departamento.DataPropertyName = "nome_departamento";
            this.nome_departamento.HeaderText = "departamento";
            this.nome_departamento.Name = "nome_departamento";
            this.nome_departamento.ReadOnly = true;
            this.nome_departamento.Visible = false;
            // 
            // rdAtivos
            // 
            this.rdAtivos.AutoSize = true;
            this.rdAtivos.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdAtivos.Location = new System.Drawing.Point(79, 13);
            this.rdAtivos.Name = "rdAtivos";
            this.rdAtivos.Size = new System.Drawing.Size(64, 21);
            this.rdAtivos.TabIndex = 1;
            this.rdAtivos.Text = "Ativos";
            this.rdAtivos.UseVisualStyleBackColor = true;
            this.rdAtivos.CheckedChanged += new System.EventHandler(this.rdAtivos_CheckedChanged);
            // 
            // rdInativos
            // 
            this.rdInativos.AutoSize = true;
            this.rdInativos.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdInativos.Location = new System.Drawing.Point(79, 36);
            this.rdInativos.Name = "rdInativos";
            this.rdInativos.Size = new System.Drawing.Size(74, 21);
            this.rdInativos.TabIndex = 2;
            this.rdInativos.Text = "Inativos";
            this.rdInativos.UseVisualStyleBackColor = true;
            this.rdInativos.CheckedChanged += new System.EventHandler(this.rdInativos_CheckedChanged);
            // 
            // rdPendentes
            // 
            this.rdPendentes.AutoSize = true;
            this.rdPendentes.Checked = true;
            this.rdPendentes.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdPendentes.Location = new System.Drawing.Point(78, 59);
            this.rdPendentes.Name = "rdPendentes";
            this.rdPendentes.Size = new System.Drawing.Size(90, 21);
            this.rdPendentes.TabIndex = 3;
            this.rdPendentes.TabStop = true;
            this.rdPendentes.Text = "Pendentes";
            this.rdPendentes.UseVisualStyleBackColor = true;
            this.rdPendentes.CheckedChanged += new System.EventHandler(this.rdPendentes_CheckedChanged);
            // 
            // txtNome
            // 
            this.txtNome.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNome.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.Location = new System.Drawing.Point(193, 36);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(626, 29);
            this.txtNome.TabIndex = 4;
            this.txtNome.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNome_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(189, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Pesquise por Nome:";
            // 
            // frmPesquisarUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(915, 498);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.rdPendentes);
            this.Controls.Add(this.rdInativos);
            this.Controls.Add(this.rdAtivos);
            this.Controls.Add(this.dataGrid);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPesquisarUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pesquisa de Usuários";
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.RadioButton rdAtivos;
        private System.Windows.Forms.RadioButton rdInativos;
        private System.Windows.Forms.RadioButton rdPendentes;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn sobrenome;
        private System.Windows.Forms.DataGridViewTextBoxColumn email;
        private System.Windows.Forms.DataGridViewTextBoxColumn nivel;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn setor;
        private System.Windows.Forms.DataGridViewTextBoxColumn senha;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo_setor;
        private System.Windows.Forms.DataGridViewTextBoxColumn nivel_acesso;
        private System.Windows.Forms.DataGridViewTextBoxColumn nome_departamento;
    }
}