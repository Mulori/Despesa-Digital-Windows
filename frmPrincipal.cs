﻿using DespesaDigital.Code.BLL.bllConexao;
using DespesaDigital.Code.BLL.bllDepartamento;
using DespesaDigital.Code.BLL.bllSetor;
using DespesaDigital.Core;
using DespesaDigital.Views.Forms.Cadastros;
using DespesaDigital.Views.Forms.Dashboard;
using DespesaDigital.Views.Forms.Despesa;
using DespesaDigital.Views.Forms.Ferramentas;
using DespesaDigital.Views.Forms.Login;
using DespesaDigital.Views.Forms.Mensagens;
using DespesaDigital.Views.Forms.MinhaConta;
using DespesaDigital.Views.Forms.Relatorio;
using DespesaDigital.Views.Forms.SolicitacaoCompra;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DespesaDigital
{
    public partial class frmPrincipal : Form
    {
        Form _objForm;
        public frmPrincipal()
        {
            InitializeComponent();

            if (!bllConexao.Conectar())
            {
                corePopUp.exibirMensagem("Não foi possivel estabelecer conexão \n com o servidor de banco de dados.", "Sem conexão!");
                Application.Exit();
                return;
            }

            using (var form = new frmLogin())
            {
                form.ShowDialog();
            }

            lbNome.Text = $"Olá, {VariaveisGlobais.nome_usuario}!";
            lbVersao.Text = Application.ProductVersion;
            lbRodape.Text = $"Data e hora de login: {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}     Departamento: {bllDepartamento.DepartamentoPorCodigo(VariaveisGlobais.codigo_departamento).nome}     Centro de Custo: {bllSetor.SetorPorCodigo(VariaveisGlobais.codigo_setor).nome}";

            setarNivelAcesso();

            this.MinimumSize = new Size(1087, 659);            
        }

        void setarNivelAcesso()
        {
            switch (VariaveisGlobais.nivel_acesso)
            {
                case 1:
                    btnDespesa.Enabled = true;
                    btnMinhaConta.Enabled = true;
                    btnRelatorios.Enabled = true;
                    break;
                case 2:
                    btnDespesa.Enabled = true;
                    btnMinhaConta.Enabled = true;
                    btnCentroCusto.Enabled = true;
                    btnCadastro.Enabled = true;
                    btnDashboard.Enabled = true;
                    btnRelatorios.Enabled = true;
                    break;
                case 3:
                    btnDespesa.Enabled = true;
                    btnMinhaConta.Enabled = true;
                    btnCentroCusto.Enabled = true;
                    btnCadastro.Enabled = true;
                    btnDashboard.Enabled = true;
                    btnRelatorios.Enabled = true;
                    btnFerramentas.Enabled = true;
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
            btnCadastro.BackColor = Color.FromArgb(139, 178, 55); //Cor Selecionada
            btnDashboard.BackColor = Color.FromArgb(43, 56, 64);
            btnDespesa.BackColor = Color.FromArgb(43, 56, 64);
            btnCentroCusto.BackColor = Color.FromArgb(43, 56, 64);
            btnMinhaConta.BackColor = Color.FromArgb(43, 56, 64);
            btnRelatorios.BackColor = Color.FromArgb(43, 56, 64);
            btnFerramentas.BackColor = Color.FromArgb(43, 56, 64);

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
            btnMinhaConta.BackColor = Color.FromArgb(139, 178, 55); //Cor Selecionada
            btnDashboard.BackColor = Color.FromArgb(43, 56, 64);
            btnDespesa.BackColor = Color.FromArgb(43, 56, 64);
            btnCentroCusto.BackColor = Color.FromArgb(43, 56, 64);
            btnCadastro.BackColor = Color.FromArgb(43, 56, 64);
            btnRelatorios.BackColor = Color.FromArgb(43, 56, 64);
            btnFerramentas.BackColor = Color.FromArgb(43, 56, 64);

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

        private void btnCentroCusto_Click(object sender, System.EventArgs e)
        {
            btnCentroCusto.BackColor = Color.FromArgb(139, 178, 55); //Cor Selecionada
            btnDashboard.BackColor = Color.FromArgb(43, 56, 64);
            btnDespesa.BackColor = Color.FromArgb(43, 56, 64);
            btnMinhaConta.BackColor = Color.FromArgb(43, 56, 64);
            btnCadastro.BackColor = Color.FromArgb(43, 56, 64);
            btnRelatorios.BackColor = Color.FromArgb(43, 56, 64);
            btnRelatorios.BackColor = Color.FromArgb(43, 56, 64);
            btnFerramentas.BackColor = Color.FromArgb(43, 56, 64);

            _objForm?.Close();

            _objForm = new frmSolicitacaoCompra
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            panelPrincipal.Controls.Add(_objForm);
            _objForm.Show();
        }

        private void btnDespesa_Click(object sender, System.EventArgs e)
        {
            btnDespesa.BackColor = Color.FromArgb(139, 178, 55); //Cor Selecionada
            btnDashboard.BackColor = Color.FromArgb(43, 56, 64);
            btnCentroCusto.BackColor = Color.FromArgb(43, 56, 64);
            btnMinhaConta.BackColor = Color.FromArgb(43, 56, 64);
            btnCadastro.BackColor = Color.FromArgb(43, 56, 64);
            btnRelatorios.BackColor = Color.FromArgb(43, 56, 64);
            btnFerramentas.BackColor = Color.FromArgb(43, 56, 64);

            _objForm?.Close();

            _objForm = new frmDespesa
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            panelPrincipal.Controls.Add(_objForm);
            _objForm.Show();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            btnDashboard.BackColor = Color.FromArgb(139, 178, 55); //Cor Selecionada
            btnDespesa.BackColor = Color.FromArgb(43, 56, 64);
            btnCentroCusto.BackColor = Color.FromArgb(43, 56, 64);
            btnMinhaConta.BackColor = Color.FromArgb(43, 56, 64);
            btnCadastro.BackColor = Color.FromArgb(43, 56, 64);
            btnRelatorios.BackColor = Color.FromArgb(43, 56, 64);
            btnFerramentas.BackColor = Color.FromArgb(43, 56, 64);

            _objForm?.Close();

            _objForm = new frmDashboard
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            panelPrincipal.Controls.Add(_objForm);
            _objForm.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Npgsql.NpgsqlConnection.ClearAllPools();
        }

        private void btnRelatorios_Click(object sender, EventArgs e)
        {
            btnRelatorios.BackColor = Color.FromArgb(139, 178, 55); //Cor Selecionada
            btnDespesa.BackColor = Color.FromArgb(43, 56, 64);
            btnCentroCusto.BackColor = Color.FromArgb(43, 56, 64);
            btnMinhaConta.BackColor = Color.FromArgb(43, 56, 64);
            btnCadastro.BackColor = Color.FromArgb(43, 56, 64);
            btnDashboard.BackColor = Color.FromArgb(43, 56, 64);
            btnFerramentas.BackColor = Color.FromArgb(43, 56, 64);

            _objForm?.Close();

            _objForm = new frmRelatorio
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            panelPrincipal.Controls.Add(_objForm);
            _objForm.Show();
        }

        private void btnFerramentas_Click(object sender, EventArgs e)
        {
            btnFerramentas.BackColor = Color.FromArgb(139, 178, 55); //Cor Selecionada
            btnDespesa.BackColor = Color.FromArgb(43, 56, 64);
            btnCentroCusto.BackColor = Color.FromArgb(43, 56, 64);
            btnMinhaConta.BackColor = Color.FromArgb(43, 56, 64);
            btnCadastro.BackColor = Color.FromArgb(43, 56, 64);
            btnDashboard.BackColor = Color.FromArgb(43, 56, 64);
            btnRelatorios.BackColor = Color.FromArgb(43, 56, 64);

            _objForm?.Close();

            _objForm = new frmFerramentasPrincipal
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
