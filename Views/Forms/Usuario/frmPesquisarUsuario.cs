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
            dataGrid.DataSource = bllUsuario.ListarUsuariosPorStatus("P");
            txtNome.Focus();
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
            var codigo = Convert.ToInt32(dataGrid.CurrentRow.Cells[0].Value.ToString());

            using (var form = new frmEditarUsuario(codigo))
            {
                form.ShowDialog();
            }

            AtualizarGrid();
        }
    }
}
