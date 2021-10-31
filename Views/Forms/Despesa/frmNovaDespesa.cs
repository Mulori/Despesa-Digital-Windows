using DespesaDigital.Code.BLL.bllFormaPagamento;
using DespesaDigital.Code.BLL.bllProduto;
using DespesaDigital.Code.BLL.bllSetor;
using DespesaDigital.Code.BLL.bllTipoDespesa;
using DespesaDigital.Code.DTO.dtoFormaPagamento;
using DespesaDigital.Code.DTO.dtoModal;
using DespesaDigital.Code.DTO.dtoProduto;
using DespesaDigital.Code.DTO.dtoSetor;
using DespesaDigital.Code.DTO.dtoTipoDespesa;
using DespesaDigital.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace DespesaDigital.Views.Forms.Despesa
{
    public partial class frmNovaDespesa : Form
    {
        byte[] file_byte;
        List<dtoProduto> list_prod_escolhido = new List<dtoProduto>();
        private List<dtoModalCheckListBox> listItens = new List<dtoModalCheckListBox>();
        private List<dtoModalCheckListBox> listItensBackup = new List<dtoModalCheckListBox>();
        

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

            if (dr == DialogResult.OK)
            {
                var file = openFileDialog1.FileName;
                lbFilePath.Text = file;

                MemoryStream tmpStream = new MemoryStream();
                file_byte = File.ReadAllBytes(file);
                tmpStream.Read(file_byte, 0, 100);
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

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtValor.Text) || string.IsNullOrEmpty(cmbTipoDespesa.Text) || string.IsNullOrEmpty(cmbFormaPagamento.Text)
              ||  string.IsNullOrEmpty(cmbSetor.Text) || string.IsNullOrEmpty(txtObservacao.Text))
            {
                corePopUp.exibirMensagem("Preencha todos os campos.", "Atenção");
                return;
            }

            if(lbFilePath.Text == "Nenhum arquivo selecionado.")
            {
                if(!corePopUp.exibirPergunta("Atenção", "Nenhum comprovante foi anexado, deseja continuar e registrar?", 2))
                {
                    return;
                }
            }
        }

        void CarregaListaItensEscolhido(List<dtoModalCheckListBox> list)
        {
            var listItensBackupTemp = new List<dtoModalCheckListBox>();
            Dictionary<string, string> comboSource = new Dictionary<string, string>();

            if (listItensBackup.Count > 0) //Valida no backup quais itens ja estão para inserir sómente alguns
            {
                foreach (var new_item in list)
                {
                    bool insere_lista = true;

                    foreach (var item in listItensBackup)
                    {
                        if (new_item.codigo == item.codigo)
                        {
                            insere_lista = false;
                            break;
                        }
                    }

                    if (insere_lista)
                    {
                        comboSource.Add($"{new_item.codigo}", $"{new_item.descricao}");

                        var dtoModalTemp = new dtoModalCheckListBox();
                        dtoModalTemp.codigo = new_item.codigo;
                        dtoModalTemp.descricao = new_item.descricao;

                        listItensBackupTemp.Add(dtoModalTemp);
                    }
                }

                foreach (var item in listItensBackup)
                {
                    comboSource.Add($"{item.codigo}", $"{item.descricao}");

                    var dtoModalTemp = new dtoModalCheckListBox();
                    dtoModalTemp.codigo = item.codigo;
                    dtoModalTemp.descricao = item.descricao;

                    listItensBackupTemp.Add(dtoModalTemp);
                }
            }
            else //Percorre normalmente 
            {
                foreach (var item in list)
                {
                    comboSource.Add($"{item.codigo}", $"{item.descricao}");

                    var dtoModalTemp = new dtoModalCheckListBox();
                    dtoModalTemp.codigo = item.codigo;
                    dtoModalTemp.descricao = item.descricao;

                    listItensBackupTemp.Add(dtoModalTemp);
                }
            }

            listItensBackup = listItensBackupTemp;
            listItensBackupTemp = null;

            if (comboSource.Count > 0)
            {
                chkListItens.DataSource = new BindingSource(comboSource, null);
                chkListItens.DisplayMember = "Value";
                chkListItens.ValueMember = "Key";

                for (int i = 0; i < chkListItens.Items.Count; i++)
                {
                    chkListItens.SetItemChecked(i, true);
                }
            }
        }

        private void txtPesquisaItem_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    using (var form = new frmPesquisaProdutoDespesa(txtPesquisaItem.Text))
                    {
                        form.ShowDialog();
                        listItens = form.listReturn;
                        CarregaListaItensEscolhido(listItens);
                    }
                    break;
            }
        }
    }
}
