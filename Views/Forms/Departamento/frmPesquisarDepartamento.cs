using DespesaDigital.Code.BLL.bllDepartamento;
using DespesaDigital.Core;
using System;
using System.Windows.Forms;

namespace DespesaDigital.Views.Forms.Departamento
{
    public partial class frmPesquisarDepartamento : Form
    {
        public frmPesquisarDepartamento()
        {
            InitializeComponent();
            Inicializa();
        }
        
        void Inicializa()
        {
            if (VariaveisGlobais.nivel_acesso == 2)
            {
                dataGrid.DataSource = bllDepartamento.DepartamentoPorSetor(VariaveisGlobais.codigo_setor);
                btnNovo.Visible = false;
            }
            else if(VariaveisGlobais.nivel_acesso == 3)
            {
                dataGrid.DataSource = bllDepartamento.TodosDepartamentos();
            }
        }

        private void btnNovo_Click(object sender, System.EventArgs e)
        {
            using (var form = new frmNovoDepartamento(0))
            {
                form.ShowDialog();
            }

            Inicializa();
        }

        private void dataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var codigo = Convert.ToInt32(dataGrid.CurrentRow.Cells[0].Value.ToString());

            using (var form = new frmNovoDepartamento(codigo))
            {
                form.ShowDialog();
            }

            Inicializa();
        }
    }
}
