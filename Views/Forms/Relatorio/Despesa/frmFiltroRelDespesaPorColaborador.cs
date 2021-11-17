using DespesaDigital.Code.BLL;
using DespesaDigital.Code.DTO;
using DespesaDigital.Core;
using DespesaDigital.Report.rptDespesa;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DespesaDigital.Views.Forms.Relatorio.Despesa
{
    public partial class frmFiltroRelDespesaPorColaborador : Form
    {
        public frmFiltroRelDespesaPorColaborador()
        {
            InitializeComponent();

            mskInicial.Text = DateTime.Today.ToString("dd/MM/yyyy");
            mskFinal.Text = DateTime.Today.ToString("dd/MM/yyyy");

            if(VariaveisGlobais.nivel_acesso != 1)
            {
                if (VariaveisGlobais.nivel_acesso > 2)
                {
                    var list = bllUsuario.ListarUsuariosPorDepartamento(VariaveisGlobais.codigo_departamento);
                    CarregaListaColaboradores(list);
                }
                else
                {
                    var list = bllUsuario.ListarUsuariosPorSetor(VariaveisGlobais.codigo_setor);
                    CarregaListaColaboradores(list);
                }
            }           
        }

        void CarregaListaColaboradores(List<dtoUsuario> list)
        {
            Dictionary<string, string> comboSource = new Dictionary<string, string>();
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

            var codigo_usuario = VariaveisGlobais.nivel_acesso > 1 ? Convert.ToInt32(((KeyValuePair<string, string>)cmbColaborador.SelectedItem).Key) : 0;

            using (var rel = new frmRelDespesaPorColaborador(inicial, final, VariaveisGlobais.nivel_acesso > 1 ? codigo_usuario : VariaveisGlobais.codigo_usuario))
            {
                rel.ShowDialog();
            }
        }
    }
}
