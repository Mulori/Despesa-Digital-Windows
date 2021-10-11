using DespesaDigital.Views.Forms.Categoria;
using DespesaDigital.Views.Forms.Departamento;
using DespesaDigital.Views.Forms.FormaPagamento;
using DespesaDigital.Views.Forms.Fornecedor;
using DespesaDigital.Views.Forms.Produtos;
using DespesaDigital.Views.Forms.Setor;
using DespesaDigital.Views.Forms.TipoDespesa;
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

        private void btnProduto_Click(object sender, EventArgs e)
        {
            using (var form = new frmPesquisarProduto())
            {
                form.ShowDialog();
            }
        }

        private void btnFornecedores_Click(object sender, EventArgs e)
        {
            using (var form = new frmPesquisarFornecedor())
            {
                form.ShowDialog();
            }
        }

        private void btnFormaPagamento_Click(object sender, EventArgs e)
        {
            using (var form = new frmPesquisarFormaPagamento())
            {
                form.ShowDialog();
            }
        }

        private void btnTipoDespesa_Click(object sender, EventArgs e)
        {
            using (var form = new frmPesquisarTipoDespesa())
            {
                form.ShowDialog();
            }
        }

        private void btnCategoria_Click(object sender, EventArgs e)
        {
            using (var form = new frmPesquisarCategoria())
            {
                form.ShowDialog();
            }
        }
    }
}
