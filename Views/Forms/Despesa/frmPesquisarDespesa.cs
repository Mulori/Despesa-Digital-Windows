using DespesaDigital.Code.BLL.bllDespesa;
using DespesaDigital.Code.BLL.bllFormaPagamento;
using DespesaDigital.Code.BLL.bllSetor;
using DespesaDigital.Code.BLL.bllTipoDespesa;
using DespesaDigital.Code.DTO.dtoFormaPagamento;
using DespesaDigital.Code.DTO.dtoSetor;
using DespesaDigital.Code.DTO.dtoTipoDespesa;
using DespesaDigital.Core;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DespesaDigital.Views.Forms.Despesa
{
    public partial class frmPesquisarDespesa : Form
    {
        public static bool libera_pesquisa { get; set; }

        public frmPesquisarDespesa()
        {
            InitializeComponent();

            libera_pesquisa = false;

            mskDataInicial.Text = DateTime.Today.ToString("dd/MM/yyyy");
            mskDataFinal.Text = DateTime.Today.ToString("dd/MM/yyyy");

            List<dtoSetor> list;
            if (VariaveisGlobais.nivel_acesso > 2)
            {
                list = bllSetor.TodosSetoresPorDepartamento(VariaveisGlobais.codigo_departamento);
            }
            else
            {
                list = bllSetor.ListSetorPorCodigo(VariaveisGlobais.codigo_setor);
            }

            if (VariaveisGlobais.nivel_acesso < 3)
            {
                cmbSetor.Enabled = false;
            }

            var list_forma_pagamento = bllFormaPagamento.ListarTodasFormasPagamentoPorStatus("A");
            var list_tipo_despesa = bllTipoDespesa.ListarTodasTipoDespesaPorStatus("A");
            CarregaListaFormaPagametno(list_forma_pagamento);
            CarregaListaTipoDespesa(list_tipo_despesa);
            CarregaListaSetores(list);

            cmbSetor.Text = bllSetor.SetorPorCodigo(VariaveisGlobais.codigo_setor).nome;
            dataGrid.DataSource = bllDespesa.ListarTodasDespesasPorData(DateTime.Today, DateTime.Today);
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

        private void cmbSetor_SelectedIndexChanged(object sender, EventArgs e)
        {
            int codigo_setor = 0;
            int codigo_forma_pagamento = 0;
            int codigo_tipo_despesa = 0;

            if (!libera_pesquisa)
            {
                libera_pesquisa = true;
                return;
            }

            try
            {
                codigo_setor = Convert.ToInt32(((KeyValuePair<string, string>)cmbSetor.SelectedItem).Key);
                codigo_forma_pagamento = Convert.ToInt32(((KeyValuePair<string, string>)cmbFormaPagamento.SelectedItem).Key);
                codigo_tipo_despesa = Convert.ToInt32(((KeyValuePair<string, string>)cmbTipoDespesa.SelectedItem).Key);
            }
            catch
            {
                return;
            }

            DateTime inicial;
            DateTime final;

            try
            {
                inicial = Convert.ToDateTime(mskDataInicial.Text);
            }
            catch
            {
                corePopUp.exibirMensagem("A data inicial não é valida.", "Atenção");
                mskDataInicial.Mask = "";
                mskDataInicial.Text = "";
                mskDataInicial.Mask = "__/__/____";

                mskDataInicial.Focus();
                return;
            }

            try
            {
                final = Convert.ToDateTime(mskDataFinal.Text);
            }
            catch
            {
                corePopUp.exibirMensagem("A data final não é valida.", "Atenção");
                mskDataFinal.Mask = "";
                mskDataFinal.Text = "";
                mskDataFinal.Mask = "__/__/____";

                mskDataFinal.Focus();
                return;
            }

            if (inicial > final)
            {
                corePopUp.exibirMensagem("A data inicial não pode ser menor que a data final.", "Atenção");
                return;
            }

            dataGrid.DataSource = bllDespesa.ListarTodasDespesas(inicial, final, codigo_forma_pagamento, codigo_tipo_despesa, codigo_setor);
        }

        private void btnPesquisarData_Click(object sender, EventArgs e)
        {

            int codigo_setor = 0;
            int codigo_forma_pagamento = 0;
            int codigo_tipo_despesa = 0;

            if (!libera_pesquisa)
            {
                return;
            }

            try
            {
                codigo_setor = Convert.ToInt32(((KeyValuePair<string, string>)cmbSetor.SelectedItem).Key);
                codigo_forma_pagamento = Convert.ToInt32(((KeyValuePair<string, string>)cmbFormaPagamento.SelectedItem).Key);
                codigo_tipo_despesa = Convert.ToInt32(((KeyValuePair<string, string>)cmbTipoDespesa.SelectedItem).Key);
            }
            catch
            {
                return;
            }

            DateTime inicial;
            DateTime final;

            try
            {
                inicial = Convert.ToDateTime(mskDataInicial.Text);
            }
            catch
            {
                corePopUp.exibirMensagem("A data inicial não é valida.", "Atenção");
                mskDataInicial.Mask = "";
                mskDataInicial.Text = "";
                mskDataInicial.Mask = "__/__/____";

                mskDataInicial.Focus();
                return;
            }

            try
            {
                final = Convert.ToDateTime(mskDataFinal.Text);
            }
            catch
            {
                corePopUp.exibirMensagem("A data final não é valida.", "Atenção");
                mskDataFinal.Mask = "";
                mskDataFinal.Text = "";
                mskDataFinal.Mask = "__/__/____";

                mskDataFinal.Focus();
                return;
            }

            if (inicial > final)
            {
                corePopUp.exibirMensagem("A data inicial não pode ser menor que a data final.", "Atenção");
                return;
            }

            dataGrid.DataSource = bllDespesa.ListarTodasDespesas(inicial, final, codigo_forma_pagamento, codigo_tipo_despesa, codigo_setor);
        }

        private void cmbTipoDespesa_SelectedIndexChanged(object sender, EventArgs e)
        {
            int codigo_setor = 0;
            int codigo_forma_pagamento = 0;
            int codigo_tipo_despesa = 0;

            if (!libera_pesquisa)
            {
                return;
            }

            try
            {
                codigo_setor = Convert.ToInt32(((KeyValuePair<string, string>)cmbSetor.SelectedItem).Key);
                codigo_forma_pagamento = Convert.ToInt32(((KeyValuePair<string, string>)cmbFormaPagamento.SelectedItem).Key);
                codigo_tipo_despesa = Convert.ToInt32(((KeyValuePair<string, string>)cmbTipoDespesa.SelectedItem).Key);
            }
            catch
            {
                return;
            }

            DateTime inicial;
            DateTime final;

            try
            {
                inicial = Convert.ToDateTime(mskDataInicial.Text);
            }
            catch
            {
                corePopUp.exibirMensagem("A data inicial não é valida.", "Atenção");
                mskDataInicial.Mask = "";
                mskDataInicial.Text = "";
                mskDataInicial.Mask = "__/__/____";

                mskDataInicial.Focus();
                return;
            }

            try
            {
                final = Convert.ToDateTime(mskDataFinal.Text);
            }
            catch
            {
                corePopUp.exibirMensagem("A data final não é valida.", "Atenção");
                mskDataFinal.Mask = "";
                mskDataFinal.Text = "";
                mskDataFinal.Mask = "__/__/____";

                mskDataFinal.Focus();
                return;
            }

            if (inicial > final)
            {
                corePopUp.exibirMensagem("A data inicial não pode ser menor que a data final.", "Atenção");
                return;
            }

            dataGrid.DataSource = bllDespesa.ListarTodasDespesas(inicial, final, codigo_forma_pagamento, codigo_tipo_despesa, codigo_setor);
        }

        private void cmbFormaPagamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            int codigo_setor = 0;
            int codigo_forma_pagamento = 0;
            int codigo_tipo_despesa = 0;

            if (!libera_pesquisa)
            {
                return;
            }

            try
            {
                codigo_setor = Convert.ToInt32(((KeyValuePair<string, string>)cmbSetor.SelectedItem).Key);
                codigo_forma_pagamento = Convert.ToInt32(((KeyValuePair<string, string>)cmbFormaPagamento.SelectedItem).Key);
                codigo_tipo_despesa = Convert.ToInt32(((KeyValuePair<string, string>)cmbTipoDespesa.SelectedItem).Key);
            }
            catch
            {
                return;
            }

            DateTime inicial;
            DateTime final;

            try
            {
                inicial = Convert.ToDateTime(mskDataInicial.Text);
            }
            catch
            {
                corePopUp.exibirMensagem("A data inicial não é valida.", "Atenção");
                mskDataInicial.Mask = "";
                mskDataInicial.Text = "";
                mskDataInicial.Mask = "__/__/____";

                mskDataInicial.Focus();
                return;
            }

            try
            {
                final = Convert.ToDateTime(mskDataFinal.Text);
            }
            catch
            {
                corePopUp.exibirMensagem("A data final não é valida.", "Atenção");
                mskDataFinal.Mask = "";
                mskDataFinal.Text = "";
                mskDataFinal.Mask = "__/__/____";

                mskDataFinal.Focus();
                return;
            }

            if (inicial > final)
            {
                corePopUp.exibirMensagem("A data inicial não pode ser menor que a data final.", "Atenção");
                return;
            }

            dataGrid.DataSource = bllDespesa.ListarTodasDespesas(inicial, final, codigo_forma_pagamento, codigo_tipo_despesa, codigo_setor);
        }
    }
}
