using DespesaDigital.Code.BLL;
using DespesaDigital.Code.BLL.bllFornecedor;
using DespesaDigital.Code.BLL.bllLogSistema;
using DespesaDigital.Code.BLL.bllSetor;
using DespesaDigital.Core;
using DespesaDigital.Views.Forms.SolicitarAcesso;
using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DespesaDigital.Views.Forms.Login
{
    public partial class frmLogin : Form
    {
        #region Variaveis
            Regex rg = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");
        #endregion

        public frmLogin()
        {
            InitializeComponent();

            lbVersao.Text = Application.ProductVersion;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtEmail.Text.Trim()) || string.IsNullOrEmpty(txtSenha.Text.Trim()))
            {
                corePopUp.exibirMensagem("Preencha todos os campos.", "Atenção");

                return;
            }

            if (!rg.IsMatch(txtEmail.Text.Trim()))
            {
                corePopUp.exibirMensagem("O e-mail informado não é valido.", "Atenção");

                txtEmail.Text = "";
                txtEmail.Focus();
                return;
            }

            if(txtSenha.Text.Trim().Length < 4)
            {
                corePopUp.exibirMensagem("A senha informada deve conter no mínimo 4 caracteres.", "Atenção");

                txtSenha.Text = "";
                txtSenha.Focus();
                return;
            }

            var bll = bllUsuario.AutenticaUsuario(txtEmail.Text.Trim(), txtSenha.Text.Trim());

            if(bll.codigo == 0)
            {
                corePopUp.exibirMensagem("E-mail ou senha invalidos.", "Atenção");
                return;
            }

            VariaveisGlobais.codigo_setor = bll.codigo_setor;
            VariaveisGlobais.codigo_usuario = bll.codigo;
            VariaveisGlobais.nome_usuario = bll.nome;
            VariaveisGlobais.sobrenome_usuario = bll.sobrenome;
            VariaveisGlobais.nivel_acesso = bll.nivel_acesso;
            VariaveisGlobais.email_usuario = bll.email;
            VariaveisGlobais.codigo_departamento = bllSetor.CodigoDepartamentoPorCodigoSetor(bll.codigo_setor);
            VariaveisGlobais.setores_concatenados = bllSetor.CodigoSetoresContatenado(VariaveisGlobais.codigo_departamento);
            VariaveisGlobais.fornecedores_concatenados = bllFornecedor.CodigoFornecedoresContatenado(VariaveisGlobais.codigo_departamento);

            bllLogSistema.Insert("Acesso ao sistema");

            this.Close();
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            txtEmail.BackColor = Color.FromArgb(218, 218, 218);
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            txtEmail.BackColor = Color.FromArgb(238, 238, 238);
        }

        private void txtSenha_Enter(object sender, EventArgs e)
        {
            txtSenha.BackColor = Color.FromArgb(218, 218, 218);
        }

        private void txtSenha_Leave(object sender, EventArgs e)
        {
            txtSenha.BackColor = Color.FromArgb(238, 238, 238);
        }

        private void linkSolicitarAcesso_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (var form = new frmSolicitarAcesso())
            {
                form.ShowDialog();
            }
        }
    }
}
