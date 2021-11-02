
namespace DespesaDigital.Views.Forms.Despesa
{
    partial class frmPesquisarDespesa
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
            this.btnPesquisarData = new System.Windows.Forms.Button();
            this.cmbSetor = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.mskDataFinal = new System.Windows.Forms.MaskedTextBox();
            this.mskDataInicial = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s_valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formaPagamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoDespesa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s_codigo_setor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigo_setor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigo_categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigo_forma_pagamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigo_tipo_despesa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigo_usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imagem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbTipoDespesa = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbFormaPagamento = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbColaborador = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPesquisarData
            // 
            this.btnPesquisarData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.btnPesquisarData.FlatAppearance.BorderSize = 0;
            this.btnPesquisarData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPesquisarData.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisarData.ForeColor = System.Drawing.Color.White;
            this.btnPesquisarData.Location = new System.Drawing.Point(336, 37);
            this.btnPesquisarData.Name = "btnPesquisarData";
            this.btnPesquisarData.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnPesquisarData.Size = new System.Drawing.Size(81, 25);
            this.btnPesquisarData.TabIndex = 20;
            this.btnPesquisarData.Text = "Pesquisar";
            this.btnPesquisarData.UseVisualStyleBackColor = false;
            this.btnPesquisarData.Click += new System.EventHandler(this.btnPesquisarData_Click);
            // 
            // cmbSetor
            // 
            this.cmbSetor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSetor.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSetor.FormattingEnabled = true;
            this.cmbSetor.Location = new System.Drawing.Point(471, 38);
            this.cmbSetor.Name = "cmbSetor";
            this.cmbSetor.Size = new System.Drawing.Size(423, 25);
            this.cmbSetor.TabIndex = 21;
            this.cmbSetor.SelectedIndexChanged += new System.EventHandler(this.cmbSetor_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(224, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 17);
            this.label2.TabIndex = 23;
            this.label2.Text = "Data Final:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(118, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 17);
            this.label1.TabIndex = 22;
            this.label1.Text = "Data Inicial:";
            // 
            // mskDataFinal
            // 
            this.mskDataFinal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mskDataFinal.Location = new System.Drawing.Point(227, 37);
            this.mskDataFinal.Mask = "00/00/0000";
            this.mskDataFinal.Name = "mskDataFinal";
            this.mskDataFinal.Size = new System.Drawing.Size(100, 25);
            this.mskDataFinal.TabIndex = 18;
            this.mskDataFinal.ValidatingType = typeof(System.DateTime);
            // 
            // mskDataInicial
            // 
            this.mskDataInicial.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mskDataInicial.Location = new System.Drawing.Point(121, 37);
            this.mskDataInicial.Mask = "00/00/0000";
            this.mskDataInicial.Name = "mskDataInicial";
            this.mskDataInicial.Size = new System.Drawing.Size(100, 25);
            this.mskDataInicial.TabIndex = 17;
            this.mskDataInicial.ValidatingType = typeof(System.DateTime);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(468, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 17);
            this.label3.TabIndex = 24;
            this.label3.Text = "Centro de Custo:";
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
            this.status,
            this.s_valor,
            this.descricao,
            this.formaPagamento,
            this.tipoDespesa,
            this.s_codigo_setor,
            this.codigo_setor,
            this.codigo_categoria,
            this.codigo_forma_pagamento,
            this.codigo_tipo_despesa,
            this.usuario,
            this.codigo_usuario,
            this.imagem});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGrid.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGrid.Location = new System.Drawing.Point(-1, 135);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.RowHeadersVisible = false;
            this.dataGrid.Size = new System.Drawing.Size(1419, 506);
            this.dataGrid.TabIndex = 19;
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
            this.status.DataPropertyName = "data_hora_emissao";
            this.status.HeaderText = "Data/Hora:";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.Width = 160;
            // 
            // s_valor
            // 
            this.s_valor.DataPropertyName = "s_valor";
            this.s_valor.HeaderText = "Valor:";
            this.s_valor.Name = "s_valor";
            this.s_valor.Width = 200;
            // 
            // descricao
            // 
            this.descricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descricao.DataPropertyName = "descricao";
            this.descricao.HeaderText = "Descrição";
            this.descricao.Name = "descricao";
            this.descricao.ReadOnly = true;
            // 
            // formaPagamento
            // 
            this.formaPagamento.DataPropertyName = "s_codigo_forma_pagamento";
            this.formaPagamento.HeaderText = "Forma de Pagamento:";
            this.formaPagamento.Name = "formaPagamento";
            this.formaPagamento.ReadOnly = true;
            this.formaPagamento.Width = 250;
            // 
            // tipoDespesa
            // 
            this.tipoDespesa.DataPropertyName = "s_codigo_tipo_despesa";
            this.tipoDespesa.HeaderText = "Tipo de Despesa:";
            this.tipoDespesa.Name = "tipoDespesa";
            this.tipoDespesa.ReadOnly = true;
            this.tipoDespesa.Width = 250;
            // 
            // s_codigo_setor
            // 
            this.s_codigo_setor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.s_codigo_setor.DataPropertyName = "s_codigo_setor";
            this.s_codigo_setor.HeaderText = "Setor:";
            this.s_codigo_setor.Name = "s_codigo_setor";
            this.s_codigo_setor.ReadOnly = true;
            // 
            // codigo_setor
            // 
            this.codigo_setor.DataPropertyName = "codigo_setor";
            this.codigo_setor.HeaderText = "codigo_setor";
            this.codigo_setor.Name = "codigo_setor";
            this.codigo_setor.ReadOnly = true;
            this.codigo_setor.Visible = false;
            // 
            // codigo_categoria
            // 
            this.codigo_categoria.DataPropertyName = "valor";
            this.codigo_categoria.HeaderText = "valor";
            this.codigo_categoria.Name = "codigo_categoria";
            this.codigo_categoria.ReadOnly = true;
            this.codigo_categoria.Visible = false;
            this.codigo_categoria.Width = 200;
            // 
            // codigo_forma_pagamento
            // 
            this.codigo_forma_pagamento.DataPropertyName = "codigo_forma_pagamento";
            this.codigo_forma_pagamento.HeaderText = "codigo_forma_pagamento";
            this.codigo_forma_pagamento.Name = "codigo_forma_pagamento";
            this.codigo_forma_pagamento.ReadOnly = true;
            this.codigo_forma_pagamento.Visible = false;
            // 
            // codigo_tipo_despesa
            // 
            this.codigo_tipo_despesa.DataPropertyName = "codigo_tipo_despesa";
            this.codigo_tipo_despesa.HeaderText = "codigo_tipo_despesa";
            this.codigo_tipo_despesa.Name = "codigo_tipo_despesa";
            this.codigo_tipo_despesa.ReadOnly = true;
            this.codigo_tipo_despesa.Visible = false;
            // 
            // usuario
            // 
            this.usuario.DataPropertyName = "s_codigo_usuario";
            this.usuario.HeaderText = "usuario";
            this.usuario.Name = "usuario";
            this.usuario.Visible = false;
            // 
            // codigo_usuario
            // 
            this.codigo_usuario.DataPropertyName = "codigo_usuario";
            this.codigo_usuario.HeaderText = "codigo_usuario";
            this.codigo_usuario.Name = "codigo_usuario";
            this.codigo_usuario.Visible = false;
            // 
            // imagem
            // 
            this.imagem.DataPropertyName = "imagem";
            this.imagem.HeaderText = "imagem";
            this.imagem.Name = "imagem";
            this.imagem.ReadOnly = true;
            this.imagem.Visible = false;
            // 
            // cmbTipoDespesa
            // 
            this.cmbTipoDespesa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoDespesa.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipoDespesa.FormattingEnabled = true;
            this.cmbTipoDespesa.Location = new System.Drawing.Point(918, 38);
            this.cmbTipoDespesa.Name = "cmbTipoDespesa";
            this.cmbTipoDespesa.Size = new System.Drawing.Size(292, 25);
            this.cmbTipoDespesa.TabIndex = 25;
            this.cmbTipoDespesa.SelectedIndexChanged += new System.EventHandler(this.cmbTipoDespesa_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(915, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 17);
            this.label4.TabIndex = 26;
            this.label4.Text = "Tipo de Despesa:";
            // 
            // cmbFormaPagamento
            // 
            this.cmbFormaPagamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFormaPagamento.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFormaPagamento.FormattingEnabled = true;
            this.cmbFormaPagamento.Location = new System.Drawing.Point(918, 90);
            this.cmbFormaPagamento.Name = "cmbFormaPagamento";
            this.cmbFormaPagamento.Size = new System.Drawing.Size(292, 25);
            this.cmbFormaPagamento.TabIndex = 27;
            this.cmbFormaPagamento.SelectedIndexChanged += new System.EventHandler(this.cmbFormaPagamento_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(915, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 17);
            this.label5.TabIndex = 28;
            this.label5.Text = "Forma de Pagamento:";
            // 
            // cmbColaborador
            // 
            this.cmbColaborador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbColaborador.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbColaborador.FormattingEnabled = true;
            this.cmbColaborador.Location = new System.Drawing.Point(471, 90);
            this.cmbColaborador.Name = "cmbColaborador";
            this.cmbColaborador.Size = new System.Drawing.Size(423, 25);
            this.cmbColaborador.TabIndex = 29;
            this.cmbColaborador.SelectedIndexChanged += new System.EventHandler(this.cmbColaborador_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(468, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 17);
            this.label6.TabIndex = 30;
            this.label6.Text = "Colaborador:";
            // 
            // frmPesquisarDespesa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1416, 651);
            this.Controls.Add(this.cmbColaborador);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbFormaPagamento);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbTipoDespesa);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnPesquisarData);
            this.Controls.Add(this.cmbSetor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mskDataFinal);
            this.Controls.Add(this.mskDataInicial);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGrid);
            this.Name = "frmPesquisarDespesa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Visualizar Despesas";
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPesquisarData;
        private System.Windows.Forms.ComboBox cmbSetor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox mskDataFinal;
        private System.Windows.Forms.MaskedTextBox mskDataInicial;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.ComboBox cmbTipoDespesa;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbFormaPagamento;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn s_valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn formaPagamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoDespesa;
        private System.Windows.Forms.DataGridViewTextBoxColumn s_codigo_setor;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo_setor;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo_categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo_forma_pagamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo_tipo_despesa;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo_usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn imagem;
        private System.Windows.Forms.ComboBox cmbColaborador;
        private System.Windows.Forms.Label label6;
    }
}