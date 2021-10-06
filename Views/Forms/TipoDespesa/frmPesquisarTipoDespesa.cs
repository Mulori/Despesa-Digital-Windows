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
    }
}
