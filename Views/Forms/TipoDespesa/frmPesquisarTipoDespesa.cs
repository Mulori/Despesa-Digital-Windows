using DespesaDigital.Code.BLL.bllTipoDespesa;
using System;
using System.Windows.Forms;

namespace DespesaDigital.Views.Forms.TipoDespesa
{
    public partial class frmPesquisarTipoDespesa : Form
    {
        public frmPesquisarTipoDespesa()
        {
            InitializeComponent();
            Inicializar();
        }

        void Inicializar()
        {
            rdAtivos.Checked = true;
            dataGrid.DataSource = bllTipoDespesa.ListarTodasTipoDespesaPorStatus("A");
        }

        private void txtDescricao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (rdAtivos.Checked)
                {
                    dataGrid.DataSource = bllTipoDespesa.ListarTodosTipoDespesaPorStatusDescricao("A", txtDescricao.Text);
                }
                else if (rdInativos.Checked)
                {
                    dataGrid.DataSource = bllTipoDespesa.ListarTodosTipoDespesaPorStatusDescricao("I", txtDescricao.Text);
                }
            }
        }

        private void rdAtivos_CheckedChanged(object sender, EventArgs e)
        {

            if (txtDescricao.Text.Length > 0)
            {
                dataGrid.DataSource = bllTipoDespesa.ListarTodosTipoDespesaPorStatusDescricao("A", txtDescricao.Text);
            }
            else
            {
                dataGrid.DataSource = bllTipoDespesa.ListarTodasTipoDespesaPorStatus("A");
            }
        }

        private void rdInativos_CheckedChanged(object sender, EventArgs e)
        {

            if (txtDescricao.Text.Length > 0)
            {
                dataGrid.DataSource = bllTipoDespesa.ListarTodosTipoDespesaPorStatusDescricao("I", txtDescricao.Text);
            }
            else
            {
                dataGrid.DataSource = bllTipoDespesa.ListarTodasTipoDespesaPorStatus("I");
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            using (var form = new frmNovoTipoDespesa(0))
            {
                form.ShowDialog();
            }

            Inicializar();
        }

        private void dataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGrid.RowCount == 0)
            {
                return;
            }

            var codigo = Convert.ToInt32(dataGrid.CurrentRow.Cells[0].Value.ToString());

            using (var form = new frmNovoTipoDespesa(codigo))
            {
                form.ShowDialog();
            }

            Inicializar();
        }
    }
}
