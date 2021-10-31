using DespesaDigital.Code.BLL.bllFormaPagamento;
using System;
using System.Windows.Forms;

namespace DespesaDigital.Views.Forms.FormaPagamento
{
    public partial class frmPesquisarFormaPagamento : Form
    {
        public frmPesquisarFormaPagamento()
        {
            InitializeComponent();
            Inicializar();
        }

        void Inicializar()
        {
            rdAtivos.Checked = true;
            dataGrid.DataSource = bllFormaPagamento.ListarTodasFormasPagamentoPorStatus("A");
        }

        private void rdAtivos_CheckedChanged(object sender, System.EventArgs e)
        {
            if (txtDescricao.Text.Length > 0)
            {
                dataGrid.DataSource = bllFormaPagamento.ListarTodasFormasPagamentoPorStatusDescricao("A", txtDescricao.Text);
            }
            else
            {
                dataGrid.DataSource = bllFormaPagamento.ListarTodasFormasPagamentoPorStatus("A");
            }           
        }

        private void rdInativos_CheckedChanged(object sender, System.EventArgs e)
        {
            if (txtDescricao.Text.Length > 0)
            {
                dataGrid.DataSource = bllFormaPagamento.ListarTodasFormasPagamentoPorStatusDescricao("I", txtDescricao.Text);
            }
            else
            {
                dataGrid.DataSource = bllFormaPagamento.ListarTodasFormasPagamentoPorStatus("I");
            }
        }

        private void txtDescricao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (rdAtivos.Checked)
                {
                    dataGrid.DataSource = bllFormaPagamento.ListarTodasFormasPagamentoPorStatusDescricao("A", txtDescricao.Text);
                }
                else if (rdInativos.Checked)
                {
                    dataGrid.DataSource = bllFormaPagamento.ListarTodasFormasPagamentoPorStatusDescricao("I", txtDescricao.Text);
                }
            }
        }

        private void btnNovo_Click(object sender, System.EventArgs e)
        {
            using (var form = new frmNovaFormaPagamento(0))
            {
                form.ShowDialog();
            }

            Inicializar();
        }

        private void dataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGrid.RowCount == 0)
            {
                return;
            }

            var codigo = Convert.ToInt32(dataGrid.CurrentRow.Cells[0].Value.ToString());

            using (var form = new frmNovaFormaPagamento(codigo))
            {
                form.ShowDialog();
            }

            Inicializar();
        }

        private void dataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
