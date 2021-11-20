using DespesaDigital.Code.BLL;
using DespesaDigital.Code.BLL.bllDespesa;
using DespesaDigital.Code.BLL.bllFormaPagamento;
using DespesaDigital.Code.BLL.bllSetor;
using DespesaDigital.Code.BLL.bllTipoDespesa;
using DespesaDigital.Code.DTO;
using DespesaDigital.Code.DTO.dtoFormaPagamento;
using DespesaDigital.Code.DTO.dtoSetor;
using DespesaDigital.Code.DTO.dtoTipoDespesa;
using DespesaDigital.Core;
using DespesaDigital.Views.Forms.Relatorio.Despesa;
using DespesaDigital.Views.Forms.Usuario;
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

            if (VariaveisGlobais.nivel_acesso > 1)
            {
                dataGrid.DataSource = bllDespesa.ListarTodasDespesasPorData(DateTime.Today, DateTime.Today);
            }

            var codigo_setor = Convert.ToInt32(((KeyValuePair<string, string>)cmbSetor.SelectedItem).Key);

            if (VariaveisGlobais.nivel_acesso > 1)
            {
                var list_colaboradores = bllUsuario.ListarUsuariosPorSetor(codigo_setor);
                CarregaListaColaboradores(list_colaboradores);
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

        void CarregaListaColaboradores(List<dtoUsuario> list)
        {
            Dictionary<string, string> comboSource = new Dictionary<string, string>();

            comboSource.Add($"{-1}", $"Todos");
            foreach (var item in list)
            {
                comboSource.Add($"{item.codigo}", $"{item.nome} {item.sobrenome}");
            }

            cmbColaborador.DataSource = new BindingSource(comboSource, null);
            cmbColaborador.DisplayMember = "Value";
            cmbColaborador.ValueMember = "Key";
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
                mskDataInicial.Mask = "##/##/####";

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
                mskDataFinal.Mask = "##/##/####";

                mskDataFinal.Focus();
                return;
            }

            if (inicial > final)
            {
                corePopUp.exibirMensagem("A data inicial não pode ser menor que a data final.", "Atenção");
                return;
            }

            dataGrid.DataSource = bllDespesa.ListarTodasDespesas(inicial, final, codigo_forma_pagamento, codigo_tipo_despesa, codigo_setor);

            var list_colaboradores = bllUsuario.ListarUsuariosPorSetor(codigo_setor);
            CarregaListaColaboradores(list_colaboradores);
        }

        private void btnPesquisarData_Click(object sender, EventArgs e)
        {

            int codigo_setor = 0;
            int codigo_forma_pagamento = 0;
            int codigo_tipo_despesa = 0;
            int codigo_usuario = -1;

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
                mskDataInicial.Mask = "##/##/####";

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
                mskDataFinal.Mask = "##/##/####";

                mskDataFinal.Focus();
                return;
            }

            if (inicial > final)
            {
                corePopUp.exibirMensagem("A data inicial não pode ser maior que a data final.", "Atenção");
                return;
            }

            if (cmbColaborador.Text == "Todos")
            {
                dataGrid.DataSource = bllDespesa.ListarTodasDespesas(inicial, final, codigo_forma_pagamento, codigo_tipo_despesa, codigo_setor);
            }
            else
            {
                dataGrid.DataSource = bllDespesa.ListarTodasDespesas(inicial, final, codigo_forma_pagamento, codigo_tipo_despesa, codigo_setor, VariaveisGlobais.nivel_acesso > 1 ? codigo_usuario : VariaveisGlobais.codigo_usuario);
            }
        }

        private void cmbTipoDespesa_SelectedIndexChanged(object sender, EventArgs e)
        {
            int codigo_setor = 0;
            int codigo_forma_pagamento = 0;
            int codigo_tipo_despesa = 0;
            int codigo_usuario = -1;

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
                mskDataInicial.Mask = "##/##/####";

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
                mskDataFinal.Mask = "##/##/####";

                mskDataFinal.Focus();
                return;
            }

            if (inicial > final)
            {
                corePopUp.exibirMensagem("A data inicial não pode ser maior que a data final.", "Atenção");
                return;
            }

            if (cmbColaborador.Text == "Todos")
            {
                dataGrid.DataSource = bllDespesa.ListarTodasDespesas(inicial, final, codigo_forma_pagamento, codigo_tipo_despesa, codigo_setor);
            }
            else
            {
                dataGrid.DataSource = bllDespesa.ListarTodasDespesas(inicial, final, codigo_forma_pagamento, codigo_tipo_despesa, codigo_setor, VariaveisGlobais.nivel_acesso > 1 ? codigo_usuario : VariaveisGlobais.codigo_usuario);
            }
        }

        private void cmbFormaPagamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            int codigo_setor = 0;
            int codigo_forma_pagamento = 0;
            int codigo_tipo_despesa = 0;
            int codigo_usuario = -1;

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
                mskDataInicial.Mask = "##/##/####";

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
                mskDataFinal.Mask = "##/##/####";

                mskDataFinal.Focus();
                return;
            }

            if (inicial > final)
            {
                corePopUp.exibirMensagem("A data inicial não pode ser maior que a data final.", "Atenção");
                return;
            }

            if (cmbColaborador.Text == "Todos")
            {
                dataGrid.DataSource = bllDespesa.ListarTodasDespesas(inicial, final, codigo_forma_pagamento, codigo_tipo_despesa, codigo_setor);
            }
            else
            {
                dataGrid.DataSource = bllDespesa.ListarTodasDespesas(inicial, final, codigo_forma_pagamento, codigo_tipo_despesa, codigo_setor, VariaveisGlobais.nivel_acesso > 1 ? codigo_usuario : VariaveisGlobais.codigo_usuario);
            }
        }

        private void dataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGrid.RowCount == 0)
            {
                return;
            }

            var codigo = Convert.ToInt32(dataGrid.CurrentRow.Cells[0].Value.ToString());

            var FormOpen = Application.OpenForms["frmFiltroRelDespesaPorCodigo"];

            if (FormOpen != null)
            {
                VariaveisGlobais.codigo_despesa_pesquisa = codigo;
                Close();
            }
            else
            {
                using (var form = new frmDetalheDespesa(codigo))
                {
                    form.ShowDialog();
                }

                dataGrid.DataSource = bllDespesa.ListarTodasDespesasPorData(DateTime.Today, DateTime.Today);
            }
        }

        private void cmbColaborador_SelectedIndexChanged(object sender, EventArgs e)
        {
            int codigo_setor = 0;
            int codigo_forma_pagamento = 0;
            int codigo_tipo_despesa = 0;
            int codigo_usuario = -1;

            if (!libera_pesquisa)
            {
                return;
            }

            try
            {
                codigo_setor = Convert.ToInt32(((KeyValuePair<string, string>)cmbSetor.SelectedItem).Key);
                codigo_forma_pagamento = Convert.ToInt32(((KeyValuePair<string, string>)cmbFormaPagamento.SelectedItem).Key);
                codigo_tipo_despesa = Convert.ToInt32(((KeyValuePair<string, string>)cmbTipoDespesa.SelectedItem).Key);
                codigo_usuario = Convert.ToInt32(((KeyValuePair<string, string>)cmbColaborador.SelectedItem).Key);
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
                mskDataInicial.Mask = "##/##/####";

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
                mskDataFinal.Mask = "##/##/####";

                mskDataFinal.Focus();
                return;
            }

            if (inicial > final)
            {
                corePopUp.exibirMensagem("A data inicial não pode ser maior que a data final.", "Atenção");
                return;
            }

            if (cmbColaborador.Text == "Todos")
            {
                dataGrid.DataSource = bllDespesa.ListarTodasDespesas(inicial, final, codigo_forma_pagamento, codigo_tipo_despesa, codigo_setor);
            }
            else
            {
                dataGrid.DataSource = bllDespesa.ListarTodasDespesas(inicial, final, codigo_forma_pagamento, codigo_tipo_despesa, codigo_setor, VariaveisGlobais.nivel_acesso > 1 ? codigo_usuario : VariaveisGlobais.codigo_usuario);
            }           
        }
    }
}
