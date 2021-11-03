using DespesaDigital.Code.BLL;
using DespesaDigital.Core;
using System;
using System.Windows.Forms;

namespace DespesaDigital.Views.Forms.MinhaConta
{
    public partial class frmMinhaConta : Form
    {
        public frmMinhaConta()
        {
            InitializeComponent();

            var usuario = bllUsuario.UsuarioPorCodigo(VariaveisGlobais.codigo_usuario);
            txtCodigo.Text = usuario.codigo.ToString();
            txtNome.Text = usuario.nome;
            txtSobrenome.Text = usuario.sobrenome;
            txtEmail.Text = usuario.email;
            txtSenha.Text = usuario.senha;
            txtDepartamento.Text = usuario.nome_departamento;
            txtSetor.Text = usuario.nome_setor;
            txtNivelAcesso.Text = usuario.s_nivel_acesso;
            txtStatus.Text = usuario.ativo;
        }

        private void btnAlteraEmail_Click(object sender, System.EventArgs e)
        {
            using (var form = new frmAlteraEmail(Convert.ToInt32(txtCodigo.Text)))
            {
                form.ShowDialog();
            }
        }

        private void btnAlteraSenha_Click(object sender, EventArgs e)
        {
            using (var form = new frmAlteraSenha(Convert.ToInt32(txtCodigo.Text)))
            {
                form.ShowDialog();
            }
        }
    }
}
