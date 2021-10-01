using DespesaDigital.Code.BLL.bllSetor;
using DespesaDigital.Core;
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
                dataGrid.DataSource = bllSetor.SetorPorCodigo(VariaveisGlobais.codigo_setor);
            }
            else if (VariaveisGlobais.nivel_acesso == 3)
            {
                dataGrid.DataSource = bllSetor.TodosSetoresPorDepartamento(VariaveisGlobais.codigo_departamento);
            }
        }
    }
}
