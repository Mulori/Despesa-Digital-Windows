using DespesaDigital.Code.BLL;
using DespesaDigital.Code.BLL.bllSetor;
using DespesaDigital.Code.DTO;
using DespesaDigital.Core;
using DespesaDigital.Views.Forms.Mensagens;
using System;
using System.Windows.Forms;

namespace DespesaDigital.Views.Forms.Usuario
{
    public partial class frmPesquisarUsuario : Form
    {
        public frmPesquisarUsuario()
        {
            InitializeComponent();
            Inicializar();
        }

        void Inicializar()
        {
            var FormOpen1 = Application.OpenForms["frmFiltroRelDespesaPorColaborador"];
            var FormOpen2 = Application.OpenForms["frmFiltroRelSolicitacoesCompra"];            

            if (FormOpen1 != null || FormOpen2 != null)
            {
                dataGrid.DataSource = bllUsuario.ListarUsuariosPorStatus("A");
                rdPendentes.Enabled = false;
                rdInativos.Enabled = false;
                rdAtivos.Checked = true;
                txtNome.Focus();
            }
            else
            {
                dataGrid.DataSource = bllUsuario.ListarUsuariosPorStatus("P");
                txtNome.Focus();
            }            
        }

        void AtualizarGrid()
        {
            if (rdAtivos.Checked)
            {
                if (txtNome.Text.Length > 0)
                {
                    dataGrid.DataSource = bllUsuario.ListarUsuariosPorNome("A", txtNome.Text);
                }
                else
                {
                    dataGrid.DataSource = bllUsuario.ListarUsuariosPorStatus("A");
                }
            }
            else if (rdInativos.Checked)
            {
                if (txtNome.Text.Length > 0)
                {
                    dataGrid.DataSource = bllUsuario.ListarUsuariosPorNome("I", txtNome.Text);
                }
                else
                {
                    dataGrid.DataSource = bllUsuario.ListarUsuariosPorStatus("I");
                }
            }
            else if (rdPendentes.Checked)
            {
                if (txtNome.Text.Length > 0)
                {
                    dataGrid.DataSource = bllUsuario.ListarUsuariosPorNome("P", txtNome.Text);
                }
                else
                {
                    dataGrid.DataSource = bllUsuario.ListarUsuariosPorStatus("P");
                }
            }
        }

        private void rdAtivos_CheckedChanged(object sender, EventArgs e)
        {
            if (txtNome.Text.Length > 0)
            {
                dataGrid.DataSource = bllUsuario.ListarUsuariosPorNome("A", txtNome.Text);
            }
            else
            {
                dataGrid.DataSource = bllUsuario.ListarUsuariosPorStatus("A");
            }
        }

        private void rdInativos_CheckedChanged(object sender, EventArgs e)
        {
            if (txtNome.Text.Length > 0)
            {
                dataGrid.DataSource = bllUsuario.ListarUsuariosPorNome("I", txtNome.Text);
            }
            else
            {
                dataGrid.DataSource = bllUsuario.ListarUsuariosPorStatus("I");
            }
        }

        private void rdPendentes_CheckedChanged(object sender, EventArgs e)
        {
            if (txtNome.Text.Length > 0)
            {
                dataGrid.DataSource = bllUsuario.ListarUsuariosPorNome("P", txtNome.Text);
            }
            else
            {
                dataGrid.DataSource = bllUsuario.ListarUsuariosPorStatus("P");
            }
        }

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (rdAtivos.Checked)
                {
                    dataGrid.DataSource = bllUsuario.ListarUsuariosPorNome("A", txtNome.Text);
                }
                else if (rdInativos.Checked)
                {
                    dataGrid.DataSource = bllUsuario.ListarUsuariosPorNome("I", txtNome.Text);
                }
                else if (rdPendentes.Checked)
                {
                    dataGrid.DataSource = bllUsuario.ListarUsuariosPorNome("P", txtNome.Text);
                }
            }
        }

        private void dataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGrid.RowCount == 0)
            {
                return;
            }

            var codigo = Convert.ToInt32(dataGrid.CurrentRow.Cells[0].Value.ToString());
            var nome =dataGrid.CurrentRow.Cells[1].Value.ToString();
            var sobrenome = dataGrid.CurrentRow.Cells[2].Value.ToString();

            var FormOpen1 = Application.OpenForms["frmFiltroRelDespesaPorColaborador"];
            var FormOpen2 = Application.OpenForms["frmFiltroRelSolicitacoesCompra"];

            if (FormOpen1 != null || FormOpen2 != null)
            {
                VariaveisGlobais.codigo_usuario_relatorio_colaborador = codigo;
                VariaveisGlobais.nome_usuario_relatorio_colaborador = nome + " " + sobrenome;
                Close();
            }
            else
            {
                using (var form = new frmEditarUsuario(codigo))
                {
                    form.ShowDialog();
                }

                AtualizarGrid();
            }
        }
    }
}
