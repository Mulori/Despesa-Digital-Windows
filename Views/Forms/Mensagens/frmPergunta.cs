using DespesaDigital.Core;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DespesaDigital.Views.Forms.Mensagens
{
    public partial class frmPergunta : Form
    {
        public frmPergunta(string titulo, string mensagem, int foco)
        {
            InitializeComponent();

            lbTitulo.Text = titulo;
            lbMensagem.Text = mensagem;

            switch (foco)
            {
                case 1:
                    btnSim.Focus();
                    break;
                case 2:
                    btnNao.Focus();
                    break;
            }
        }

        private void btnSim_Click(object sender, EventArgs e)
        {
            VariaveisGlobais.resposta_pergunta = true;
            this.Close();
        }

        private void btnSim_Enter(object sender, EventArgs e)
        {
            btnSim.BackColor = Color.FromArgb(43, 56, 64);
            btnNao.BackColor = Color.FromArgb(31, 40, 45);
        }

        private void btnNao_Enter(object sender, EventArgs e)
        {
            btnNao.BackColor = Color.FromArgb(43, 56, 64);
            btnSim.BackColor = Color.FromArgb(31, 40, 45);
        }

        private void btnNao_Click(object sender, EventArgs e)
        {
            VariaveisGlobais.resposta_pergunta = false;
            this.Close();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            VariaveisGlobais.resposta_pergunta = false;
            this.Close();
        }
    }
}
