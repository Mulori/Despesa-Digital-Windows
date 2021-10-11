using DespesaDigital.Code.BLL.bllCategoria;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DespesaDigital.Views.Forms.Categoria
{
    public partial class frmPesquisarCategoria : Form
    {
        public frmPesquisarCategoria()
        {
            InitializeComponent();
            Inicializa();
        }

        void Inicializa()
        {
            rdAtivos.Checked = true;
            dataGrid.DataSource = bllCategoria.ListarTodasCategoriasPorStatus("A");
        }

        private void txtDescricao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (rdAtivos.Checked)
                {
                    dataGrid.DataSource = bllCategoria.ListarTodasCategoriaPorStatusDescricao("A", txtDescricao.Text);
                }
                else if (rdInativos.Checked)
                {
                    dataGrid.DataSource = bllCategoria.ListarTodasCategoriaPorStatusDescricao("I", txtDescricao.Text);
                }
            }
        }

        private void rdAtivos_CheckedChanged(object sender, EventArgs e)
        {
            if (txtDescricao.Text.Length > 0)
            {
                dataGrid.DataSource = bllCategoria.ListarTodasCategoriaPorStatusDescricao("A", txtDescricao.Text);
            }
            else
            {
                dataGrid.DataSource = bllCategoria.ListarTodasCategoriasPorStatus("A");
            }
        }

        private void rdInativos_CheckedChanged(object sender, EventArgs e)
        {
            if (txtDescricao.Text.Length > 0)
            {
                dataGrid.DataSource = bllCategoria.ListarTodasCategoriaPorStatusDescricao("I", txtDescricao.Text);
            }
            else
            {
                dataGrid.DataSource = bllCategoria.ListarTodasCategoriasPorStatus("I");
            }
        }

        private void dataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGrid.RowCount == 0)
            {
                return;
            }

            var codigo = Convert.ToInt32(dataGrid.CurrentRow.Cells[0].Value.ToString());

            using (var form = new frmNovaCategoria(codigo))
            {
                form.ShowDialog();
            }

            Inicializa();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            using (var form = new frmNovaCategoria(0))
            {
                form.ShowDialog();
            }

            Inicializa();
        }
    }
}
