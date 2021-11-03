using DespesaDigital.Code.BLL;
using DespesaDigital.Core;
using System;
using System.Windows.Forms;

namespace DespesaDigital.Views.Forms.MinhaConta
{
    public partial class frmAlteraSenha : Form
    {
        public static int codigo_usuario { get; set; }
        public frmAlteraSenha(int _codigo_usuario)
        {
            InitializeComponent();
            codigo_usuario = _codigo_usuario;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSenha.Text.Trim()) || string.IsNullOrEmpty(txtConfirmeSenha.Text.Trim()) || string.IsNullOrEmpty(txtSenhaAtual.Text.Trim()))
            {
                corePopUp.exibirMensagem("Preencha todos os campos.", "Atenção");
                return;
            }

            if (!txtSenha.Text.Equals(txtConfirmeSenha.Text))
            {
                corePopUp.exibirMensagem("As senhas inseridas não são correspondentes.", "Atenção");
                return;
            }

            if (txtSenha.Text.Trim().Length < 4)
            {
                corePopUp.exibirMensagem("A senha deve conter no minimo 4 caracteres!", "Atenção");
                txtSenha.Text = "";
                txtConfirmeSenha.Text = "";
                txtSenha.Focus();
                return;
            }

            if (!VariaveisGlobais.senha.ToUpper().Equals(coreCrypt.CreateMD5(txtSenhaAtual.Text.Trim())))
            {
                corePopUp.exibirMensagem("A senha não corresponde com a senha atual.", "Atenção");
                txtSenhaAtual.Text = "";
                txtSenhaAtual.Focus();
                return;
            }

            if (!bllUsuario.UpdateSenha(codigo_usuario, txtSenha.Text.Trim()))
            {
                corePopUp.exibirMensagem("Ocorreu um problema ao alterar a senha, tente novamente!", "Atenção");
                return;
            }
            else
            {
                corePopUp.exibirMensagem("A senha foi alterada com sucesso, o sistema será finalizado!", "Atenção");
                Application.Exit();
            }
        }
    }
}
