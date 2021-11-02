using DespesaDigital.Code.BLL;
using DespesaDigital.Core;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DespesaDigital.Views.Forms.MinhaConta
{
    public partial class frmAlteraEmail : Form
    {
        #region Variaveis
        Regex rg = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");
        #endregion

        public static int codigo_usuario {get;set;}

        public frmAlteraEmail(int _codigo_usuario)
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
            if (string.IsNullOrEmpty(txtEmail.Text.Trim()) || string.IsNullOrEmpty(txtConfirmeEmail.Text.Trim()) || string.IsNullOrEmpty(txtSenha.Text.Trim()))
            {
                corePopUp.exibirMensagem("Preencha todos os campos.", "Atenção");
                return;
            }

            if (!txtEmail.Text.Equals(txtConfirmeEmail.Text.Trim()))
            {
                corePopUp.exibirMensagem("Os e-mails inseridos não são correspondentes.", "Atenção");
                return;
            }

            if (!rg.IsMatch(txtEmail.Text.Trim()))
            {
                corePopUp.exibirMensagem("O e-mail informado não é valido!", "Atenção");
                txtConfirmeEmail.Text = "";
                txtEmail.Text = "";
                txtEmail.Focus();
                return;
            }

            if (bllUsuario.VerificaEmailExistente(txtEmail.Text.Trim()))
            {
                corePopUp.exibirMensagem("O e-mail informado já está cadastrado.", "Atenção");
                txtConfirmeEmail.Text = "";
                txtEmail.Text = "";
                txtEmail.Focus();
                return;
            }

            if (txtSenha.Text.Trim().Length < 4)
            {
                corePopUp.exibirMensagem("A senha deve conter no minimo 4 caracteres!", "Atenção");
                txtSenha.Text = "";
                txtSenha.Focus();
                return;
            }

            if (!VariaveisGlobais.senha.ToUpper().Equals(coreCrypt.CreateMD5(txtSenha.Text.Trim())))
            {
                corePopUp.exibirMensagem("A senha não corresponde com a senha atual.", "Atenção");
                txtSenha.Text = "";
                txtSenha.Focus();
                return;
            }

            if (!bllUsuario.UpdateEmail(codigo_usuario, txtEmail.Text.Trim()))
            {
                corePopUp.exibirMensagem("Ocorreu um problema ao alterar o email, tente novamente!", "Atenção");
                return;
            }
            else
            {
                corePopUp.exibirMensagem("O e-mail foi alterado com sucesso, o sistema será finalizado!", "Atenção");
                Application.Exit();
            }
        }
    }
}
