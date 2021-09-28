using DespesaDigital.Code.BLL.bllConexao;
using DespesaDigital.Core;
using DespesaDigital.Views.Forms.Login;
using System.Windows.Forms;

namespace DespesaDigital
{
    public partial class frmPrincipal : Form
    {
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
    }
}
