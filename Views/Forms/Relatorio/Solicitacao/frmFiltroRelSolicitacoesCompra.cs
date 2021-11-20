using DespesaDigital.Code.BLL;
using DespesaDigital.Code.BLL.bllSetor;
using DespesaDigital.Code.DTO;
using DespesaDigital.Code.DTO.dtoSetor;
using DespesaDigital.Core;
using DespesaDigital.Report.rptSolicitacoesCompra;
using DespesaDigital.Views.Forms.Usuario;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DespesaDigital.Views.Forms.Relatorio.Solicitacao
{
    public partial class frmFiltroRelSolicitacoesCompra : Form
    {
        public frmFiltroRelSolicitacoesCompra()
        {
            InitializeComponent();
            mskInicial.Text = DateTime.Today.ToString("dd/MM/yyyy");
            mskFinal.Text = DateTime.Today.ToString("dd/MM/yyyy");

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

            if (VariaveisGlobais.nivel_acesso > 2)
            {
                var list_usuario = bllUsuario.ListarUsuariosPorDepartamento(VariaveisGlobais.codigo_departamento);
                CarregaListaColaboradores(list_usuario);
            }
            else
            {
                var list_usuario = bllUsuario.ListarUsuariosPorSetor(VariaveisGlobais.codigo_setor);
                CarregaListaColaboradores(list_usuario);
            }
        }

        void CarregaListaSetores(List<dtoSetor> list)
        {
            Dictionary<string, string> comboSource = new Dictionary<string, string>();

            if(VariaveisGlobais.nivel_acesso > 2)
            {
                comboSource.Add($"-1", $"Todos");
            }

            foreach (var item in list)
            {
                comboSource.Add($"{item.codigo}", $"{item.nome}");
            }

            cmbSetor.DataSource = new BindingSource(comboSource, null);
            cmbSetor.DisplayMember = "Value";
            cmbSetor.ValueMember = "Key";
        }

        void CarregaListaColaboradores(List<dtoUsuario> list)
        {
            Dictionary<string, string> comboSource = new Dictionary<string, string>();

            if (VariaveisGlobais.nivel_acesso > 2)
            {
                comboSource.Add($"-1", $"Todos");
            }

            foreach (var item in list)
            {
                comboSource.Add($"{item.codigo}", $"{item.nome} {item.sobrenome}");
            }

            cmbColaborador.DataSource = new BindingSource(comboSource, null);
            cmbColaborador.DisplayMember = "Value";
            cmbColaborador.ValueMember = "Key";
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

            var codigo_usuario = Convert.ToInt32(((KeyValuePair<string, string>)cmbColaborador.SelectedItem).Key);
            var codigo_setor = Convert.ToInt32(((KeyValuePair<string, string>)cmbSetor.SelectedItem).Key);

            using (var rel = new frmRelSolicitacoesCompras(inicial, final, codigo_setor, codigo_usuario))
            {
                rel.ShowDialog();
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            using (var form = new frmPesquisarUsuario())
            {
                form.ShowDialog();
                if (VariaveisGlobais.nome_usuario_relatorio_colaborador != null)
                {
                    cmbColaborador.Text = VariaveisGlobais.nome_usuario_relatorio_colaborador.ToString();
                }
                VariaveisGlobais.nome_usuario_relatorio_colaborador = null;
            }
        }
    }
}
