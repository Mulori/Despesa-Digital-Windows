using DespesaDigital.Code.BLL.bllDepartamento;
using DespesaDigital.Core;
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
            }
            else if(VariaveisGlobais.nivel_acesso == 3)
            {
                dataGrid.DataSource = bllDepartamento.TodosDepartamentos();
            }
        }
    }
}
