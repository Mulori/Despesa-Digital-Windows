using DespesaDigital.Code.BLL.bllCategoria;
using DespesaDigital.Code.BLL.bllProduto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DespesaDigital.Views.Forms.Produtos
{
    public partial class frmPesquisarProduto : Form
    {
        public frmPesquisarProduto()
        {
            InitializeComponent();
            Inicializa();
        }

        void Inicializa()
        {
            dataGrid.DataSource = bllProduto.ListarTodosProdutosPorStatus("A");
        }

        private void rdAtivos_CheckedChanged(object sender, EventArgs e)
        {
            if (txtDescricao.Text.Length > 0)
            {
                dataGrid.DataSource = bllProduto.ListarTodosProdutosPorStatusDescricao("A", txtDescricao.Text);
            }
            else
            {
                dataGrid.DataSource = bllProduto.ListarTodosProdutosPorStatus("A");
            }
        }

        private void rdInativos_CheckedChanged(object sender, EventArgs e)
        {
            if (txtDescricao.Text.Length > 0)
            {
                dataGrid.DataSource = bllProduto.ListarTodosProdutosPorStatusDescricao("I", txtDescricao.Text);
            }
            else
            {
                dataGrid.DataSource = bllProduto.ListarTodosProdutosPorStatus("I");
            }
        }

        private void txtDescricao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (rdAtivos.Checked)
                {
                    dataGrid.DataSource = bllProduto.ListarTodosProdutosPorStatusDescricao("A", txtDescricao.Text);
                }
                else if (rdInativos.Checked)
                {
                    dataGrid.DataSource = bllProduto.ListarTodosProdutosPorStatusDescricao("I", txtDescricao.Text);
                }
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            using (var form = new frmNovoProduto(0))
            {
                form.ShowDialog();
            }

            Inicializa();
        }
    }
}
