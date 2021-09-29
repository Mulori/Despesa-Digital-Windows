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

        private void dataGrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var dto = new dtoUsuario();
            dto.codigo = Convert.ToInt32(dataGrid.CurrentRow.Cells[0].Value.ToString());
            dto.nome = dataGrid.CurrentRow.Cells[1].Value.ToString();
            dto.sobrenome = dataGrid.CurrentRow.Cells[2].Value.ToString();
            dto.email = dataGrid.CurrentRow.Cells[3].Value.ToString();

            if (string.IsNullOrEmpty(dataGrid.CurrentRow.Cells[6].Value.ToString()))
            {
                corePopUp.exibirMensagem("Selecione o nivel de acesso do usuário!", "Atenção");
                return;
            }

            switch (dataGrid.CurrentRow.Cells[6].Value.ToString())
            {
                case "Técnico":
                    dto.nivel_acesso = 1;
                    break;
                case "Supervisor":
                    dto.nivel_acesso = 2;
                    break;
                case "Gestor": //Gestor
                    dto.nivel_acesso = 3;
                    break;
            }

            switch (dataGrid.CurrentRow.Cells[7].Value.ToString())
            {
                case "Ativo":
                    dto.ativo = "A";
                    break;
                case "Pendente":
                    dto.ativo = "P";
                    break;
                case "Inativo":
                    dto.ativo = "I";
                    break;
            }

            dto.codigo_setor = bllSetor.IdSetorPorNome(dataGrid.CurrentRow.Cells[9].Value.ToString());

            switch (dataGrid.CurrentCell.ColumnIndex)
            {
                case 10: //Salvar

                    if (!corePopUp.exibirPergunta("Atenção:", "Deseja salvar esse cadastro?", 1))
                    {
                        return;
                    }

                    if (bllUsuario.Update(dto))
                    {
                        corePopUp.exibirMensagem("Usuário alterado com sucesso.", "Atenção");
                    }
                    else
                    {
                        corePopUp.exibirMensagem("Ocorreu um erro ao alterar o usuário!", "Atenção");
                    }

                    break;
                case 11: //Excluir

                    if (!corePopUp.exibirPergunta("Atenção:", "Deseja excluir esse cadastro?", 2))
                    {
                        return;
                    }

                    if (bllUsuario.Delete(dto.codigo))
                    {
                        corePopUp.exibirMensagem("Usuário excluido com sucesso.", "Atenção");
                    }
                    else
                    {
                        corePopUp.exibirMensagem("Ocorreu um erro ao excluir o usuário!", "Atenção");
                    }

                    break;
                default:
                    return;
            }

            AtualizarGrid();
        }
    }
}
