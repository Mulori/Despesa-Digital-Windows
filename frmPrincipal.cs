﻿using DespesaDigital.Code.BLL.bllConexao;
using DespesaDigital.Core;
using DespesaDigital.Views.Forms.Cadastros;
using DespesaDigital.Views.Forms.Login;
using DespesaDigital.Views.Forms.Mensagens;
using DespesaDigital.Views.Forms.MinhaConta;
using System.Windows.Forms;

namespace DespesaDigital
{
    public partial class frmPrincipal : Form
    {
        Form _objForm;
        public frmPrincipal()
        {
            InitializeComponent();

            bllConexao.Conectar();

            using (var form = new frmLogin())
            {
                form.ShowDialog();
            }

            lbNome.Text = $"Olá, {VariaveisGlobais.nome_usuario}!";

            setarNivelAcesso();

            this.MinimumSize = new System.Drawing.Size(1087, 659);            
        }

        void setarNivelAcesso()
        {
            switch (VariaveisGlobais.nivel_acesso)
            {
                case 1:
                    btnDespesa.Enabled = true;
                    btnMinhaConta.Enabled = true;
                    break;
                case 2:
                    btnDespesa.Enabled = true;
                    btnMinhaConta.Enabled = true;
                    btnCentroCusto.Enabled = true;
                    btnCadastro.Enabled = true;
                    break;
                case 3:
                    btnDespesa.Enabled = true;
                    btnMinhaConta.Enabled = true;
                    btnCentroCusto.Enabled = true;
                    btnCadastro.Enabled = true;
                    break;
            }
        }

        private void btnLogout_Click(object sender, System.EventArgs e)
        {
            if (!exibirPergunta("Atenção:", "Você deseja sair do sistema?", 2))
            {
                return;
            }

            using (var form = new frmLogin())
            {
                this.Hide();
                form.ShowDialog();
            }
        }

        public bool exibirPergunta (string titulo, string mensagem, int foco)
        {
            using (var form = new frmPergunta(titulo, mensagem, foco))
            {
                form.ShowDialog();
                if (VariaveisGlobais.resposta_pergunta)
                {
                    VariaveisGlobais.resposta_pergunta = false;
                    return true;
                } else
                {
                    VariaveisGlobais.resposta_pergunta = false;
                    return false;
                }
            }
        }

        public void exibirMensagem(string mensagem, string titulo)
        {
            using (var form = new frmMensagem(mensagem, titulo))
            {
                form.ShowDialog();                
            }
        }

        private void btnCadastro_Click(object sender, System.EventArgs e)
        {
            _objForm?.Close();

            _objForm = new frmCadastro
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            panelPrincipal.Controls.Add(_objForm);
            _objForm.Show();
        }

        private void btnSair_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, System.EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMinhaConta_Click(object sender, System.EventArgs e)
        {
            _objForm?.Close();

            _objForm = new frmMinhaConta
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            panelPrincipal.Controls.Add(_objForm);
            _objForm.Show();
        }
    }
}
