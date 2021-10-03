
namespace DespesaDigital.Views.Forms.Produtos
{
    partial class frmPesquisarProduto
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.rdInativos = new System.Windows.Forms.RadioButton();
            this.rdAtivos = new System.Windows.Forms.RadioButton();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.btnNovo = new System.Windows.Forms.Button();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigo_categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(126, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Pesquise por Descrição:";
            // 
            // rdInativos
            // 
            this.rdInativos.AutoSize = true;
            this.rdInativos.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdInativos.Location = new System.Drawing.Point(22, 45);
            this.rdInativos.Name = "rdInativos";
            this.rdInativos.Size = new System.Drawing.Size(74, 21);
            this.rdInativos.TabIndex = 2;
            this.rdInativos.Text = "Inativos";
            this.rdInativos.UseVisualStyleBackColor = true;
            this.rdInativos.CheckedChanged += new System.EventHandler(this.rdInativos_CheckedChanged);
            // 
            // rdAtivos
            // 
            this.rdAtivos.AutoSize = true;
            this.rdAtivos.Checked = true;
            this.rdAtivos.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdAtivos.Location = new System.Drawing.Point(22, 22);
            this.rdAtivos.Name = "rdAtivos";
            this.rdAtivos.Size = new System.Drawing.Size(64, 21);
            this.rdAtivos.TabIndex = 1;
            this.rdAtivos.TabStop = true;
            this.rdAtivos.Text = "Ativos";
            this.rdAtivos.UseVisualStyleBackColor = true;
            this.rdAtivos.CheckedChanged += new System.EventHandler(this.rdAtivos_CheckedChanged);
            // 
            // txtDescricao
            // 
            this.txtDescricao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescricao.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricao.Location = new System.Drawing.Point(130, 37);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(626, 29);
            this.txtDescricao.TabIndex = 0;
            this.txtDescricao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescricao_KeyPress);
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigo,
            this.descricao,
            this.status,
            this.codigo_categoria,
            this.categoria});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGrid.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGrid.Location = new System.Drawing.Point(-1, 88);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.RowHeadersVisible = false;
            this.dataGrid.Size = new System.Drawing.Size(917, 405);
            this.dataGrid.TabIndex = 3;
            // 
            // btnNovo
            // 
            this.btnNovo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNovo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.btnNovo.FlatAppearance.BorderSize = 0;
            this.btnNovo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovo.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovo.ForeColor = System.Drawing.Color.White;
            this.btnNovo.Location = new System.Drawing.Point(777, 37);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(112, 28);
            this.btnNovo.TabIndex = 5;
            this.btnNovo.Text = "Novo";
            this.btnNovo.UseVisualStyleBackColor = false;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // codigo
            // 
            this.codigo.DataPropertyName = "codigo";
            this.codigo.HeaderText = "Código:";
            this.codigo.Name = "codigo";
            this.codigo.ReadOnly = true;
            // 
            // descricao
            // 
            this.descricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descricao.DataPropertyName = "descricao";
            this.descricao.HeaderText = "Descrição:";
            this.descricao.Name = "descricao";
            this.descricao.ReadOnly = true;
            // 
            // status
            // 
            this.status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.status.DataPropertyName = "ativo";
            this.status.HeaderText = "Status:";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            // 
            // codigo_categoria
            // 
            this.codigo_categoria.DataPropertyName = "codigo_categoria";
            this.codigo_categoria.HeaderText = "codigo_categoria";
            this.codigo_categoria.Name = "codigo_categoria";
            this.codigo_categoria.ReadOnly = true;
            this.codigo_categoria.Visible = false;
            // 
            // categoria
            // 
            this.categoria.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.categoria.DataPropertyName = "s_codigo_categoria";
            this.categoria.HeaderText = "Categoria:";
            this.categoria.Name = "categoria";
            this.categoria.ReadOnly = true;
            // 
            // frmPesquisarProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 498);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rdInativos);
            this.Controls.Add(this.rdAtivos);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.dataGrid);
            this.Name = "frmPesquisarProduto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pesquisa de Produto";
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdInativos;
        private System.Windows.Forms.RadioButton rdAtivos;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo_categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoria;
    }
}