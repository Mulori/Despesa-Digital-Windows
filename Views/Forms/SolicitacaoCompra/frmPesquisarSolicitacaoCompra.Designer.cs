
namespace DespesaDigital.Views.Forms.SolicitacaoCompra
{
    partial class frmPesquisarSolicitacaoCompra
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
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s_valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s_codigo_setor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigo_setor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigo_produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigo_categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rdPendentes = new System.Windows.Forms.RadioButton();
            this.rdAprovados = new System.Windows.Forms.RadioButton();
            this.rdRejeitados = new System.Windows.Forms.RadioButton();
            this.mskDataInicial = new System.Windows.Forms.MaskedTextBox();
            this.mskDataFinal = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSetor = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPesquisarData = new System.Windows.Forms.Button();
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
            this.status,
            this.descricao,
            this.s_valor,
            this.categoria,
            this.item,
            this.s_codigo_setor,
            this.codigo_setor,
            this.codigo_produto,
            this.codigo_categoria,
            this.usuario});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGrid.Location = new System.Drawing.Point(-1, 104);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.RowHeadersVisible = false;
            this.dataGrid.Size = new System.Drawing.Size(1373, 547);
            this.dataGrid.TabIndex = 4;
            this.dataGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellDoubleClick);
            // 
            // codigo
            // 
            this.codigo.DataPropertyName = "codigo";
            this.codigo.HeaderText = "Código:";
            this.codigo.Name = "codigo";
            this.codigo.ReadOnly = true;
            // 
            // status
            // 
            this.status.DataPropertyName = "data_solicitacao";
            this.status.HeaderText = "Data/Hora:";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.Width = 160;
            // 
            // descricao
            // 
            this.descricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descricao.DataPropertyName = "motivo";
            this.descricao.HeaderText = "Observação/Motivo:";
            this.descricao.Name = "descricao";
            this.descricao.ReadOnly = true;
            // 
            // s_valor
            // 
            this.s_valor.DataPropertyName = "s_valor";
            this.s_valor.HeaderText = "Valor:";
            this.s_valor.Name = "s_valor";
            // 
            // categoria
            // 
            this.categoria.DataPropertyName = "status";
            this.categoria.HeaderText = "Status:";
            this.categoria.Name = "categoria";
            this.categoria.ReadOnly = true;
            this.categoria.Width = 160;
            // 
            // item
            // 
            this.item.DataPropertyName = "s_codigo_produto";
            this.item.HeaderText = "Item:";
            this.item.Name = "item";
            this.item.Width = 150;
            // 
            // s_codigo_setor
            // 
            this.s_codigo_setor.DataPropertyName = "s_codigo_setor";
            this.s_codigo_setor.HeaderText = "Setor:";
            this.s_codigo_setor.Name = "s_codigo_setor";
            this.s_codigo_setor.ReadOnly = true;
            this.s_codigo_setor.Width = 200;
            // 
            // codigo_setor
            // 
            this.codigo_setor.DataPropertyName = "codigo_setor";
            this.codigo_setor.HeaderText = "codigo_setor";
            this.codigo_setor.Name = "codigo_setor";
            this.codigo_setor.ReadOnly = true;
            this.codigo_setor.Visible = false;
            // 
            // codigo_produto
            // 
            this.codigo_produto.DataPropertyName = "codigo_produto";
            this.codigo_produto.HeaderText = "codigo_produto";
            this.codigo_produto.Name = "codigo_produto";
            this.codigo_produto.ReadOnly = true;
            this.codigo_produto.Visible = false;
            // 
            // codigo_categoria
            // 
            this.codigo_categoria.DataPropertyName = "valor";
            this.codigo_categoria.HeaderText = "Valor:";
            this.codigo_categoria.Name = "codigo_categoria";
            this.codigo_categoria.ReadOnly = true;
            this.codigo_categoria.Visible = false;
            this.codigo_categoria.Width = 200;
            // 
            // usuario
            // 
            this.usuario.DataPropertyName = "usuario";
            this.usuario.HeaderText = "usuario";
            this.usuario.Name = "usuario";
            this.usuario.Visible = false;
            // 
            // rdPendentes
            // 
            this.rdPendentes.AutoSize = true;
            this.rdPendentes.Checked = true;
            this.rdPendentes.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdPendentes.Location = new System.Drawing.Point(47, 42);
            this.rdPendentes.Name = "rdPendentes";
            this.rdPendentes.Size = new System.Drawing.Size(90, 21);
            this.rdPendentes.TabIndex = 1;
            this.rdPendentes.TabStop = true;
            this.rdPendentes.Text = "Pendentes";
            this.rdPendentes.UseVisualStyleBackColor = true;
            this.rdPendentes.CheckedChanged += new System.EventHandler(this.rdPendentes_CheckedChanged);
            // 
            // rdAprovados
            // 
            this.rdAprovados.AutoSize = true;
            this.rdAprovados.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdAprovados.Location = new System.Drawing.Point(47, 19);
            this.rdAprovados.Name = "rdAprovados";
            this.rdAprovados.Size = new System.Drawing.Size(92, 21);
            this.rdAprovados.TabIndex = 0;
            this.rdAprovados.Text = "Aprovados";
            this.rdAprovados.UseVisualStyleBackColor = true;
            this.rdAprovados.CheckedChanged += new System.EventHandler(this.rdAprovados_CheckedChanged);
            // 
            // rdRejeitados
            // 
            this.rdRejeitados.AutoSize = true;
            this.rdRejeitados.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdRejeitados.Location = new System.Drawing.Point(47, 65);
            this.rdRejeitados.Name = "rdRejeitados";
            this.rdRejeitados.Size = new System.Drawing.Size(88, 21);
            this.rdRejeitados.TabIndex = 2;
            this.rdRejeitados.Text = "Rejeitados";
            this.rdRejeitados.UseVisualStyleBackColor = true;
            this.rdRejeitados.CheckedChanged += new System.EventHandler(this.rdRejeitados_CheckedChanged);
            // 
            // mskDataInicial
            // 
            this.mskDataInicial.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mskDataInicial.Location = new System.Drawing.Point(200, 63);
            this.mskDataInicial.Mask = "00/00/0000";
            this.mskDataInicial.Name = "mskDataInicial";
            this.mskDataInicial.Size = new System.Drawing.Size(100, 25);
            this.mskDataInicial.TabIndex = 3;
            this.mskDataInicial.ValidatingType = typeof(System.DateTime);
            // 
            // mskDataFinal
            // 
            this.mskDataFinal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mskDataFinal.Location = new System.Drawing.Point(306, 63);
            this.mskDataFinal.Mask = "00/00/0000";
            this.mskDataFinal.Name = "mskDataFinal";
            this.mskDataFinal.Size = new System.Drawing.Size(100, 25);
            this.mskDataFinal.TabIndex = 4;
            this.mskDataFinal.ValidatingType = typeof(System.DateTime);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(197, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Data Inicial:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(303, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Data Final:";
            // 
            // cmbSetor
            // 
            this.cmbSetor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSetor.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSetor.FormattingEnabled = true;
            this.cmbSetor.Location = new System.Drawing.Point(550, 64);
            this.cmbSetor.Name = "cmbSetor";
            this.cmbSetor.Size = new System.Drawing.Size(423, 25);
            this.cmbSetor.TabIndex = 6;
            this.cmbSetor.SelectedIndexChanged += new System.EventHandler(this.cmbSetor_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(547, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "Centro de Custo:";
            // 
            // btnPesquisarData
            // 
            this.btnPesquisarData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.btnPesquisarData.FlatAppearance.BorderSize = 0;
            this.btnPesquisarData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPesquisarData.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisarData.ForeColor = System.Drawing.Color.White;
            this.btnPesquisarData.Location = new System.Drawing.Point(415, 63);
            this.btnPesquisarData.Name = "btnPesquisarData";
            this.btnPesquisarData.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnPesquisarData.Size = new System.Drawing.Size(81, 25);
            this.btnPesquisarData.TabIndex = 5;
            this.btnPesquisarData.Text = "Pesquisar";
            this.btnPesquisarData.UseVisualStyleBackColor = false;
            this.btnPesquisarData.Click += new System.EventHandler(this.btnPesquisarData_Click);
            // 
            // frmPesquisarSolicitacaoCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 651);
            this.Controls.Add(this.btnPesquisarData);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbSetor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mskDataFinal);
            this.Controls.Add(this.mskDataInicial);
            this.Controls.Add(this.rdRejeitados);
            this.Controls.Add(this.rdPendentes);
            this.Controls.Add(this.rdAprovados);
            this.Controls.Add(this.dataGrid);
            this.Name = "frmPesquisarSolicitacaoCompra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Visualizar Solicitações de Compras";
            this.Load += new System.EventHandler(this.frmPesquisarSolicitacaoCompra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.RadioButton rdPendentes;
        private System.Windows.Forms.RadioButton rdAprovados;
        private System.Windows.Forms.RadioButton rdRejeitados;
        private System.Windows.Forms.MaskedTextBox mskDataInicial;
        private System.Windows.Forms.MaskedTextBox mskDataFinal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbSetor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPesquisarData;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn s_valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn item;
        private System.Windows.Forms.DataGridViewTextBoxColumn s_codigo_setor;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo_setor;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo_produto;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo_categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuario;
    }
}