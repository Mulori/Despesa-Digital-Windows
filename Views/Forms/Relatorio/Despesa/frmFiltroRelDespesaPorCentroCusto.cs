using DespesaDigital.Code.BLL.bllFormaPagamento;
using DespesaDigital.Code.BLL.bllSetor;
using DespesaDigital.Code.BLL.bllTipoDespesa;
using DespesaDigital.Code.DTO.dtoFormaPagamento;
using DespesaDigital.Code.DTO.dtoSetor;
using DespesaDigital.Code.DTO.dtoTipoDespesa;
using DespesaDigital.Core;
using DespesaDigital.Report.rptDespesa;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DespesaDigital.Views.Forms.Relatorio.Despesa
{
    public partial class frmFiltroRelDespesaPorCentroCusto : Form
    {
        public frmFiltroRelDespesaPorCentroCusto()
        {
            InitializeComponent();
            mskInicial.Text = DateTime.Today.ToString("dd/MM/yyyy");
            mskFinal.Text = DateTime.Today.ToString("dd/MM/yyyy");

            var list_forma_pagamento = bllFormaPagamento.ListarTodasFormasPagamentoPorStatus("A");
            var list_tipo_despesa = bllTipoDespesa.ListarTodasTipoDespesaPorStatus("A");
            CarregaListaFormaPagametno(list_forma_pagamento);
            CarregaListaTipoDespesa(list_tipo_despesa);

            List<dtoSetor> list;
            if (VariaveisGlobais.nivel_acesso > 2)
            {
                list = bllSetor.TodosSetoresPorDepartamento(VariaveisGlobais.codigo_departamento);
            }
            else
            {
                list = bllSetor.ListSetorPorCodigo(VariaveisGlobais.codigo_setor);
            }
            CarregaListaSetores(list);

            if (VariaveisGlobais.nivel_acesso < 3)
            {
                cmbSetor.Enabled = false;
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

        void CarregaListaFormaPagametno(List<dtoFormaPagamento> list)
        {
            Dictionary<string, string> comboSource = new Dictionary<string, string>();
            comboSource.Add($"{-1}", $"Todos");
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
            comboSource.Add($"{-1}", $"Todos");
            foreach (var item in list)
            {
                comboSource.Add($"{item.codigo}", $"{item.descricao}");
            }

            cmbTipoDespesa.DataSource = new BindingSource(comboSource, null);
            cmbTipoDespesa.DisplayMember = "Value";
            cmbTipoDespesa.ValueMember = "Key";
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            DateTime inicial;
            DateTime final;

            try
            {
                inicial = Convert.ToDateTime(mskInicial.Text);
            }
            catch
            {
                corePopUp.exibirMensagem("A data inicial não é valida.", "Atenção");
                mskInicial.Mask = "";
                mskInicial.Text = "";
                mskInicial.Mask = "##/##/####";

                mskInicial.Focus();
                return;
            }

            try
            {
                final = Convert.ToDateTime(mskFinal.Text);
            }
            catch
            {
                corePopUp.exibirMensagem("A data final não é valida.", "Atenção");
                mskFinal.Mask = "";
                mskFinal.Text = "";
                mskFinal.Mask = "##/##/####";

                mskFinal.Focus();
                return;
            }

            if (inicial > final)
            {
                corePopUp.exibirMensagem("A data inicial não pode ser menor que a data final.", "Atenção");
                return;
            }

            var codigo_forma_pagamento = Convert.ToInt32(((KeyValuePair<string, string>)cmbFormaPagamento.SelectedItem).Key);
            var codigo_tipo_despesa = Convert.ToInt32(((KeyValuePair<string, string>)cmbTipoDespesa.SelectedItem).Key);
            var codigo_setor = Convert.ToInt32(((KeyValuePair<string, string>)cmbSetor.SelectedItem).Key);
            var centro_custo = ((KeyValuePair<string, string>)cmbSetor.SelectedItem).Value;

            using (var rel = new frmRelDespesaPorCentroCusto(inicial, final, codigo_setor, codigo_forma_pagamento, codigo_tipo_despesa, centro_custo))
            {
                rel.ShowDialog();
            }
        }
    }
}
