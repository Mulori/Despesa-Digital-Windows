using DespesaDigital.Code.BLL.bllSetor;
using DespesaDigital.Code.BLL.bllSolicitacaoCompra;
using DespesaDigital.Code.DTO.dtoSetor;
using DespesaDigital.Core;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DespesaDigital.Views.Forms.SolicitacaoCompra
{
    public partial class frmPesquisarSolicitacaoCompra : Form
    {
        public frmPesquisarSolicitacaoCompra()
        {
            InitializeComponent();
        }

        private void rdAprovados_CheckedChanged(object sender, EventArgs e)
        {
            dataGrid.DataSource = bllSolicitacaoCompra.ListarTodosProdutosPorStatus("A");
        }

        private void rdPendentes_CheckedChanged(object sender, EventArgs e)
        {
            dataGrid.DataSource = bllSolicitacaoCompra.ListarTodosProdutosPorStatus("P");
        }

        private void rdRejeitados_CheckedChanged(object sender, EventArgs e)
        {
            dataGrid.DataSource = bllSolicitacaoCompra.ListarTodosProdutosPorStatus("R");
        }

        private void frmPesquisarSolicitacaoCompra_Load(object sender, EventArgs e)
        {
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
            
            CarregaListaSetores(list);            

            cmbSetor.Text = bllSetor.SetorPorCodigo(VariaveisGlobais.codigo_setor).nome;
            dataGrid.DataSource = bllSolicitacaoCompra.ListarTodosProdutosPorStatus("P");
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

        private void cmbSetor_SelectedIndexChanged(object sender, EventArgs e)
        {
            var codigo_setor = Convert.ToInt32(((KeyValuePair<string, string>)cmbSetor.SelectedItem).Key);

            if (rdAprovados.Checked)
            {
                dataGrid.DataSource = bllSolicitacaoCompra.ListarTodasSolicitacaoPorStatusSetor("A", codigo_setor);
            }
            else if (rdPendentes.Checked)
            {
                dataGrid.DataSource = bllSolicitacaoCompra.ListarTodasSolicitacaoPorStatusSetor("P", codigo_setor);
            }
            else if (rdRejeitados.Checked)
            {
                dataGrid.DataSource = bllSolicitacaoCompra.ListarTodasSolicitacaoPorStatusSetor("R", codigo_setor);
            }
        }

        private void btnPesquisarData_Click(object sender, EventArgs e)
        {
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

            if (rdAprovados.Checked)
            {
                dataGrid.DataSource = bllSolicitacaoCompra.ListarTodasSolicitacaoPorStatusData("A", inicial, final);
            }
            else if (rdPendentes.Checked)
            {
                dataGrid.DataSource = bllSolicitacaoCompra.ListarTodasSolicitacaoPorStatusData("P", inicial, final);
            }
            else if (rdRejeitados.Checked)
            {
                dataGrid.DataSource = bllSolicitacaoCompra.ListarTodasSolicitacaoPorStatusData("R", inicial, final);
            }
        }

        private void dataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var codigo = Convert.ToInt32(dataGrid.CurrentRow.Cells[0].Value.ToString());

            using (var form = new frmDetalheSolicitacaoCompra(codigo))
            {
                form.ShowDialog();
            }

            if (rdAprovados.Checked)
            {
                dataGrid.DataSource = bllSolicitacaoCompra.ListarTodosProdutosPorStatus("A");
            }
            else if (rdPendentes.Checked)
            {
                dataGrid.DataSource = bllSolicitacaoCompra.ListarTodosProdutosPorStatus("P");
            }
            else if (rdRejeitados.Checked)
            {
                dataGrid.DataSource = bllSolicitacaoCompra.ListarTodosProdutosPorStatus("R");
            }
        }
    }
}
