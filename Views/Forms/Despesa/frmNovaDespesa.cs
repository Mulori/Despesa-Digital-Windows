using DespesaDigital.Code.BLL.bllFormaPagamento;
using DespesaDigital.Code.BLL.bllProduto;
using DespesaDigital.Code.BLL.bllSetor;
using DespesaDigital.Code.BLL.bllTipoDespesa;
using DespesaDigital.Code.DTO.dtoFormaPagamento;
using DespesaDigital.Code.DTO.dtoProduto;
using DespesaDigital.Code.DTO.dtoSetor;
using DespesaDigital.Code.DTO.dtoTipoDespesa;
using DespesaDigital.Core;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DespesaDigital.Views.Forms.Despesa
{
    public partial class frmNovaDespesa : Form
    {
        public frmNovaDespesa()
        {
            InitializeComponent();
            var list_forma_pagamento = bllFormaPagamento.ListarTodasFormasPagamentoPorStatus("A");
            var list_tipo_despesa = bllTipoDespesa.ListarTodasTipoDespesaPorStatus("A");
            CarregaListaFormaPagamento(list_forma_pagamento);
            CarregaListaTipoDespesa(list_tipo_despesa);

            List<dtoSetor> list;
            if (VariaveisGlobais.nivel_acesso > 2)
            {
                list = bllSetor.TodosSetoresPorDepartamento(VariaveisGlobais.codigo_departamento);
            }
            else
            {
                list = bllSetor.ListSetorPorCodigo(VariaveisGlobais.codigo_setor);
                cmbSetor.Enabled = false;
            }

            CarregaListaSetores(list);

            cmbSetor.Text = bllSetor.SetorPorCodigo(VariaveisGlobais.codigo_setor).nome;
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {

        }

        void CarregaListaFormaPagamento(List<dtoFormaPagamento> list)
        {
            Dictionary<string, string> comboSource = new Dictionary<string, string>();
            foreach (var item in list)
            {
                comboSource.Add($"{item.codigo}", $"{item.descricao}");
            }

            cmbFormaPagamento.DataSource = new BindingSource(comboSource, null);
            cmbFormaPagamento.DisplayMember = "Value";
            cmbFormaPagamento.ValueMember = "Key";
        }

        void CarregaListaTipoDespesa(List<dtoTipoDespesa> list)
        {
            Dictionary<string, string> comboSource = new Dictionary<string, string>();
            foreach (var item in list)
            {
                comboSource.Add($"{item.codigo}", $"{item.descricao}");
            }

            cmbTipoDespesa.DataSource = new BindingSource(comboSource, null);
            cmbTipoDespesa.DisplayMember = "Value";
            cmbTipoDespesa.ValueMember = "Key";
        }

        private void btnAnexo_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Selecione um Comprovante";
            openFileDialog1.Filter = "Images (*.JPG;*.PNG)|*.JPG;*.PNG|" + "All files (*.*)|*.*";
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.ReadOnlyChecked = true;
            openFileDialog1.ShowReadOnly = true;

            DialogResult dr = this.openFileDialog1.ShowDialog();

            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                var file = openFileDialog1.FileName;
                lbFilePath.Text = file;
            }
        }

        void CarregaListaSetores(List<dtoSetor> list)
        {
            Dictionary<string, string> comboSource = new Dictionary<string, string>();
            foreach (var item in list)
            {
                comboSource.Add($"{item.codigo}", $"{item.nome}");
            }

            cmbSetor.DataSource = new BindingSource(comboSource, null);
            cmbSetor.DisplayMember = "Value";
            cmbSetor.ValueMember = "Key";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            lbQtdeCaracter.Text = txtObservacao.Text.Length.ToString() + "/500";
        }

        private void cmbItem_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F10:
                    using (var form = new frmPesquisaProdutoDespesa())
                    {
                        form.ShowDialog();
                    }
                    break;
                case Keys.Enter:
                    var list = bllProduto.ListarTodosProdutosPorStatusDescricao("A", cmbItem.Text);

                    if (list.Count == 0)
                    {
                        break;
                    }

                    CarregaListaItens(list);
                    SendKeys.Send("{F4}");
                    break;
            }
        }

        private void cmbItem_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        void CarregaListaItens(List<dtoProduto> list)
        {
            Dictionary<string, string> comboSource = new Dictionary<string, string>();
            foreach (var item in list)
            {
                comboSource.Add($"{item.codigo}", $"{item.descricao}");
            }

            cmbItem.DataSource = new BindingSource(comboSource, null);
            cmbItem.DisplayMember = "Value";
            cmbItem.ValueMember = "Key";
        }
    }
}
