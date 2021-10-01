using DespesaDigital.Code.BLL;
using DespesaDigital.Code.BLL.bllDepartamento;
using DespesaDigital.Code.BLL.bllSetor;
using DespesaDigital.Code.DTO;
using DespesaDigital.Core;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DespesaDigital.Views.Forms.SolicitarAcesso
{
    public partial class frmSolicitarAcesso : Form
    {
        #region Variaveis
        Regex rg = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");
        #endregion

        public frmSolicitarAcesso()
        {
            InitializeComponent();
            CarregaDepartamento();
        }

        void CarregaDepartamento()
        {
            var list = bllDepartamento.TodosDepartamentos();

            Dictionary<string, string> comboSource = new Dictionary<string, string>();
            foreach (var item in list)
            {
                comboSource.Add($"{item.codigo}", $"{item.nome}");
            }

            cmbDepartamento.DataSource = new BindingSource(comboSource, null);
            cmbDepartamento.DisplayMember = "Value";
            cmbDepartamento.ValueMember = "Key";
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            string key = ((KeyValuePair<string, string>)cmbDepartamento.SelectedItem).Key;
            //string value = ((KeyValuePair<string, string>)cmbDepartamento.SelectedItem).Value;

            cmbSetor.DataSource = null;

            var list = bllSetor.TodosSetoresPorDepartamento(Convert.ToInt32(key));
            Dictionary<string, string> comboSource = new Dictionary<string, string>();
            foreach (var item in list)
            {
                comboSource.Add($"{item.codigo}", $"{item.nome}");
            }

            cmbSetor.DataSource = new BindingSource(comboSource, null);
            cmbSetor.DisplayMember = "Value";
            cmbSetor.ValueMember = "Key";
        }

        private void btnSolicitar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNome.Text))
            {
                corePopUp.exibirMensagem("Informe o nome do cadastro.", "Atenção");
                txtNome.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtSobrenome.Text))
            {
                corePopUp.exibirMensagem("Informe o sobrenome do cadastro.", "Atenção");
                txtSobrenome.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                corePopUp.exibirMensagem("Informe o e-mail do cadastro.", "Atenção");
                txtEmail.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtSenha.Text))
            {
                corePopUp.exibirMensagem("Informe a senha do cadastro.", "Atenção");
                txtSenha.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtConfirmeSenha.Text))
            {
                corePopUp.exibirMensagem("Informe a confirmação da senha do cadastro.", "Atenção");
                txtConfirmeSenha.Focus();
                return;
            }

            if (string.IsNullOrEmpty(cmbDepartamento.Text))
            {
                corePopUp.exibirMensagem("Selecione o departamento.", "Atenção");
                cmbDepartamento.Focus();
                SendKeys.Send("{F4}");
                return;
            }

            if (string.IsNullOrEmpty(cmbSetor.Text))
            {
                corePopUp.exibirMensagem("Selecione o setor.", "Atenção");
                cmbSetor.Focus();
                SendKeys.Send("{F4}");
                return;
            }

            if (!rg.IsMatch(txtEmail.Text))
            {
                corePopUp.exibirMensagem("O e-mail informado não é valido!", "Atenção");

                txtEmail.Text = "";
                txtEmail.Focus();
                return;
            }

            if(txtSenha.Text.Length < 4)
            {
                corePopUp.exibirMensagem("A senha deve conter no minimo 4 caracteres!", "Atenção");

                txtSenha.Text = "";
                txtSenha.Focus();
                return;
            }

            if (!txtSenha.Text.Equals(txtConfirmeSenha.Text))
            {
                corePopUp.exibirMensagem("As senhas não coincidem!", "Atenção");
                txtConfirmeSenha.Text = "";
                txtConfirmeSenha.Focus();
                return;
            }

            var dto = new dtoUsuario();
            dto.nome = txtNome.Text;
            dto.sobrenome = txtSobrenome.Text;
            dto.email = txtEmail.Text;
            dto.senha = txtSenha.Text;
            dto.codigo_setor = Convert.ToInt32(((KeyValuePair<string, string>)cmbSetor.SelectedItem).Key);

            if (bllUsuario.NovoUsuario(dto) < 1)
            {
                corePopUp.exibirMensagem("Ocorreu um erro ao solicitar acesso, tente novamente!", "Atenção");
                return;
            }

            corePopUp.exibirMensagem("Solicitação concluida com sucesso!", "Atenção");

            Close();
        }

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtSobrenome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
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

        private void txtConfirmeSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{TAB}");
            }
        }
    }
}
