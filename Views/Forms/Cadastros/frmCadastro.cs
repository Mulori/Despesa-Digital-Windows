using DespesaDigital.Views.Forms.Departamento;
using DespesaDigital.Views.Forms.Setor;
using DespesaDigital.Views.Forms.Usuario;
using System;
using System.Windows.Forms;

namespace DespesaDigital.Views.Forms.Cadastros
{
    public partial class frmCadastro : Form
    {
        public frmCadastro()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            using (var form = new frmPesquisarUsuario())
            {
                form.ShowDialog();
            }
        }

        private void btnDepartamentos_Click(object sender, EventArgs e)
        {
            using (var form = new frmPesquisarDepartamento())
            {
                form.ShowDialog();
            }
        }

        private void btnSetores_Click(object sender, EventArgs e)
        {
            using (var form = new frmPesquisaSetor())
            {
                form.ShowDialog();
            }
        }
    }
}
