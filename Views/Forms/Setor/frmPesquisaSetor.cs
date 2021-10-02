using DespesaDigital.Code.BLL.bllSetor;
using DespesaDigital.Core;
using System;
using System.Windows.Forms;

namespace DespesaDigital.Views.Forms.Setor
{
    public partial class frmPesquisaSetor : Form
    {
        public frmPesquisaSetor()
        {
            InitializeComponent();
            Inicializa();
        }

        void Inicializa()
        {
            if (VariaveisGlobais.nivel_acesso == 2)
            {
                dataGrid.DataSource = bllSetor.ListSetorPorCodigo(VariaveisGlobais.codigo_setor);
            }
            else if (VariaveisGlobais.nivel_acesso == 3)
            {
                dataGrid.DataSource = bllSetor.TodosSetoresPorDepartamento(VariaveisGlobais.codigo_departamento);
            }
        }

        private void btnNovo_Click(object sender, System.EventArgs e)
        {
            using (var form = new frmNovoSetor(0))
            {
                form.ShowDialog();
            }

            Inicializa();
        }

        private void dataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var codigo = Convert.ToInt32(dataGrid.CurrentRow.Cells[0].Value.ToString());

            using (var form = new frmNovoSetor(codigo))
            {
                form.ShowDialog();
            }

            Inicializa();
        }

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                dataGrid.DataSource = bllSetor.ListSetorPorNome(txtNome.Text);
            }
        }
    }
}
