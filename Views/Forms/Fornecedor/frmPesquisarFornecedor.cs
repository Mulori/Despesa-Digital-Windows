using DespesaDigital.Code.BLL.bllFornecedor;
using DespesaDigital.Core;
using System;
using System.Windows.Forms;

namespace DespesaDigital.Views.Forms.Fornecedor
{
    public partial class frmPesquisarFornecedor : Form
    {
        public frmPesquisarFornecedor()
        {
            InitializeComponent();
            Inicializar();
        }

        void Inicializar()
        {
            dataGrid.DataSource = bllFornecedor.ListarTodosFornecedores();
        }

        private void mskCNPJ_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (mskCNPJ.Text.Length == 18)
                {
                    dataGrid.DataSource = bllFornecedor.ListarTodosFornecedoresPorCNPJ(coreFormat.SemFormatacao(mskCNPJ.Text));
                }                
            }
        }

        private void txtRazaoSocial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                dataGrid.DataSource = bllFornecedor.ListarTodosFornecedoresPorRazaoSocial(txtRazaoSocial.Text);
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            using (var form = new frmNovoFornecedor(0))
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

            using (var form = new frmNovoFornecedor(codigo))
            {
                form.ShowDialog();
            }

            Inicializar();
        }
    }
}
