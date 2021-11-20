using DespesaDigital.Code.BLL.bllDespesa;
using DespesaDigital.Code.BLL.bllFormaPagamento;
using DespesaDigital.Code.BLL.bllLogSistema;
using DespesaDigital.Code.BLL.bllProdutoDespesa;
using DespesaDigital.Code.BLL.bllTipoDespesa;
using DespesaDigital.Code.DTO.dtoDespesa;
using DespesaDigital.Code.DTO.dtoFormaPagamento;
using DespesaDigital.Code.DTO.dtoTipoDespesa;
using DespesaDigital.Core;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DespesaDigital.Views.Forms.Despesa
{
    public partial class frmDetalheDespesa : Form
    {
        public static long codigo_despesa_ {get;set;}

        public frmDetalheDespesa(long _codigo_despesa)
        {
            InitializeComponent();
            codigo_despesa_ = _codigo_despesa;

            var list_forma_pagamento = bllFormaPagamento.ListarTodasFormasPagamentoPorStatus("A");
            var list_tipo_despesa = bllTipoDespesa.ListarTodasTipoDespesaPorStatus("A");
            CarregaListaFormaPagametno(list_forma_pagamento);
            CarregaListaTipoDespesa(list_tipo_despesa);
            Inicializa();
        }

        void CarregaListaFormaPagametno(List<dtoFormaPagamento> list)
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

        private void Inicializa()
        {
            var despesa = bllDespesa.DespesaPorCodigo(codigo_despesa_);
            txtCodigo.Text = despesa.codigo.ToString();
            mskData.Text = despesa.data_hora_emissao.ToString("dd/MM/yyyy HH:mm:ss");
            txtValor.Text = Convert.ToDouble(despesa.valor).ToString("N2");
            cmbFormaPagamento.Text = despesa.s_codigo_forma_pagamento;
            cmbTipoDespesa.Text = despesa.s_codigo_tipo_despesa;
            txtCentroCusto.Text = despesa.s_codigo_setor;
            txtColaborador.Text = despesa.s_codigo_usuario;
            txtDescricao.Text = despesa.descricao;

            dataGrid.DataSource = bllDespesaItens.ListarTodoProdutoDespesaPorCodigo(codigo_despesa_);
        }

        private void btnImagem_Click_1(object sender, EventArgs e)
        {
            using (var form = new frmImagemDespesa(Convert.ToInt64(txtCodigo.Text)))
            {
                form.ShowDialog();
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if(btnEditar.Text == "Editar") //Função de editar
            {
                if (!corePopUp.exibirPergunta("Atenção", "Deseja fazer alterações nesse lançamento?", 2))
                {
                    return;
                }

                btnEditar.Text = "Salvar";
                cmbTipoDespesa.Enabled = true;
                cmbFormaPagamento.Enabled = true;
                txtValor.Enabled = true;
                txtDescricao.Enabled = true;
                btnIncluirProduto.Visible = true;

                cmbTipoDespesa.Focus();
                SendKeys.Send("{F4}");
            }
            else //Função de Salvar
            {
                if(cmbFormaPagamento.Text == "" || cmbTipoDespesa.Text == "" || txtValor.Text == "" || txtDescricao.Text == "")
                {
                    corePopUp.exibirMensagem("Preencha todos os campos.", "Atenção");
                    return;
                }

                if (dataGrid.Rows.Count < 1)
                {
                    corePopUp.exibirMensagem("Selecione ao menos 1 item.", "Atenção");
                    return;
                }

                var dto = new dtoDespesa();
                dto.codigo = Convert.ToInt64(txtCodigo.Text);
                var s_valor = txtValor.Text.Trim().Replace(".", string.Empty);
                dto.valor = Convert.ToDecimal(s_valor);
                dto.codigo_forma_pagamento = Convert.ToInt32(((KeyValuePair<string, string>)cmbFormaPagamento.SelectedItem).Key);
                dto.codigo_tipo_despesa = Convert.ToInt32(((KeyValuePair<string, string>)cmbTipoDespesa.SelectedItem).Key);
                dto.descricao = txtDescricao.Text.Trim();

                if (!bllDespesa.UpdateDespesa(dto))
                {
                    corePopUp.exibirMensagem("Não foi possivel alterar o lançamento", "Atenção");
                    return;
                }
                else
                {
                    bllLogSistema.Insert($"Alteração de despesa: Valor({txtValor.Text}) Forma Pagamento({cmbFormaPagamento.Text}) Tipo Despesa({cmbTipoDespesa.Text}) Descrição({txtDescricao.Text})");
                    corePopUp.exibirMensagem("Lançamento alterado com sucesso!", "Atenção");
                    btnEditar.Text = "Editar";
                    cmbTipoDespesa.Enabled = false;
                    cmbFormaPagamento.Enabled = false;
                    txtValor.Enabled = false;
                    txtDescricao.Enabled = false;
                    btnIncluirProduto.Visible = false;
                }                
            }            
        }

        private void txtValor_Leave(object sender, EventArgs e)
        {
            if(txtValor.Text.Length > 0)
            {
                txtValor.Text = Convert.ToDouble(txtValor.Text.Trim()).ToString("N2");
            }
        }

        private void txtDescricao_TextChanged(object sender, EventArgs e)
        {
            lbQtdeCaracter.Text = txtDescricao.Text.Length.ToString() + "/500";
        }

        private void dataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnEditar.Text == "Editar")
            {
                return;
            }

            try
            {
                var codigo_id_produto_despesa = Convert.ToInt32(dataGrid.CurrentRow.Cells[0].Value.ToString());

                if(!corePopUp.exibirPergunta("Atenção","Deseja remover este item?", 2))
                {
                    return;
                }

                if (bllDespesaItens.Delete(codigo_id_produto_despesa))
                {
                    corePopUp.exibirMensagem("Item removido com sucesso!", "Atenção");
                    bllLogSistema.Insert($"Item removido com sucesso: Despesa:{codigo_despesa_} Cod. Produto: {codigo_id_produto_despesa}");
                    dataGrid.DataSource = bllDespesaItens.ListarTodoProdutoDespesaPorCodigo(codigo_despesa_);
                }
                else
                {
                    corePopUp.exibirMensagem("Ocorreu um problema ao remover o item.", "Atenção");
                }
            }
            catch
            {

            }            
        }

        private void btnIncluirProduto_Click(object sender, EventArgs e)
        {
            using (var form = new frmPesquisaProdutoDespesa(""))
            {
                form.ShowDialog();
                try
                {
                    var codigo_item = form.listReturn[0].codigo;
                    var descricao_item = form.listReturn[0].descricao;

                    if (codigo_item == 0)
                    {
                        return;
                    }
                                
                    if (bllProdutoDespesa.Insert(codigo_despesa_, codigo_item) != 0)
                    {
                        corePopUp.exibirMensagem("Item incluido com sucesso!", "Atenção");
                        bllLogSistema.Insert($"Item incluido com sucesso: Despesa:{codigo_despesa_} Cod. Produto: {codigo_item} Descrição: {descricao_item}");
                        dataGrid.DataSource = bllDespesaItens.ListarTodoProdutoDespesaPorCodigo(codigo_despesa_);
                    }
                    else
                    {
                        corePopUp.exibirMensagem("Ocorreu um problema ao incluir o item.", "Atenção");
                    }

                    dataGrid.DataSource = bllDespesaItens.ListarTodoProdutoDespesaPorCodigo(codigo_despesa_);
                }
                catch
                {

                }               
            }
        }
    }
}
